using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.YouTube.v3;
using Model;

namespace APIConnection
{
    public class APIStatistics
    {
        VideoStatistics videoStatistics = new VideoStatistics();
        YouTubeService conctionYouTubeService = new YouTubeService();
        ConectionYouTubeService conectionYouTubeService = new ConectionYouTubeService();

        public VideoStatistics GetVideoStatistics(String apiKey, String videoId)
        {

            conctionYouTubeService = conectionYouTubeService.GetYouTubeServiceConection(apiKey);

            var searchVideo = conctionYouTubeService.Videos.List("statistics");
            searchVideo.Id = videoId;
            var getStatisticsVideo = searchVideo.Execute();
           
            videoStatistics.CaptureDate = DateTime.Now.Date;
            videoStatistics.VideoId = videoId;
            videoStatistics.ViewCount= Convert.ToInt32(getStatisticsVideo.Items[0].Statistics.ViewCount);
            videoStatistics.Likes = Convert.ToInt32(getStatisticsVideo.Items[0].Statistics.LikeCount);
            videoStatistics.Dislikes = Convert.ToInt32(getStatisticsVideo.Items[0].Statistics.DislikeCount);
            videoStatistics.Comments = Convert.ToInt32(getStatisticsVideo.Items[0].Statistics.CommentCount);

            return videoStatistics;
        }
    }
}
