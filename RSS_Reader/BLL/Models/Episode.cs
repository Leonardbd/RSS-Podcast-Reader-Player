using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Episode : IEntity
    {
        public int EpisodeNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Url { get; set; }
        public Episode(int episodeNumber, string name, string description, string url)
        {
            EpisodeNumber = episodeNumber;
            Name = name;
            Description = description;
            Url = url;

        }
        public Episode()
        {

        }
    }
}
