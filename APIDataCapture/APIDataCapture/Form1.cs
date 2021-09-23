using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Service;

namespace APIDataCapture
{
    public partial class Form1 : Form
    {
        ServiceChannels serviceChannels = new ServiceChannels();
        ServiceVideos serviceVideos = new ServiceVideos();
        ServiceVideoStatistics serviceVideoStatistics = new ServiceVideoStatistics();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                         
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            serviceChannels.InsertChannel(textBox2.Text,textBox1.Text);
            serviceVideos.InsertVideo(textBox2.Text, textBox1.Text,(int)numericUpDown2.Value,(int)numericUpDown1.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serviceVideoStatistics.CaptureVideoStatistics(textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = serviceVideoStatistics.ListVideoStatistic();
            //dataGridView1.DataSource = serviceVideos.ListVideo();
        }
    }
}
