using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Data
{
    public class AddressBookRepository : IAddressBookRepository
    {
        private readonly AddressBookContext _context;
        private readonly ILogger<AddressBookRepository> _logger;
        public AddressBookRepository(AddressBookContext context, ILogger<AddressBookRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Address> GetLastAddress()
        {
            _logger.LogInformation($"Getting last added adress.");
            return await _context.Addresses.LastOrDefaultAsync();
        }

        public async Task<Address[]> GetAllAddressesAsync()
        {
            _logger.LogInformation($"Getting all adresses.");
            var query = _context.Addresses.OrderBy(a => a.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Address[]> GetAllAddressesByCityAsync(string city)
        {
            _logger.LogInformation($"Getting all adresses from {city}.");
            var query = _context.Addresses.Where(a => a.City.ToLower() == city.ToLower()).OrderBy(c => c.Id);
            return await query.ToArrayAsync();
        }

    }
}
