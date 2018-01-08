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
        /// <summary>
        /// Отсутствует ли в папке PKL-файл
        /// </summary>
        bool emptyPath = true;
        /// <summary>
        /// Хранит адрес проверяемой папки
        /// </summary>
        string folderName;
        /// <summary>
        /// Хранит список PKL-файлов 
        /// </summary>
        List<string> fileNameWithPKL = new List<string>();
        /// <summary>
        /// Хранит ВСЮ инфу о файлах
        /// </summary>
        List<Data> files = new List<Data>();
        /// <summary>
        /// Хранит информацию о файлах, которые указаны в PKL-файле
        /// </summary>
        //List<Data> files = new List<Data>();
        /// <summary>
        /// Хранит список файлов, которые указаны в PKL-файле
        /// </summary>
        List<string> fileInfoFromPKL = new List<string>();
        /// <summary>
        /// Результаты проверки (временное)
        /// </summary>
        List<string> infoAboutCheck = new List<string>();
        /// <summary>
        /// Инициализация класса для проверки Хэш-суммы
        /// </summary>
        HashPkl HashPkl = new HashPkl();


        public List<string> filelist = new List<string>();

        /// <summary>
        /// Установка папки, в которой будет выполняться проверка
        /// </summary>
        /// <param name="name">Принимаемая строка с адресом папки</param>
        /// <returns>Возвращает адрес папки, в которой будет выполняться проверка</returns>
        public string SetFolderName(string name)
        {
            folderName = name;

            // GetFileNameWithPKL();

            return folderName;
        }

        /// <summary>
        /// Поиск файлов в папках
        /// </summary>
        /// <param name="workFolder">Корневая папка, в которой будет выполняться поиск</param>
        /// <param name="isAssetmap">Поиск ASSETMAP-файла, иначе PKL-файла</param>
        /// <returns>Массив адресов файлов</returns>
        public List<string> FindList(string workFolder, bool isAssetmap)
        {
            // Очистка текущего массива адресов файлов
            filelist.Clear();

            if (isAssetmap)
            {
                SearchFile(workFolder, true, "ASSETMAP");
            }
            else
            {
                SearchFile(workFolder, true, "*PKL*");
            }

            return filelist;
        }

        /// <summary>
        /// Поиск файлов в папках
        /// </summary>
        /// <param name="folder">Папка, в которой будет осуществляться поиск</param>
        /// <param name="firstSearch">Поиск в корневой папке (обязательный параметр)</param>
        /// <param name="request">Строка запроса</param>
        void SearchFile(string folder, bool firstSearch, string request)
        {
            if (firstSearch)
            {
                foreach (string file in Directory.GetFiles(folder, request))
                {
                    filelist.Add(file);
                }
            }
            foreach (string dir in Directory.GetDirectories(folder))
            {
                foreach (string file in Directory.GetFiles(dir, request))
                {
                    filelist.Add(file);
                }

                SearchFile(dir, false, request);
            }
        }

        public void ReadListAssetmap()
        {
            // Очистка текущего списка файлов
            files.Clear();

            foreach (string file in filelist)
            {
                files = ASSETMAPParser.GetInfoOfASSETMAP(file);
            }
        }



        ///// <summary>
        ///// Считываю все файлы у которых в имени есть PKL-файлы
        ///// </summary>
        //void GetFileNameWithPKL()
        //{
        //    SearchPKLFile(folderName, true);

        //    if (fileNameWithPKL.Count == 0)
        //    {
        //        emptyPath = true;
        //    }
        //    else
        //    {
        //        emptyPath = false;
        //    }
        //}

        ///// <summary>
        ///// Рекурсивный поиск файлов в папке
        ///// </summary>
        ///// <param name="dir">Адрес папки</param>
        ///// <param name="firstSearch">Выполнять ли поиск в корневой папке</param>
        //void SearchPKLFile(string dir, bool firstSearch)
        //{
        //    // Получение списка файлов в корневой папке
        //    if (firstSearch)
        //    {
        //        foreach (string f in Directory.GetFiles(dir, "*PKL*"))
        //        {
        //            if (Path.GetExtension(f) == ".xml")
        //            {
        //                fileNameWithPKL.Add(f);
        //            }
                    
        //        }
        //    }
        //    // Получение списка директорий в папке
        //    foreach (string d in Directory.GetDirectories(dir))
        //    {
        //        // Получение списка файлов в папке
        //        foreach (string f in Directory.GetFiles(d, "*PKL*"))
        //        {
        //            if (Path.GetExtension(f) == ".xml")
        //            {
        //                fileNameWithPKL.Add(f);
        //            }
        //        }
        //        // Рекурсивный вызов поиска файлов
        //        SearchPKLFile(d, false);
        //    }
        //}

        /// <summary>
        /// Вывод списка файлов
        /// </summary>
        public string[] ShowAllFileWithPKL()
        {
            return fileNameWithPKL.ToArray();
        }

        /// <summary>
        /// Получение информации о файлах из PKL-файла
        /// </summary>
        //void Getfiles()
        //{
        //    foreach (var item in fileNameWithPKL)
        //    {
        //        // Порсинг информации
        //        files.Add(new Data(PKLParser.GetAnnotationTextOfPKL(item), ""));

        //        // Заполнение информации в список
        //        foreach (Data data in files)
        //        {
        //            if (data.Name != "")
        //            {
        //                fileInfoFromPKL.Add(data.Name);
        //            }
        //            if (data.AnnotationText != "")
        //            {
        //                fileInfoFromPKL.Add(data.AnnotationText);
        //            }
        //            fileInfoFromPKL.Add(data.HashPkl);
        //            fileInfoFromPKL.Add(data.Size);
        //        }

        //        // Расчет Хэш-суммы
        //        CalcHash();
        //    }
        //}
        /// <summary>
        /// Расчет Хэш-суммы
        /// </summary>
        public List<Data> CalcHash()
        {
            foreach (Data assetName in files)
            {
                //string path = Path.GetDirectoryName(s);

                
                    // Переменная для хранения адреса файла
                    string fullPath;

                    // Проверка источника имени адреса файла
                    if (assetName.FileLocation != "")
                    {
                    //fullPath = assetName.Path.ToString();
                    fullPath = assetName.FileLocation;
                    }
                    else
                    {
                    //fullPath = assetName.Path.ToString();
                    fullPath = assetName.FileLocation;
                    }

                    // Получение системной информации о файле
                    FileInfo fileInfo = new FileInfo(fullPath);

                    // Создание потока для просчета Хэш-суммы и размера файла
                    Thread t1 = new Thread(() =>
                    {
                        assetName.HashCalc = HashPkl.GetBase64EncodedSHA1HashPkl(fullPath);
                        assetName.SizeCalc = fileInfo.Length.ToString();
                    });
                    t1.Start();
                    t1.Join();
                }
            return files;
        }


        /// <summary>
        /// Запуск подсчета контрольных сумм
        /// </summary>
        //public void StartCheck()
        //{
        //    // Есть ли в папке PKL-файл 
        //    if (!emptyPath)
        //    {
        //        Getfiles();
        //    }
        //}

        /// <summary>
        /// Получение информации о файлах 
        /// </summary>
        /// <returns>Массив строк с информацией о найденных файлах</returns>
        public string[] GetInfoFromAssetmap()
        {
            List<string> infoAboutCheck = new List<string>();

            infoAboutCheck.Add("Найдены следующие Файлы------------------------------------------------------------------------------------------------------------------");
            foreach (var item in filelist)
            {
                infoAboutCheck.Add(item);
            }

            infoAboutCheck.Add("Найдены следующие файлы пакетов----------------------------------------------------------------------------------------------------------");

            foreach (var item in files)
            {
                infoAboutCheck.Add(item.Path);
                infoAboutCheck.Add("-----------------------------------------------------------------------------------------------------------------------------------------");
                infoAboutCheck.Add(@"ASSETMAP Id:            " + item.ASSETMAPId);
                infoAboutCheck.Add(@"Имя файла:              " + item.FileLocation);
                infoAboutCheck.Add(@"Id файла:               " + item.Id);
                infoAboutCheck.Add(@"Является ли PKL-файлом: " + item.ASSETIsPackingList.ToString());
                infoAboutCheck.Add("-----------------------------------------------------------------------------------------------------------------------------------------");
            }

            infoAboutCheck.Add(files.Count.ToString());

            return infoAboutCheck.ToArray();
        }
        
        public void ReadPkl()
        {
            PKLParser.ParserPklFromAssetmap(files);
        }


        /// <summary>
        /// Заполнение информации о сканированных файлах
        /// </summary>
        /// <returns>Массив информации о проверенных файлых</returns>
        public string[] GetInfoFromPkl()
        {
            //infoAboutCheck.Add("-----------------------Найдены следующие PKL-файлы----------------------");
            //foreach (var item in fileNameWithPKL)
            //{
            //    infoAboutCheck.Add(item);
            //}

           // infoAboutCheck.Add("---------------------Найдены следующие файлы пакетов--------------------");

            foreach (var item in files)
            {
                infoAboutCheck.Add("Id файла:           " + item.Id);
                infoAboutCheck.Add("Путь к файлу:       " + item.FileLocation);
                infoAboutCheck.Add("Имя файла:          " + item.Name);
                infoAboutCheck.Add("Аннотация:          " + item.AnnotationText);
                infoAboutCheck.Add("Хэш-сумма из PKL:   " + item.HashPkl);
                infoAboutCheck.Add("Хэш-сумма расчет:   " + item.HashCalc);
                infoAboutCheck.Add("Размер файла:       " + item.Size);
                infoAboutCheck.Add("Размер файла расчет:" + item.SizeCalc);
                infoAboutCheck.Add("------------------------------------------------------------------------");
            }

            return infoAboutCheck.ToArray();
        }
    }
}
