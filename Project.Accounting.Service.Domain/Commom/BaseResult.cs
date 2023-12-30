namespace Project.Accounting.Service.Domain.Commom
{
    public record BaseResult<T>
    {
        public BaseResult(T result, bool error = false, List<string> errorMessages = null!)
        {
            Error = error;
            ErrorMessages = errorMessages;
            Result = result;
         
        }

        public bool Error { get; }
        public List<string> ErrorMessages { get; }
        public T Result { get; }
    }
}