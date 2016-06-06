using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouTube.Repository;
using YouTube.RepositoryDAL;

namespace YouTube.Types
{
    public class Comment
    {
        public int CommentId { get; private set; }
        public String Content { get; private set; }
        public int DownVotes { get; private set; }
        public bool IsReply { get; private set; }
        public DateTime UploadDate { get; private set; }
        public int UpVotes { get; private set; }
        public int VideoId { get; private set; }
        public Channel Author { get; private set; }
        public List<Comment> Replies { get; private set; }

        private DAL dal = new DAL(new OracleRepository());

        public Comment(int commentId, String content, DateTime uploadDate, Channel author, int videoId, int downVotes = 0, bool isReply = false, int upVotes = 0, List<Comment> replies = null)
        {
            CommentId = commentId;
            Content = content;
            UploadDate = uploadDate;
            Author = author;
            VideoId = videoId;
            DownVotes = downVotes;
            IsReply = isReply;
            UpVotes = upVotes;
            Replies = replies ?? new List<Comment>();
        }

        public void AddDownVote()
        {
            dal.AddDownVoteToComment(CommentId, VideoId);
            DownVotes++;
        }

        public void AddReply(Comment reply)
        {
            dal.AddReplytoComment(CommentId, reply);
            Replies.Add(reply);
        }

        public void AddUpVote()
        {
            dal.AddUpVoteToComment(CommentId, VideoId);
            UpVotes++;
        }

        public void EditContent(String content)
        {
            dal.EditContentOfComment(CommentId, VideoId, content);
            Content = content;
        }

        public void RemoveDownVote()
        {
            dal.RemoveDownVoteToComment(CommentId, VideoId);
            DownVotes--;
        }

        public void RemoveUpVote()
        {
            dal.RemoveUpVoteToComment(CommentId, VideoId);
            UpVotes--;
        }
    }
}