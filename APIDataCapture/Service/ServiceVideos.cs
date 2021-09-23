using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using System.Data;
using APIConnection;
using Model;
using Repository;

namespace Service
{
    public class ServiceVideos
    {
        APIVideos apiVideos = new APIVideos();
        RepositoryVideos repositoryVideos = new RepositoryVideos();

        public void InsertVideo(String apiKey, String channelId, int index, int requests)
        {
            List<Videos> getVideos = apiVideos.GetVideos(apiKey, channelId, index, requests);

            foreach (Videos video in getVideos)
            {
                if (!(video.VideoId is null))
                {
                    repositoryVideos.InsertVideo(video);
                }                
            }

        }

        public DataTable ListVideo()
        {
            return repositoryVideos.ListVideos();
        } 

    }
}
