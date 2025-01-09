namespace SkillZee.Domain.Result
{
    public class PagedResult<T>
    {
        public T[] Data { get; }

        public PagedResult(T[] data, int totalCount)
        {
            Data = data;
        }
    }
}
