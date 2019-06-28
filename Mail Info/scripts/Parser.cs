using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Mail_Info.scripts
{
    /*
    struct MailInfo
    {
        public string Mail  { get; set; }
        public string Password  { get; set; }
        public string Date { get; set; }
        public int Line { get; set; }
    }
    */

    class Parser
    {
        static public List<int> ParseFile(string path)
        {
            string[] file = File.ReadAllLines(path);

            List<int> mailIndexes = new List<int>();

            for (int i = 0; i < file.Length; i++)
			{

			    string[] firstSplit = file[i].Split('|');
                string[] daSplit = file[i].Split('|');

                string[] accountSplit = firstSplit[0].Split(':');
                string[] dateSplit = firstSplit[1].Split(':');

                string date = dateSplit[1].Substring(1);
                date = date.Split(' ')[0];

                DateTime dateLimit = new DateTime(2019, 7, 1);
                DateTime dateTime = DateTime.Parse(date);

                if (dateTime >= dateLimit)
                {
                    mailIndexes.Add(i + 1);   
                }
			}

            return mailIndexes;
        }
    }
}
