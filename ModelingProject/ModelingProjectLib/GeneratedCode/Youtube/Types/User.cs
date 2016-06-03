namespace Youtube.Types
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class User
	{
		public string Email { get; private set; }

		public IEnumerable<Channel> Channels { get; private set; }

		public void AddChannel(Channel channel)
		{
			throw new System.NotImplementedException();
		}

	}
}

