namespace Youtube.Types
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class ChatMessage
	{
		public int MessageID { get; private set; }

		public string Content { get; private set; }

		public Channel Author { get; private set; }

	}
}

