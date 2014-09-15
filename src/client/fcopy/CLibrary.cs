using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace uBizSoft.FileCopy.fCopy
{
    /// <summary></summary>
    public class CLibrary
    {
        private uBizSoft.FileCopy.Channel.Library m_library = null;
        public uBizSoft.FileCopy.Channel.Library Library
        {
            get
            {
                if (m_library == null)
                {
                    m_library = new uBizSoft.FileCopy.Channel.Library();
                }
                return m_library;
            }
        }

        private uBizSoft.FileCopy.Channel.Channel m_channel = null;
        public uBizSoft.FileCopy.Channel.Channel Channel
        {
            get
            {
                if (m_channel == null)
                {
                    m_channel = new uBizSoft.FileCopy.Channel.Channel(
                        ConfigurationSettings.AppSettings["ServerUrl"]
                        );
                }

                return m_channel;
            }
        }

        public const int Removable = 2;
        public const int LocalDisk = 3;
        public const int Network = 4;
        public const int CD = 5;
        public const int RAMDrive = 6;

        public string GetPathName(string stringPath)
        {
            var stringSplit = stringPath.Split('\\');
            var _maxIndex = stringSplit.Length;
            return stringSplit[_maxIndex - 1];
        }

        public string FormatDate(DateTime dtDate)
        {
            var stringDate = string.Empty;

            stringDate = dtDate.ToShortDateString().ToString() + " " + dtDate.ToShortTimeString().ToString();

            return stringDate;
        }

        public string FormatSize(Int64 lSize)
        {
            var stringSize = string.Empty;
            var myNfi = new NumberFormatInfo();

            var lKBSize = 0;

            if (lSize < 1024)
            {
                if (lSize == 0)
                {
                    stringSize = "0";
                }
                else
                {
                    stringSize = "1";
                }
            }
            else
            {
                lKBSize = lSize / 1024;
                stringSize = lKBSize.ToString("n", myNfi);
                stringSize = stringSize.Replace(".00", string.Empty);
            }

            return stringSize + " KB";
        }

        private const int AVERAGE_SAMPLE = 5;
        private const int INIT_CHUNK_SIZE = 65536 / 2;
        private const int MAX_CHUNK_SIZE = 65536;
        private const int PREFERRED_TRANSFER_DURATION = 2048;

        public bool DownloadServerFile(string p_srvfile, string p_clifile, long p_fileSize, long p_readsize)
        {
            var _success = true;

            var _readRetry = 0;
            var _fileSize = (int)p_fileSize;
            var _chunksize = INIT_CHUNK_SIZE;

            var _iterations = 0;
            var _startTime = DateTime.Now;

            var _treadsize = 0L;
            if (p_readsize > 0)
            {
                _treadsize = p_readsize;
            }
            using (var _fs = new FileStream(p_clifile, FileMode.Append, FileAccess.Write))
            {
                while (_fileSize > _treadsize)
                {
                    if (_iterations++ == AVERAGE_SAMPLE + 1)
                    {
                        var _timeforinitchunks = (long)DateTime.Now.Subtract(_startTime).TotalMilliseconds;
                        var _averagechunktime = Math.Max(1, _timeforinitchunks / AVERAGE_SAMPLE);

                        _chunksize = (int)(_chunksize * PREFERRED_TRANSFER_DURATION / _averagechunktime);
                        _chunksize = (int)Math.Max(INIT_CHUNK_SIZE, _chunksize);
                        _chunksize = (int)Math.Min(MAX_CHUNK_SIZE, _chunksize);

                        _iterations = 0;
                        _startTime = DateTime.Now;
                    }

                    var _buffer = Channel.Proxy.DownloadFile(p_srvfile, _treadsize, _chunksize);
                    if (_buffer == null)
                    {
                        _success = false;
                        break;
                    }

                    if (_buffer.Length < 1)
                    {
                        if (_readRetry++ > 3)
                        {
                            _success = false;
                            break;
                        }
                    }
                    else
                    {
                        _fs.Write(_buffer, 0, _buffer.Length);
                        _treadsize += _buffer.Length;

                        _readRetry = 0;
                    }

                    System.Threading.Thread.Sleep(0);
                    Application.DoEvents();
                }
            }

            if (_success == true)
            {
                var _clihash = Library.ComputeFileHash(p_clifile);
                _success = Channel.Proxy.VerifyFile(p_srvfile, _clihash);
            }

            return _success;
        }
    }
}
