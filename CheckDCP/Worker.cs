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
        List<string> fileNameWithPKL = new List<string>();
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
            SearchPKLFile(folderName, true);
            
            if (fileNameWithPKL.Count == 0)
            {
                emptyPath = true;
            }

            emptyPath = false;
        }
        
        void SearchPKLFile(string dir, bool firstSearch)
        {
            if (firstSearch)
            {
                foreach (string f in Directory.GetFiles(dir, "*PKL*"))
                {
                    fileNameWithPKL.Add(f);
                }
            }
            foreach (string d in Directory.GetDirectories(dir))
            {
                foreach (string f in Directory.GetFiles(d, "*PKL*"))
                {
                    fileNameWithPKL.Add(f);
                }

                SearchPKLFile(d, false);
            }
        }

        /// <summary>
        /// Вывод списка файлов
        /// </summary>
        public string[] ShowAllFileWithPKL()
        {
            return fileNameWithPKL.ToArray();
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
                string path = Path.GetDirectoryName(s);

                foreach (Data data in fileList)
                {
                    string fullPath = path + "/" + data.OriginalFileName.ToString();

                    FileInfo fileInfo = new FileInfo(fullPath);

                    //создаю поток в котором считаю хеш
                    Thread t1 = new Thread(() =>
                    {
                        if (data.OriginalFileName != "")
                        {
                            data.HashCalculated = hash.GetBase64EncodedSHA1Hash(fullPath);
                            data.SizeCalculated = fileInfo.Length.ToString();
                        }
                        else
                        {
                            data.HashCalculated = hash.GetBase64EncodedSHA1Hash(fullPath);
                            data.SizeCalculated = fileInfo.Length.ToString();
                        }
                    });
                    t1.Start();
                    t1.Join();
                }
            }
        }


        /// <summary>
        /// Запуск подсчета контрольных сумм
        /// </summary>
        public void StartCheck()
        {
            if (!emptyPath)
            {
                GetFileList();
            }
        }
        
        /// <summary>
        /// Заполнение информации о сканированных файлах
        /// </summary>
        /// <returns>Массив информации о проверенных файлых</returns>
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
