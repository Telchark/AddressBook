using AddressBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookTests
{
    public class Utilities
    {
        public static void InitializeDbForTests(AddressBookContext context)
        {
            context.Addresses.AddRange(
                        new Address
                        {
                            Id = 1,
                            FirstName = "Andrzej",
                            LastName = "B",
                            Country = "Poland",
                            City = "Bielsko-Biała",
                            ZipCode = "34-100",
                            Street = "Dworska",
                            BuildingNumber = 35,
                            LocalNumber = null
                        },
                        new Address
                        {
                            Id = 2,
                            FirstName = "Jan",
                            LastName = "Kowalski",
                            Country = "Poland",
                            City = "Bielsko-Biała",
                            ZipCode = "34-100",
                            Street = "Dworska",
                            BuildingNumber = 36,
                            LocalNumber = null,

                        },

                        new Address
                        {
                            Id = 3,
                            FirstName = "John",
                            LastName = "Doe",
                            Country = "Poland",
                            City = "Wadowice",
                            ZipCode = "22-100",
                            Street = "Lipowa",
                            BuildingNumber = 100,
                            LocalNumber = 83
                        },
                        new Address
                        {
                            Id = 4,
                            FirstName = "Franz",
                            LastName = "Muller",
                            Country = "Germany",
                            City = "Berlin",
                            ZipCode = "22-100",
                            Street = "German Street",
                            BuildingNumber = 22,
                            LocalNumber = null
                        });

            context.SaveChanges();
        }
    }
 }
