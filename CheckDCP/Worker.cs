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
        /// Хранит информацию о файлах, которые указаны в PKL-файле
        /// </summary>
        List<Data> fileList = new List<Data>();
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
        Hash hash = new Hash();

        /// <summary>
        /// Установка папки, в которой будет выполняться проверка
        /// </summary>
        /// <param name="name">Принимаемая строка с адресом папки</param>
        /// <returns>Возвращает адрес папки, в которой будет выполняться проверка</returns>
        public string SetFolderName(string name)
        {
            folderName = name;

            GetFileNameWithPKL();

            return folderName;
        }

        /// <summary>
        /// Считываю все файлы у которых в имени есть PKL-файлы
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
        /// <summary>
        /// Рекурсивный поиск файлов в папке
        /// </summary>
        /// <param name="dir">Адрес папки</param>
        /// <param name="firstSearch">Выполнять ли поиск в корневой папке</param>
        void SearchPKLFile(string dir, bool firstSearch)
        {
            // Получение списка файлов в корневой папке
            if (firstSearch)
            {
                foreach (string f in Directory.GetFiles(dir, "*PKL*"))
                {
                    fileNameWithPKL.Add(f);
                }
            }
            // Получение списка директорий в папке
            foreach (string d in Directory.GetDirectories(dir))
            {
                // Получение списка файлов в папке
                foreach (string f in Directory.GetFiles(d, "*PKL*"))
                {
                    fileNameWithPKL.Add(f);
                }
                // Рекурсивный вызов поиска файлов
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

        /// <summary>
        /// Получение информации о файлах из PKL-файла
        /// </summary>
        void GetFileList()
        {
            foreach (var item in fileNameWithPKL)
            {
                // Порсинг информации
                fileList = PKLParser.GetArrayFromPkl(item);

                // Заполнение информации в список
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

                // Расчет Хэш-суммы
                GetFileHash();
            }
        }
        /// <summary>
        /// Расчет Хэш-суммы
        /// </summary>
        public void GetFileHash()
        {
            foreach (string s in fileNameWithPKL)
            {
                string path = Path.GetDirectoryName(s);

                foreach (Data data in fileList)
                {
                    // Переменная для хранения адреса файла
                    string fullPath;

                    // Проверка источника имени адреса файла
                    if (data.OriginalFileName != "")
                    {
                        fullPath = path + "/" + data.OriginalFileName.ToString();
                    }
                    else
                    {
                        fullPath = path + "/" + data.AnnotationText.ToString();
                    }

                    // Получение системной информации о файле
                    FileInfo fileInfo = new FileInfo(fullPath);

                    // Создание потока для просчета Хэш-суммы и размера файла
                    Thread t1 = new Thread(() =>
                    {
                        data.HashCalculated = hash.GetBase64EncodedSHA1Hash(fullPath);
                        data.SizeCalculated = fileInfo.Length.ToString();
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
            // Есть ли в папке PKL-файл 
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
