using System;
using System.Collections.Generic;
using System.Text;


namespace Logic
{
	public enum eTypeSign
	{
		EMPTY,
		O,
		U,
		X,
		K,
	}
	public enum eActionState
	{
		MoveIsPossible,
		NeedToEat,
		IlegalMove
	}
	public enum eResultOfGame
	{
		User1Winner,
		User2Winner,
		DrawResult
	}
	public enum eUserType
	{
		Computer,
		User
	}
	class Enums
	{

	
	}
}
