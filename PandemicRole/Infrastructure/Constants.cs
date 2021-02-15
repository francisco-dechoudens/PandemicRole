using System;
using System.IO;
using System.Reflection;

namespace PandemicRole.Infrastructure
{
    public static class Constants
    {
        public const string DatabaseFilename = "PandemicRoleSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var DatabasePath = Path.Combine(basePath, DatabaseFilename);

                Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                Stream embeddedDatabaseStream = assembly.GetManifestResourceStream("PandemicRole.PandemicRoleSQLite.db3");

                if (!File.Exists(DatabasePath))
                {
                    FileStream fileStreamToWrite = File.Create(DatabasePath);
                    embeddedDatabaseStream.Seek(0, SeekOrigin.Begin);
                    embeddedDatabaseStream.CopyTo(fileStreamToWrite);
                    fileStreamToWrite.Close();
                }

                return DatabasePath;
            }
        }
    }
}
