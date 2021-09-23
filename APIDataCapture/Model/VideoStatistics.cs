using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VideoStatistics
    {
        public DateTime CaptureDate { get;set;}

        public String VideoId  { get;set;}

        public int ViewCount { get; set; }

        public int Likes { get;set;}

        public int Dislikes { get;set;}

        public int Comments { get;set;} 
    }
}
