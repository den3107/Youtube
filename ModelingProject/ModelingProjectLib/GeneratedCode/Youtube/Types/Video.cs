namespace Youtube.Types
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Video
	{
		public int VideoID { get; private set; }

		public string Title { get; private set; }

		public int Views { get; private set; }

		public string Description { get; private set; }

		public DateTime UploadDate { get; private set; }

		public int UpVotes { get; private set; }

		public int DownVotes { get; private set; }

		public string VideoLink { get; private set; }

		public IEnumerable<Comment> Comments { get; private set; }

		public Channel Creator { get; private set; }

		public void EditDescription(string description)
		{
			throw new System.NotImplementedException();
		}

		public void AddDownVote()
		{
			throw new System.NotImplementedException();
		}

		public void RemoveDownVote()
		{
			throw new System.NotImplementedException();
		}

		public void EditTitle(string title)
		{
			throw new System.NotImplementedException();
		}

		public void AddUpVote()
		{
			throw new System.NotImplementedException();
		}

		public void RemoveUpVote()
		{
			throw new System.NotImplementedException();
		}

		public void AddView()
		{
			throw new System.NotImplementedException();
		}

		public void AddComment(Comment comment)
		{
			throw new System.NotImplementedException();
		}

	}
}

