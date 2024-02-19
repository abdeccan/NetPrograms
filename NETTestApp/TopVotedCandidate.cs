using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    public class TopVotedCandidate
    {
        int[] _times;
        int[] _persons;
        Dictionary<int, int> _personVotes = new();
        List<int> _leadersAtTimes = new();
        int currLeader = -1;
        int maxVotes = 0;
        public TopVotedCandidate(int[] persons, int[] times)
        {
            _persons = persons;
            _times = times;

            // pre-calculate the leaders for every slot in times
            for (int index = 0; index < times.Length; index++) {
                if (_personVotes.ContainsKey(_persons[index]))
                {
                    _personVotes[_persons[index]]++;
                    if (_personVotes[_persons[index]] >= maxVotes)
                    {
                        currLeader = _persons[index];
                        maxVotes = _personVotes[_persons[index]];
                    }
                }
                else
                {                    
                    if (currLeader == -1)
                    {
                        currLeader = _persons[index];
                        maxVotes = 1;
                    }
                    _personVotes[_persons[index]] = 1;

                    if (maxVotes == 1) { 
                        currLeader = _persons[index];
                    }
                }

                _leadersAtTimes.Add(currLeader);
            }
        }

        public int Q(int t)
        {
            // if 't' is not there in times, this will give us the first time value thats greater than 't'
            int index = Array.BinarySearch(_times, t);
            if (index == 0)
                return _persons[0];
            else if (t > _times.Last()) // this is when the 't' is not present in array and we get index of last elem + 1 
                index = _times.Length - 1;
            else if (index < 0)
                index = ~index - 1;            
            
            //
            // now index is the limit till we search in persons array
            return _leadersAtTimes.ElementAt(index);
        }
    }

    /**
     * Your TopVotedCandidate object will be instantiated and called as such:
     * TopVotedCandidate obj = new TopVotedCandidate(persons, times);
     * int param_1 = obj.Q(t);
     */
}
