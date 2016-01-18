using System;

namespace test1
{
	/// <remarks>
	/// There is a finite set of productions or rewriting rules
	/// of the form A --~ a. 
	/// </remarks>
	public class Production
	{
		public Production (NonTerminal t, RewriteRule e)
		{
			this.LeftPart = t;
			this.RightPart = e;
		}
		public NonTerminal LeftPart { get; set;}
		public RewriteRule RightPart { get; set;}
	}
}

