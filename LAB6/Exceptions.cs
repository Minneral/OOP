namespace LAB5;

public class ListWrongIndex : ApplicationException
{
    public int Index { get; }
    public ListWrongIndex() { }
    public ListWrongIndex(string message) : base(message) { }
    public ListWrongIndex(string message, Exception innerException) : base(message, innerException) { }
    public ListWrongIndex(string message, int index) : base(message)
    {
        Index = index;
    }
}

public class ProductWrongArgument : ArgumentException
{
    public string Value { get; }
    public ProductWrongArgument() { }
    public ProductWrongArgument(string message) : base(message) { }
    public ProductWrongArgument(string message, string value) : base(message)
    {
        Value = value;
    }
}

public class ProductNullReference : ApplicationException
{
    public ProductNullReference() { }
    public ProductNullReference(string message) : base(message) { }
}


