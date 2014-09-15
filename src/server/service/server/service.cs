using System;
using System.IO;
using System.Management;

namespace uBizSoft.FileCopy.Server
{
    public class MoveService : IMoveService
    {
        public MoveService()
        {
        }

        private uBizSoft.FileCopy.Interface.FileCopy m_interface = null;
        private uBizSoft.FileCopy.Interface.FileCopy Interface
        {
            get
            {
                if (m_interface == null)
                {
                    m_interface = new uBizSoft.FileCopy.Interface.FileCopy();
                }
                return m_interface;
            }
        }

        private uBizSoft.FileCopy.Channel.library m_library = null;
        private uBizSoft.FileCopy.Channel.library Library
        {
            get
            {
                if (m_library == null)
                {
                    m_library = new uBizSoft.FileCopy.Channel.library();
                }
                return m_library;
            }
        }

        public string[] GetDirectories(string p_directory)
        {
            var _result = Directory.GetDirectories(p_directory);

            Interface.Logger.WriteLog("L", String.Format("GetDirectories(): {0} dirs", _result.Length));
            return _result;
        }

        public DirectoryInfo GetDirectoryInfo(string p_directory)
        {
            var _result = new DirectoryInfo(p_directory);

            Interface.Logger.WriteLog("L", String.Format("GetDirectoryInfo(): {0}", _result.Name));
            return _result;
        }
        public DirectoryInfo[] GetDirectoryInfos(string p_directory)
        {
            var _di = new DirectoryInfo(p_directory);
            var _result = _di.GetDirectories();

            Interface.Logger.WriteLog("L", String.Format("GetDirectoryInfos(): {0}", _result.Length));
            return _result;
        }

        public uDriver[] GetDrives()
        {
            Interface.Logger.WriteLog("L", "Enter GetDrives()");
            var _result = (uDriver[] )null;

            try
            {
                var _searcher = new ManagementObjectSearcher("SELECT * From Win32_LogicalDisk ");
                var _objects = _searcher.Get();

                _result = new uDriver[_objects.Count];

                var i = 0;
                foreach (ManagementObject _mo in _objects)
                {
                    _result[i] = new uDriver();

                    _result[i].DriveType = _mo["DriveType"].ToString();
                    _result[i].DriveName = _mo["Name"].ToString();

                    i++;
                }
            }
            catch (Exception ex)
            {
                Interface.Logger.WriteLog("L", ex.ToString());
            }

            Interface.Logger.WriteLog("L", String.Format("GetDrives(): {0} drives", _result.Length));
            return _result;
        }

        public bool DirectoryExists(string p_fullpath)
        {
            var _result = Directory.Exists(p_fullpath);

            Interface.Logger.WriteLog("L", String.Format("DirectoryExists(): {0} {1} ", p_fullpath, _result));
            return _result;
        }

        public string[] GetFiles(string p_directory)
        {
            var _di = new DirectoryInfo(p_directory);

            var _fis = _di.GetFiles();
            var _result = new string[_fis.Length];
            for (var i = 0; i < _fis.Length ; i++)
            {
                _result[i] = _fis[i].FullName;
            }
            Interface.Logger.WriteLog("L", String.Format("GetFiles(): {0} files", _result.Length));
            return _result;
        }

        public uFile[] GetFileInfos(string p_directory)
        {
            var _di = new DirectoryInfo(p_directory);
            var _fileinfs = _di.GetFiles();

            var _result = new uFile[_fileinfs.Length];
            var i = 0;
            foreach (FileInfo _fileinf in _fileinfs)
            {
                _result[i] = new uFile();

                _result[i].Length = _fileinf.Length;

                _result[i].CreationTime = _fileinf.CreationTime;
                _result[i] .LastWriteTime = _fileinf.LastWriteTime;

                _result[i].FullName = _fileinf.FullName;
                _result[i].Name = _fileinf.Name;

                i++;
            }

            Interface.Logger.WriteLog("L", String.Format("GetFileInfos(): {0} files", _result.Length));
            return _result;
        }

        public bool PrepareFile(string p_fullname)
        {
            var _result = true;

            Interface.Logger.WriteLog("L", String.Format("PrepareFile(): {0}{1}", p_fullname, _result));
            return _result;
        }

        public byte[] DownloadFile(string p_fullname, long p_offset, int p_bufferSize)
        {
            var _result = new byte[0];

            if (File.Exists(p_fullname) == true)
            {
                var _filesize = new FileInfo(p_fullname).Length;
                if (p_offset <= _filesize)
                {
                    using (var _fs = new FileStream(p_fullname, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        _fs.Seek(p_offset, SeekOrigin.Begin);

                        _result = new byte[p_bufferSize];
                        var _bytesread = _fs.Read(_result, 0, p_bufferSize);

                        if (_bytesread != p_bufferSize)
                        {
                            Array.Resize<byte>(ref _result, _bytesread);
                        }
                    }
                }
            }

            Interface.Logger.WriteLog("L", String.Format("DownloadFile(): {0}\t\t{1} byte(s)", p_fullname, _result.Length));
            return _result;
        }

        public bool VerifyFile(string p_fullname, string p_filehash)
        {
            var _result = p_filehash.Equals(Library.ComputeFileHash(p_fullname));

            Interface.Logger.WriteLog("L", String.Format("VerifyFile(): {0}\t\t{1} byte(s)", p_fullname, _result));
            return _result;
        }
    }
}
