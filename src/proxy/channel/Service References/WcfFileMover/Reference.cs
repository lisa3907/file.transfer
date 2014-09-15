namespace uBizSoft.FileCopy.Channel.WcfFileMover
{
    using System.Runtime.Serialization;
    using System;

    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "uDriver", Namespace = "http://schemas.datacontract.org/2004/07/uBizSoft.FileCopy.Server")]
    [System.SerializableAttribute]
    public partial class uDriver : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {
        [System.NonSerializedAttribute]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string DriveNameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string DriveTypeField;
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataField;
            }
            set
            {
                extensionDataField = value;
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string DriveName
        {
            get
            {
                return DriveNameField;
            }
            set
            {
                if ((object.ReferenceEquals(DriveNameField, value) != true))
                {
                    DriveNameField = value;
                    RaisePropertyChanged("DriveName");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string DriveType
        {
            get
            {
                return DriveTypeField;
            }
            set
            {
                if ((object.ReferenceEquals(DriveTypeField, value) != true))
                {
                    DriveTypeField = value;
                    RaisePropertyChanged("DriveType");
                }
            }
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "uFile", Namespace = "http://schemas.datacontract.org/2004/07/uBizSoft.FileCopy.Server")]
    [System.SerializableAttribute]
    public partial class uFile : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {
        [System.NonSerializedAttribute]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private System.DateTime CreationTimeField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string FullNameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private System.DateTime LastWriteTimeField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private long LengthField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string NameField;
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataField;
            }
            set
            {
                extensionDataField = value;
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public System.DateTime CreationTime
        {
            get
            {
                return CreationTimeField;
            }
            set
            {
                if ((CreationTimeField.Equals(value) != true))
                {
                    CreationTimeField = value;
                    RaisePropertyChanged("CreationTime");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string FullName
        {
            get
            {
                return FullNameField;
            }
            set
            {
                if ((object.ReferenceEquals(FullNameField, value) != true))
                {
                    FullNameField = value;
                    RaisePropertyChanged("FullName");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public System.DateTime LastWriteTime
        {
            get
            {
                return LastWriteTimeField;
            }
            set
            {
                if ((LastWriteTimeField.Equals(value) != true))
                {
                    LastWriteTimeField = value;
                    RaisePropertyChanged("LastWriteTime");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public long Length
        {
            get
            {
                return LengthField;
            }
            set
            {
                if ((LengthField.Equals(value) != true))
                {
                    LengthField = value;
                    RaisePropertyChanged("Length");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Name
        {
            get
            {
                return NameField;
            }
            set
            {
                if ((object.ReferenceEquals(NameField, value) != true))
                {
                    NameField = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "WcfFileMover.IMoveService")]
    public interface IMoveService
    {
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMoveService/GetDirectories", ReplyAction = "http://tempuri.org/IMoveService/GetDirectoriesResponse")]
        string[] GetDirectories(string p_directory);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMoveService/GetDirectoryInfo", ReplyAction = "http://tempuri.org/IMoveService/GetDirectoryInfoResponse")]
        System.IO.DirectoryInfo GetDirectoryInfo(string p_directory);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMoveService/GetDirectoryInfos", ReplyAction = "http://tempuri.org/IMoveService/GetDirectoryInfosResponse")]
        System.IO.DirectoryInfo[] GetDirectoryInfos(string p_directory);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMoveService/GetDrives", ReplyAction = "http://tempuri.org/IMoveService/GetDrivesResponse")]
        uBizSoft.FileCopy.Channel.WcfFileMover.uDriver[] GetDrives();
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMoveService/DirectoryExists", ReplyAction = "http://tempuri.org/IMoveService/DirectoryExistsResponse")]
        bool DirectoryExists(string p_fullpath);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMoveService/GetFiles", ReplyAction = "http://tempuri.org/IMoveService/GetFilesResponse")]
        string[] GetFiles(string p_directory);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMoveService/GetFileInfos", ReplyAction = "http://tempuri.org/IMoveService/GetFileInfosResponse")]
        uBizSoft.FileCopy.Channel.WcfFileMover.uFile[] GetFileInfos(string p_directory);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMoveService/PrepareFile", ReplyAction = "http://tempuri.org/IMoveService/PrepareFileResponse")]
        bool PrepareFile(string p_fullname);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMoveService/DownloadFile", ReplyAction = "http://tempuri.org/IMoveService/DownloadFileResponse")]
        byte[] DownloadFile(string p_fullname, long p_offset, int p_bufferSize);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMoveService/VerifyFile", ReplyAction = "http://tempuri.org/IMoveService/VerifyFileResponse")]
        bool VerifyFile(string p_fullname, string p_filehash);
    }
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMoveServiceChannel : uBizSoft.FileCopy.Channel.WcfFileMover.IMoveService, System.ServiceModel.IClientChannel
    {
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MoveServiceClient : System.ServiceModel.ClientBase<uBizSoft.FileCopy.Channel.WcfFileMover.IMoveService>, uBizSoft.FileCopy.Channel.WcfFileMover.IMoveService
    {
        public MoveServiceClient()
        {
        }
        public MoveServiceClient(string endpointConfigurationName)
            :
            base(endpointConfigurationName)
        {
        }
        public MoveServiceClient(string endpointConfigurationName, string remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public MoveServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public MoveServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
            :
            base(binding, remoteAddress)
        {
        }
        public string[] GetDirectories(string p_directory)
        {
            return base.Channel.GetDirectories(p_directory);
        }
        public System.IO.DirectoryInfo GetDirectoryInfo(string p_directory)
        {
            return base.Channel.GetDirectoryInfo(p_directory);
        }
        public System.IO.DirectoryInfo[] GetDirectoryInfos(string p_directory)
        {
            return base.Channel.GetDirectoryInfos(p_directory);
        }
        public uBizSoft.FileCopy.Channel.WcfFileMover.uDriver[] GetDrives()
        {
            return base.Channel.GetDrives();
        }
        public bool DirectoryExists(string p_fullpath)
        {
            return base.Channel.DirectoryExists(p_fullpath);
        }
        public string[] GetFiles(string p_directory)
        {
            return base.Channel.GetFiles(p_directory);
        }
        public uBizSoft.FileCopy.Channel.WcfFileMover.uFile[] GetFileInfos(string p_directory)
        {
            return base.Channel.GetFileInfos(p_directory);
        }
        public bool PrepareFile(string p_fullname)
        {
            return base.Channel.PrepareFile(p_fullname);
        }
        public byte[] DownloadFile(string p_fullname, long p_offset, int p_bufferSize)
        {
            return base.Channel.DownloadFile(p_fullname, p_offset, p_bufferSize);
        }
        public bool VerifyFile(string p_fullname, string p_filehash)
        {
            return base.Channel.VerifyFile(p_fullname, p_filehash);
        }
    }
}
