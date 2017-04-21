using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace ScruffyNerfHerderSabers.DAL
{
    public class StoreConfiguration : DbConfiguration
    {
        public StoreConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}