using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml;

namespace CheckDCP
{
    class PklParser
    {

        static public List<Data> GetArrayFromPkl(string fileName)
        {
            XmlTextReader reader = new XmlTextReader(fileName);

            List<Data> myListName = new List<Data>();
            //ArrayList myListHash = new ArrayList();

            string OFN = "";
            string H = "";

            while (reader.Read())
            {



                if (reader.IsStartElement("OriginalFileName"))
                {
                    //Console.WriteLine(reader.ReadString().Remove(0, 9));
                    //Count++;
                    //myListName.Add(reader.ReadString());
                    OFN = reader.ReadString();
                }
                if (reader.IsStartElement("Hash"))
                {
                    //Console.WriteLine(reader.ReadString().Remove(0, 9));
                    //Count++;
                    // myListHash.Add(reader.ReadString());
                    H = reader.ReadString();
                }
                if (OFN != "" & H != "")
                {
                    myListName.Add(new Data(OFN, H));

                    OFN = "";
                    H = "";
                }

            }
            return myListName;
        }
    }
}

