//-----------------------------------------------------------------------
// <copyright file="Video.cs" company="YouTube">
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
    /// Video object</summary>
    public class Video
    {
        /// <summary>
        /// DAL for database access</summary>
        private DAL dal = new DAL(new OracleRepository());

        /// <summary>
        /// Initializes a new instance of the <see cref="Video"/> class.</summary>
        /// <param name="description">Video's description</param>
        /// <param name="title">Video's title</param>
        /// <param name="uploadDate">Video's upload date</param>
        /// <param name="videoId">Video's ID</param>
        /// <param name="videoLink">Video's link</param>
        /// <param name="creator">Video's creator</param>
        /// <param name="downVotes">Video's down votes</param>
        /// <param name="upVotes">Video's up votes</param>
        /// <param name="views">Video's views</param>
        /// <param name="comments">Video's comments</param>
        public Video(string description, string title, DateTime uploadDate, int videoId, string videoLink, Channel creator, int downVotes = 0, int upVotes = 0, int views = 0, List<Comment> comments = null)
        {
            this.Description = description;
            this.Title = title;
            this.UploadDate = uploadDate;
            this.VideoId = videoId;
            this.VideoLink = videoLink;
            this.Creator = creator;
            this.DownVotes = downVotes;
            this.UpVotes = upVotes;
            this.Views = views;
            this.Comments = comments ?? new List<Comment>();
        }

        /// <summary>
        /// Gets video's description</summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets video's down votes</summary>
        public int DownVotes { get; private set; }

        /// <summary>
        /// Gets video's title</summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets video's upload date</summary>
        public DateTime UploadDate { get; private set; }

        /// <summary>
        /// Gets video's up votes</summary>
        public int UpVotes { get; private set; }

        /// <summary>
        /// Gets video's ID</summary>
        public int VideoId { get; private set; }

        /// <summary>
        /// Gets video's link</summary>
        public string VideoLink { get; private set; }

        /// <summary>
        /// Gets video's views</summary>
        public int Views { get; private set; }

        /// <summary>
        /// Gets video's creator</summary>
        public Channel Creator { get; private set; }

        /// <summary>
        /// Gets video's comments</summary>
        public List<Comment> Comments { get; private set; }

        /// <summary>
        /// Adds comment to video.</summary>
        /// <param name="comment">Comment to add</param>
        public void AddComment(Comment comment)
        {
            this.dal.AddCommentToVideo(comment);
            this.Comments.Add(comment);
        }

        /// <summary>
        /// Adds down vote to comment.</summary>
        public void AddDownVote()
        {
            this.dal.AddDownVoteToVideo(this.VideoId);
            this.DownVotes++;
        }

        /// <summary>
        /// Adds up vote to comment.</summary>
        public void AddUpVote()
        {
            this.dal.AddUpVoteToVideo(this.VideoId);
            this.UpVotes++;
        }

        /// <summary>
        /// Adds view to comment.</summary>
        public void AddView()
        {
            this.dal.AddViewToVideo(this.VideoId);
            this.Views++;
        }

        /// <summary>
        /// Edits description of video.</summary>
        /// <param name="description">New description</param>
        public void EditDescription(string description)
        {
            this.dal.EditDescriptionOfVideo(this.VideoId, description);
            this.Description = description;
        }

        /// <summary>
        /// Edits title of video.</summary>
        /// <param name="title">New title</param>
        public void EditTitle(string title)
        {
            this.dal.EditTitleOfVideo(this.VideoId, title);
            this.Title = title;
        }

        /// <summary>
        /// Removes down vote from comment.</summary>
        public void RemoveDownVote()
        {
            this.dal.RemoveDownVoteFromVideo(this.VideoId);
            this.DownVotes--;
        }

        /// <summary>
        /// Removes up vote from comment.</summary>
        public void RemoveUpVote()
        {
            this.dal.RemoveUpVoteFromVideo(this.VideoId);
            this.UpVotes--;
        }
    }
}