
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class IsGameOverEvent : EventArgs
    {
        private eResultOfGame m_GameOver;
        private Move m_LastMove;

       public eResultOfGame GameOverStatusCode
       {
           get 
           {
               return m_GameOver;
           }

           set 
           {
               m_GameOver = value;
           }
       }

       public Move LastMove
       {
           get 
           { 
               return m_LastMove;
           }

           set 
           { 
               m_LastMove = value;
           }
       }
    }
}
