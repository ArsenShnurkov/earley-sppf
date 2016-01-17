using System;
using System.Collections.Generic;

namespace test1
{
	public class EbnfExpression
	{
		List<ISymbol> symbols = new List<ISymbol>();
		public EbnfExpression (params ISymbol[] symbols)
		{
			foreach (var s in symbols) {
				this.symbols.Add (s);
			}
		}
		public IEnumerable<ISymbol> Symbols {get { return this.symbols; } }
	}
}

