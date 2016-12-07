using CmTool.Db;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestConfiguration
{
    [TestClass]
    public class TestDatabase
    {
        [TestMethod]
        public void TestDb()
        {
            var con = "Data Source=core7.rigilog.com;Initial Catalog=Support_DB;User ID=dbo_Support_DB;Password=Zh!ef$dFR87tA";
            var rep = new DbAccountRepository(con);
            var users = rep.GetAllUsers();

        }

    }
}
