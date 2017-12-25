using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckDCP
{
    class Worker
    {
        bool emptyPath = true;

        string folderName;
        string[] fileNameWithPKL;
        List<Data> fileList = new List<Data>();

        List<string> fileInfoFromPKL;

        public string SetFolderName(string name)
        {
            folderName = name;
            return folderName;
        }

        /// <summary>
        /// считываю все файлы у которых в имени есть pkl
        /// </summary>
        public string GetFileNameWithPKL()
        {
            fileNameWithPKL = Directory.GetFiles(folderName, "*pkl*");
            
            if (fileNameWithPKL.Length == 0)
            {
                emptyPath = true;
                return "В выбранной папке нет DCP-контента или отсутствует PKL-файл";
            }

            emptyPath = false;
            return "В папке найдено " + fileNameWithPKL.Length + "PKL-файла";
        }

        /// <summary>
        /// Вывод списка файлов
        /// </summary>
        public string[] ShowAllFileWithPKL()
        {
            return fileNameWithPKL;
        }

        public string[] GetFileList()
        {
            foreach (var item in fileNameWithPKL)
            {
                fileList = PklParser.GetArrayFromPkl(item);

                foreach (Data v in fileList)
                {
                    fileInfoFromPKL.Add("Имя файла: " + ((v.OFN)));
                    fileInfoFromPKL.Add("Эталонное значение: " + v.OrigHash);
                }

                GetFileHash();
            }

            return fileInfoFromPKL.ToArray();
        }

        public void GetFileHash()
        {

        }

        public void startCheck()
        {

        }
    }
}
