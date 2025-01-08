namespace SkillZee.Domain.Result
{
    public abstract class BaseResult
    {
        public bool IsSuccess => Error == null;

        public Error? Error { get; set; }
    }

    public class BaseResult<T>: BaseResult
    {
        public BaseResult(Error error)
        {
            Error = error;
        }

        public BaseResult(T data)
        {
            Data = data;
        }

        public T? Data { get; set; }
    }

    public class CollectionResullt<T>: BaseResult<IEnumerable<T>>
    {
        public readonly int Count;

        public CollectionResullt(Error error) : base(error)
        {
        }

        public CollectionResullt(IEnumerable<T> data) : base(data)
        {
            Count = data.Count();
        }
    }
}
