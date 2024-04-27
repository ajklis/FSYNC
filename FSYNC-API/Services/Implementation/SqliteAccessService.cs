using FSYNC_API.Services.Interfaces;

namespace FSYNC_API.Services.Implementation
{
    internal class SqliteAccessService : ISqliteAccess
    {
        public Task<bool> AddRecord(string recordName, string path)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveRecord(string recordName)
        {
            throw new NotImplementedException();
        }
    }
}
