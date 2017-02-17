    private void showCheckedNodesButton_Click(object sender, EventArgs e)
    {
        // Disable redrawing of treeView1 to prevent flickering 
        // while changes are made.
        treeView1.BeginUpdate();

        // Collapse all nodes of treeView1.
        treeView1.ExpandAll();

        // Add the checkForCheckedChildren event handler to the BeforeExpand event.
        treeView1.BeforeCollapse += checkForCheckedChildren;

        // Expand all nodes of treeView1. Nodes without checked children are 
        // prevented from expanding by the checkForCheckedChildren event handler.
        treeView1.CollapseAll();

        // Remove the checkForCheckedChildren event handler from the BeforeExpand 
        // event so manual node expansion will work correctly.
        treeView1.BeforeCollapse -= checkForCheckedChildren;

        // Enable redrawing of treeView1.
        treeView1.EndUpdate();
    }

    // Prevent collapse of a node that has checked child nodes.
    private void CheckForCheckedChildrenHandler(object sender, 
        TreeViewCancelEventArgs e)
    {
        if (HasCheckedChildNodes(e.Node)) e.Cancel = true;
    }

    // Returns a value indicating whether the specified 
    // TreeNode has checked child nodes.
    private bool HasCheckedChildNodes(TreeNode node)
    {
        if (node.Nodes.Count == 0) return false;
        foreach (TreeNode childNode in node.Nodes)
        {
            if (childNode.Checked) return true;
            // Recursively check the children of the current child node.
            if (HasCheckedChildNodes(childNode)) return true;
        }
        return false;
    }