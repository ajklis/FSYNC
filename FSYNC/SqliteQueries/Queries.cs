namespace FSYNC.SqliteQueries
{
    public static class Queries
    {
        public static string GetCreateTableQuery()
            => File.ReadAllText("SqliteQueries/createTables.sql");
        /// <summary>
        /// Get insert query with correct params
        /// </summary>
        /// <param name="recordName">Record name</param>
        /// <param name="originalName">Original file name</param>
        /// <returns></returns>
        public static string GetRecordInsertQuery(string recordName, string originalName)
            => File.ReadAllText("SqliteQueries/recordInsert.sql")
            .Replace("#RecordName", recordName)
            .Replace("#OriginalName", originalName);
    }
}
