using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckDCP
{
    class Worker
    {
        #region Неиспользуемые переменные и методы
        ///// <summary>
        ///// Отсутствует ли в папке PKL-файл
        ///// </summary>
        //bool emptyPath = true;
        ///// <summary>
        ///// Хранит адрес проверяемой папки
        ///// </summary>
        //string folderName;
        ///// <summary>
        ///// Хранит список PKL-файлов 
        ///// </summary>
        //List<string> fileNameWithPKL = new List<string>();
        ///// <summary>
        ///// Хранит информацию о файлах, которые указаны в PKL-файле
        ///// </summary>
        //// List<Data> files = new List<Data>();
        ///// <summary>
        ///// Хранит список файлов, которые указаны в PKL-файле
        ///// </summary>
        //List<string> fileInfoFromPKL = new List<string>();
        ///// <summary>
        ///// Результаты проверки (временное)
        ///// </summary>
        //List<string> infoAboutCheck = new List<string>();

        ///// <summary>
        ///// Установка папки, в которой будет выполняться проверка
        ///// </summary>
        ///// <param name="name">Принимаемая строка с адресом папки</param>
        ///// <returns>Возвращает адрес папки, в которой будет выполняться проверка</returns>
        //public string SetFolderName(string name)
        //{
        //    folderName = name;

        //    // GetFileNameWithPKL();

        //    return folderName;
        //}///// <summary>
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

        ///// <summary>
        ///// Вывод списка файлов
        ///// </summary>
        //public string[] ShowAllFileWithPKL()
        //{
        //    return fileNameWithPKL.ToArray();
        //}

        ///// <summary>
        ///// Получение информации о файлах из PKL-файла
        ///// </summary>
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

        ///// <summary>
        ///// Запуск подсчета контрольных сумм
        ///// </summary>
        //public void StartCheck()
        //{
        //    // Есть ли в папке PKL-файл 
        //    if (!emptyPath)
        //    {
        //        Getfiles();
        //    }
        //}        
        ///// <summary>
        ///// Заполнение информации о сканированных файлах
        ///// </summary>
        ///// <returns>Массив информации о проверенных файлых</returns>
        //public string[] GetInfoFromPkl()
        //{
        //    List<string> infoAboutCheck = new List<string>();

        //    //infoAboutCheck.Add("-----------------------Найдены следующие PKL-файлы----------------------");
        //    //foreach (var item in fileNameWithPKL)
        //    //{
        //    //    infoAboutCheck.Add(item);
        //    //}

        //    // infoAboutCheck.Add("---------------------Найдены следующие файлы пакетов--------------------");

        //    foreach (var item in data)
        //    {
        //        infoAboutCheck.Add("Id файла:           " + item.Id);
        //        infoAboutCheck.Add("Путь к файлу:       " + item.FileLocation);
        //        infoAboutCheck.Add("Имя файла:          " + item.Name);
        //        infoAboutCheck.Add("Аннотация:          " + item.AnnotationText);
        //        infoAboutCheck.Add("Хэш-сумма из PKL:   " + item.HashPkl);
        //        infoAboutCheck.Add("Хэш-сумма расчет:   " + item.HashCalc);
        //        infoAboutCheck.Add("Размер файла:       " + item.Size);
        //        infoAboutCheck.Add("Размер файла расчет:" + item.SizeCalc);
        //        infoAboutCheck.Add("------------------------------------------------------------------------");
        //    }

        //    return infoAboutCheck.ToArray();
        //}
        ///// <summary>
        ///// Расчет Хэш-суммы
        ///// </summary>
        //public List<Data> CalcHash()
        //{
        //    foreach (Data assetName in data)
        //    {
        //        //string path = Path.GetDirectoryName(s);


        //            // Переменная для хранения адреса файла
        //            string fullPath;

        //            // Проверка источника имени адреса файла
        //            if (assetName.FileLocation != "")
        //            {
        //            //fullPath = assetName.Path.ToString();
        //            fullPath = assetName.FileLocation;
        //            }
        //            else
        //            {
        //            //fullPath = assetName.Path.ToString();
        //            fullPath = assetName.FileLocation;
        //            }

        //            // Получение системной информации о файле
        //            FileInfo fileInfo = new FileInfo(fullPath);

        //            // Создание потока для просчета Хэш-суммы и размера файла
        //            Thread t1 = new Thread(() =>
        //            {
        //                assetName.HashCalc = Hash.GetBase64EncodedSHA1HashPkl(fullPath);
        //                assetName.SizeCalc = fileInfo.Length.ToString();
        //            });
        //            t1.Start();
        //            t1.Join();
        //        }
        //    return data;
        //}        
        //public void ReadPkl()
        //{
        //    PKLParser.ParserPklFromAssetmap(data);
        //}
        ///// <summary>
        ///// Получение информации о файлах 
        ///// </summary>
        ///// <returns>Массив строк с информацией о найденных файлах</returns>
        //public string[] GetInfoFromAssetmap()
        //{
        //    List<string> infoAboutCheck = new List<string>();

        //    infoAboutCheck.Add("Найдены следующие Файлы------------------------------------------------------------------------------------------------------------------");
        //    foreach (var item in filelist)
        //    {
        //        infoAboutCheck.Add(item);
        //    }

        //    infoAboutCheck.Add("Найдены следующие файлы пакетов----------------------------------------------------------------------------------------------------------");

        //    foreach (var item in data)
        //    {
        //        infoAboutCheck.Add(item.Path);
        //        infoAboutCheck.Add("-----------------------------------------------------------------------------------------------------------------------------------------");
        //        infoAboutCheck.Add(@"ASSETMAP Id:            " + item.ASSETMAPId);
        //        infoAboutCheck.Add(@"Имя файла:              " + item.FileLocation);
        //        infoAboutCheck.Add(@"Id файла:               " + item.Id);
        //        infoAboutCheck.Add(@"Является ли PKL-файлом: " + item.ASSETIsPackingList.ToString());
        //        infoAboutCheck.Add("-----------------------------------------------------------------------------------------------------------------------------------------");
        //    }

        //    infoAboutCheck.Add(data.Count.ToString());

        //    return infoAboutCheck.ToArray();
        //}
        #endregion

        /// <summary>
        /// Хранит информацию, полученную из файлов
        /// </summary>
        private List<Data> data = new List<Data>();
        /// <summary>
        /// Хранит список файлов ASSETMAP
        /// </summary>
        private List<string> filelist = new List<string>();
        /// <summary>
        /// Тектовый результат проверки
        /// </summary>
        private List<string> checkResult = new List<string>();
        /// <summary>
        /// Хранит названия контента, который выбрал пользователь
        /// </summary>
        string[] selectedItems;
        /// <summary>
        /// Хранит количество проверяемых файлов
        /// </summary>
        public int selectedFiles = 0;
        /// <summary>
        /// Хранит текущий индекс проверяемого файла
        /// </summary>
        public int selectedFilesIndexOfCurrent = 0;

        /// <summary>
        /// Формирование списка адресов файлов ASSETMAP
        /// </summary>
        /// <param name="workFolder">Корневая папка, в которой будет выполняться поиск</param>
        /// <returns>Массив адресов файлов</returns>
        public void FindList(string workFolder)
        {
            // Очистка текущего массива адресов файлов
            filelist.Clear();

            SearchFile(workFolder, true, "ASSETMAP");
            
            ReadListAssetmap();
            
            GetInfoAboutASSET();
        }

        /// <summary>
        /// Поиск файлов в папках
        /// </summary>
        /// <param name="folder">Папка, в которой будет осуществляться поиск</param>
        /// <param name="firstSearch">Поиск в корневой папке (обязательный параметр)</param>
        /// <param name="request">Строка запроса</param>
        void SearchFile(string folder, bool firstSearch, string request)
        {
            // Поиск файлов в корневой папке
            if (firstSearch)
            {
                foreach (string file in Directory.GetFiles(folder, request))
                {
                    filelist.Add(file);
                }
            }
            // Поиск каталогов и файлов в них
            foreach (string dir in Directory.GetDirectories(folder))
            {
                foreach (string file in Directory.GetFiles(dir, request))
                {
                    filelist.Add(file);
                }

                SearchFile(dir, false, request);
            }
        }

        /// <summary>
        /// Получение списка адресов файлов из файлов ASSETMAP
        /// </summary>
        public void ReadListAssetmap()
        {
            // Очистка текущего списка файлов
            data.Clear();

            foreach (string file in filelist)
            {
                data.AddRange(ASSETMAPParser.GetInfoOfASSETMAP(file));
            }
        }

        /// <summary>
        /// Формирование списка информации. Проверка существования файла, чтение информации из PKL-файла
        /// </summary>
        void GetInfoAboutASSET()
        {
            List<Data> tempData = new List<Data>();

            // Проверка существования файла
            foreach (Data item in data)
            {
                // Проверка существования файла
                if (File.Exists(item.ASSETPath))
                {
                    item.ASSETFileExists = true;
                }
            }

            // Получение информации о ресурсах из PKL-файла
            foreach (Data item in data)
            {
                // Проверка, является ли текущий элемент PKL-файлом
                if (item.ASSETIsPackingList && item.ASSETFileExists)
                {
                    tempData = PKLParser.GetASSETOfPKL(item.ASSETPath);

                    // Копирование данных в основной список
                    foreach (Data itemData in data)
                    {
                        foreach (Data itemDataTemp in tempData)
                        {
                            if (itemData.ASSETId == itemDataTemp.PKLASSETId)
                            {
                                itemData.PKLASSETId = itemDataTemp.PKLASSETId;
                                itemData.PKLASSETHash = itemDataTemp.PKLASSETHash;
                                itemData.PKLASSETSize = itemDataTemp.PKLASSETSize;
                                itemData.PKLASSETId = itemDataTemp.PKLASSETId;
                            }
                        }
                    }
                }
            }
            // Получние названия контента
            foreach (Data itemTemp in data)
            {
                // Получние названия контента
                if (itemTemp.ASSETIsCompositionPlaylist && itemTemp.ASSETFileExists)
                {
                    itemTemp.CPLContentTitleText = CPLParser.GetContentTitleTextAndContentKindOfCPL(itemTemp.ASSETPath).CPLContentTitleText;
                    itemTemp.CPLContentKind = CPLParser.GetContentTitleTextAndContentKindOfCPL(itemTemp.ASSETPath).CPLContentKind;
                }
            }
        }

        /// <summary>
        /// Подсчет Hash-суммы и размера файла
        /// </summary>
        void GetCalculate(BackgroundWorker worker)
        {
            selectedFilesIndexOfCurrent = 0;

            foreach (Data item in data)
            {
                // Проверка существования файла
                if (item.ASSETFileExists && item.Selected)
                {
                    // При наличии исходной Hash-суммы пересчитываем Hash-сумму существующего файла
                    if (item.PKLASSETHash != null)
                    {
                        selectedFilesIndexOfCurrent++;
                        worker.ReportProgress(100 / selectedFiles * selectedFilesIndexOfCurrent);
                        item.PKLASSETHashCalculated = Hash.GetBase64EncodedSHA1Hash(item.ASSETPath);
                    }
                    // При наличии исходного размера файла получаем размер существующего файла
                    if (item.ASSETLength != null || item.PKLASSETSize != null)
                    {
                        FileInfo fileInfo = new FileInfo(item.ASSETPath);
                        item.PKLASSETSizeCalculated = fileInfo.Length.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Получение информации о контенте
        /// </summary>
        public bool CheckFiles(BackgroundWorker worker)
        {
            selectedFiles = 0;

            foreach (Data item in data)
            {
                // Проверка существования файла
                if (item.ASSETFileExists && item.Selected)
                {
                    selectedFiles++;
                }
            }

            // Подсчет Hash-суммы и размера файла
            GetCalculate(worker);

            checkResult.Clear();
            // Формирование отчета о проверке (Тест)
            foreach (Data selected in data)
            {
                string selectedASSETMAPId;

                // Выбран ли файл пользователем
                if (selected.Selected && selected.ASSETIsCompositionPlaylist)
                {
                    selectedASSETMAPId = selected.ASSETMAPId;

                    checkResult.Add("---------------------------------------------------------------------------------------------------------------------------------------");
                    checkResult.Add("DCP-пакет: " + selected.CPLContentTitleText);
                    foreach (Data item in data)
                    {
                        if (item.ASSETMAPId == selectedASSETMAPId)
                        {
                            checkResult.Add("Файл: " + item.ASSETPath);

                            // Существование файла
                            if (item.ASSETFileExists)
                            {
                                checkResult.Add(" + Файл существует.");

                                // Сравнение размера файла по таблице ASSETMAP
                                if (item.ASSETLength != null)
                                {
                                    if (item.ASSETLength == item.PKLASSETSizeCalculated)
                                    {
                                        checkResult.Add(" + Размер файла совпадает с таблицей файлов ASSETMAP");
                                    }
                                    else
                                    {
                                        checkResult.Add(" - Размер файла (" + item.PKLASSETSizeCalculated +
                                            ") НЕ совпадает с таблицей файлов ASSETMAP (" + item.ASSETLength + ")");
                                    }
                                }
                                else
                                {
                                    checkResult.Add(" + В таблице файлов ASSETMAP отсутствует информация о размере файла");
                                }

                                // Сравнение размера файла с информацией из PKL-файла
                                if (item.PKLASSETSize != null)
                                {
                                    if (item.PKLASSETSize == item.PKLASSETSizeCalculated)
                                    {
                                        checkResult.Add(" + Размер файла совпадает с информацией из PKL-файла");
                                    }
                                    else
                                    {
                                        checkResult.Add(" - Размер файла (" + item.PKLASSETSizeCalculated +
                                            ") НЕ совпадает с информацией из PKL-файла (" + item.PKLASSETSize + ")");
                                    }
                                }
                                else
                                {
                                    checkResult.Add(" + В PKL-файле отсутствует информация о размере файла");
                                }

                                // Сравнение Hash-суммы файла
                                if (item.PKLASSETHash != null)
                                {
                                    if (item.PKLASSETHash == item.PKLASSETHashCalculated)
                                    {
                                        checkResult.Add(" + Hash-сумма файла совпадает с информацией из PKL-файла");
                                    }
                                    else
                                    {
                                        checkResult.Add(" - Hash-сумма файла (" + item.PKLASSETHashCalculated +
                                            ") НЕ совпадает с информацией из PKL-файла (" + item.PKLASSETHash + ")");
                                    }
                                }
                                else
                                {
                                    checkResult.Add(" + В PKL-файле отсутствует информация о Hash-сумме файла");
                                }
                            }
                            else
                            {
                                checkResult.Add(" - Файл отсутствует!");
                            }
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Получение списка названий пакетов
        /// </summary>
        /// <returns>Список названий пакетов</returns>
        public string[] GetContentTitleText()
        {
            // Временный список названий пакетов
            List<string> itemContentTitleText = new List<string>();

            // Поиск названий пакетов из общего списка и добавление их во временный список
            foreach (Data item in data)
            {
                if (item.ASSETIsCompositionPlaylist)
                {
                    itemContentTitleText.Add(item.CPLContentTitleText);
                }
            }

            return itemContentTitleText.ToArray(); ;
        }

        /// <summary>
        /// Установка элементов, выбранных пользователями
        /// </summary>
        /// <param name="selectedItems">Массив строк из названий контента</param>
        public void SetSelectedItems(string[] items)
        {
            selectedItems = items;

            // Очистка выбранных элементов
            foreach (Data itemData in data)
            {
                itemData.Selected = false;
            }

            // Перебор выделенных пользователем элементов
            foreach (string itemSelected in selectedItems)
            {
                // Перебор имеющихся файлов
                foreach (Data itemData in data)
                {
                    // Поиск совпадений
                    if (itemSelected == itemData.CPLContentTitleText)
                    {
                        // Перебор и установка флага проверки выбранных файлов
                        foreach (Data itemSelectedData in data)
                        {
                            if (itemData.ASSETMAPId == itemSelectedData.ASSETMAPId)
                            {
                                itemSelectedData.Selected = true;
                                itemSelectedData.CPLContentTitleText = itemData.CPLContentTitleText;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Получние результата проверки
        /// </summary>
        /// <returns>Массив строк с результатами проверки</returns>
        public string[] GetCheckResult()
        {
            return checkResult.ToArray();
        }
    }
}
