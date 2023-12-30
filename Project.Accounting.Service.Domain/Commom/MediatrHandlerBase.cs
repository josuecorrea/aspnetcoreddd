namespace Project.Accounting.Service.Domain.Commom
{
    public class MediatrHandlerBase
    {
        protected ICollection<string> Errors = new List<string>();

        protected void AddError(string error)
        {
            Errors.Add(error);
        }

        protected BaseResult<T> Result<T>(T param)
        {
            var result = new BaseResult<T>(param);

            if (Errors.Any())
            {
                return new BaseResult<T>(param, Errors.ToList());
            }

            return result;
        }
    }
}
