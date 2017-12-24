using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DCPCheck
{
    class Hash
    {
        public string GetBase64EncodedSHA1Hash(string filename)
        {
            //эта конструкция высвобождает ресурсы после использования
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                return Convert.ToBase64String(sha1.ComputeHash(fs));
            }
        }

    }
}
