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
        public void GetFileNameWithPKL()
        {
            fileNameWithPKL = Directory.GetFiles(folderName, "*pkl*");
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
    }
}
