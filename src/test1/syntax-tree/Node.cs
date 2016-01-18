using System;
using System.Collections.Generic;

namespace test1
{
	public class Node
	{
		public string Name { get; set; }
		public IEnumerable<Node> Nodes {get { return nodes; }}
		List<Node> nodes = new List<Node>();
		public Node ()
		{
		}
	}
}

