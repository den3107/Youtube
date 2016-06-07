//-----------------------------------------------------------------------
// <copyright file="Comment.cs" company="YouTube">
//     Copyright (c) YouTube. All rights reserved
// </copyright>
//-----------------------------------------------------------------------

namespace YouTube.Types
{
    using System;
    using System.Collections.Generic;
    using Repository;
    using RepositoryDAL;

    /// <summary>
    /// Comment object</summary>
    public class Comment
    {
        /// <summary>
        /// DAL for database access</summary>
        private DAL dal = new DAL(new OracleRepository());

        /// <summary>
        /// Initializes a new instance of the <see cref="Comment"/> class.</summary>
        /// <param name="commentId">Comment's ID</param>
        /// <param name="content">Comment's content</param>
        /// <param name="uploadDate">Comment's upload date</param>
        /// <param name="author">Comment's author</param>
        /// <param name="videoId">Comment's parent video ID</param>
        /// <param name="downVotes">Comment's down votes</param>
        /// <param name="isReply">Is comment a reply on other comment</param>
        /// <param name="upVotes">Comment's up votes</param>
        /// <param name="replies">Comment's replies</param>
        public Comment(int commentId, string content, DateTime uploadDate, Channel author, int videoId, int downVotes = 0, bool isReply = false, int upVotes = 0, List<Comment> replies = null)
        {
            this.CommentId = commentId;
            this.Content = content;
            this.UploadDate = uploadDate;
            this.Author = author;
            this.VideoId = videoId;
            this.DownVotes = downVotes;
            this.IsReply = isReply;
            this.UpVotes = upVotes;
            this.Replies = replies ?? new List<Comment>();
        }

        /// <summary>
        /// Gets comment's ID</summary>
        public int CommentId { get; private set; }

        /// <summary>
        /// Gets comment's content</summary>
        public string Content { get; private set; }

        /// <summary>
        /// Gets comment's down votes</summary>
        public int DownVotes { get; private set; }

        /// <summary>
        /// Gets a value indicating whether comment is a reply on other comment or not</summary>
        public bool IsReply { get; private set; }

        /// <summary>
        /// Gets comment's upload date</summary>
        public DateTime UploadDate { get; private set; }

        /// <summary>
        /// Gets comment's up votes</summary>
        public int UpVotes { get; private set; }

        /// <summary>
        /// Gets comment's parent video ID</summary>
        public int VideoId { get; private set; }

        /// <summary>
        /// Gets comment's author</summary>
        public Channel Author { get; private set; }

        /// <summary>
        /// Gets comment's replies</summary>
        public List<Comment> Replies { get; private set; }

        /// <summary>
        /// Adds down vote to comment.</summary>
        public void AddDownVote()
        {
            this.dal.AddDownVoteToComment(this.CommentId, this.VideoId);
            this.DownVotes++;
        }

        /// <summary>
        /// Adds reply to comment.</summary>
        /// <param name="reply">Comment to add as reply</param>
        public void AddReply(Comment reply)
        {
            this.dal.AddReplytoComment(this.CommentId, reply);
            this.Replies.Add(reply);
        }

        /// <summary>
        /// Adds up vote to comment.</summary>
        public void AddUpVote()
        {
            this.dal.AddUpVoteToComment(this.CommentId, this.VideoId);
            this.UpVotes++;
        }

        /// <summary>
        /// Edit content of comment.</summary>
        /// <param name="content">New content</param>
        public void EditContent(string content)
        {
            this.dal.EditContentOfComment(this.CommentId, this.VideoId, content);
            this.Content = content;
        }

        /// <summary>
        /// Removes down vote from comment.</summary>
        public void RemoveDownVote()
        {
            this.dal.RemoveDownVoteFromComment(this.CommentId, this.VideoId);
            this.DownVotes--;
        }

        /// <summary>
        /// Removes up vote from comment.</summary>
        public void RemoveUpVote()
        {
            this.dal.RemoveUpVoteFromComment(this.CommentId, this.VideoId);
            this.UpVotes--;
        }
    }
}