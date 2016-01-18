using System;

namespace test1
{
	public class NonTerminal : ISymbol
	{
		public NonTerminal (string name)
		{
			this.Name = name;
		}

		/// <remarks>
		/// Name of nonterminal can be used, for example,
		/// when specifying root production (rewriting rule) of grammar
		/// </remarks>
		/// <value>The name.</value>
		public string Name { get; set; }
	}
}
