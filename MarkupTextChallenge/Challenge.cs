using System;
using System.Collections.Generic;
using System.Text;

namespace MarkupTextChallenge 
{
	/*
	* N: length of text
	* M: number of targets
	* K: number of matches
	*/
	class Challenge 
	{
		/// <summary>
		/// Replaces all matches in input with <mark>match</mark>
		/// </summary>
		public static string MarkupString(string input, List<string> targets) 
		{
			const string tagName = "mark";
			string tagOpen = String.Format ("<{0}>", tagName),
				   tagClose = String.Format ("</{0}>", tagName);

			Trie trie = new Trie(targets);
			List<Match> matches = trie.Match(input);
			Dictionary<int, int> matched = new Dictionary<int, int>();
			int matchCounter = 1;

			// sort descending by length
			// O(K log K)
			matches.Sort((match1, match2) => match1.Value.Length.CompareTo(match2.Value.Length) * -1);

			// mark each index to be matched or not
			// O(K * length of match)
			// which i assume < 30
			// O(K)
			foreach (Match match in matches) 
			{
				bool canTake = true;

				// check if it overlaps with some bigger match
				for (int i = match.Index; i < match.Index + match.Value.Length; i++) 
				{
					if (matched.ContainsKey(i)) 
					{
						canTake = false;
						break;
					}
				}

				// not overlapped
				if (canTake)
				{
					for (int i = match.Index; i < match.Index + match.Value.Length; i++) 
					{
						matched[i] = matchCounter;
					}

					matchCounter++;
				}
			}

			StringBuilder resultBuilder = new StringBuilder();
			int currentMatchID = -1;

			// build string that contains the <tags>
			// O(N)
			for (int i = 0; i < input.Length; i++) 
			{
				int matchValue = matched.ContainsKey (i) ? matched [i] : -1;

				if (currentMatchID == -1 && matchValue != -1) // open tag
				{
					resultBuilder.Append(tagOpen + input[i]);
					currentMatchID = matched[i];
				}
				else if (currentMatchID != -1 && matchValue != currentMatchID) // close tag
				{
					resultBuilder.Append(tagClose);
					i--;
					currentMatchID = -1;
				}
				else
				{
					resultBuilder.Append(input[i]);
				}
			}

			// close tag if a match is at the end
			if (currentMatchID != -1)
			{
				resultBuilder.Append(tagClose);
			}

			return resultBuilder.ToString();
		}
	}
}