using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;
using DAL;
using BLL.Models;
using BLL.Validation;
using System.Xml.Linq;
using System.Diagnostics;

namespace BLL.Services
{
    public static class FeedManager
    {
        public static List<Feed> LoadFeeds()
        {
            return Serializer.Deserialize<List<Feed>>(Environment.CurrentDirectory + "\\feeds.xml");
        }

        public static void SaveFeeds(List<Feed> feeds)
        {
            Serializer.Serialize<List<Feed>>(feeds, Environment.CurrentDirectory + "\\feeds.xml");
        }

        private static string GetTitle(string url)
        {
            SyndicationFeed feed = RSSReader.Reader(url);

            if (Validator.IsNotNull(feed))
            {
                
                return feed.Title.Text;
            }

            return null;
        }

               
            
            //var url = document.Root.Element("channel").Element("item").Element("enclosure").Attribute("url").Value;
                              
                              
                              
                             
       

        public static List<Episode> GetEpisodes(string url)
        {
            SyndicationFeed feed = RSSReader.Reader(url);
            List<Episode> episodes = new List<Episode>();

            var listURL = new List<string>();

            var document = XDocument.Load(url);

            foreach (var item in document.Descendants("item"))
            {
                var namnURL = item.Name.ToString();
                var urln = item.Element("enclosure").Attribute("url").Value;
                listURL.Add(urln);
            }

            if (Validator.IsNotNull(feed))
            {
                int episodeCounter = feed.Items.ToList().Count;

                int i = 0;

                foreach (var item in feed.Items.ToList())
                {
                    episodes.Add(new Episode(episodeCounter, item.Title.Text, item.Summary.Text, listURL[i]));
                    episodeCounter--;
                    i++;
                }

            }
            return episodes;
        }

        public static Feed CreateFeed(string url, Category category, UpdateFrequency frequency)
        {
            string name = GetTitle(url);

            if (Validator.IsNotNull(name))
            {
                int number = GetEpisodes(url).Count();
                List<Episode> episodes = GetEpisodes(url);
                return new Feed(name, number, episodes, category, url, frequency);
            }
            return null;
        }
    }
}
