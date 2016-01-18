using System;

namespace test1
{
	public class Match
	{
		public Node Node { get {return node;}}
		Node node;
		public IPosition Index {get { return position; }}
		IPosition position;
		public int Count {get { return count; } }
		int count;
		public Match (Node node, IPosition pos, int count)
		{
			this.node = node;
			this.position = pos;
			this.count = count;
		}
	}
}

