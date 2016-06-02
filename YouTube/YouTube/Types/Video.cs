using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouTube.Repository;
using YouTube.RepositoryDAL;

namespace YouTube.Types
{
    public class Video
    {
        public String Description { get; private set; }
        public int DownVotes { get; private set; }
        public String Title { get; private set; }
        public DateTime UploadDate { get; private set; }
        public int UpVotes { get; private set; }
        public int VideoId { get; private set; }
        public String VideoLink { get; private set; }
        public int Views { get; private set; }
        public Channel Creator { get; private set; }
        public List<Comment> Comments { get; private set; }

        private DAL dal = new DAL(new OracleRepository());

        public Video(String description, String title, DateTime uploadDate, int videoId, String videoLink, Channel creator, int downVotes = 0, int upVotes = 0, int views = 0, List<Comment> comments = null)
        {
            Description = description;
            Title = title;
            UploadDate = uploadDate;
            VideoId = videoId;
            VideoLink = videoLink;
            Creator = creator;
            DownVotes = downVotes;
            UpVotes = upVotes;
            Views = views;
            Comments = comments ?? new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            dal.AddCommentToVideo(VideoId, comment);
            Comments.Add(comment);
        }

        public void AddDownVote()
        {
            dal.AddDownVoteToVideo(VideoId);
            DownVotes++;
        }

        public void AddUpVote()
        {
            dal.AddUpVoteToVideo(VideoId);
            UpVotes++;
        }

        public void AddView()
        {
            dal.AddViewToVideo(VideoId);
            Views++;
        }

        public void EditDescription(String description)
        {
            dal.EditDescriptionOfVideo(VideoId, description);
            Description = description;
        }

        public void EditTitle(String title)
        {
            dal.EditTitleOfVideo(VideoId, title);
            Title = title;
        }

        public void RemoveDownVote()
        {
            dal.RemoveDownVoteToVideo(VideoId);
            DownVotes--;
        }

        public void RemoveUpVote()
        {
            dal.RemoveUpVoteToVideo(VideoId);
            UpVotes--;
        }
    }
}