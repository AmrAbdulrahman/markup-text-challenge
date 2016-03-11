
namespace MarkupTextChallenge 
{
	/// <summary>
	/// This class encapsulates a match value and its index
	/// I use this to calculate matches start/end indicies
	/// then spot matches intersections to display the longest one
	/// </summary>
	class Match 
	{
		public string Value {get; set;}
		public int Index {get; set;}
	}
}
