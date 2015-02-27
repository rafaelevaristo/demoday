using System.Data.Entity;
 
namespace demoDay.MysqlMigrationsFix
{
  public class MySqlConfiguration : DbConfiguration
  {
    public MySqlConfiguration()
    {
      SetHistoryContext(
      "MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
    }
  }
}