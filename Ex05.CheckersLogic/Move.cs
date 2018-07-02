
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Move
    {
       private int m_StratRowPos;
	   private int m_StartColPos;
	   private int m_EndRowPos;
	   private int m_EndColPos;

	   public Move(int i_StratRowPos, int i_StartColPos, int i_EndRowPos, int i_EndColPos)
        {

			m_StratRowPos = i_StratRowPos;
			m_StartColPos = i_StartColPos;
            m_EndRowPos = i_EndRowPos;
            m_EndColPos = i_EndColPos;
        }

        public override bool Equals(object obj)
        {
            Move move = obj as Move;
			bool IsPosNotEquals = false;

            if (!(obj == null) && !((object)move == null))
            {

				IsPosNotEquals = (m_StratRowPos == move.StartRow) && (m_StartColPos == move.StartCol) && (m_EndRowPos == move.EndRow) && (m_EndColPos == move.EndCol);
            }

			return IsPosNotEquals;
        }

        public override int GetHashCode()
        {
            return m_StratRowPos * m_StartColPos * m_EndRowPos * m_EndColPos;
        }

        public int StartRow
        {
            get
            {
                return this.m_StratRowPos;
            }
        }

        public int StartCol
        {
            get
            {
                return this.m_StartColPos;
            }
        }

        public int EndCol
        {
            get
            {
                return this.m_EndColPos;
            }
        }

        public int EndRow
        {
            get
            {
                return this.m_EndRowPos;
            }
        }
    }
}