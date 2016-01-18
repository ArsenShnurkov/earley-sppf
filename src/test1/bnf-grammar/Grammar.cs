using System;
using System.Collections.Generic;

namespace test1
{
	/// <remarks>
	/// Let G = ( V, Sigma, P, S) denote an	arbitrary context-free grammar., where 
	/// V is the vocabulary (V-Sigma is the set of non-terminal symbols, denoted by N.), 
	/// Sigma the set of terminal symbols,
	/// P a finite set of productions, and
	/// S the start symbol.
	/// (q) J. M. 1. M. Leo, 2. Informal Description
	/// </summary>
	public class Grammar
	{
		protected List<NonTerminal> nonTerminals = new List<NonTerminal> ();
		protected List<Terminal> terminals = new List<Terminal> ();
		protected List<Production> rules = new List<Production>();
		public NonTerminal RootNonTerminal { get; set; }

		public IEnumerable<Terminal> Terminals { get { return terminals; } }
		public IEnumerable<NonTerminal> NonTerminals { get { return nonTerminals; } }
		public IEnumerable<Production> Productions { get { return rules; } }

		public Grammar ()
		{
		}

		/// <remarks>
		/// The productions with a particular nonterminal D on their left sides
		/// are called the alternatives of D.
		/// </remarks>
		IEnumerable<Production> GetAlternatives(NonTerminal D)
		{
			var list = new SortedSet<Production> ();
			foreach (var p in this.Productions)
			{
				if (p.LeftPart == D) {
					list.Add (p);
				}
			}
			return list;
		}
	}
}

