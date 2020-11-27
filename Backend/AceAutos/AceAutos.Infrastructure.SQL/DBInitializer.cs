using PetShopApplicationSolution.Infrastructure.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AceAutos.Infrastructure.SQL
{
    public class DBInitializer : IDBInitializer
    {
        private readonly IAuthenticationHelper authenticationHelper;

        public DBInitializer(IAuthenticationHelper authHelper)
        {
            authenticationHelper = authHelper;
        }

        public void SeedDB(DBContext atx)
        {
            // Delete the database, if it already exists. I do this because an
            // existing database may not be compatible with the entity model,
            // if the entity model was changed since the database was created.
            // This operation has no effect for an in-memory database.
            atx.Database.EnsureDeleted();

            // Create the database, if it does not already exists. This operation
            // has no effect for an in-memory database.
            atx.Database.EnsureCreated();
        }
    }
}
