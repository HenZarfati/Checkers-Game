
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class IsBoardChangedEvent : EventArgs
    {
        private Move m_Move;
        private eTypeSign m_UserTypeSign;
        private bool m_IsCanEat;
        private int m_ClearLastColPos;
        private int m_ClearLastRowPos;
        public Move Move
        {
            get 
            {
                return m_Move; 
            }

            set 
            { 
                m_Move = value; 
            }
        }
        public eTypeSign SignOfEndPos
        {
            get
            {
				return m_UserTypeSign; 
            }

            set 
            {
				m_UserTypeSign = value;
            }
        }
        public bool IsCanEat
        {
            get 
            { 
                return m_IsCanEat;
            }

            set
            { 
                m_IsCanEat = value; 
            }
        }
        public int ClearLastColPos
        {
            get 
            {
                return m_ClearLastColPos;
            }

            set
            { 
                m_ClearLastColPos = value;
            }
        }
        public int ClearLastRowPos
        {
            get
            { 
             return m_ClearLastRowPos;
                }

            set
            {
                m_ClearLastRowPos = value;
                }
        }
    }
}
