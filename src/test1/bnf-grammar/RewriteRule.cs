using System;
using System.Collections.Generic;

namespace test1
{
	public class RewriteRule
	{
		List<ISymbol> symbols = new List<ISymbol>();
		public RewriteRule (params ISymbol[] symbols)
		{
			foreach (var s in symbols) {
				this.symbols.Add (s);
			}
		}
		public IEnumerable<ISymbol> Symbols {get { return this.symbols; } }
	}
}

