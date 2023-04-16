using EfcDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xUnit.Utils;

public class DbTestBaseClass
{
    public PaddlerNationContext PaddleBoardDb { get; private set; }

    [TestInitialize]
    public virtual void TestInit()
    {
        // configure an in memory database
        PaddleBoardDb = new PaddleBoardDbContextInMemory();
        // this ensures that the database is created in the memory and it's ready to use 
        PaddleBoardDb.Database.EnsureCreated();
    }


    private class PaddleBoardDbContextInMemory : PaddlerNationContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
        }
    }
}