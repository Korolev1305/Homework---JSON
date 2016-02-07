using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace JSON2
{
    public partial class Form1 : Form
    {
        public  IEnumerable<Players> CLE ;
        public  IEnumerable<Players> LAL ;
        public int scoreOfCLE;
        public int scoreOfLAL;
        public Form1()
        {
            InitializeComponent();
            SolveProblem();
        }

        public void SolveProblem() 
        {
             int ch;

        HttpWebRequest req = (HttpWebRequest)
            WebRequest.Create("http://api.lod-misis.ru/testassignment");
        HttpWebResponse resp = (HttpWebResponse)
            req.GetResponse();
        Stream istrm = resp.GetResponseStream();
        string response = null;
            for (int i = 1; ; i++)
            {
                ch = istrm.ReadByte();
                if (ch == -1) break;
                response += ((char)ch);
            }


            resp.Close();
            string json = response;
            List<Players> newPlayers = Deserialization.DeserializeJSon<List<Players>>(json);
            var notSortedLAL = new List<Players>();
            var notSortedCLE = new List<Players>();
            scoreOfCLE = 0;
            scoreOfLAL = 0;
            foreach (var player in newPlayers)
            {
                if (player.Team == "LAL")
                {
                    notSortedLAL.Add(player);
                    scoreOfLAL += player.Score;
                }
                else
                {
                    notSortedCLE.Add(player);
                    scoreOfCLE += player.Score;
                }
                LAL = notSortedLAL.OrderByDescending(players => players.Score);
                CLE = notSortedCLE.OrderByDescending(players => players.Score);
                
            }
            richTextBox1.Text += "Cleveland Cavaliers" +' '+ scoreOfCLE+'\n';
            richTextBox2.Text += "Los Angeles Lakers" + ' ' +scoreOfLAL+'\n';
            foreach (var players in CLE)
            {
                richTextBox1.Text += players.PlayerName + ' '+players.Score + '\n';
            }
            foreach (var players in LAL)
            {
                richTextBox2.Text += players.PlayerName +' ' + players.Score + '\n';
            }
        }
        
    }
}
