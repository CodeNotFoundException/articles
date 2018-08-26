using CustomConstructorSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConstructorSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                if (!context.Tweets.Any())
                {
                    var tweet = Tweet.Create(
                        42,
                        "Lorem ipsum dolor sit amet, ipsum noster efficiendi te sit. Mea an modus vitae mediocritatem, usu ferri vocent dissentiunt at. Pro in scripta accusamus intellegam, quo eleifend contentiones id. Eu brute periculis vis, ei quas suavitate eam, integre eruditi ad qui."
                    );

                    context.Tweets.Add(tweet);
                    context.SaveChanges();
                }
            }

            using (var context = new MyDbContext())
            {
                var tweets = context.Tweets.ToList();

                foreach(var tweet in tweets)
                {
                    Console.WriteLine($"Id: {tweet.Id}");
                    Console.WriteLine($"User Id: {tweet.UserId}");
                    Console.WriteLine($"Content: {tweet.Content}");
                    Console.WriteLine("======");
                }
            }

            Console.ReadKey();
        }
    }
}
