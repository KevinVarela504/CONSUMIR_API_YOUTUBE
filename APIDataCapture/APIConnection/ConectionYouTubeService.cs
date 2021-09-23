using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;

namespace APIConnection
{
    public class ConectionYouTubeService
    {       
         
        public YouTubeService GetYouTubeServiceConection(String apiKey)
        {
            var youtubeAPI = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey
            });
            return youtubeAPI;
        } 
        

        
    }
}
