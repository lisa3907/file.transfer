using System;

namespace uBizSoft.FileCopy.Interface
{
    /// <summary>
    /// CProxy에 대한 요약 설명입니다.
    /// </summary>
    public class FileCopy : IDisposable
    {
        public FileCopy()
            : this(true)
        {
        }

        public FileCopy(bool p_isService)
        {
            Manager.IsService = p_isService;
        }
        private uBizSoft.LIB.Communication.WcfProxy m_wcfProxy = null;
        public uBizSoft.LIB.Communication.WcfProxy Proxy
        {
            get
            {
                if (m_wcfProxy == null)
                {
                    m_wcfProxy = new uBizSoft.LIB.Communication.WcfProxy
                        (
                        "uBizSoft File Copy Service V4.0",

                        "net.tcp",
                        8100,
                        8101,
                        "uBizSoft_FileCopy_V40.soap",
                        "filecopy",

                        "33B51BE3-BA10-424C-AB58-57BE71B2224C",

                        "FileCopy_DBC",
                        "FileCopy_CFG",

                        "file_copy",
                        "file_copy_V40",
                        "V4.0.2011.03"
                        );
                }

                return m_wcfProxy;
            }
        }

        private QService m_manager = null;
        public QService Manager
        {
            get
            {
                if (m_manager == null)
                {
                    m_manager = new QService(Proxy.AppSvcName, RegHelper.SNG.GetProductId(Proxy.AppSvcID), Proxy.AppVersion);
                }
                return m_manager;
            }
        }

        private Guid m_certapp = Guid.Empty;
        public Guid g_certapp
        {
            get
            {
                if (m_certapp == Guid.Empty)
                {
                    m_certapp = new Guid(Proxy.AppGuid);
                }
                return m_certapp;
            }
        }

        public bool CheckValidApplication(Guid p_certapp)
        {
            return p_certapp.Equals(g_certapp);
        }

        private uBizSoft.SVC.Proxy.CLogger.Channel m_clogger = null;
        public uBizSoft.SVC.Proxy.CLogger.Channel CLogger
        {
            get
            {
                if (m_clogger == null)
                {
                    m_clogger = new uBizSoft.SVC.Proxy.CLogger.Channel(Manager);
                }
                return m_clogger;
            }
        }

        public void WriteLog(string p_message)
        {
            WriteLog("X", p_message);
        }

        public void WriteLog(string p_exception, string p_message)
        {
            try
            {
                if (Manager.IsService == true)
                {
                    CLogger.WriteLogToQFile(p_exception, p_message);
                }
                else
                {
                    CLogger.WriteLogToEvent(p_message);
                }
            }
            catch (Exception)
            {
                CLogger.WriteLogToEvent(p_message);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (m_wcfProxy != null)
                {
                    m_wcfProxy.Dispose();
                    m_wcfProxy = null;
                }
                if (m_manager != null)
                {
                    m_manager.Dispose();
                    m_manager = null;
                }
            }
        }
        ~FileCopy()
        {
            Dispose(false);
        }
    }
}
