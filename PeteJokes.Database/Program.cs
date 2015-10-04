using System;
using System.Data.SqlClient;
using System.Reflection;
using DbUp;
using NDesk.Options;

namespace PeteJokes.Database
{
    class Program
    {
        static int Main(string[] args)
        {
            var server = string.Empty;
            var database = string.Empty;
            var directory = string.Empty;
            var username = string.Empty;
            var password = string.Empty;
            var mark = false;
            var connectionString = string.Empty;

            var showHelp = false;

            var optionSet =
                new OptionSet()
                {
                    { "s|server=", "The SQL Server host", s => server = s },
                    { "db|database=", "Database to upgrade", d => database = d},
                    { "d|directory=", "Directory containing SQL Update files", dir => directory = dir },
                    { "u|user=", "Database username", u => username = u},
                    { "p|password=", "Database password", p => password = p},
                    { "cs|connectionString=", "Full connection string", cs => connectionString = cs},
                    { "h|help",  "Show this message and exit", v => showHelp = v != null },
                    {"mark", "Mark scripts as executed but take no action", m => mark = true},
                };

            optionSet.Parse(args);

            if (args.Length == 0)
            {
                showHelp = true;
            }

            if (showHelp)
            {
                optionSet.WriteOptionDescriptions(Console.Out);
                return 0;
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = BuildConnectionString(server, database, username, password);
            }

            var dbup = DeployChanges.To
                .SqlDatabase(connectionString)
                .LogToConsole()
                .JournalToSqlTable("dbo", "MigrationHistory")
                .WithScriptsAndCodeEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .Build();

            var result = !mark ? dbup.PerformUpgrade() : dbup.MarkAsExecuted();

            return result.Successful ? 0 : 1;
        }

        private static string BuildConnectionString(string server, string database, string username, string password)
        {
            var conn = new SqlConnectionStringBuilder();
            conn.DataSource = server;
            conn.InitialCatalog = database;
            if (!String.IsNullOrEmpty(username))
            {
                conn.UserID = username;
                conn.Password = password;
                conn.IntegratedSecurity = false;
            }
            else
            {
                conn.IntegratedSecurity = true;
            }

            return conn.ToString();
        }
    }
}