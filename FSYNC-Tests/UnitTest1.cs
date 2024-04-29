using FSYNC.Services.Implementation;

namespace FSYNC_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task CheckDb()
        {
            SqliteAccessService sqlite = new SqliteAccessService(null);
            await sqlite.ConfigureAsync();
        }
    }
}