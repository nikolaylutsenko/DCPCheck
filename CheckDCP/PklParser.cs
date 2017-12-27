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
            // Временная переменная для хранения информации о файле из PKL-файла для передачи в базовый класс
            List<Data> fileListOfPKL = new List<Data>();
            
            // Инициализация Xml-документа
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(fileName);

            XmlElement xRoot = xDoc.DocumentElement;

            // Перебор в корневом теге
            foreach (XmlNode xNode in xRoot)
            {
                if (xNode.Name == "AssetList")
                {
                    // Перебор в тегах AssetList
                    foreach (XmlNode assets in xNode.ChildNodes)
                    {
                        // Переменные для временного хранения информации о файле
                        Data fileInfo = new Data();

                        // Перебор в тегах Asset
                        foreach (XmlNode date in assets.ChildNodes)
                        {
                            if (date.Name == "Id")
                            {
                                fileInfo.Id = date.InnerText;
                            }
                            if (date.Name == "AnnotationText")
                            {
                                fileInfo.AnnotationText = date.InnerText;
                            }
                            if (date.Name == "Hash")
                            {
                                fileInfo.Hash = date.InnerText;
                            }
                            if (date.Name == "Size")
                            {
                                fileInfo.Size = date.InnerText;
                            }
                            if (date.Name == "OriginalFileName")
                            {
                                fileInfo.OriginalFileName = date.InnerText;
                            }
                        }

                        // Добавление временных переменных во временные данные 
                        fileListOfPKL.Add(fileInfo);
                    }
                }
            }

            return fileListOfPKL;



            //XmlTextReader reader = new XmlTextReader(fileName);

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
        }
    }
}

