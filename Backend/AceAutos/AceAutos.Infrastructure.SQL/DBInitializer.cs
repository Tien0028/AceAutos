using AceAutos.Core.Entity;
using AceAutos.Infrastructure.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AceAutos.Infrastructure.SQL
{
    public class DBInitializer : IDBInitializer
    {
        private readonly IAuthenticationHelper authenticationHelper;
        public static IEnumerable<Car> Cars;


        public DBInitializer(IAuthenticationHelper authHelper)
        {
            authenticationHelper = authHelper;
        }

        public void SeedDB(DBContext ctx)
        {
            // Delete the database, if it already exists. I do this because an
            // existing database may not be compatible with the entity model,
            // if the entity model was changed since the database was created.
            // This operation has no effect for an in-memory database.
            ctx.Database.EnsureDeleted();

            // Create the database, if it does not already exists. This operation
            // has no effect for an in-memory database.
            ctx.Database.EnsureCreated();

            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn, passwordHashJanet, passwordSaltJanet, passwordHashAni, passwordSaltAni;
            authenticationHelper.CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            authenticationHelper.CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);
            authenticationHelper.CreatePasswordHash(password, out passwordHashJanet, out passwordSaltJanet);
            authenticationHelper.CreatePasswordHash(password, out passwordHashAni, out passwordSaltAni);

            List<User> users = new List<User>
            {
                new User{Username = "UserJoe", PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe, IsAdmin = false},
                new User{Username = "AdminAnn", PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn, IsAdmin = true},
                new User{Username = "UserJanet", PasswordHash = passwordHashJanet,
                    PasswordSalt =passwordSaltJanet, IsAdmin = false},
                new User{Username = "AdminAni", PasswordHash = passwordHashAni,
                    PasswordSalt = passwordSaltAni, IsAdmin = true},
            };

            List<Car> cars = new List<Car>
            {
               new Car{Manufacturer = "Porsche", Model = "900", Color = "Brown", Type = "Coupe", Price = 999, Fuel = "Gas", Year = 2018, Mileage = 20000, Description = "",},
               new Car{Manufacturer = "Mercedes Benz", Model = "S Class", Color = "White", Type = "Luxury", Price = 01, Fuel = "Gas", Year = 2018, Mileage = 20000, Description = "",},
               new Car{Manufacturer = "Audi", Model = "R8", Color = "Indigo", Type = "Sports", Price = 90, Fuel = "Gas", Year = 2018, Mileage = 20000, Description = "",},
               new Car{Manufacturer = "BMW", Model = "M8", Color = "Red", Type = "SUV", Price = 12, Fuel = "Gas", Year = 2018, Mileage = 20000, Description = "",}
            };

            ctx.AddRange(users);
            ctx.AddRange(cars);
            ctx.SaveChanges();



        }
    }
}
