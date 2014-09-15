using System;
using System.ServiceProcess;

namespace uBizSoft.FileCopy.Server
{
    public partial class fCopyService : ServiceBase
    {
        public fCopyService()
        {
            InitializeComponent();
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

        private uBizSoft.LIB.Communication.WcfServer m_wcfServer = null;
        private uBizSoft.LIB.Communication.WcfServer WcfServer
        {
            get
            {
                if (m_wcfServer == null)
                {
                    m_wcfServer = new uBizSoft.LIB.Communication.WcfServer();

                    m_wcfServer.StartServer(
                            typeof(MoveService), typeof(IMoveService),
                            Interface.Proxy.BindingName,
                            Interface.Proxy.AppSvcName,
                            Interface.Proxy.Port
                    );

                    m_wcfServer.ServerHost.Opened += new EventHandler(ServerHost_Opened);
                    m_wcfServer.ServerHost.Closed += new EventHandler(ServerHost_Closed);
                    m_wcfServer.ServerHost.Faulted += new EventHandler(ServerHost_Faulted);
                }

                return m_wcfServer;
            }
        }

        private void StartService()
        {
            WcfServer.ServerHost.Open();
        }

        private void StopService()
        {
            if (m_wcfServer != null)
            {
                m_wcfServer.ServerHost.Abort();
                m_wcfServer = null;
            }
        }

        private void ServerHost_Opened(object sender, EventArgs e)
        {
            Interface.Logger.WriteLog("S", "WcfHost Opened()...");
        }

        private void ServerHost_Closed(object sender, EventArgs e)
        {
            Interface.Logger.WriteLog("S", "WcfHost Closed()...");
        }

        private void ServerHost_Faulted(object sender, EventArgs e)
        {
            Interface.Logger.WriteLog("S", "WcfHost Faulted()...");

            StopService();
            StartService();
        }

        protected override void OnStart(string[] args)
        {
            Interface.Logger.WriteLog("S", "Server Service OnStart()...");
            StartService();

            base.OnStart(args);
        }

        protected override void OnStop()
        {
            Interface.Logger.WriteLog("S", "Server Service OnStop()...");
            StopService();

            base.OnStop();
        }
    }
}
