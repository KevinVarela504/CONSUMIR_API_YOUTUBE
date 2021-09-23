using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using Google.Apis.YouTube.v3;
using Model;

namespace APIConnection
{
    public class APIVideos
    {
        
        String url = "https://www.youtube.com/watch?v=";
        YouTubeService conctionYouTubeService = new YouTubeService();
        ConectionYouTubeService conectionYouTubeService = new ConectionYouTubeService();

        public List<Videos> GetVideos(String apiKey, String channelId, int index, int requests)
        {
            List<Videos> alVideos = new List<Videos>();
            conctionYouTubeService = conectionYouTubeService.GetYouTubeServiceConection(apiKey);
           String nextpagetoken = " ";

            for (int i=0;i< index; i++)
            {
                var searchChannel = conctionYouTubeService.Search.List("snippet");
                searchChannel.ChannelId = channelId;
                searchChannel.MaxResults = requests;
                searchChannel.PageToken = nextpagetoken;
                var getInfoChannel = searchChannel.Execute();

                foreach (var getVideo in getInfoChannel.Items)
                {
                    Videos video = new Videos();

                    video.VideoId = getVideo.Id.VideoId;
                    video.ChannelId = channelId;
                    video.VideoName = getVideo.Snippet.Title.ToString();
                    video.VideoDescription = getVideo.Snippet.Description.ToString();
                    video.PublicationDate = Convert.ToDateTime(getVideo.Snippet.PublishedAtRaw);
                    video.Url = url + video.VideoId;
                    alVideos.Add(video);
                }
                nextpagetoken = getInfoChannel.NextPageToken;
            }
            

            return alVideos;
        }

    }
}
