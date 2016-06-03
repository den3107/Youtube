namespace Youtube.Types
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Playlist
	{
		public int PlaylistID { get; private set; }

		public string Title { get; private set; }

		public string Description { get; private set; }

		public DateTime UploadDate { get; private set; }

		public IEnumerable<Video> Videos { get; private set; }

		public Channel Creator { get; private set; }

		public void AddVideo(Video video)
		{
			throw new System.NotImplementedException();
		}

		public void RemoveVideo(Video video)
		{
			throw new System.NotImplementedException();
		}

		public void MoveDown(Video video)
		{
			throw new System.NotImplementedException();
		}

		public void MoveDown(int index)
		{
			throw new System.NotImplementedException();
		}

		public void MoveUP(Video video)
		{
			throw new System.NotImplementedException();
		}

		public void MoveUp(int index)
		{
			throw new System.NotImplementedException();
		}

		public void EditDescription(string description)
		{
			throw new System.NotImplementedException();
		}

		public void EditTitle(string title)
		{
			throw new System.NotImplementedException();
		}

	}
}

