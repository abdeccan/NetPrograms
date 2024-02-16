using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    internal class TeamVoting
    {   public string RankTeams(string[] votes)
        {
            if (votes.Length == 1)
                return votes[0];

            return String.Empty;
        }
    }
}
