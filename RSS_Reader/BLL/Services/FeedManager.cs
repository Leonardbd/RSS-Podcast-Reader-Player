﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;
using DAL;

namespace BLL
{
    public static class FeedManager
    {
        public static List<Feed> LoadFeeds()
        {
            List<Feed> feeds = Serializer.DeSerialize<List<Feed>>();
            return feeds;
        }

        public static void SaveFeeds(List<Feed> feeds)
        {
            Serializer.Serialize<List<Feed>>(feeds);
        }

        private static string GetTitle(string url)
        {
            SyndicationFeed feed = RSSReader.Reader(url);
            return feed.Title.Text;
        }

        private static List<Episode> GetEpisodes(string url)
        {
            SyndicationFeed feed = RSSReader.Reader(url);
            List<Episode> episodes = new List<Episode>();
            int episodeCounter = 1;

            foreach (var item in feed.Items.ToList())
            {
                episodes.Add(new Episode(episodeCounter, item.Title.Text, item.Summary.Text));
                episodeCounter++;
            }

            return episodes;
        }

        public static Feed CreateFeed(string url)
        {
            int number = GetEpisodes(url).Count();
            string name = GetTitle(url);
            List<Episode> episodes = GetEpisodes(url);

            return new Feed(name, number, episodes);
        }
    }
}