using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using Model;

namespace Repository
{
    public class RepositoryVideos
    {
        SqlConnection cnOLTPAPI = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlOLTP"].ConnectionString);

        public void InsertVideo(Videos video)
        {
            SqlCommand cmd = new SqlCommand("insert_videos", cnOLTPAPI);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@videoId", video.VideoId);
            cmd.Parameters.AddWithValue("@channelId", video.ChannelId);
            cmd.Parameters.AddWithValue("@videoName", video.VideoName);
            cmd.Parameters.AddWithValue("@videoDescription", video.VideoDescription);
            cmd.Parameters.AddWithValue("@publicationDate", video.PublicationDate);
            cmd.Parameters.AddWithValue("@url", video.Url);
            cnOLTPAPI.Open();
            cmd.ExecuteNonQuery();
            cnOLTPAPI.Close();
        }

        public DataTable ListVideos()
        {
            SqlCommand cmd = new SqlCommand("list_videos", cnOLTPAPI);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtVideos = new DataTable();
            da.Fill(dtVideos);
            return dtVideos;
        }

        public DataTable SearchChannelVideo(Channels channel)
        {
            SqlCommand cmd = new SqlCommand("search_channel_video", cnOLTPAPI);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@channelId", channel.ChannelId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtSearchChannelVideo = new DataTable();
            da.Fill(dtSearchChannelVideo);
            return dtSearchChannelVideo;
        }
    }
}
