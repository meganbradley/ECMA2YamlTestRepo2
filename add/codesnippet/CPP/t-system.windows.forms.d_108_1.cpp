#using <System.Data.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

#using <System.Xml.dll>
#using <System.EnterpriseServices.dll>
#using <System.Transactions.dll>
using namespace System;
using namespace System::Data;
using namespace System::Data::SqlClient;
using namespace System::Windows::Forms;
using namespace System::Collections::Generic;
using namespace System::Drawing;

public ref class Employees : public Form
{
private:
    DataGridView^ DataGridView1;

private:
    DataGridView^ DataGridView2;

public:
    [STAThread]
    static void Main()
    {
        try
        {
            Application::EnableVisualStyles();
            Application::Run(gcnew Employees());
        }
        catch (Exception^ e)
        {
            MessageBox::Show(e->Message + e->StackTrace);
        }
    }

private:
    Dictionary<String^, bool>^ inOffice;

public:
    Employees()
    {
        DataGridView1 = gcnew DataGridView();
        DataGridView2 = gcnew DataGridView();
        connectionString =
            "Integrated Security=SSPI;Persist Security Info=False;" +
            "Initial Catalog=Northwind;Data Source=localhost";
        inOffice = gcnew Dictionary<String^, bool>;

        this->Load += gcnew EventHandler(this, &Employees::Form1_Load);
    }

private:
    void Form1_Load(System::Object^ /*sender*/, System::EventArgs^ /*e*/)
    {
        try
        {
            SetUpForm();
            SetUpDataGridView1();
            SetUpDataGridView2();
        }
        catch (SqlException^)
        {
            MessageBox::Show("The connection string <"
                + connectionString
                + "> failed to connect.  Modify it "
                + "to connect to a Northwind database accessible to "
                + "your system.",
                "ERROR", MessageBoxButtons::OK, MessageBoxIcon::Exclamation);
            Application::Exit();
        }
    }

private:
    void SetUpForm()
    {
        Size = System::Drawing::Size(800, 600);
        FlowLayoutPanel^ flowLayout = gcnew FlowLayoutPanel();
        flowLayout->FlowDirection = FlowDirection::TopDown;
        flowLayout->Dock = DockStyle::Fill;
        Controls->Add(flowLayout);

        flowLayout->Controls->Add(DataGridView1);
        flowLayout->Controls->Add(DataGridView2);
    }

private:
    void SetUpDataGridView2()
    {
        DataGridView2->Dock = DockStyle::Bottom;
        DataGridView2->TopLeftHeaderCell->Value = "Sales Details";
        DataGridView2->RowHeadersWidthSizeMode = 
            DataGridViewRowHeadersWidthSizeMode::AutoSizeToAllHeaders;
    }

private:
    void SetUpDataGridView1()
    {
        //DataGridView1.DataError += new 
          //  DataGridViewDataErrorEventHandler(DataGridView1_DataError);
        DataGridView1->CellContentClick += gcnew 
            DataGridViewCellEventHandler(this, &Employees::DataGridView1_CellContentClick);
        DataGridView1->CellValuePushed += gcnew 
            DataGridViewCellValueEventHandler(this, &Employees::DataGridView1_CellValuePushed);
        DataGridView1->CellValueNeeded += gcnew 
            DataGridViewCellValueEventHandler(this, &Employees::DataGridView1_CellValueNeeded);

        // Virtual mode is turned on so that the
        // unbound DataGridViewCheckBoxColumn will
        // keep its state when the bound columns are
        // sorted.       
        DataGridView1->VirtualMode = true;
        DataGridView1->AutoSize = true;
        DataGridView1->DataSource = Populate("SELECT * FROM Employees");
        DataGridView1->TopLeftHeaderCell->Value = "Employees";
        DataGridView1->RowHeadersWidthSizeMode = 
            DataGridViewRowHeadersWidthSizeMode::AutoSizeToAllHeaders;
        DataGridView1->ColumnHeadersHeightSizeMode = 
            DataGridViewColumnHeadersHeightSizeMode::AutoSize;
        DataGridView1->AutoSizeColumnsMode = 
            DataGridViewAutoSizeColumnsMode::AllCells;
        DataGridView1->AllowUserToAddRows = false;
        DataGridView1->AllowUserToDeleteRows = false;

        // The below autogenerated column is removed so 
        // a DataGridViewComboboxColumn could be used instead.
        DataGridView1->Columns->Remove(ColumnName::TitleOfCourtesy.ToString());
        DataGridView1->Columns->Remove(ColumnName::ReportsTo.ToString());

        AddLinkColumn();
        AddComboBoxColumns();
        AddButtonColumn();
        AddOutOfOfficeColumn();
    }

private:
    void AddComboBoxColumns()
    {
        DataGridViewComboBoxColumn^ comboboxColumn;
        comboboxColumn = CreateComboBoxColumn();
        SetAlternateChoicesUsingDataSource(comboboxColumn);
        comboboxColumn->HeaderText = "TitleOfCourtesy (via DataSource property)";
        DataGridView1->Columns->Insert(0, comboboxColumn);

        comboboxColumn = CreateComboBoxColumn();
        SetAlternateChoicesUsingItems(comboboxColumn);
        comboboxColumn->HeaderText = "TitleOfCourtesy (via Items property)";
        // Tack this example column onto the end.
        DataGridView1->Columns->Add(comboboxColumn);
    }

private:
    void AddLinkColumn()
    {
        DataGridViewLinkColumn^ links = gcnew DataGridViewLinkColumn();

		links->UseColumnTextForLinkValue = true;
        links->HeaderText = ColumnName::ReportsTo.ToString();
        links->DataPropertyName = ColumnName::ReportsTo.ToString();
        links->ActiveLinkColor = Color::White;
        links->LinkBehavior = LinkBehavior::SystemDefault;
        links->LinkColor = Color::Blue;
        links->TrackVisitedState = true;
        links->VisitedLinkColor = Color::YellowGreen;

        DataGridView1->Columns->Add(links);
    }

private:
    void SetAlternateChoicesUsingItems(
        DataGridViewComboBoxColumn^ comboboxColumn)
    {
        comboboxColumn->Items->AddRange("Mr.", "Ms.", "Mrs.", "Dr.");
    }

private:
    DataGridViewComboBoxColumn^ CreateComboBoxColumn()
    {
        DataGridViewComboBoxColumn^ column =
            gcnew DataGridViewComboBoxColumn();
        {
            column->DataPropertyName = ColumnName::TitleOfCourtesy.ToString();
            column->HeaderText = ColumnName::TitleOfCourtesy.ToString();
            column->DropDownWidth = 160;
            column->Width = 90;
            column->MaxDropDownItems = 3;
            column->FlatStyle = FlatStyle::Flat;
        }
        return column;
    }

private:
    void SetAlternateChoicesUsingDataSource(DataGridViewComboBoxColumn^ comboboxColumn)
    {
        {
            comboboxColumn->DataSource = RetrieveAlternativeTitles();
            comboboxColumn->ValueMember = ColumnName::TitleOfCourtesy.ToString();
            comboboxColumn->DisplayMember = comboboxColumn->ValueMember;
        }
    }

private:
    DataTable^ RetrieveAlternativeTitles()
    {
        return Populate("SELECT distinct TitleOfCourtesy FROM Employees");
    }

    String^ connectionString;

private:
    DataTable^ Populate(String^ sqlCommand)
    {
        SqlConnection^ northwindConnection = gcnew SqlConnection(connectionString);
        northwindConnection->Open();

        SqlCommand^ command = gcnew SqlCommand(sqlCommand, northwindConnection);
        SqlDataAdapter^ adapter = gcnew SqlDataAdapter();
        adapter->SelectCommand = command;

        DataTable^ table = gcnew DataTable();
        adapter->Fill(table);

        return table;
    }

	// Using an enum provides some abstraction between column index
    // and column name along with compile time checking, and gives
    // a handy place to store the column names.
    enum class ColumnName
    {
        EmployeeID,
        LastName,
        FirstName,
        Title,
        TitleOfCourtesy,
        BirthDate,
        HireDate,
        Address,
        City,
        Region,
        PostalCode,
        Country,
        HomePhone,
        Extension,
        Photo,
        Notes,
        ReportsTo,
        PhotoPath,
        OutOfOffice
    };

private:
    void AddButtonColumn()
    {
        DataGridViewButtonColumn^ buttons = gcnew DataGridViewButtonColumn();
        {
            buttons->HeaderText = "Sales";
            buttons->Text = "Sales";
            buttons->UseColumnTextForButtonValue = true;
            buttons->AutoSizeMode =
                DataGridViewAutoSizeColumnMode::AllCells;
            buttons->FlatStyle = FlatStyle::Standard;
            buttons->CellTemplate->Style->BackColor = Color::Honeydew;
            buttons->DisplayIndex = 0;
        }

        DataGridView1->Columns->Add(buttons);

    }

private:
    void AddOutOfOfficeColumn()
    {
        DataGridViewCheckBoxColumn^ column = gcnew DataGridViewCheckBoxColumn();
        {
            column->HeaderText = ColumnName::OutOfOffice.ToString();
            column->Name = ColumnName::OutOfOffice.ToString();
            column->AutoSizeMode = 
                DataGridViewAutoSizeColumnMode::DisplayedCells;
            column->FlatStyle = FlatStyle::Standard;
            column->ThreeState = true;
            column->CellTemplate = gcnew DataGridViewCheckBoxCell();
            column->CellTemplate->Style->BackColor = Color::Beige;
        }

        DataGridView1->Columns->Insert(0, column);
    }

private:
    void PopulateSales(DataGridViewCellEventArgs^ buttonClick)
    {

        String^ employeeID = DataGridView1->Rows[buttonClick->RowIndex]
            ->Cells[ColumnName::EmployeeID.ToString()]->Value->ToString();
        DataGridView2->DataSource = Populate("SELECT * FROM Orders WHERE EmployeeID = " + employeeID);
    }

    #pragma region "SQL Error handling"
private:
    void DataGridView1_DataError(Object^ sender, DataGridViewDataErrorEventArgs^ anError)
    {

        MessageBox::Show("Error happened " + anError->Context.ToString());

        if (anError->Context == DataGridViewDataErrorContexts::Commit)
        {
            MessageBox::Show("Commit error");
        }
        if (anError->Context == DataGridViewDataErrorContexts::CurrentCellChange)
        {
            MessageBox::Show("Cell change");
        }
        if (anError->Context == DataGridViewDataErrorContexts::Parsing)
        {
            MessageBox::Show("parsing error");
        }
        if (anError->Context == DataGridViewDataErrorContexts::LeaveControl)
        {
            MessageBox::Show("leave control error");
        }

        if (dynamic_cast<ConstraintException^>(anError->Exception) != nullptr)
        {
            DataGridView^ view = (DataGridView^)sender;
            view->Rows[anError->RowIndex]->ErrorText = "an error";
            view->Rows[anError->RowIndex]->Cells[anError->ColumnIndex]->ErrorText = "an error";

            anError->ThrowException = false;
        }
    }
    #pragma endregion

private:
    void DataGridView1_CellContentClick(Object^ /*sender*/, DataGridViewCellEventArgs^ e)
    {

        if (IsANonHeaderLinkCell(e))
        {
            MoveToLinked(e);
        }
        else if (IsANonHeaderButtonCell(e))
        {
            PopulateSales(e);
        }
    }

private:
    void MoveToLinked(DataGridViewCellEventArgs^ e)
    {
        String^ employeeId;
        Object^ value = DataGridView1->Rows[e->RowIndex]->Cells[e->ColumnIndex]->Value;
        if (dynamic_cast<DBNull^>(value) != nullptr) { return; }

        employeeId = value->ToString();
        DataGridViewCell^ boss = RetrieveSuperiorsLastNameCell(employeeId);
        if (boss != nullptr)
        {
            DataGridView1->CurrentCell = boss;
        }
    }

private:
    bool IsANonHeaderLinkCell(DataGridViewCellEventArgs^ cellEvent)
    {
        if (dynamic_cast<DataGridViewLinkColumn^>(DataGridView1->Columns[cellEvent->ColumnIndex]) != nullptr
             &&
            cellEvent->RowIndex != -1)
        { return true; }
        else { return false; }
    }

private:
    bool IsANonHeaderButtonCell(DataGridViewCellEventArgs^ cellEvent)
    {
        if (dynamic_cast<DataGridViewButtonColumn^>(DataGridView1->Columns[cellEvent->ColumnIndex]) != nullptr
             &&
            cellEvent->RowIndex != -1)
        { return true; }
        else { return (false); }
    }

private:
    DataGridViewCell^ RetrieveSuperiorsLastNameCell(String^ employeeId)
    {

        for each (DataGridViewRow^ row in DataGridView1->Rows)
        {
            if (row->IsNewRow) { return nullptr; }
            if (row->Cells[ColumnName::EmployeeID.ToString()]->Value->ToString()->Equals(employeeId))
            {
                return row->Cells[ColumnName::LastName.ToString()];
            }
        }
        return nullptr;
    }

    #pragma region "checkbox state"

private:
    void DataGridView1_CellValuePushed(Object^ sender,
        DataGridViewCellValueEventArgs^ e)
    {
        if (IsCheckBoxColumn(e->ColumnIndex))
        {
            String^ employeeId = GetKey(e);
            if (!inOffice->ContainsKey(employeeId))
            {
                inOffice->Add(employeeId, (Boolean)e->Value);
            }
            else
            {
                inOffice[employeeId] = (Boolean)e->Value;
            }
        }
    }

private:
    String^ GetKey(DataGridViewCellValueEventArgs^ cell)
    {
        return DataGridView1->Rows[cell->RowIndex]->
            Cells[ColumnName::EmployeeID.ToString()]->Value->ToString();
    }

private:
    void DataGridView1_CellValueNeeded(Object^ sender,
        DataGridViewCellValueEventArgs^ e)
    {

        if (IsCheckBoxColumn(e->ColumnIndex))
        {
            String^ employeeId = GetKey(e);
            if (!inOffice->ContainsKey(employeeId))
            {
                bool defaultValue = false;
                inOffice->Add(employeeId, defaultValue);
            }

            e->Value = inOffice[employeeId];
        }
    }

private:
    bool IsCheckBoxColumn(int columnIndex)
    {
        DataGridViewColumn^ outOfOfficeColumn =
            DataGridView1->Columns[ColumnName::OutOfOffice.ToString()];
        return (DataGridView1->Columns[columnIndex] == outOfOfficeColumn);
    }
    #pragma endregion
};

int main()
{
    Employees::Main();
}