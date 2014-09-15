using System;
using System.ServiceModel;
using System.IO;
using System.Runtime.Serialization;

namespace uBizSoft.FileCopy.Server
{
    [DataContract(Name = "uDriver")]
    public class uDriver
    {
        [DataMember(Name = "DriveType")]
        public string DriveType { get; set; }

        [DataMember(Name = "DriveName")]
        public string DriveName { get; set; }
    }

    [DataContract(Name = "uFile")]
    public class uFile
    {
        [DataMember(Name = "CreationTime")]
        public DateTime CreationTime { get; set; }

        [DataMember(Name = "LastWriteTime")]
        public DateTime LastWriteTime { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "FullName")]
        public string FullName { get; set; }

        [DataMember(Name = "Length")]
        public Int64 Length { get; set; }
    }

    [ServiceContract]
    public interface IMoveService
    {
        [OperationContract]
        string[] GetDirectories(string p_directory);

        [OperationContract]
        DirectoryInfo GetDirectoryInfo(string p_directory);

        [OperationContract]
        DirectoryInfo[] GetDirectoryInfos(string p_directory);

        [OperationContract]
        uDriver[] GetDrives();

        [OperationContract(Name = "DirectoryExists")]
        bool DirectoryExists(string p_fullpath);

        [OperationContract]
        string[] GetFiles(string p_directory);

        [OperationContract]
        uFile[] GetFileInfos(string p_directory);

        [OperationContract]
        bool PrepareFile(string p_fullname);

        [OperationContract]
        byte[] DownloadFile(string p_fullname, long p_offset, int p_bufferSize);

        [OperationContract]
        bool VerifyFile(string p_fullname, string p_filehash);
    }
}
