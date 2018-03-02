using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml;
using System.IO;

namespace CheckDCP
{
    class PKLParser
    {
        #region Неиспользуемые методы

        ///// <summary>
        ///// Получение списка информации о файле из PKL-файла
        ///// </summary>
        ///// <param name="fileName">Адрес PKL-файла</param>
        ///// <returns>Список информации о файлах, полученный из PKL-файла</returns>
        //static public List<Data> oldCode (string fileName)
        //{
        //    // Временная переменная для хранения информации о файле из PKL-файла для передачи в базовый класс
        //    List<Data> fileListOfPKL = new List<Data>();

        //    // Переменные для временного хранения информации о файле
        //    Data fileInfo = new Data();

        //    // Временная переменная для хранения AnnotationText
        //    string pklAnnotationText = null;

        //    // Инициализация Xml-документа
        //    XmlDocument xDoc = new XmlDocument();

        //    if (File.Exists(fileName))
        //    {
        //        xDoc.Load(fileName);

        //        XmlElement xRoot = xDoc.DocumentElement;

        //        // Перебор в корневом теге
        //        foreach (XmlNode xNode in xRoot)
        //        {
        //            if (xNode.Name == "AssetList")
        //            {
        //                // Перебор в тегах AssetList
        //                foreach (XmlNode assets in xNode.ChildNodes)
        //                {
        //                    // Перебор в тегах Asset
        //                    foreach (XmlNode data in assets.ChildNodes)
        //                    {
        //                        switch (data.Name)
        //                        {
        //                            case "Id":
        //                                fileInfo.PKLId = data.InnerText;
        //                                break;
        //                            case "Hash":
        //                                fileInfo.HashPkl = data.InnerText;
        //                                break;
        //                            case "Size":
        //                                fileInfo.Size = data.InnerText;
        //                                break;
        //                        }
        //                    }
        //                    fileInfo.PKLAnnotationText = pklAnnotationText;

        //                    // Добавление временных переменных во временные данные 
        //                    fileListOfPKL.Add(fileInfo);

        //                    fileInfo = new Data();
        //                }
        //            }
        //        }
        //    }

        //    return fileListOfPKL;
        //}
        //static public List<Data> ParserPklFromAssetmap(List<Data> inList)
        //{
        //    //List<Data> temp = null;
        //    List<string> allPkl = GetPkl(inList);
        //    foreach(string s in allPkl)
        //    {
        //        GetInfoFromPkl(s, inList);
        //    }




        //    return inList;
        //}

        ///// <summary>
        ///// возвращает адресс ПКЛ файла
        ///// </summary>
        ///// <param name="files"></param>
        ///// <returns></returns>
        //static public List<string> GetPkl(List<Data> files)
        //{
        //    List<string> pklAddress = new List<string>();

        //    foreach (Data d in files)
        //    {
        //        if (d.ASSETIsPackingList)
        //        {
        //            pklAddress.Add(d.FileLocation);
        //        }
        //    }
        //    return pklAddress;
        //}        ///// <summary>
        ///// Получение списка информации о файле из PKL-файла
        ///// </summary>
        ///// <param name="fileName">Адрес PKL-файла</param>
        ///// <returns>Список информации о файлах, полученный из PKL-файла</returns>
        //static public List<Data> GetInfoFromPkl(string fileName,List<Data> list)
        //{
        //    // Временная переменная для хранения информации о файле из PKL-файла для передачи в базовый класс
        //    List<Data> tempList = new List<Data>();

        //    // Переменные для временного хранения информации о файле
        //    Data fileInfo = new Data();

        //    // Временная переменная для хранения AnnotationText
        //    string pklAnnotationText = null;

        //    // Инициализация Xml-документа
        //    XmlDocument xDoc = new XmlDocument();

        //    if (File.Exists(fileName))
        //    {
        //        xDoc.Load(fileName);

        //        XmlElement xRoot = xDoc.DocumentElement;

        //        // Перебор в корневом теге
        //        foreach (XmlNode xNode in xRoot)
        //        {
        //            if (xNode.Name == "AssetList")
        //            {
        //                // Перебор в тегах AssetList
        //                foreach (XmlNode assets in xNode.ChildNodes)
        //                {
        //                    // Перебор в тегах Asset
        //                    foreach (XmlNode data in assets.ChildNodes)
        //                    {
        //                        switch (data.Name)
        //                        {
        //                            case "Id":
        //                                fileInfo.PKLId = data.InnerText;
        //                                break;
        //                            case "Hash":
        //                                fileInfo.HashPkl = data.InnerText;
        //                                break;
        //                            case "Size":
        //                                fileInfo.Size = data.InnerText;
        //                                break;
        //                            case "OriginalFileName":
        //                                fileInfo.Name = data.InnerText;
        //                                break;
        //                        }
        //                    }
        //                    fileInfo.PKLAnnotationText = pklAnnotationText;

        //                    // Добавление временных переменных во временные данные 
        //                    tempList.Add(fileInfo);


        //                    fileInfo = new Data();
        //                }
        //            }
        //        }

        //    }

        //    foreach (Data d in tempList)
        //    {
        //        foreach (Data s in list)
        //        {
        //            if (d.PKLId == s.Id)
        //            {
        //                s.HashPkl = d.HashPkl;
        //                s.Name = d.Name;


        //            }
        //        }
        //    }
        //    return list;
        //}

        ///// <summary>
        ///// Получение имени контента
        ///// </summary>
        ///// <param name="fileName">Адрес PKL-файла</param>
        ///// <returns>Название контента</returns>
        //static public string GetAnnotationTextOfPKL(string fileName)
        //{
        //    string annotationText = null;

        //    XmlDocument xDoc = new XmlDocument();

        //    xDoc.Load(fileName);

        //    XmlElement xRoot = xDoc.DocumentElement;

        //    // Перебор в корневом теге
        //    foreach (XmlNode xNode in xRoot)
        //    {
        //        if (xNode.Name == "AnnotationText")
        //        {
        //            annotationText = xNode.InnerText;
        //        }
        //    }

        //    return annotationText;
        //}
        #endregion

        /// <summary>
        /// Получение списка информации о файле из PKL-файла
        /// </summary>
        /// <param name="fileName">Адрес PKL-файла</param>
        /// <returns>Список информации о файлах, полученный из PKL-файла</returns>
        static public List<Data> GetASSETOfPKL(string fileName)
        {
            // Временная переменная для хранения информации о файле из PKL-файла для передачи в базовый класс
            List<Data> fileListOfPKL = new List<Data>();

            // Переменные для временного хранения информации о файле
            Data fileInfo = new Data();

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
                        // Перебор в тегах Asset
                        foreach (XmlNode data in assets.ChildNodes)
                        {
                            switch (data.Name)
                            {
                                case "Id":
                                    fileInfo.PKLASSETId = data.InnerText;
                                    break;
                                case "Hash":
                                    fileInfo.PKLASSETHash = data.InnerText;
                                    break;
                                case "Size":
                                    fileInfo.PKLASSETSize = data.InnerText;
                                    break;
                            }
                        }

                        // Добавление временных переменных во временные данные 
                        fileListOfPKL.Add(fileInfo);

                        fileInfo = new Data();
                    }
                }
            }

            return fileListOfPKL;
        }
    }
}

