using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Username_Scraper_Lightweight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool isRunning = false;
        private void btn_startScrape_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                ThreadPool.QueueUserWorkItem(ScrapePage, new State());
            }
        }

        public class State
        {
            enum WorkState
            {
               Working = 0,
               Failed = 1,
               Paused = 2,
               Aborted = 3,
            };

            public class User
            {
                public string Username { get; set; }
            }
        }

        public void ScrapePage(object obj)
        {
            string url = $"https://api.mojang.com/users/profiles/minecraft/TAKOYAKI007?at=140000000";
            WebClient wc = new WebClient();
            //wc.Proxy = new WebProxy(host, port);
            var page = wc.DownloadString(url);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(page);
            Console.WriteLine("test");
        }
    }
}
