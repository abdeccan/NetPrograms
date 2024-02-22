using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    public interface MostPopular
    {
        public void increasePopularity(int contentId);

        public int mostPopular();

        public void decreasePopularity(int contentId);

    }
    // draft
    internal class ArticlePopularityHeap : MostPopular
    {
        public class NewsArticlePopularity : IComparer<NewsArticlePopularity>
        { 
            int contentId;
            int popularity;
            public NewsArticlePopularity(int contentId) 
            {
                this.contentId = contentId;
            }

            public int Compare(NewsArticlePopularity? a, NewsArticlePopularity? b)
            {
                if (a == null && b == null)
                {
                    return 0;
                }
                else if (a == null && b != null)
                {
                    return 1;
                }
                else if (a != null && b == null)
                {
                    return -1;
                }

                if (a.popularity > b.popularity)
                    return -1;
                else if (a.popularity == b.popularity)
                    return 0;
                else
                    return 1;
            }
        }

        PriorityQueue<NewsArticlePopularity, NewsArticlePopularity> newsPopularityCollection = new PriorityQueue<NewsArticlePopularity, NewsArticlePopularity>();

        public void increasePopularity(int contentId)
        {
            NewsArticlePopularity article = new NewsArticlePopularity(contentId);
            
        }

        public int mostPopular()
        {
            return -1;
        }

        public void decreasePopularity(int contentId)
        { 

        }
    }
    internal class ArticlePopularityMap: MostPopular
    {
        public static void TestArticlePopularityMap()
        {
            ArticlePopularityMap popularityTracker = new ArticlePopularityMap();

            popularityTracker.increasePopularity(7);

            popularityTracker.increasePopularity(7);

            popularityTracker.increasePopularity(8);

            Console.WriteLine($"Most popular :{popularityTracker.mostPopular()}");        // returns 7

            popularityTracker.increasePopularity(8);

            popularityTracker.increasePopularity(8);

            Console.WriteLine($"Most popular :{popularityTracker.mostPopular()}");        // returns 8

            popularityTracker.decreasePopularity(8);

            popularityTracker.decreasePopularity(8);

            Console.WriteLine($"Most popular :{popularityTracker.mostPopular()}");        // returns 7

            popularityTracker.decreasePopularity(7);

            popularityTracker.decreasePopularity(7);

            popularityTracker.decreasePopularity(8);
        }
        
        // approach: 1
        // store the association between the article_id and popularity_score and then sort the map by desc values
        Dictionary<int, int> PopularityMap= new();
        //

        public ArticlePopularityMap()
        {
            
        }

        public void increasePopularity(int contentId)
        {
            if (PopularityMap.ContainsKey(contentId))
            {
                PopularityMap[contentId]++;
            }
            else
            {
                PopularityMap.Add(contentId, 1);
            }
        }

        public int mostPopular() 
        {
            if (PopularityMap.Count > 0)
            {
                var mostPopular = PopularityMap.OrderByDescending(kvp => kvp.Value).ToList().ElementAt(0);
                if (mostPopular.Value > 0)
                    return mostPopular.Key;
                else
                    return -1;
            }
            else
            {
                return - 1;
            }

        }

        public void decreasePopularity(int contentId)
        {
            if (PopularityMap.ContainsKey(contentId) && PopularityMap[contentId] > 0)
            {
                PopularityMap[contentId]--;
            }
        }

    }
}
