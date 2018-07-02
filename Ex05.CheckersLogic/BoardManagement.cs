
    using System;
    using System.Collections.Generic;
    using System.Text;

namespace Logic
{
    public delegate void IsBoardChangeEventHandler(object sender, IsBoardChangedEvent e);

    public delegate void IsGameOverEventHandler(object sender, IsGameOverEvent e);
	public class BoardManagement
    {
        private  eTypeSign[,] m_Board;
		private readonly int r_BoardSize;
		private User m_User1;
		private User m_User2;
		private bool m_User1Turn;

        public event IsGameOverEventHandler m_IsGameOver;

        public event IsBoardChangeEventHandler m_IsBoardChanged;

        public BoardManagement(int i_BoardSize, User i_User1, User i_User2)
        {
            r_BoardSize = i_BoardSize;
            m_Board = new eTypeSign[r_BoardSize, r_BoardSize];
            m_User1 = i_User1;
            m_User2 = i_User2;
            m_User1Turn = true;
            Initialize();
        }

        public IsGameOverEventHandler GameOverDelegate
        {
            get 
            { 
                return m_IsGameOver;
            }

            set 
            { 
                m_IsGameOver = value;
            }
        }

        public bool User1Turn
        {
            get { return m_User1Turn; }
        }

        public eTypeSign[,] Board
        {
            get
            {
                return this.m_Board;
            }
        }

        public User User1
        {
            get { return m_User1; }
        }

        public User User2
        {
            get 
            { 
                return m_User2;
            }
        }

        public IsBoardChangeEventHandler IsBoardChanged
        {
            get 
            { 
                return m_IsBoardChanged;
            }

            set 
            { 
                m_IsBoardChanged = value;
            }
        }

        public IsGameOverEventHandler IsGameOver
        {
            get
            {
                return m_IsGameOver;
            }

            set
            {
                m_IsGameOver = value;
            }
        }
        private void Initialize()
        {
            int numOfUserSoldiers = (r_BoardSize / 2) - 1;
            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
            
                    if (!(((i + j) % 2) == 0))
                    {
                        if (i < numOfUserSoldiers)
                        {
                            m_Board[i, j] = eTypeSign.O;
                        }
                        else if (i > r_BoardSize - numOfUserSoldiers - 1)
                        {
                            m_Board[i, j] = eTypeSign.X;
                        }
                        else
                        {
                            m_Board[i, j] = eTypeSign.EMPTY;
                        }
                    }
                    else
                    {
                        m_Board[i, j] = eTypeSign.EMPTY;
                    }
                }
            }
        }


        private bool IsCanEat(Move i_Move)
        {
            
			bool isCanEat = (Math.Abs(i_Move.StartRow - i_Move.EndRow) == 2) && (Math.Abs(i_Move.StartCol - i_Move.EndCol) == 2);

			return isCanEat;
        }

		public eActionState CheckingMovementState(Move i_Move)
        {
            User UserWhoPlays = UserTurn();
			List<Move> UserMoveCollection = UserMovesCollection(UserWhoPlays);
            eActionState ActionState = eActionState.MoveIsPossible;

            if (i_Move.StartRow < 0 || i_Move.StartRow >= r_BoardSize || i_Move.StartCol < 0 || i_Move.StartCol >= r_BoardSize)
            {
                ActionState = eActionState.IlegalMove;
            }
            else if (m_Board[i_Move.StartRow, i_Move.StartCol] != UserWhoPlays.SoldierSign && m_Board[i_Move.StartRow, i_Move.StartCol] != UserWhoPlays.KingSign)
            {
                ActionState = eActionState.IlegalMove;
            }
			else if (IsCanEat(UserMoveCollection[0]) && !IsCanEat(i_Move))
            {
                ActionState = eActionState.NeedToEat;
            }
			else if (IsCanEat(i_Move))
            {
                int EndRowPos = (i_Move.StartRow + i_Move.EndRow) / 2;
                int EndColPos = (i_Move.StartCol + i_Move.EndCol) / 2;

				if (!CanEatMove(UserWhoPlays, i_Move.StartRow, i_Move.StartCol, EndRowPos, EndColPos, i_Move.EndRow, i_Move.EndCol))
                {
                    ActionState = eActionState.IlegalMove;
                }
            }
            else
            {
				if (!CheckingLegalMovment(UserWhoPlays, i_Move.StartRow, i_Move.StartCol, i_Move.EndRow, i_Move.EndCol))
                {
                    ActionState = eActionState.IlegalMove;
                }
            }

            return ActionState;
        }
		public bool DoMove(Move i_Move)
        {
            User UserWhoPlays = UserTurn();
            bool IsEatStillPossible = false;
            List<Move> EatsCollection;

            MoveAction(UserWhoPlays, i_Move);

            if (IsCanEat(i_Move) && (EatsCollection = AllPosEatMovePossible(UserWhoPlays, i_Move.EndRow, i_Move.EndCol)) != null)
            {
                IsEatStillPossible = true;
            }
            if (!IsEatStillPossible)
            {
                m_User1Turn = !m_User1Turn;
            }

            BoardUpdate(i_Move);

            checkIfGameEnded(UserWhoPlays, i_Move);

            return IsEatStillPossible;
        }
        private void BoardUpdate(Move i_Move)
        {
            IsBoardChangedEvent e = new IsBoardChangedEvent();
            e.Move = i_Move;
            e.SignOfEndPos = m_Board[i_Move.EndRow, i_Move.EndCol];
            e.IsCanEat = IsCanEat(i_Move);
            if (e.IsCanEat)
            {
                e.ClearLastRowPos = (i_Move.StartRow + i_Move.EndRow) / 2;
                e.ClearLastColPos = (i_Move.StartCol + i_Move.EndCol) / 2;
            }

            BoardUpdatNotify(e);      
        }

        private void checkIfGameEnded(User i_UserWhoPlays, Move i_LastMove)
        {
            User UserOpponent;
			if( i_UserWhoPlays == m_User1)
			{
				UserOpponent = m_User2;
			}
			else
			{
				UserOpponent = m_User1;
			}

			if (UserMovesCollection(UserOpponent) == null)
            {
				if (UserMovesCollection(i_UserWhoPlays) == null)
                {
                    GameEndResult(eResultOfGame.DrawResult, i_LastMove);
                }
                else
                {
                    GameEndResult( i_UserWhoPlays.Equals(m_User1) ?eResultOfGame.User1Winner : eResultOfGame.User2Winner,i_LastMove);
                }
            }
        }

        private void GameEndResult(eResultOfGame i_ResultOfGame, Move i_LastMove)
        {
            IsGameOverEvent e = new IsGameOverEvent();
            e.LastMove = i_LastMove;
            e.GameOverStatusCode = i_ResultOfGame;

            // update score
            switch (i_ResultOfGame)
            {
                case eResultOfGame.DrawResult:
                    break;
                case eResultOfGame.User1Winner:
                    m_User1.Score++;
                    break;
                case eResultOfGame.User2Winner:
                    m_User2.Score++;
                    break;
                default: break;
            }

            m_User1Turn = true;
            Initialize();
            GameOverNotify(e);   
        }

		protected virtual void BoardUpdatNotify(IsBoardChangedEvent e)
        {
            if(IsBoardChanged != null)
            {
                IsBoardChanged.Invoke(this, e);
            }
        }

		protected virtual void GameOverNotify(IsGameOverEvent e)
        {
            if(IsGameOver != null)
            {
                IsGameOver.Invoke(this, e);
            }
        }
        private List<Move> AllPosEatMovePossible(User i_User, int i_Row, int i_Col)
        {
            List<Move> PosEatCollection = new List<Move>();
			
            if (m_Board[i_Row, i_Col] == i_User.SoldierSign || m_Board[i_Row, i_Col] == i_User.KingSign)
            {
				if (CanEatMove(i_User, i_Row, i_Col, i_Row + 1, i_Col + 1, i_Row + 2, i_Col + 2))
                {
                    PosEatCollection.Add(new Move(i_Row, i_Col, i_Row + 2, i_Col + 2));
                }

				if (CanEatMove(i_User, i_Row, i_Col, i_Row - 1, i_Col + 1, i_Row - 2, i_Col + 2))
                {
                    PosEatCollection.Add(new Move(i_Row, i_Col, i_Row - 2, i_Col + 2));
                }

				if (CanEatMove(i_User, i_Row, i_Col, i_Row + 1, i_Col - 1, i_Row + 2, i_Col - 2))
                {
                    PosEatCollection.Add(new Move(i_Row, i_Col, i_Row + 2, i_Col - 2));
                }

				if (CanEatMove(i_User, i_Row, i_Col, i_Row - 1, i_Col - 1, i_Row - 2, i_Col - 2))
                {
                    PosEatCollection.Add(new Move(i_Row, i_Col, i_Row - 2, i_Col - 2));
                }
            }

            if (PosEatCollection.Count == 0)
            {
                PosEatCollection = null;
            }

            return PosEatCollection;
        }

        private void MoveAction(User i_User, Move i_Move)
        {
			m_Board[i_Move.EndRow, i_Move.EndCol] = m_Board[i_Move.StartRow, i_Move.StartCol];
			m_Board[i_Move.StartRow, i_Move.StartCol] = eTypeSign.EMPTY;
			if (Math.Abs(i_Move.StartRow - i_Move.EndRow) == 2)
			{
				int EatRowPos = (i_Move.StartRow + i_Move.EndRow) / 2;
				int EatColPos = (i_Move.StartCol + i_Move.EndCol) / 2;
				m_Board[EatRowPos, EatColPos] = eTypeSign.EMPTY;
			}
			if (i_Move.EndRow == r_BoardSize - 1 && i_User.TurnFlag && !(m_Board[i_Move.EndRow, i_Move.EndCol] == eTypeSign.K))
			{
				m_Board[i_Move.EndRow, i_Move.EndCol] = eTypeSign.U;
			}
			if (i_Move.EndRow == 0 && !i_User.TurnFlag && !(m_Board[i_Move.EndRow, i_Move.EndCol] == eTypeSign.K))
			{
				m_Board[i_Move.EndRow, i_Move.EndCol] = eTypeSign.K;
			}
        }
		public void ComputerRandomAction()
        {
			List<Move> ComputerMovesCollection = UserMovesCollection(m_User2);
			int CollectionFirstIdx = 0;
			int endIndexOfList = ComputerMovesCollection.Count - 1;
			Move computerMove;
			Random random = new Random();
			int result = random.Next(CollectionFirstIdx, endIndexOfList);
			computerMove = ComputerMovesCollection[result];
			if (DoMove(computerMove))
			{
				ComputerRandomAction();
			}
        }

		private List<Move> UserMovesCollection(User i_User)
		{
			eTypeSign UserSoldierSign = i_User.SoldierSign;
			eTypeSign UserKingSign = i_User.KingSign;
			List<Move> UserMoveCollection = new List<Move>();

			UserMoveCollection = EatMovesCollection(i_User);
			bool playerCanMakeAJump = UserMoveCollection.Count > 0;
			if (!playerCanMakeAJump)
			{
				UserMoveCollection = UserOnlyMoveCollection(i_User);
			}

			if (UserMoveCollection.Count == 0)
			{
				UserMoveCollection = null;
			}

			return UserMoveCollection;
		}

		private List<Move> EatMovesCollection(User i_User)
		{
			eTypeSign UserSoldierSign = i_User.SoldierSign;
			eTypeSign UserKingSign = i_User.KingSign;
			List<Move> UserEatMoveCollection = new List<Move>();


			for (int i = 0; i < r_BoardSize; i++)
			{
				for (int j = 0; j < r_BoardSize; j++)
				{
					if (m_Board[i, j] == i_User.SoldierSign || m_Board[i, j] == i_User.KingSign)
					{
						if (CanEatMove(i_User, i, j, i + 1, j + 1, i + 2, j + 2))
						{
							UserEatMoveCollection.Add(new Move(i, j, i + 2, j + 2));
						}

						if (CanEatMove(i_User, i, j, i + 1, j - 1, i + 2, j - 2))
						{
							UserEatMoveCollection.Add(new Move(i, j, i + 2, j - 2));
						}

						if (CanEatMove(i_User, i, j, i - 1, j - 1, i - 2, j - 2))
						{
							UserEatMoveCollection.Add(new Move(i, j, i - 2, j - 2));
						}

						if (CanEatMove(i_User, i, j, i - 1, j + 1, i - 2, j + 2))
						{
							UserEatMoveCollection.Add(new Move(i, j, i - 2, j + 2));
						}
					}
				}
			}

			return UserEatMoveCollection;
		}

		private List<Move> UserOnlyMoveCollection(User i_User)
		{
			eTypeSign UserSoldierSign = i_User.SoldierSign;
			eTypeSign UserKingSign = i_User.KingSign;
			List<Move> UserOnlyMoveCollection = new List<Move>();

			for (int i = 0; i < r_BoardSize; i++)
			{
				for (int j = 0; j < r_BoardSize; j++)
				{

					if (m_Board[i, j] == UserSoldierSign || m_Board[i, j] == UserKingSign)
					{
						if (CheckingLegalMovment(i_User, i, j, i + 1, j - 1))
						{
							UserOnlyMoveCollection.Add(new Move(i, j, i + 1, j - 1));
						}

						if (CheckingLegalMovment(i_User, i, j, i - 1, j - 1))
						{
							UserOnlyMoveCollection.Add(new Move(i, j, i - 1, j - 1));
						}

						if (CheckingLegalMovment(i_User, i, j, i + 1, j + 1))
						{
							UserOnlyMoveCollection.Add(new Move(i, j, i + 1, j + 1));
						}

						if (CheckingLegalMovment(i_User, i, j, i - 1, j + 1))
						{
							UserOnlyMoveCollection.Add(new Move(i, j, i - 1, j + 1));
						}
					}
				}
			}

			return UserOnlyMoveCollection;
		}

		private bool CheckingLegalMovment(User i_User, int i_StartRow, int i_StartCol, int i_EndRow, int i_EndCol)
		{
			bool IsLegalMove = true;

			if (i_EndRow < 0 || i_EndRow >= r_BoardSize || i_EndCol < 0 || i_EndCol >= r_BoardSize)
			{
				IsLegalMove = false;
			}
			else if (Math.Abs(i_StartRow - i_EndRow) != 1 || Math.Abs(i_StartCol - i_EndCol) != 1)
			{
				IsLegalMove = false;
			}
			else if (m_Board[i_EndRow, i_EndCol] != eTypeSign.EMPTY)
			{
				IsLegalMove = false;
			}
			else if (m_Board[i_StartRow, i_StartCol] == eTypeSign.O && i_StartRow >= i_EndRow)
			{
				IsLegalMove = false;
			}
			else if (m_Board[i_StartRow, i_StartCol] == eTypeSign.X && i_StartRow <= i_EndRow)
			{
				IsLegalMove = false;
			}

			return IsLegalMove;
		}
		private bool CanEatMove(User i_User, int i_StartRow, int i_StartCol, int i_MiddleRow, int i_MiddleCol, int i_EndRow, int i_EndCol)
		{
			bool canEatFlag = true;

			if (i_EndRow < 0 || i_EndRow >= r_BoardSize || i_EndCol < 0 || i_EndCol >= r_BoardSize)
			{
				canEatFlag = false;
			}
			else if (m_Board[i_EndRow, i_EndCol] != eTypeSign.EMPTY)
			{
				canEatFlag = false;
			}
			else if (m_Board[i_MiddleRow, i_MiddleCol] == eTypeSign.EMPTY)
			{
				canEatFlag = false;
			}
			else if ((m_Board[i_StartRow, i_StartCol] == eTypeSign.O || m_Board[i_StartRow, i_StartCol] == eTypeSign.U)
				&& (m_Board[i_MiddleRow, i_MiddleCol] == eTypeSign.O || m_Board[i_MiddleRow, i_MiddleCol] == eTypeSign.U))
			{
				canEatFlag = false;
			}
			else if ((m_Board[i_StartRow, i_StartCol] == eTypeSign.X || m_Board[i_StartRow, i_StartCol] == eTypeSign.K)
				&& (m_Board[i_MiddleRow, i_MiddleCol] == eTypeSign.X || m_Board[i_MiddleRow, i_MiddleCol] == eTypeSign.K))
			{
				canEatFlag = false;
			}
			else if ((m_Board[i_StartRow, i_StartCol] == eTypeSign.O) && (i_EndRow < i_StartRow))
			{
				canEatFlag = false;
			}
			else if ((m_Board[i_StartRow, i_StartCol] == eTypeSign.O) && (i_EndRow < i_StartRow))
			{
				canEatFlag = false;
			}
			else if ((m_Board[i_StartRow, i_StartCol] == eTypeSign.X) && (i_EndRow > i_StartRow))
			{
				canEatFlag = false;
			}

			return canEatFlag;
		}


        private User UserTurn()
        {
			User m_CurrentUserTurn;

			if (m_User1Turn == true)
			{
				m_CurrentUserTurn = m_User1;

			}
			else
			{
				m_CurrentUserTurn = m_User2;
			}
			return m_CurrentUserTurn;
        }
    }
}
