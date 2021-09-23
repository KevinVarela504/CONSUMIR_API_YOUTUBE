using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.YouTube.v3;
using Model;

namespace APIConnection
{
    public class APIChannels
    {
        Channels channel = new Channels();
        YouTubeService conctionYouTubeService = new YouTubeService();
        ConectionYouTubeService conectionYouTubeService = new ConectionYouTubeService();

        public Channels GetChannel(String apiKey, String channelId)
        {
            conctionYouTubeService = conectionYouTubeService.GetYouTubeServiceConection(apiKey);

            var searchChannel = conctionYouTubeService.Channels.List("snippet");
            searchChannel.Id = channelId;
            var getInfoChannel = searchChannel.Execute();

            channel.ChannelId = getInfoChannel.Items[0].Id.ToString();
            channel.ChannelTitle = getInfoChannel.Items[0].Snippet.Title.ToString();
            channel.ChannelsDescription = getInfoChannel.Items[0].Snippet.Description.ToString();
            channel.PublishedAtRaw = Convert.ToDateTime(getInfoChannel.Items[0].Snippet.PublishedAtRaw);

            return channel;

        }  
    }
}
