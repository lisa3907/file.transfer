namespace uBizSoft.FileCopy.Server
{
    partial class MoveInstaller
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.fCopySVI = new System.ServiceProcess.ServiceInstaller();
            this.fCopySPI = new System.ServiceProcess.ServiceProcessInstaller();
            // 
            // fCopySVI
            // 
            this.fCopySVI.Description = "본 서비스는 업로드를 위한 서버측 서비스 입니다.";
            this.fCopySVI.DisplayName = "uBizSoft File Copy Service V40";
            this.fCopySVI.ServiceName = "uBizSoft File Copy Service V40";
            this.fCopySVI.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // fCopySPI
            // 
            this.fCopySPI.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.fCopySPI.Password = null;
            this.fCopySPI.Username = null;
            // 
            // MoveInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.fCopySVI,
            this.fCopySPI});

        }

        #endregion

        private System.ServiceProcess.ServiceInstaller fCopySVI;
        private System.ServiceProcess.ServiceProcessInstaller fCopySPI;

    }
}