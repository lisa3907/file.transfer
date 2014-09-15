using System;
using System.Collections.Generic;
using System.Linq;

namespace uBizSoft.FileCopy.Channel
{
    public class eventArgs
    {
        private object[] m_results = new object[16];
        private object m_userState = null;
        private bool m_completed = false;
        private int m_state = -1;

        public eventArgs()
        {
        }

        public eventArgs(object p_userState)
        {
            m_userState = p_userState;
        }

        /// <remarks/>
        public object[] Results
        {
            get
            {
                return m_results;
            }
            set
            {
                m_results = value;
            }
        }

        /// <remarks/>
        public object UserState
        {
            get
            {
                return m_userState;
            }
            set
            {
                m_userState = value;
            }
        }

        public int State
        {
            get
            {
                return m_state;
            }
            set
            {
                m_state = value;
            }
        }

        public bool Completed
        {
            get
            {
                return m_completed;
            }
            set
            {
                m_completed = value;
            }
        }
    }
}
