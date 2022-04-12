
using System.Diagnostics;
using System.Xml;

// Project: Project 2
// Author: Roberto Amaral
//  Date: April 11, 2022 

namespace Project2
{
    public class XMLExtension
    {
        //writes xml file
        public void xmlwriter(int sno, List<String> Infix, List<String> Prefix, List<String> Postfix, List<double> res, List<bool> match)
        {
            string filename = "Project 2_INFO_5101XML.xml";
            XmlTextWriter xmlwriter = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
            xmlwriter.Formatting = Formatting.Indented;
            xmlwriter.WriteStartDocument();
            xmlwriter.WriteStartElement("root");
            for (int i = 0; i < Infix.Count - 1; i++)
            {
                xmlwriter.WriteStartElement("elements");
                xmlwriter.WriteElementString("Sno", Convert.ToString(i + 1));
                xmlwriter.WriteElementString("infix", Infix[i + 1]);
                xmlwriter.WriteElementString("prefix", Prefix[i]);
                xmlwriter.WriteElementString("postfix", Postfix[i]);
                xmlwriter.WriteElementString("evaluation", Convert.ToString(res[i]));
                xmlwriter.WriteElementString("comperision", Convert.ToString(match[i]));
                xmlwriter.WriteEndElement();
            }
            xmlwriter.WriteEndElement();
            xmlwriter.WriteEndDocument();
            xmlwriter.Flush();
            xmlwriter.Close();

            var p = new Process();
            p.StartInfo.FileName = filename;
            p.Start();
        }
    }
}
