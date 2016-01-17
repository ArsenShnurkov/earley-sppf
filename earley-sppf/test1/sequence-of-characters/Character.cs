using System;

namespace test1
{
	public class Character : ICharacter
	{
		string character;
		public Character(string character)
		{
			this.character = character;
		}
		public override string ToString()
		{
			return character;
		}
	}
}

