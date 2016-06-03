namespace Youtube.Types
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Comment
	{
		public int CommentID { get; private set; }

		public DateTime UploadDate { get; private set; }

		public string Content { get; private set; }

		public int UpVotes { get; private set; }

		public int DownVotes { get; private set; }

		public bool IsReply { get; private set; }

		public IEnumerable<Comment> Replies { get; private set; }

		public Channel Author { get; private set; }

		public void RemoveUpVote()
		{
			throw new System.NotImplementedException();
		}

		public void RemoveDownVote()
		{
			throw new System.NotImplementedException();
		}

		public void EditContent(string content)
		{
			throw new System.NotImplementedException();
		}

		public void AddUpVote()
		{
			throw new System.NotImplementedException();
		}

		public void AddDownVote()
		{
			throw new System.NotImplementedException();
		}

		public void AddReply(Comment reply)
		{
			throw new System.NotImplementedException();
		}

	}
}

