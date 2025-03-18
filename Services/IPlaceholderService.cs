using interview.Models;

namespace interview.Services
{
    public interface IPlaceholderService
    {
        Task<List<PlaceholderDTO>> FetchTitle(int pageNumber, int pageSize);
        Task AddExample(Example example);
        Task<List<Example>> GetExample();
        Task UpdateExample(Example example);
        Task DeleteExample(long id);
    }
}
