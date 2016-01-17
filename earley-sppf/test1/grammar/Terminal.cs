using System;

namespace test1
{
	public class Terminal : ISymbol
	{
		ICharacter ic;
		public Terminal (ICharacter ic)
		{
			this.ic = ic;
		}
		public string Name { get; set; }

		/// <remarks>
		/// public virtual string Object.ToString()
		/// </remarks>
		public override string ToString()
		{
			return ((Character)ic).ToString();
		}
	}
}

