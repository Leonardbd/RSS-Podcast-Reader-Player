﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel.Syndication;
using System.Xml;

namespace BLL.Services
{
    public static class RSSReader
    {
        public static SyndicationFeed Reader(string url)
        {
            SyndicationFeed feed = null;
            try
            {
                

                using (XmlReader xr = XmlReader.Create(url))
                {
                    feed = SyndicationFeed.Load(xr);
                }
            }
                
            
            
            catch (Exception e)
            {

                
            }
            

            return feed;
        }

    }
}
