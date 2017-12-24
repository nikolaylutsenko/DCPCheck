using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Collections;
using System.Web;
using System.Threading;

namespace DCPCheck
{



    class Program
    {

        static void Main(string[] args)
        {
            //ввожу адрес
            Console.WriteLine("Введите адресс папки и нажмите <Enter>:");
            string s = Console.ReadLine();
            Console.WriteLine("Проверяю контент " + s);
            Console.WriteLine(new string('_', 50));
            Console.WriteLine("Парсю PKL");

            //считываю все файлы у которых в имени есть pkl
            string[] name = Directory.GetFiles(s, "*pkl*");

            //Console.WriteLine(name.Length);
            //присваиваю единственный найденый файл переменной
            string fileName = name[0];


            List<Data> fileList = PklParser.GetArrayFromPkl(fileName);

            foreach (Data v in fileList)
            {
                
                Console.WriteLine("Имя файла: " + ((v.OFN)));
                Console.WriteLine("Эталонное значение: " + v.OrigHash);
            }


            //сообщение в консоль
            Console.WriteLine(new string('_', 50));
            Console.WriteLine("Считаю...");
            
            //экземпляр класса для подсчета хеша
            Hash hash = new Hash();

            //список для хранения расчитаных хешей
            //List<Data> myCalcList = new List<Data>();

            
            //создаю список для расчета хеш
            //по именам из ПКЛ
            //foreach (Data d in fileList)
            //{
            //    myCalcList.Add(new Data(d.OFN, ""));
            //}

            //обьект класса для отображения роботы
            ConsoleSpiner spin = new ConsoleSpiner();

            //расчитываю хеш по найденым именам файлов
            foreach (Data l in fileList)
            {
                //создаю поток в котором считаю хеш
                Thread t1 = new Thread(() =>
                {
                    l.CalcHash = hash.GetBase64EncodedSHA1Hash((s + "/" + l.OFN.ToString()));
                });
                t1.Start();
                //t1.Join();
                //Thread.Sleep(500);
                Console.Write("Работаю над {0}....",l.OFN);
                while (t1.IsAlive)
                {
                    spin.Turn();
                }
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write("Готово!");
                Console.WriteLine();
            }

            Console.WriteLine(new string('_', 50));
            Console.WriteLine();
            //вывожу в консоль расчитанные данные
            foreach (Data d in fileList)
            {
                Console.WriteLine("Имя файла: " + d.OFN);
                Console.WriteLine("Расчитанное значение: " + d.CalcHash);
            }

            
            //сообщение в консоль
            Console.WriteLine(new string('_', 50));
            Console.WriteLine("Сравниваю ХЕШи");

            //проверяю имя и размер файлов и вывожу сообщение
            foreach (Data f in fileList)
            {
                //foreach (Data j in myCalcList)
                //{
                //    if (i.OFN == j.OFN)
                //    {
                //        if (i.OrigHash != j.OrigHash)
                //        {
                //            Console.ForegroundColor = ConsoleColor.Red;
                //            Console.WriteLine("Файл {0} имеет значение {1}, отличное от {2}.", i.OFN, j.OrigHash, i.OrigHash);
                //            Console.ForegroundColor = ConsoleColor.White;
                //        }
                //        else
                //        {
                //            Console.ForegroundColor = ConsoleColor.Green;
                //            Console.WriteLine("Файл {0}, размер совпадает со значением.",i.OFN);
                //            Console.ForegroundColor = ConsoleColor.White;
                //        }
                //    }
                //}
            
            if(f.OrigHash == f.CalcHash)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Файл {0}, размер совпадает со значением.",f.OFN);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Файл {0} имеет значение {1}, отличное от {2}.", f.OFN, f.CalcHash, f.OrigHash);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.WriteLine("Завершено!");
            //жду отклик
            Console.ReadKey();


        }
    }
}

