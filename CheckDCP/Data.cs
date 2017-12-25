using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckDCP
{
    class Data
    {
        public string OFN;
        public string OrigHash;
        public string CalcHash = "";

        public Data(string Ofn, string H)
        {
            this.OFN = Ofn;
            this.OrigHash = H;
        } 
        //public Data(string Ofn, string OH,string CH)
        //{
        //    this.OFN = Ofn;
        //    this.OrigHash = OH;
        //    this.CalcHash = CH;
        //}

    }
}
