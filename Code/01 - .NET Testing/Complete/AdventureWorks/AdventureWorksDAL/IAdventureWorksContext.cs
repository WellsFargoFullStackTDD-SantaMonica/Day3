using System;
using System.Data.Entity;

namespace AdventureWorksDAL
{
    public interface IAdventureWorksContext : IDisposable
    {
        DbSet<Product> Products { get; set;  }
        int SaveChanges();
        void MarkAsModified(Product item);
    }
}