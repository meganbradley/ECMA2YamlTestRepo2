        [OperationContract]
        [WebGet(UriTemplate = "Sub?x={x}&y={y}")]
        long Subtract(long x, long y);