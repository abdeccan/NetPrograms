using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{ 
    internal class RateLimiter
    {
        readonly int _TimeWindowInSeconds = 0;
        readonly int _NumRequestsAllowed = 0;
        public struct RateLimits
        {
            public DateTime StartTime;
            public int NumRequestsMadeSoFar;
            public DateTime LastRequestMadeAt; // may not be needed
        }

        // c1: {10am, 11am, 100, 10.20am}
        Dictionary<int, RateLimits> rateLimits = new Dictionary<int, RateLimits>();
        
        public RateLimiter(int NumRequestsAllowed, int TimeWindowInSeconds) 
        {
            _TimeWindowInSeconds = TimeWindowInSeconds;
            _NumRequestsAllowed = NumRequestsAllowed;
        }
        /* “Each customer can make X requests per Y seconds”

        // Perform rate limiting logic for provided customer ID. Return true if the
        // request is allowed, and false if it is not.
        */

        // approach is to have the customerId mapped to the start and end times of the time 
        // window
        public bool rateLimit(int customerId) 
        {
            if (rateLimits.ContainsKey(customerId))
            {
                TimeSpan delta = DateTime.Now - rateLimits[customerId].StartTime;
                //Console.WriteLine($"{delta.Seconds}");
                if ((DateTime.Now - rateLimits[customerId].StartTime).Seconds >= _TimeWindowInSeconds)
                {
                   // Console.WriteLine("time to reset window");
                    // time to clear the previous window
                    rateLimits[customerId] = new RateLimits
                    { StartTime = DateTime.Now, LastRequestMadeAt = DateTime.Now, NumRequestsMadeSoFar = 1 };
                    return true;
                }
                else
                {
                    if (rateLimits[customerId].NumRequestsMadeSoFar >= _NumRequestsAllowed)
                        return false;
                    else
                    {
                        RateLimits newLimit = rateLimits[customerId];
                        newLimit.NumRequestsMadeSoFar++;
                        rateLimits[customerId] = newLimit;
                        return true;
                    }
                }

            }
            else 
            {
                // this is the first time we get the req from this customer
                rateLimits.Add(customerId, new RateLimits 
                    { StartTime = DateTime.Now, LastRequestMadeAt = DateTime.Now, NumRequestsMadeSoFar = 1 } );
                return true;
            }
        }

        public static void TestRateLimiter()
        {
            RateLimiter rl = new RateLimiter(3, 1);
            Console.WriteLine($"Allowed: {rl.rateLimit(1)}");
            Console.WriteLine($"Allowed: {rl.rateLimit(1)}");
            Console.WriteLine($"Allowed: {rl.rateLimit(1)}");
            Console.WriteLine($"Allowed: {rl.rateLimit(1)}");
            Thread.Sleep(1500);
            Console.WriteLine($"Allowed: {rl.rateLimit(1)}");
            Console.WriteLine($"Allowed: {rl.rateLimit(2)}");
            Console.WriteLine($"Allowed: {rl.rateLimit(1)}");
            Console.WriteLine($"Allowed: {rl.rateLimit(1)}");
        }
    }
}
