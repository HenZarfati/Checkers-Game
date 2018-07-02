using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Logic;

namespace Interface
{
    public partial class CheckersForm : Form
    {
		 private const int k_ButtonSize = 40;
        private readonly BoardManagement m_CheckersBoardManagment;
        private readonly int m_BoardSize;
        private Label m_LabelUser1 = new Label();
        private Label m_LabelUser2 = new Label();
        private Button[,] m_Board;  
		private bool m_TurnFlag = false;
        private Button m_ButtonStartMove;

		public CheckersForm(MyLogIn i_MyLogIn)
        {
            
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Damka";
            User player1 = new User(
                i_MyLogIn.FirstPlayerName,
                eUserType.User,
                0,
                eTypeSign.O,
                eTypeSign.U,
                true);
            User player2 = new User(
                i_MyLogIn.SecondPlayerName == "[Computer]" ? "Computer"
                : i_MyLogIn.SecondPlayerName,
                i_MyLogIn.CheckBoxOfPlayer2IsChecked ? eUserType.User : eUserType.Computer,
                0,
                eTypeSign.X,
                eTypeSign.K,
                false);

            if (i_MyLogIn.RadioButtonBoardSize6X6IsChecked)
            {
                m_BoardSize = 6;
            }
            else if (i_MyLogIn.RadioButtonBoardSize8X8IsChecked)
            {
                m_BoardSize = 8;
            }
            else
            {
                m_BoardSize = 10;
            }

            m_CheckersBoardManagment = new BoardManagement(m_BoardSize, player1, player2);
            m_CheckersBoardManagment.IsGameOver += GameOver;
			m_CheckersBoardManagment.IsBoardChanged += BoardChanged;
            m_Board = new Button[m_BoardSize, m_BoardSize];
            Size = new Size((m_BoardSize * k_ButtonSize) + 100, (m_BoardSize * k_ButtonSize) + 100);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            SetControls();
            BoardPrint();
        }

        private void SetControls()
        {
    
            m_LabelUser1.Size = new Size(100, 20);
            m_LabelUser1.Text = m_CheckersBoardManagment.User1.Name + ": " + m_CheckersBoardManagment.User1.Score;
            m_LabelUser1.Location = new Point(50 + k_ButtonSize, 20);
            m_LabelUser2.Size = new Size(100, 20);
            m_LabelUser2.Text = m_CheckersBoardManagment.User2.Name + ": " + m_CheckersBoardManagment.User2.Score;
            m_LabelUser2.Location = new Point(50 + ((m_BoardSize - 2) * k_ButtonSize), m_LabelUser1.Height);
            this.Controls.AddRange(
               new Control[]
               { 
                 m_LabelUser1, 
                 m_LabelUser2
               });

            UserLabelUpdate();

            int startX = 50;
            int startY = m_LabelUser1.Height + 30;
            int currentX;
            int currentY;

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    m_Board[i, j] = new Button();
					m_Board[i, j].BackColor = Color.Wheat;
                    m_Board[i, j].Size = new Size(k_ButtonSize, k_ButtonSize);
                    currentX = startX + (i * k_ButtonSize);
                    currentY = startY + (j * k_ButtonSize);
                    m_Board[i, j].Location = new Point(currentX, currentY);
                    if (((i + j) % 2) == 0)
                    {
                        m_Board[i, j].Enabled = false;
                        m_Board[i, j].BackColor = Color.Black;
                    }

                    this.Controls.Add(m_Board[i, j]);
                    m_Board[i, j].Click += new EventHandler(m_ButtonClick);
                }
            }
        }

        private void UserLabelUpdate()
        {
            m_LabelUser1.Text = m_CheckersBoardManagment.User1.Name + ": " + m_CheckersBoardManagment.User1.Score;
            m_LabelUser2.Text = m_CheckersBoardManagment.User2.Name + ": " + m_CheckersBoardManagment.User2.Score;
        }
        private void BoardPrint()
        {
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
					m_Board[j, i].Text = SymbolOfButton(m_CheckersBoardManagment.Board[i, j]);
			
                }
            }
        }

        private string SymbolOfButton(eTypeSign i_TypeSign)
        {
            string result = null;

            switch (i_TypeSign)
            {
                case eTypeSign.EMPTY:
                   result = string.Empty;
                    break;
                case eTypeSign.U:
					result = eTypeSign.U.ToString();
                    break;
                case eTypeSign.O:
					result = eTypeSign.O.ToString();
                    break;
                case eTypeSign.K:
					result = eTypeSign.K.ToString();
                    break;
                case eTypeSign.X:
					result = eTypeSign.X.ToString();
                    break;
                default: break;          
            }

            return result;
        }

        private void m_ButtonClick(object sender, EventArgs e)
        {
            if (!m_TurnFlag)
            {
                m_ButtonStartMove = sender as Button;
                ActionOfStartMove(m_ButtonStartMove);
            }
            else
            {
                Button endOfMove = sender as Button;
                ActionOfFinishMove(m_ButtonStartMove, endOfMove);

                if (!m_CheckersBoardManagment.User1Turn &&
                    m_CheckersBoardManagment.User2.UserType == eUserType.Computer)
                {
					m_CheckersBoardManagment.ComputerRandomAction();
                }
            }
        }

        private void ActionOfStartMove(Button i_ButtonClicked)
		{
            int colOfButtonClicked = (i_ButtonClicked.Left - m_Board[0, 0].Location.X) / k_ButtonSize;
            int rowOfButtonClicked = (i_ButtonClicked.Location.Y - m_Board[0, 0].Location.Y) / k_ButtonSize;
            bool StartButtonFlag = false;

            if (m_CheckersBoardManagment.User1Turn)
            {
                if (m_CheckersBoardManagment.Board[rowOfButtonClicked, colOfButtonClicked] == eTypeSign.O ||
                    m_CheckersBoardManagment.Board[rowOfButtonClicked, colOfButtonClicked] == eTypeSign.U)
                {
                    StartButtonFlag = true;
                }
            }
            else
            {
                if (m_CheckersBoardManagment.Board[rowOfButtonClicked, colOfButtonClicked] == eTypeSign.X ||
                    m_CheckersBoardManagment.Board[rowOfButtonClicked, colOfButtonClicked] == eTypeSign.K)
                {
                    StartButtonFlag = true;
                }
            }

            if (StartButtonFlag)
            {
                i_ButtonClicked.BackColor = Color.Green;
                m_ButtonStartMove = i_ButtonClicked;
                m_TurnFlag = true;
            }
        }

        private void ActionOfFinishMove(Button i_ButtonStartOfMove, Button i_ButtonClicked)
        {
            int colSourcePosition = (i_ButtonStartOfMove.Left - m_Board[0, 0].Location.X) / k_ButtonSize;
            int rowSourcePosition = (i_ButtonStartOfMove.Location.Y - m_Board[0, 0].Location.Y) / k_ButtonSize;
            int colChoosePosition = (i_ButtonClicked.Left - m_Board[0, 0].Location.X) / k_ButtonSize;
            int rowChoosePosition = (i_ButtonClicked.Location.Y - m_Board[0, 0].Location.Y) / k_ButtonSize;
            bool IsSourceIsChoose = i_ButtonStartOfMove.Equals(i_ButtonClicked);
            if (IsSourceIsChoose)
            {
                i_ButtonStartOfMove.BackColor = Color.Wheat;
                m_TurnFlag = false;
            }
            else
            {
                Move move = new Move( rowSourcePosition,colSourcePosition,rowChoosePosition, colChoosePosition);
				eActionState ActionState = m_CheckersBoardManagment.CheckingMovementState(move);

				switch (ActionState)
                {
                    case eActionState.IlegalMove:
                        ShowTryAgainMessage("Ilegal Move!");
                        break;
                    case eActionState.NeedToEat:
                        ShowTryAgainMessage("You need to eat first");
                        break;
                    case eActionState.MoveIsPossible:
                        m_CheckersBoardManagment.DoMove(move);
                        break;
                    default: break;
                }

                i_ButtonStartOfMove.BackColor = Color.Wheat;
                m_TurnFlag = false;
            }
        }

        private void ShowTryAgainMessage(string i_Message)
        {
		
            MessageBox.Show(
                     "Wrong Move! \n Please try again....",
                      i_Message,
                     MessageBoxButtons.OK);
        }
        private void BoardChanged(object sender, IsBoardChangedEvent e)
        {
			m_Board[e.Move.StartCol, e.Move.StartRow].Text = string.Empty.ToString();
            m_Board[e.Move.EndCol, e.Move.EndRow].Text = SymbolOfButton(e.SignOfEndPos);
            if (e.IsCanEat)
            {
				m_Board[e.ClearLastColPos, e.ClearLastRowPos].Text = string.Empty.ToString();
            }
        }

        private void GameOver(object sender, IsGameOverEvent e)
        {
            bool EndOfGame = false;
            m_Board[e.LastMove.StartCol, e.LastMove.StartRow].BackColor = Color.White;
            switch (e.GameOverStatusCode)
            {
                case eResultOfGame.DrawResult:
                    EndOfGame = showMessage("Tie");
                    break;
                case eResultOfGame.User1Winner:
                    EndOfGame = showMessage(m_CheckersBoardManagment.User1.Name + " Won!");
                    break;
                case eResultOfGame.User2Winner:
                    EndOfGame = showMessage(m_CheckersBoardManagment.User2.Name + " Won!");
                    break;
                default: break;
            }

            if (EndOfGame)
            {
                this.Close();
            }
            else
            {
                m_TurnFlag = false;
                UserLabelUpdate();
                BoardPrint();
            }
        }
		
        private bool showMessage(string i_Message)
        {
            string message = string.Format("{0}{1} Another Round?", i_Message, Environment.NewLine);
            return MessageBox.Show(
            message,
               "Damka",
           MessageBoxButtons.YesNo) == DialogResult.No;
        }



    }


}
