using System;

namespace test1
{
	/// <remarks>
	/// E -> T
	/// E -> E+T
	/// T -> P
	/// T -> T*P
	/// P -> a		
	///	The terminal symbols are {a,+,.},
	///	the nonterminals are {E, T, P}, 
	///	and the root is E. 
	/// </remarks>
	public class ExampleGrammar : Grammar
	{
		NonTerminal E = new NonTerminal("E");
		NonTerminal T = new NonTerminal("T");
		NonTerminal P = new NonTerminal("P");
		Terminal a = new Terminal(new Character("a"));
		Terminal plus = new Terminal(new Character("+"));
		Terminal star = new Terminal(new Character("*"));
		public ExampleGrammar ()
		{
			RootNonTerminal = E;
			this.nonTerminals.Add (E);
			this.nonTerminals.Add (T);
			this.nonTerminals.Add (P);
			this.terminals.Add (a);
			this.terminals.Add (plus);
			this.terminals.Add (star);
			Production E1 = new Production (E, new RewriteRule(T));
			Production E2 = new Production (E, new RewriteRule(E, plus, T));
			Production T1 = new Production (T, new RewriteRule(P));
			Production T2 = new Production (T, new RewriteRule(T, star, P));
			Production P1 = new Production (P, new RewriteRule(a));
			this.rules.Add (E1);
			this.rules.Add (E2);
			this.rules.Add (T1);
			this.rules.Add (T2);
			this.rules.Add (P1);
		}
	}
}

