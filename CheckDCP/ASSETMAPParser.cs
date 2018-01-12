using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace CheckDCP
{
    class ASSETMAPParser
    {
        /// <summary>
        /// Получение списка информации о файле из ASSETMAP
        /// </summary>
        /// <param name="fileAssetmap">Адрес файла ASSETMAP</param>
        /// <returns>Список информации о файлах, полученный из ASSETMAP</returns>
        static public List<Data> GetInfoOfASSETMAP(string fileAssetmap)
        {
            // Хранение списка получаемых данных из ASSETMAP
            List<Data> infoOfASSETMAP = new List<Data>();
            // Хранение текущих данных
            Data assetmapData = new Data();
            // Временная переменная для хранения Id файла ASSETMAP
            string assetmapId = null;
            // Временная переменная для хранения адреса папки с файлом ASSETMAP
            string path = Path.GetDirectoryName(fileAssetmap);

            string pattern = @"^CPL";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileAssetmap);

            XmlElement xmlRoot = xmlDoc.DocumentElement;

            // Перебор в корневом теге
            foreach (XmlNode xmlNode in xmlRoot)
            {
                // Получение Id файла ASSETMAP
                if (xmlNode.Name == "Id")
                {
                    assetmapId = xmlNode.InnerText;
                }

                if (xmlNode.Name == "AssetList")
                {
                    // Перебор списка файлов
                    foreach (XmlNode assets in xmlNode.ChildNodes)
                    {
                        // Перебор и получение списка информации о файле
                        foreach (XmlNode data in assets.ChildNodes)
                        {
                            switch (data.Name)
                            {
                                case "Id":
                                    assetmapData.ASSETId = data.InnerText;
                                    break;
                                case "PackingList":
                                    assetmapData.ASSETIsPackingList = true;
                                    break;
                                case "ChunkList":
                                    foreach (XmlNode chunk in data.FirstChild)
                                    {
                                        switch (chunk.Name)
                                        {
                                            case "Length":
                                                assetmapData.ASSETLength = chunk.InnerText;
                                                break;
                                            case "Path":
                                                assetmapData.ASSETPath = path + "\\" + chunk.InnerText;
                                                if (Regex.IsMatch(chunk.InnerText, pattern))
                                                {
                                                    assetmapData.ASSETIsCompositionPlaylist = true;
                                                }
                                                break;
                                        }
                                    }
                                    break;
                            }
                        }

                        // Запись глобальных данных из ASSETMAP
                        assetmapData.ASSETMAPId = assetmapId;

                        // Добавление временных данных в общий список
                        infoOfASSETMAP.Add(assetmapData);

                        // Выделение памяти для новых временных данных
                        assetmapData = new Data();
                    }
                }
            }

            return infoOfASSETMAP;
        }
    }
}
