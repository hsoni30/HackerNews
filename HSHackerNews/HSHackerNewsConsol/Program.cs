using System;
using System.Configuration;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace HSHackerNewsConsol
{
    class Program
    {
        static void Main(string[] args)
        {                        
            string HackerNewsJSONURL = ConfigurationManager.AppSettings["HackerNewsJSONURL"];
            long minPoints = 1;
            long minComments = 1;
            long maxNumberofPosts = 100;

            do
            {
                long numberofPosts = 0;
                Console.WriteLine("_______________________");
                do
                {                    
                    Console.WriteLine("Please provide Numbers of hackernews posts to print(between 0 to 100) Or 'q' to exit");
                    string input = Console.ReadLine();
                    if (input == "q") return;
                    long.TryParse(input, out numberofPosts);
                } while (numberofPosts <= 0 || numberofPosts > maxNumberofPosts);
                
                var urlJSON = string.Format(HackerNewsJSONURL + "?points={0}&comments={1}&count={2}", minPoints, minComments, numberofPosts);

                var json_data = string.Empty;

                HackerNewsData data;
                using (var w = new WebClient())
                {
                    try
                    {
                        json_data = w.DownloadString(urlJSON);
                    }
                    catch (Exception) { }
                    // if string with JSON data is not empty, deserialize it to class and return its instance 
                    data = !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<HackerNewsData>(json_data) : new HackerNewsData();
                }
                Console.WriteLine("");
                StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
                standardOutput.AutoFlush = true;
                standardOutput.Write(JsonConvert.SerializeObject(data.Items));               
                Console.SetOut(standardOutput);
                Console.WriteLine("");
            } while (true);
        }
    }
}
