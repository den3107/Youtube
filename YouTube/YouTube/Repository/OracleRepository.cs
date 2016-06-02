using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouTube.Types;

namespace YouTube.Repository
{
    public class OracleRepository : IRepository
    {
        private readonly String connectionString  = "User Id=YOUTUBE;Password=YOUTUBE;Data Source=localhost";

        public void AddChannelToUser(string email, Channel channel)
        {
            throw new NotImplementedException();
        }

        public void AddCommentToVideo(int videoId, Comment comment)
        {
            throw new NotImplementedException();
        }

        public void AddDownVoteToComment(int commentId, int videoId)
        {
            throw new NotImplementedException();
        }

        public void AddDownVoteToVideo(int videoId)
        {
            throw new NotImplementedException();
        }

        public void AddPlaylistToChannel(int channelId, Playlist playlist)
        {
            throw new NotImplementedException();
        }

        public void AddReplytoComment(int commentId, int videoId, Comment reply)
        {
            throw new NotImplementedException();
        }

        public void AddSubscriptionToChannel(int channelId, int subscriptionId)
        {
            throw new NotImplementedException();
        }

        public void AddUpVoteToComment(int commentId, int videoId)
        {
            throw new NotImplementedException();
        }

        public void AddUpVoteToVideo(int videoId)
        {
            throw new NotImplementedException();
        }

        public void AddVideoToChannel(int channelId, Video video)
        {
            throw new NotImplementedException();
        }

        public void AddVideoToPlaylist(int playlistId, Video video)
        {
            throw new NotImplementedException();
        }

        public void AddViewToVideo(int videoId)
        {
            throw new NotImplementedException();
        }

        public void EditAboutOfChannel(int channelId, string about)
        {
            throw new NotImplementedException();
        }

        public void EditContentOfComment(int commentId, int videoId, string content)
        {
            throw new NotImplementedException();
        }

        public void EditDescriptionOfPlaylist(int playlistId, string description)
        {
            throw new NotImplementedException();
        }

        public void EditDescriptionOfVideo(int videoId, string description)
        {
            throw new NotImplementedException();
        }

        public void EditTitleOfPlaylist(int playlistId, string title)
        {
            throw new NotImplementedException();
        }

        public void EditTitleOfVideo(int videoId, string title)
        {
            throw new NotImplementedException();
        }

        public void RemoveDownVoteToComment(int commentId, int videoId)
        {
            throw new NotImplementedException();
        }

        public void RemoveDownVoteToVideo(int videoId)
        {
            throw new NotImplementedException();
        }

        public void RemoveSubscriptionFromChannel(int channelId, int subscriptionId)
        {
            throw new NotImplementedException();
        }

        public void RemoveUpVoteToComment(int commentId, int videoId)
        {
            throw new NotImplementedException();
        }

        public void RemoveUpVoteToVideo(int videoId)
        {
            throw new NotImplementedException();
        }

        public void RemoveVideoFromPlaylist(int playlistId, int videoId)
        {
            throw new NotImplementedException();
        }
    }
}