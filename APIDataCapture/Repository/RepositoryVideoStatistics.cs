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
    public class RepositoryVideoStatistics
    {
        SqlConnection cnOLTPAPI = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlOLTP"].ConnectionString);

        public void InsertVideo(VideoStatistics videoStatistics)
        {
            SqlCommand cmd = new SqlCommand("insert_statistics", cnOLTPAPI);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@captureDate", videoStatistics.CaptureDate);
            cmd.Parameters.AddWithValue("@videoId", videoStatistics.VideoId);
            cmd.Parameters.AddWithValue("@view", videoStatistics.ViewCount);
            cmd.Parameters.AddWithValue("@likes", videoStatistics.Likes);
            cmd.Parameters.AddWithValue("@dislikes", videoStatistics.Dislikes);
            cmd.Parameters.AddWithValue("@comments", videoStatistics.Comments);
            cnOLTPAPI.Open();
            cmd.ExecuteNonQuery();
            cnOLTPAPI.Close();
        }

        public DataTable ListVideoStatistics()
        {
            SqlCommand cmd = new SqlCommand("list_statistics", cnOLTPAPI);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtVideoStatistics = new DataTable();
            da.Fill(dtVideoStatistics);
            return dtVideoStatistics;
        }


    }
}
