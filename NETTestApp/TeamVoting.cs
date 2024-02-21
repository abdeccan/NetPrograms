using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    #region others


    //public class TeamVoting
    //{
    //    // B -> 2, 2, 2
    //    // C -> 2, 2, 2
    //    // A -> 2, 2, 2

    //    // isTie = false, add top team, remove from dictionary
    //    // isTie = true, go to next position
    //    // repeat until nothing left in dictionary
    //    public string RankTeams(string[] votes)
    //    {
    //        int numVotes = votes.Length;

    //        if (numVotes == 1)
    //            return votes[0];

    //        Dictionary<char, int[]> voteMap = new Dictionary<char, int[]>();

    //        int numTeams = votes[0].Length;

    //        for (int i = 0; i < numTeams; i++)
    //        {
    //            for (int j = 0; j < votes.Length; j++)
    //            {
    //                char team = votes[j][i];

    //                if (!voteMap.ContainsKey(team))
    //                {
    //                    voteMap.Add(team, new int[numTeams]);
    //                }

    //                voteMap[team][i]++;
    //            }
    //        }

    //        StringBuilder sb = new StringBuilder();
    //        while (voteMap.Count > 0)
    //        {
    //            sb.Append(FindNextTeam(voteMap, 0, voteMap.Keys.ToList(), numTeams));
    //        }

    //        return sb.ToString();
    //    }

    //    private char FindNextTeam(Dictionary<char, int[]> voteMap, int currPosition, List<char> remainingTeams, int maxPosition)
    //    {
    //        if (currPosition == maxPosition)
    //        {
    //            var topTeam = remainingTeams.Min();
    //            voteMap.Remove(topTeam);
    //            return topTeam;
    //        }

    //        int maxVotes = 0;
    //        List<char> topTeams = new List<char>();

    //        foreach (var team in remainingTeams)
    //        {
    //            int votes = voteMap[team][currPosition];
    //            if (votes > maxVotes)
    //            {
    //                maxVotes = votes;
    //                topTeams = new List<char> { team };
    //            }
    //            else if (votes == maxVotes)
    //            {
    //                topTeams.Add(team);
    //            }
    //        }

    //        if (topTeams.Count == 1)
    //        {
    //            var topTeam = topTeams[0];
    //            voteMap.Remove(topTeam);
    //            return topTeam;
    //        }

    //        return FindNextTeam(voteMap, currPosition + 1, topTeams, maxPosition);
    //    }
    //}
    #endregion // others
    #region mine
    //internal class TeamVoting
    //{
    //    int numTeams = 0;
    //    List<char> Teams = new List<char>();

    //    public string RankTeams(string[] votes)
    //    {
    //        int numVotes = votes.Length;

    //        if (numVotes == 1)
    //            return votes[0];

    //        numTeams = votes[0].Length;

    //        // ["ABC","ACB","ABC","ACB","ACB"] <-- votes
    //        // for each position we need 'numVotes' maps

    //        foreach (char c in votes[0])
    //        { 
    //            Teams.Add(c);
    //        }
    //        Dictionary<char, int>[] positionMaps = new Dictionary<char, int>[numTeams];
    //        for (int index = 0; index < numTeams; index++)
    //        {
    //            if (positionMaps[index] == null) positionMaps[index] = new();

    //            foreach (var vote in votes)
    //            {
    //                if (positionMaps[index].ContainsKey(vote[index]))
    //                {
    //                    positionMaps[index][vote[index]]++;
    //                }
    //                else
    //                {
    //                    positionMaps[index].Add(vote[index], 1);
    //                }
    //            }
    //        }
    //        string result = string.Empty;
    //        // now the dictionary is populated we need to resolve ties and declare result
    //        // sample positionMaps at this time: [{A:5}, {B:2, C:3}, {B:3, C:2}]
    //        for (int place = 0; place < numTeams; place++)
    //        {
    //            char res = FindNextTeam(place, positionMaps, Teams, Teams.Count);
    //            Teams.Remove(res);
    //            result += res;
    //        }




    //        return result;
    //    }




    //    char FindNextTeam(int rank, Dictionary<char, int>[] positionMaps, List<char> remainingTeams, int remTeams)
    //    {
    //        if (rank == remTeams)
    //        {
    //            var topTeam = remainingTeams.Min();
    //            return topTeam;
    //        }
    //        char twinner = '\0';
    //        int maxVal = 0;

    //        List<char> ListOfTiedTeams = new();

    //        for (int index = rank; index < numTeams; index++)
    //        {
    //            List<KeyValuePair<char, int>> orderedPosMaps =
    //                positionMaps[index].OrderByDescending(kvp => kvp.Value).ToList();

    //            twinner = orderedPosMaps.FirstOrDefault().Key;

    //            int maxIndex = orderedPosMaps.Count - 1;

    //            if (remainingTeams.Contains(twinner))
    //            {
    //                if (maxIndex == 0) return twinner; // all voted for only one team at one  place


    //                maxVal = orderedPosMaps.ElementAt(0).Value;

    //                ListOfTiedTeams.Add(orderedPosMaps.ElementAt(0).Key);
    //            }

    //            bool IsTie = false;
    //            for (int j = 0; j < maxIndex; j++)
    //            {
    //                if (maxVal > orderedPosMaps.ElementAt(j + 1).Value)
    //                {
    //                    if( !IsTie)  return orderedPosMaps.ElementAt(j).Key;
    //                    break;
    //                }
    //                else
    //                {
    //                    IsTie = true;
    //                    ListOfTiedTeams.Add(orderedPosMaps.ElementAt(j+1).Key);                       
    //                }
    //            }
    //            return FindNextTeam(rank + 1, positionMaps, ListOfTiedTeams,remTeams);

    //        }
    //        return winner;
    //    }
    //}
    #endregion// mine

    public class TeamVoting
    {

        public string RankTeams(string[] votes)
        {
            int NumVotes = votes.Length;

            if (NumVotes == 1) return votes[0];

            int NumTeams = votes[0].Length;

            // we want to have a mapping between the teams and the votes they secured in each rank/ place i.e. A: {5, 0, 0} assuming there are 3 places
            Dictionary<char, int[]> VotesMap = new();
            for (int i = 0; i < NumTeams; i++)
            {
                for (int j = 0; j < NumVotes; j++)
                {
                    char currTeam = votes[j][i];
                    if (!VotesMap.ContainsKey(currTeam))
                    {
                        VotesMap.Add(currTeam, new int[NumTeams]);
                    }
                    VotesMap[currTeam][i]++;
                }
            }

            // now we have the VotesMap/. we need to go through the map matrix to find winners for each place

            StringBuilder sb = new StringBuilder();
            int currPos = 0;
            int maxPos = NumTeams;
            
            while (VotesMap.Count > 0)
            {
                sb.Append(FindNextWinner(VotesMap, currPos, maxPos, VotesMap.Keys.ToList()));
            }

            return sb.ToString();
        }

        char FindNextWinner(Dictionary<char, int[]> votesMap, int currPos, int maxPos, List<char> remainingTeams)
        {
            // base condition - we have reached the last column
            if (currPos == maxPos)
            {
                // return the team in alphabetical order
                char winner = remainingTeams.Min();
                votesMap.Remove(winner);
                return winner;
            }

            // we need to identify top teams and potential ties!
            int maxVotes = 0;
            List<char> topTeams = new();
            foreach (var team in remainingTeams)
            {
                if (votesMap[team][currPos] > maxVotes)
                {
                    maxVotes = votesMap[team][currPos];
                    topTeams = new List<char> { team }; // new leader!
                }
                else if (votesMap[team][currPos] == maxVotes)
                {
                    topTeams.Add(team); // tie!
                }
            }

            if (topTeams.Count == 1)
            {
                // single winner
                char winner = topTeams[0];
                votesMap.Remove(winner);
                return winner;
            }

            // settle the tie recursively between top teams
            return FindNextWinner(votesMap, currPos + 1, maxPos, topTeams);
        }
    }
}
