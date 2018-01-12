using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CheckDCP
{
    class CPLParser
    {
        /// <summary>
        /// Получение имени контента или его типа
        /// </summary>
        /// <param name="fileName">Адрес CPL-файла</param>
        /// <returns>Информация с двумя заполненными полями Название контента и его тип</returns>
        static public Data GetContentTitleTextAndContentKindOfCPL(string fileName)
        {
            // Переменные для временного хранения информации о файле
            Data fileInfo = new Data();

            // Инициализация Xml-документа
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(fileName);

            XmlElement xRoot = xDoc.DocumentElement;

            // Перебор в корневом теге
            foreach (XmlNode xNode in xRoot)
            {
                switch (xNode.Name)
                {
                    case "ContentTitleText":
                        fileInfo.CPLContentTitleText = xNode.InnerText;
                        break;
                    case "ContentKind":
                        fileInfo.CPLContentKind = xNode.InnerText;
                        break;
                }
            }

            return fileInfo;
        }
    }
}
