using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = "localhost";
            string elementKey = "testKeyRedis";

            using (RedisClient redisClient = new RedisClient(host))
            {
                if (redisClient.Get<string>(elementKey) == null)
                {
                    // adding delay to see the difference
                    Thread.Sleep(2000);
                    // save value in cache
                    redisClient.Set(elementKey, "default value");
                }

                //change the value
                redisClient.Set(elementKey, "fuck you value");

                // get value from the cache by key
                string message = "Item value is: " + redisClient.Get<string>(elementKey);

                Console.WriteLine(message);
                Console.ReadLine();
            }
        }
    }
}
