using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using APIConnection;
using Model;
using Repository;

namespace Service
{
    public class ServiceChannels
    {
        RepositoryChannels repositoryChannel = new RepositoryChannels();
        APIChannels apiChannel = new APIChannels();

        public void InsertChannel(String apiKey,String channelId)
        {
            repositoryChannel.InsertChannel(apiChannel.GetChannel(apiKey, channelId));
        }

    }
}
