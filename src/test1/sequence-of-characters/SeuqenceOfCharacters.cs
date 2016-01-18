using System;
using System.Collections.Generic;

namespace test1
{
	public class SeuqenceOfCharacters : ISequenceOfCharacters
	{
		ISet<ICharacter> characters = new SortedSet<ICharacter> ();
		List<ICharacter> sequence = new List<ICharacter>();

		public SeuqenceOfCharacters (string seq)
		{
			foreach (char c in seq)
			{
				ICharacter ic = new Character (new string(c, 1));
				if (characters.Contains (ic) == false) {
					characters.Add (ic);
				}
				this.sequence.Add(ic);
			}
		}

		#region ISequenceOfCharacters implementation

		ICharacter ISequenceOfCharacters.this [IPosition idx] {
			get {
				return sequence [idx.Offset];
			}
		}

		#endregion
	}
}

