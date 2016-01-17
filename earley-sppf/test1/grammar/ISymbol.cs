using System;

namespace test1
{
	/// <summary>
	/// This class is derived from Object,
	/// and thus have ToString virtual method.
	/// Both Terminal and NonTerminal are descendants of this class
	/// This allows to conver Terminals and NonTerminals
	/// to string in a uniform way
	/// when printing Production (rewriting rule)
	/// </summary>
	public interface ISymbol
	{
		string ToString();
	}
}

