namespace Youtube.Types
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Livestream
	{
		public IEnumerable<ChatMessage> Messages { get; private set; }

		public Channel Streamer { get; private set; }

		public void AddMessage(ChatMessage message)
		{
			throw new System.NotImplementedException();
		}

	}
}

