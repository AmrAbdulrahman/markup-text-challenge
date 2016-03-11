using System.Collections.Generic;

// https://en.wikipedia.org/wiki/Aho%E2%80%93Corasick_algorithm
namespace MarkupTextChallenge 
{
	class Trie {
		private Node root = new Node();

		public Trie(List<string> words) 
		{
			ConstructTrie(words);
			BuildFailureLinks();
		}

		private void ConstructTrie(List<string> words) 
		{
			foreach (string word in words) 
			{
				Add(word);
			}
		}

		// adds string to trie
		private void Add(string word)
		{
			// start at the root
			Node node = root;

			// simple trie construction
			foreach (char character in word) 
			{
				Node child = node[character]; // get child node

				// no match
				if (child == null) 
				{
					child = node[character] = new Node(character, node); // make a new branch
				}

				node = child;
			}

			node.Values.Add(word);
		}

		// build failure links using BFS
		private void BuildFailureLinks() 
		{
			Queue<Node> queue = new Queue<Node>();
			queue.Enqueue(root);

			while (queue.Count > 0) 
			{
				Node node = queue.Dequeue();

				// 1) visit children
				foreach (Node child in node.Children.Values)
				{
					queue.Enqueue(child);
				}

				// 2) calculate failure function

				// case root: fail link of root is root
				if (node == root)
				{
					root.Fail = root;
					continue;
				}

				// start from parent because it's 'proper' suffix
				Node fail = node.Parent.Fail;

				// keep failing until we match the character or reach root
				while (fail[node.Character] == null && fail != root)
				{
					fail = fail.Fail;
				}

				// set fail node
				node.Fail = fail[node.Character] != null ? fail[node.Character] : root;

				// if it fails on itself, then make it fail on root
				if (node.Fail == node) 
				{
					node.Fail = root;
				}

				// 3) inherit matches
				node.Values.AddRange(node.Fail.Values);
			}
		}

		// matches text against trie and returns list of matches
		public List<Match> Match(string text)
		{
			Node node = root;
			List<Match> matches = new List<Match>();

			// O(N + M + K)
			// where
			// N: length of text
			// M: number of strings in the trie
			// K: number of matches
			for (int index = 0; index < text.Length; index++)
			{
				char character = text[index];

				// keep failing until we match character
				while (node[character] == null && node != root)
				{
					node = node.Fail;
				}

				node = node[character] != null ? node[character] : root;

				// O(K)
				foreach (string value in node.Values)
				{
					int matchIndex = index - value.Length + 1;
					Match match = new Match();
					match.Value = value;
					match.Index = matchIndex;
					matches.Add(match);
				}
			}

			return matches;
		}
	}
}