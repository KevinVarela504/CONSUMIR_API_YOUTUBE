using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using APIConnection;
using Model;
using Repository;

namespace Service
{
    public class ServiceVideoStatistics
    {
        ServiceVideos serviceVideos = new ServiceVideos();
        RepositoryVideoStatistics repositoryVideoStatistics = new RepositoryVideoStatistics();
        VideoStatistics videoStatistics = new VideoStatistics();
        APIStatistics apiStatistics = new APIStatistics();

        public void CaptureVideoStatistics(String apiKey)
        {
            DataTable dtVideos = serviceVideos.ListVideo();

            foreach (DataRow row in dtVideos.Rows)
            {
                VideoStatistics videoStatistics = new VideoStatistics();                
                videoStatistics = apiStatistics.GetVideoStatistics(apiKey, row["VideoId"].ToString());
                repositoryVideoStatistics.InsertVideo(videoStatistics);
            }
        }

        public DataTable ListVideoStatistic()
        {
            return repositoryVideoStatistics.ListVideoStatistics();
        }
    }
}
