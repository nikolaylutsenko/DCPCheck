using System;
using System.IO;
using System.Security.Cryptography;

namespace CheckDCP
{
    class Hash
    {
        public static string GetBase64EncodedSHA1Hash(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                return Convert.ToBase64String(sha1.ComputeHash(fs));
            }
        }
    }
}
