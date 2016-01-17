using System;

namespace test1
{
	public interface ISequenceOfCharacters
	{
		ICharacter this [IPosition idx]
		{
			get;
		}
	}
}

