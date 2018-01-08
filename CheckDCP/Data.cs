using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckDCP
{
    class Data
    {

        //string id;
        //string name;
        //string hashPkl;
        //string hashCalc;
        //string fileLocation;
        //string size;
        //string sizeCalc;
        public string AnnotationText;


        public string Id { get; set; }
        public string Name { get; set; }

        //переменная для хранения адреса папкис файлом ассет
        public string Path { get; set; }
        public string HashPkl { get; set; }
        public string HashCalc { get; set; }
        public string FileLocation { get; set; }
        public string Size { get; set; }
        public string SizeCalc { get; set; }


        public bool ASSETIsPackingList { get; set; }

        public string PKLAnnotationText { get; set; }
                
        

        //айди ассетмапа
        public string ASSETMAPId { get; set; }
        
        public string PKLId { get; set; }
        
        public Data()
        {

        }

        public Data(string ofn, string h)
        {
            this.Name = ofn;
            this.HashPkl = h;
        }

        public Data(string id, string ofn, string h, string at, string s)
        {
            this.Id = id;
            this.Name = ofn;
            this.AnnotationText = at;
            this.HashPkl = h;
            this.Size = s;
        }

        /// <summary>
        /// Очистка данных в поле
        /// </summary>
        public void Clear()
        {
            Id = "";
            Name = "";
            AnnotationText = "";
            HashPkl = "";
            HashCalc = "";
            Size = "";
            SizeCalc = "";
        }

    }
}
