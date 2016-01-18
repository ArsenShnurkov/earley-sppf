using System;
using System.Text;

namespace test1
{
	/// <remarks>
	/// Earley's dot notation: given a production X → αβ, 
	/// the notation X → α • β represents a condition 
	/// in which α has already been parsed and β is expected.
	/// </remarks>
	public class StateOfProduction
	{
		Production production;
		int dotPosition;
		public StateOfProduction (Production production, int dotPosition)
		{
			this.production = production;
			this.dotPosition = dotPosition;
		}
		public override string ToString()
		{
			var res = new StringBuilder ();
			int index = 0;
			foreach (var symbol in production.RightPart.Symbols)
			{
				if (index > 0) {
					res.Append (" ");
				}
				if (index == dotPosition) {
					string dot = "*";
					res.Append(dot);
				}
				string part = symbol.ToString ();
				res.Append(part);
				index++;
			}
			return res.ToString();
		}
	}
}

