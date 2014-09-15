using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace uBizSoft.FileCopy.Channel
{
    public class filecopy
    {
        public filecopy(string p_wcfServerUrl)
        {
            m_serverUrl = p_wcfServerUrl;
        }

        private string m_serverUrl = String.Empty;
        public string ServerUrl
        {
            get
            {
                return m_serverUrl;
            }
            set
            {
                m_serverUrl = value;
            }
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

        private uBizSoft.FileCopy.Channel.WcfFileMover.IMoveService m_proxy = null;
        public uBizSoft.FileCopy.Channel.WcfFileMover.IMoveService Proxy
        {
            get
            {
                if (m_proxy == null || ((ICommunicationObject)m_proxy).State != CommunicationState.Opened)
                {
                    m_proxy = (new uBizSoft.LIB.Communication.WcfClient()).StartClient<uBizSoft.FileCopy.Channel.WcfFileMover.IMoveService>
                    (
                        Interface.Proxy.BindingName,
                        Interface.Proxy.AppSvcName,
                        ServerUrl,
                        Interface.Proxy.Port
                    );

                    ((ICommunicationObject)m_proxy).Opened += WcfHelper_Opened;
                    ((ICommunicationObject)m_proxy).Closed += WcfHelper_Closed;
                    ((ICommunicationObject)m_proxy).Faulted += WcfHelper_Faulted;
                }

                return m_proxy;
            }
        }

        private void StopChannel()
        {
            if (m_proxy != null)
            {
                ((ICommunicationObject)m_proxy).Abort();
                m_proxy = null;
            }
        }

        private void WcfHelper_Opened(object sender, EventArgs e)
        {
            Interface.Logger.WriteLog("L", String.Format("Service Opened()....."));
        }

        private void WcfHelper_Closed(object sender, EventArgs e)
        {
            Interface.Logger.WriteLog("L", String.Format("Service Closed()....."));
        }

        private void WcfHelper_Faulted(object sender, EventArgs e)
        {
            Interface.Logger.WriteLog("L", String.Format("Service Faulted()....."));
            StopChannel();
        }
    }
}
