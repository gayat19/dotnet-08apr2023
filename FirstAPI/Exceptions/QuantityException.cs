namespace FirstAPI.Exceptions
{
    public class QuantityException :Exception
    {
        public override string Message => "Invalid quantity for the product";
    }
}
