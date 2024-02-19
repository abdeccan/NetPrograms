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
            int numTeams = votes.Length;

            if (numTeams == 1)
                return votes[0];

            // for each position we need 'numTeams' maps 
            Dictionary<char, int>[] positionMaps = new Dictionary<char, int>[numTeams]; 

            return String.Empty;
        }
    }
}
