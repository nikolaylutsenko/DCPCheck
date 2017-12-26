using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckDCP
{
    class Worker
    {
        bool emptyPath = true;

        string folderName;
        string[] fileNameWithPKL;
        List<Data> fileList = new List<Data>();

        List<string> fileInfoFromPKL = new List<string>();
        List<string> infoAboutCheck = new List<string>();

        Hash hash = new Hash();

        public string SetFolderName(string name)
        {
            folderName = name;

            GetFileNameWithPKL();

            return folderName;
        }

        /// <summary>
        /// считываю все файлы у которых в имени есть pkl
        /// </summary>
        void GetFileNameWithPKL()
        {
            fileNameWithPKL = Directory.GetFiles(folderName, "*pkl*");
            
            if (fileNameWithPKL.Length == 0)
            {
                emptyPath = true;
            }

            emptyPath = false;
        }

        /// <summary>
        /// Вывод списка файлов
        /// </summary>
        public string[] ShowAllFileWithPKL()
        {
            return fileNameWithPKL;
        }

        void GetFileList()
        {
            foreach (var item in fileNameWithPKL)
            {
                fileList = PKLParser.GetArrayFromPkl(item);

                foreach (Data data in fileList)
                {
                    if (data.OriginalFileName != "")
                    {
                        fileInfoFromPKL.Add(data.OriginalFileName);
                    }
                    if (data.AnnotationText != "")
                    {
                        fileInfoFromPKL.Add(data.AnnotationText);
                    }
                    fileInfoFromPKL.Add(data.Hash);
                    fileInfoFromPKL.Add(data.Size);
                }

                GetFileHash();
            }
        }

        public void GetFileHash()
        {
            foreach (string s in fileNameWithPKL)
            {
                foreach (Data data in fileList)
                {
                    //создаю поток в котором считаю хеш
                    Thread t1 = new Thread(() =>
                    {
                        data.HashCalculated = hash.GetBase64EncodedSHA1Hash((folderName + "/" + data.OriginalFileName.ToString()));
                    });
                    t1.Start();

                    while (t1.IsAlive)
                    {
                        
                    }

                    bool alive = t1.IsAlive;
                }
            }
        }

        public void StartCheck()
        {
            if (!emptyPath)
            {
                GetFileList();
            }
        }
        
        public string[] GetInfoAboutCheck()
        {
            infoAboutCheck.Add("-----------------------Найдены следующие PKL-файлы----------------------");
            foreach (var item in fileNameWithPKL)
            {
                infoAboutCheck.Add(item);
            }

            infoAboutCheck.Add("---------------------Найдены следующие файлы пакетов--------------------");

            foreach (var item in fileList)
            {
                infoAboutCheck.Add("Оригинальное имя: " + item.OriginalFileName);
                infoAboutCheck.Add("Аннотация:        " + item.AnnotationText);
                infoAboutCheck.Add("Хэш-сумма:        " + item.Hash);
                infoAboutCheck.Add("Хэш-сумма:        " + item.HashCalculated);
                infoAboutCheck.Add("Размер файла:     " + item.Size);
                infoAboutCheck.Add("Размер файла:     " + item.SizeCalculated);
                infoAboutCheck.Add("------------------------------------------------------------------------");
            }

            return infoAboutCheck.ToArray();
        }
    }
}
