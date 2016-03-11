using System.Collections;
using System.Collections.Generic;

namespace MarkupTextChallenge 
{
	/// <summary>
	/// Trie node
	/// </summary>
	/// <remarks>
	/// We don't need to make a flag 'isEnd', we use the 'values' list instead
	/// if it has one or more values, then it's an end
	/// </remarks>
	class Node 
	{
		private char character;
		private Node parent;
		private Dictionary<char, Node> children = new Dictionary<char, Node>();
		private List<string> values = new List<string>(); // self + inherited from failures

		// empty constructor for root node
		public Node()
		{ }

		public Node(char character, Node parent) 
		{
			this.character = character;
			this.parent = parent;
		}

		public char Character
		{
			get { return character; }
		}

		public Node Parent 
		{
			get { return parent; }
		}

		public Node Fail 
		{
			get; set;
		}

		// flexability to access the node children like a dictionary
		public Node this[char c] 
		{
			get
			{
				return children.ContainsKey(c) ? children[c] : null; 
			}

			set
			{
				children[c] = value; 
			}
		}

		public List<string> Values 
		{
			get { return values; }
		}

		public Dictionary<char, Node> Children 
		{
			get { return children; }
		}
	}	
}
