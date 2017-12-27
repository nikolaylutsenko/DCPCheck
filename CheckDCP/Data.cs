using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckDCP
{
    class Data
    {
        public string Id;
        public string OriginalFileName;
        public string AnnotationText;
        public string Hash;
        public string HashCalculated;
        public string Size;
        public string SizeCalculated;

        public Data()
        {

        }

        public Data(string ofn, string h)
        {
            this.OriginalFileName = ofn;
            this.Hash = h;
        }

        public Data(string id, string ofn, string h, string at, string s)
        {
            this.Id = id;
            this.OriginalFileName = ofn;
            this.AnnotationText = at;
            this.Hash = h;
            this.Size = s;
        }

        /// <summary>
        /// Очистка данных в поле
        /// </summary>
        public void Clear()
        {
            Id = "";
            OriginalFileName = "";
            AnnotationText = "";
            Hash = "";
            HashCalculated = "";
            Size = "";
            SizeCalculated = "";
        }

    }
}
