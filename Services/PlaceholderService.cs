using interview.Data;
using interview.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing.Printing;

namespace interview.Services
{
    public class PlaceholderService : IPlaceholderService
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationDBContext _dbContext;
        private readonly string _getPlaceholderURL;

        public PlaceholderService(HttpClient httpClient, ApplicationDBContext dbContext, IOptions<APISettings> options)
        {
            _httpClient = httpClient;
            _dbContext = dbContext;
            _getPlaceholderURL = options.Value.PlaceholderURL;
        }

        public async Task<List<PlaceholderDTO>> FetchTitle(int pageNumber, int pageSize)
        {
            try
            {
                if (pageNumber == 0)
                    pageNumber = 1;

                if (pageSize == 0)
                    pageSize = int.MaxValue;
                var skip = (pageNumber - 1) * pageSize;

                var response = await _httpClient.GetStringAsync(_getPlaceholderURL);
                List<Placeholder> placeholders = JsonConvert.DeserializeObject<List<Placeholder>>(response);

                var data = placeholders.Skip(skip).Take(pageSize).Select(p => new PlaceholderDTO { Id = p.Id, Title = p.Title })
                                      .ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddExample(Example example)
        {
            try
            {
                await _dbContext.Examples.AddAsync(example);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteExample(long id)
        {
            try
            {
                var examp = await _dbContext.Examples.FindAsync(id);
                if (examp != null)
                {
                    _dbContext.Examples.Remove(examp);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Example>> GetExample()
        {
            try
            {
                return await _dbContext.Examples.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateExample(Example example)
        {
            try
            {
                var examp = await _dbContext.Examples.FindAsync(example.id);
                if (examp != null)
                {
                    examp.name = example.name;
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
