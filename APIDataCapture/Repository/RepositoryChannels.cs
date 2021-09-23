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
    public class RepositoryChannels
    {
        SqlConnection cnOLTPAPI = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlOLTP"].ConnectionString);

        public void InsertChannel(Channels channel)
        {
            SqlCommand cmd = new SqlCommand("insert_channel", cnOLTPAPI);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@channelId", channel.ChannelId);
            cmd.Parameters.AddWithValue("@channelTitle", channel.ChannelTitle);
            cmd.Parameters.AddWithValue("@channelDescription", channel.ChannelsDescription);
            cmd.Parameters.AddWithValue("@publishedAtRaw", channel.PublishedAtRaw);
            cnOLTPAPI.Open();
            cmd.ExecuteNonQuery();
            cnOLTPAPI.Close();
        }

        public DataTable ListChannel()
        {
            SqlCommand cmd = new SqlCommand("list_channels", cnOLTPAPI);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtChannel = new DataTable();
            da.Fill(dtChannel);
            return dtChannel;
        }
    }
}
