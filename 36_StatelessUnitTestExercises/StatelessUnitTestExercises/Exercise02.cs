namespace StatelessUnitTestExercises
{
	public class Exercise02
	{
		// 1. Read the SurroundWithTag docs.
		// 2. Complete the SurroundWithTag method. You're only allowed to confirm it's working by running
		// the accompanying test in Exercise02Test.
		// 3. The test is incomplete. It doesn't account for all scenarios. Complete the test to ensure
		// SurroundWithTag is 100% correct.

		/// <summary>
		///	Given two strings: some text and a tag name, return a string that embeds the text in a pseudo-HTML tag.
		///	Examples:
		///	"abc", "boom" -> "<boom>abc</boom>"
		///	"Cats are mean.", "fact" -> "<fact>Cats are mean.</fact>"
		///	"this is just text", "" -> "this is just text"
		///	null, "span" -> "<span></span>"
		///	"splendid", null -> splendid
		/// </summary>
		/// <param name="text">string value to be surrounded by an HTML tag</param>
		/// <param name="tagName">the HTML tag name</param>
		/// <returns>string in the form: <tagName>text</tagName></returns>
		public static string SurroundWithTag(string text, string tagName)
		{
			if (string.IsNullOrEmpty(tagName))
			{
				return text;
			}
			return $"<{tagName}>{text}</{tagName}>";
		}
	}
}
