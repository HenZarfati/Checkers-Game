using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Logic;

namespace Interface
{
	public class CheckersStartGame
	{
		internal static void RunGame()
		{
            MyLogIn formInitializeGame = new MyLogIn();

			if (formInitializeGame.ShowDialog() == DialogResult.OK)
			{
				// if the initial parameters are not ok show a message
				if (formInitializeGame.FirstPlayerName.Length == 0 || (formInitializeGame.CheckBoxOfPlayer2IsChecked
					&& formInitializeGame.SecondPlayerName.Length == 0))
				{
					if (MessageBox.Show(
						"Invalid Parameters",
						"Please enter Parameters Again",
						MessageBoxButtons.RetryCancel,
						MessageBoxIcon.Error) == DialogResult.Retry)
					{
						RunGame();
					}
				}
				else
				{
					CheckersForm formCheckersGame = new CheckersForm(formInitializeGame);
					formCheckersGame.ShowDialog();
				}
			}
		}
	}
}
