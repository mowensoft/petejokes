using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using MediatR;

namespace PeteJokes.Queries
{
    public class RecentJokesQueryHandler : IAsyncRequestHandler<RecentJokesQuery, IEnumerable<RecentJokesQuery.Result>>
    {
        private const string GetRecentJokes = "SELECT TOP 25 * FROM [dbo].[Joke] WITH (NOLOCK) ORDER BY [ToldOn] DESC";

        public async Task<IEnumerable<RecentJokesQuery.Result>> Handle(RecentJokesQuery message)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ComedyClub"].ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<RecentJokesQuery.Result>(GetRecentJokes);
            }
        }
    }
}
