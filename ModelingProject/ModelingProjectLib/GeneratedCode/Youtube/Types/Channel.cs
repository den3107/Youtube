namespace Youtube.Types
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Channel
	{
		public int ChannelID { get; private set; }

		public string Name { get; private set; }

		public string About { get; private set; }

		public IEnumerable<Playlist> Playlists { get; private set; }

		public IEnumerable<Video> Videos { get; private set; }

		public Livestream Livestream { get; private set; }

		public void AddSubscription(Channel channel)
		{
			throw new System.NotImplementedException();
		}

		public void RemoveSubscription(Channel channel)
		{
			throw new System.NotImplementedException();
		}

		public void AddPlaylist(Playlist playlist)
		{
			throw new System.NotImplementedException();
		}

		public void AddVideo(Video video)
		{
			throw new System.NotImplementedException();
		}

		public void StartLivestream(Livestream livestream)
		{
			throw new System.NotImplementedException();
		}

		public void EndLivestream()
		{
			throw new System.NotImplementedException();
		}

		public void EditAbout(string about)
		{
			throw new System.NotImplementedException();
		}

	}
}

