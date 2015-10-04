using System;
using System.Collections.Generic;
using MediatR;

namespace PeteJokes.Queries
{
    public class RecentJokesQuery : IAsyncRequest<IEnumerable<RecentJokesQuery.Result>>
    {
        public class Result
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public string Location { get; set; }
            public DateTime ToldOn { get; set; }
            public int UpGoats { get; set; }
            public int DownBoats { get; set; }

            public int Score
            {
                get { return UpGoats - DownBoats; }
            }
        }
    }
}
