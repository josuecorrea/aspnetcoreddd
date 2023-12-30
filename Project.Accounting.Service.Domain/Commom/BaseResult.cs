namespace Project.Accounting.Service.Domain.Commom
{
    public record BaseResult<T>
    {
        public BaseResult(T result, bool error = false, string[] errorMessages = null!)
        {
            Error = error;
            ErrorMessages = errorMessages;
            Result = result;
         
        }

        public bool Error { get; }
        public string[] ErrorMessages { get; }
        public T Result { get; }
    }
}