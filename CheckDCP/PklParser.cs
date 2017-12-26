using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml;

namespace CheckDCP
{
    class PKLParser
    {
        static public List<Data> GetArrayFromPkl(string fileName)
        {
            //XmlTextReader reader = new XmlTextReader(fileName);


            List<Data> fileListOfPKL = new List<Data>();

            string id = "";
            string ofn = "";
            string h = "";
            string at = "";
            string s = "";


            //while (reader.Read())
            //{
            //    if (reader.IsStartElement("AnnotationText"))
            //    {
            //        at = reader.ReadString();
            //    }
            //    if (reader.IsStartElement("Hash"))
            //    {
            //        h = reader.ReadString();
            //    }
            //    if (reader.IsStartElement("Size"))
            //    {
            //        s = reader.ReadString();
            //    }
            //    if (reader.IsStartElement("OriginalFileName"))
            //    {
            //        ofn = reader.ReadString();
            //    }
            //    if (h != "")
            //    {
            //        fileListOfPKL.Add(new Data(ofn, h, at, s));

            //        ofn = "";
            //        h = "";
            //        at = "";
            //        s = "";
            //    }

            //}


            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(fileName);

            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xNode in xRoot)
            {
                if (xNode.Name == "AssetList")
                {
                    foreach (XmlNode assets in xNode.ChildNodes)
                    {
                        foreach (XmlNode date in assets.ChildNodes)
                        {
                            if (date.Name == "Id")
                            {
                                id = date.InnerText;
                            }
                            if (date.Name == "AnnotationText")
                            {
                                at = date.InnerText;
                            }
                            if (date.Name == "Hash")
                            {
                                h = date.InnerText;
                            }
                            if (date.Name == "Size")
                            {
                                s = date.InnerText;
                            }
                            if (date.Name == "OriginalFileName")
                            {
                                ofn = date.InnerText;
                            }
                        }

                        fileListOfPKL.Add(new Data(id, ofn, h, at, s));

                        id = "";
                        ofn = "";
                        h = "";
                        at = "";
                        s = "";
                    }
                }
            }



            return fileListOfPKL;
        }
    }
}

