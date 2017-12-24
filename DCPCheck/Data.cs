using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCPCheck
{
    class Data
    {
        public string OFN;
        public string Hash;

        public Data(string Ofn, string H)
        {
            this.OFN = Ofn;
            this.Hash = H;
        }

    }
}
