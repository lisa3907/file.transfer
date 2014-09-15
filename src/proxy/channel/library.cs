using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Cryptography;

namespace uBizSoft.FileCopy.Channel
{
    /// <summary></summary>
    public class library
    {
        /// <summary></summary>
        public library()
        {
        }

        public string MD5ComputeHash(byte[] p_source)
        {
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(p_source)).Replace("-", string.Empty).ToLower();
        }

        public string SHA1ComputeHash(byte[] p_source)
        {
            return BitConverter.ToString(new SHA1CryptoServiceProvider().ComputeHash(p_source)).Replace("-", string.Empty).ToLower();
        }

        public string ComputeFileHash(string p_filename)
        {
            var _result = Guid.NewGuid().ToString();

            try
            {
                using (var _fs = new FileStream(p_filename, FileMode.Open, FileAccess.Read, FileShare.Read, 4096))
                {
                    var _crypto = new SHA1CryptoServiceProvider();
                    var _hashs = _crypto.ComputeHash(_fs);
                    _result = BitConverter.ToString(_hashs);
                }
            }
            catch (Exception)
            {
            }

            return _result;
        }
    }
}
