using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Data
{
    public interface IAddressBookRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Address[]> GetAllAddressesAsync();
        Task<Address[]> GetAllAddressesByCityAsync(string city);
        Task<Address> GetLastAddress();

    }
}
