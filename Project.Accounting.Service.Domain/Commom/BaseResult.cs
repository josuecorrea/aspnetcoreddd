namespace Project.Accounting.Service.Domain.Commom
{
    public record BaseResult<T>
    {
        public BaseResult(T result, List<string> errorMessages = null!)
        {
            ErrorMessages = errorMessages;
            Result = result;
            
            Error = errorMessages?.Any() ?? false;  
        }

        public bool Error { get; private set; }
        public List<string> ErrorMessages { get; }
        public T Result { get; }

        public void SetError(bool error) => Error = error; 
    }
}