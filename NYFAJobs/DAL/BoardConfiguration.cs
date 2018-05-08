using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace NYFAJobs.DAL
{
    public class BoardConfiguration : DbConfiguration
    {
        public BoardConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}