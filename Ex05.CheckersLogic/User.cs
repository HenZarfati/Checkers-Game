 
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class User
    {
        private int m_Score;
        private string m_Name;
        private eUserType m_UserType;
        private eTypeSign m_SoldierSign;
        private eTypeSign m_KingSign;
        private bool m_TurnFlag;

        public User(string i_Name, eUserType i_UserType, int i_Score, eTypeSign i_SoldierSign, eTypeSign i_KingSign, bool i_TurnFlag)
        {
            this.m_Name = i_Name;
            this.m_Score = i_Score;
            this.m_UserType = i_UserType;
            this.m_SoldierSign = i_SoldierSign;
            this.m_KingSign = i_KingSign;
            this.m_TurnFlag = i_TurnFlag;
        }

        public bool TurnFlag
        {
            get
            {
                return this.m_TurnFlag;
            }

            set
            {
                this.m_TurnFlag = value;
            }
        }

        public eTypeSign KingSign
        {
            get
            {
                return this.m_KingSign;
            }

            set
            {
                this.m_KingSign = value;
            }
        }

        public eTypeSign SoldierSign
        {
            get
            {
                return this.m_SoldierSign;
            }

            set
            {
                this.m_SoldierSign = value;
            }
        }

        public int Score
        {
            get
            {
                return this.m_Score;
            }

            set
            {
                this.m_Score = value;
            }
        }

        public eUserType UserType
        {
            get
            {
                return this.m_UserType;
            }

            set
            {
                this.m_UserType = value;
            }
        }

        public string Name
        {
            get
            {
                return this.m_Name;
            }

            set
            {
                this.m_Name = value;
            }
        }
    }
}