﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Youtube.Types
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Channel
	{
		public virtual int ChannelID
		{
			get;
			private set;
		}

		public virtual string Name
		{
			get;
			private set;
		}

		public virtual string About
		{
			get;
			private set;
		}

		public virtual IEnumerable<Playlist> Playlists
		{
			get;
			set;
		}

		public virtual IEnumerable<Video> Videos
		{
			get;
			set;
		}

		public virtual Livestream Livestream
		{
			get;
			set;
		}

		public virtual void AddSubscription(Channel channel)
		{
			throw new System.NotImplementedException();
		}

		public virtual void RemoveSubscription(Channel channel)
		{
			throw new System.NotImplementedException();
		}

		public virtual void AddPlaylist(Playlist playlist)
		{
			throw new System.NotImplementedException();
		}

		public virtual void AddVideo(Video video)
		{
			throw new System.NotImplementedException();
		}

		public virtual void StartLivestream(Livestream livestream)
		{
			throw new System.NotImplementedException();
		}

		public virtual void EndLivestream()
		{
			throw new System.NotImplementedException();
		}

		public virtual void EditAbout(string about)
		{
			throw new System.NotImplementedException();
		}

	}
}

