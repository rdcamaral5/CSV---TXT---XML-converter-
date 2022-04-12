// Project: Project 2
// Author: Roberto Amaral
//  Date: April 11, 2022 

namespace Project2
{
    public class CSVFile
    {
        //read CSV file
        public List<String> CSV_Serialized()
        {
            //list for infixes
            List<string> Infix = new List<string>();
            using (var reader = new StreamReader("Project 2_INFO_5101.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var file = reader.ReadLine();
                    var values = file.Split(',');
                    Infix.Add(values[1]);
                }
            }

            return Infix;
        }
    }
}
