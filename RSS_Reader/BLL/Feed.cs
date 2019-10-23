﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Feed
    {
        public string Name { get; set; }
        public int NumberOfEpisodes { get; set; }

        public Feed(string PodcastName, int numberOfEpisodes)
        {
            Name = PodcastName;
            NumberOfEpisodes = numberOfEpisodes;
            
        }

    }
}
