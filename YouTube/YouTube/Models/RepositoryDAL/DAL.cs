//-----------------------------------------------------------------------
// <copyright file="DAL.cs" company="YouTube">
//     Copyright (c) YouTube. All rights reserved
// </copyright>
//-----------------------------------------------------------------------

namespace YouTube.RepositoryDAL
{
    using System.Collections.Generic;
    using Repository;
    using Types;

    /// <summary>
    /// DAL to get data from specific repository</summary>
    public class DAL
    {
        /// <summary>
        /// Repository to get data from</summary>
        private IRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DAL"/> class.</summary>
        /// <param name="repository">Repository to use</param>
        public DAL(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Add channel to user.</summary>
        /// <param name="email">Email of user</param>
        /// <param name="channel">Channel to add</param>
        public void AddChannelToUser(string email, Channel channel)
        {
            this.repository.AddChannelToUser(email, channel);
        }

        /// <summary>
        /// Add comment to video (comment contains videoId).</summary>
        /// <param name="comment">Comment to add to video</param>
        public void AddCommentToVideo(Comment comment)
        {
            this.repository.AddCommentToVideo(comment);
        }

        /// <summary>
        /// Add down vote to comment.</summary>
        /// <param name="commentId">CommentId to add down vote to</param>
        /// <param name="videoId">VideoId comment is placed on</param>
        public void AddDownVoteToComment(int commentId, int videoId)
        {
            this.repository.AddDownVoteToComment(commentId, videoId);
        }

        /// <summary>
        /// Add down vote to video.</summary>
        /// <param name="videoId">VideoId to add down vote to</param>
        public void AddDownVoteToVideo(int videoId)
        {
            this.repository.AddDownVoteToVideo(videoId);
        }

        /// <summary>
        /// Add playlist to channel (playlist already contains channelId).</summary>
        /// <param name="playlist">Playlist to add</param>
        public void AddPlaylistToChannel(Playlist playlist)
        {
            this.repository.AddPlaylistToChannel(playlist);
        }

        /// <summary>
        /// Add reply to comment (reply contains videoId).</summary>
        /// <param name="commentId">CommentId to add reply to</param>
        /// <param name="reply">Reply to add to comment</param>
        public void AddReplytoComment(int commentId, Comment reply)
        {
            this.repository.AddReplytoComment(commentId, reply);
        }

        /// <summary>
        /// Add subscription to channel.</summary>
        /// <param name="channelId">ChannelId to add subscription to</param>
        /// <param name="subscriptionId">ChannelId of subscription</param>
        public void AddSubscriptionToChannel(int channelId, int subscriptionId)
        {
            this.repository.AddSubscriptionToChannel(channelId, subscriptionId);
        }

        /// <summary>
        /// Add up vote to comment.</summary>
        /// <param name="commentId">CommentId to add up vote to</param>
        /// <param name="videoId">VideoId comment is placed on</param>
        public void AddUpVoteToComment(int commentId, int videoId)
        {
            this.repository.AddUpVoteToComment(commentId, videoId);
        }

        /// <summary>
        /// Add up vote to video.</summary>
        /// <param name="videoId">VideoId to add up vote to</param>
        public void AddUpVoteToVideo(int videoId)
        {
            this.repository.AddUpVoteToVideo(videoId);
        }

        /// <summary>
        /// Add video to channel (video already contains channelId).</summary>
        /// <param name="video">Video to add</param>
        public void AddVideoToChannel(Video video)
        {
            this.repository.AddVideoToChannel(video);
        }

        /// <summary>
        /// Add video to playlist.</summary>
        /// <param name="playlistId">PlaylistId to add video to</param>
        /// <param name="videoId">Video to add</param>
        public void AddVideoToPlaylist(int playlistId, int videoId)
        {
            this.repository.AddVideoToPlaylist(playlistId, videoId);
        }

        /// <summary>
        /// Add view to video.</summary>
        /// <param name="videoId">VideoId to add view to</param>
        public void AddViewToVideo(int videoId)
        {
            this.repository.AddViewToVideo(videoId);
        }

        /// <summary>
        /// Change about of channel.</summary>
        /// <param name="channelId">ChannelId who's about must change</param>
        /// <param name="about">New about</param>
        public void EditAboutOfChannel(int channelId, string about)
        {
            this.repository.EditAboutOfChannel(channelId, about);
        }

        /// <summary>
        /// Edit content of comment.</summary>
        /// <param name="commentId">CommentId to change content of</param>
        /// <param name="videoId">VideoId comment was placed on</param>
        /// <param name="content">New content</param>
        public void EditContentOfComment(int commentId, int videoId, string content)
        {
            this.repository.EditContentOfComment(commentId, videoId, content);
        }

        /// <summary>
        /// Change description of video.</summary>
        /// <param name="videoId">VideoId to change description of</param>
        /// <param name="description">New description</param>
        public void EditDescriptionOfVideo(int videoId, string description)
        {
            this.repository.EditDescriptionOfVideo(videoId, description);
        }

        /// <summary>
        /// Change description of playlist.</summary>
        /// <param name="playlistId">PlaylistId to change description of</param>
        /// <param name="description">New description</param>
        public void EditDescriptionOfPlaylist(int playlistId, string description)
        {
            this.repository.EditDescriptionOfPlaylist(playlistId, description);
        }

        /// <summary>
        /// Change title of video.</summary>
        /// <param name="videoId">VideoId to change title of</param>
        /// <param name="title">New description</param>
        public void EditTitleOfVideo(int videoId, string title)
        {
            this.repository.EditTitleOfVideo(videoId, title);
        }

        /// <summary>
        /// Change title of playlist.</summary>
        /// <param name="playlistId">PlaylistId to change title of</param>
        /// <param name="title">New title</param>
        public void EditTitleOfPlaylist(int playlistId, string title)
        {
            this.repository.EditTitleOfPlaylist(playlistId, title);
        }

        /// <summary>
        /// Remove down vote from comment.</summary>
        /// <param name="commentId">CommentId to remove down vote from</param>
        /// <param name="videoId">VideoId comment is placed on</param>
        public void RemoveDownVoteFromComment(int commentId, int videoId)
        {
            this.repository.RemoveDownVoteFromComment(commentId, videoId);
        }

        /// <summary>
        /// Remove down vote from video.</summary>
        /// <param name="videoId">VideoId to remove down vote from</param>
        public void RemoveDownVoteFromVideo(int videoId)
        {
            this.repository.RemoveDownVoteFromVideo(videoId);
        }

        /// <summary>
        /// Remove subscription from channel.</summary>
        /// <param name="channelId">ChannelId who removes subscription</param>
        /// <param name="subscriptionId">ChannelId of subscription</param>
        public void RemoveSubscriptionFromChannel(int channelId, int subscriptionId)
        {
            this.repository.RemoveSubscriptionFromChannel(channelId, subscriptionId);
        }

        /// <summary>
        /// Remove up vote from comment.</summary>
        /// <param name="commentId">CommentId to remove up vote from</param>
        /// <param name="videoId">VideoId comment is placed on</param>
        public void RemoveUpVoteFromComment(int commentId, int videoId)
        {
            this.repository.RemoveUpVoteFromComment(commentId, videoId);
        }

        /// <summary>
        /// Remove up vote from video.</summary>
        /// <param name="videoId">VideoId to remove up vote from</param>
        public void RemoveUpVoteFromVideo(int videoId)
        {
            this.repository.RemoveUpVoteFromVideo(videoId);
        }

        /// <summary>
        /// Remove video to playlist.</summary>
        /// <param name="playlistId">PlaylistId to add video to</param>
        /// <param name="videoId">Video to remove</param>
        public void RemoveVideoFromPlaylist(int playlistId, int videoId)
        {
            this.repository.RemoveVideoFromPlaylist(playlistId, videoId);
        }

        /// <summary>
        /// Returns [amount] amount of most popular videos of [channelId].</summary>
        /// <returns>
        /// Returns [amount] amount of most popular videos of [channelId]</returns>
        /// <param name="channelId">Channel to get videos from</param>
        /// <param name="amount">Max amount of videos to get</param>
        public List<Video> GetPopularVideosOfChannel(int channelId, int amount)
        {
            return this.repository.GetPopularVideosOfChannel(channelId, amount);
        }

        /// <summary>
        /// Returns [amount] amount of newest videos of [channelId].</summary>
        /// <returns>
        /// Returns [amount] amount of newest videos of [channelId]</returns>
        /// <param name="channelId">Channel to get videos from</param>
        /// <param name="amount">Max amount of videos to get</param>
        public List<Video> GetNewVideosOfChannel(int channelId, int amount)
        {
            return this.repository.GetNewVideosOfChannel(channelId, amount);
        }

        /// <summary>
        /// Returns [amount] amount of most popular videos.</summary>
        /// <returns>
        /// Returns [amount] amount of most popular videos</returns>
        /// <param name="amount">Max amount of videos to get</param>
        public List<Video> GetPopularVideos(int amount)
        {
            return this.repository.GetPopularVideos(amount);
        }

        /// <summary>
        /// Returns [amount] amount of most popular videos.</summary>
        /// <returns>
        /// Returns [amount] amount of most popular videos</returns>
        /// <param name="amount">Max amount of videos to get</param>
        public List<Video> GetNewVideos(int amount)
        {
            return this.repository.GetNewVideos(amount);
        }

        /// <summary>
        /// Validate credentials of login attempt.</summary>
        /// <returns>
        /// Returns if credentials are valid</returns>
        /// <param name="email">Email to check</param>
        /// <param name="password">Password to check</param>
        public bool ValidateLogin(string email, string password)
        {
            return this.repository.ValidateLogin(email, password);
        }

        /// <summary>
        /// Get basic info of all the channels of user.</summary>
        /// <returns>
        /// Returns basic info of all channels of user</returns>
        /// <param name="email">Email of user</param>
        public List<Channel> GetUserChannels(string email)
        {
            return this.repository.GetUserChannels(email);
        }

        /// <summary>
        /// Get full info of channel.</summary>
        /// <returns>
        /// Returns full info of channel</returns>
        /// <param name="channelId">ChannelId of channel</param>
        public Channel GetFullChannel(int channelId)
        {
            return this.repository.GetFullChannel(channelId);
        }

        /// <summary>
        /// Get whether video link exists or not.</summary>
        /// <returns>
        /// Returns whether video link exists or not</returns>
        /// <param name="videolink">Video link to search for</param>
        public bool DoesVideoLinkExist(string videolink)
        {
            return this.repository.DoesVideoLinkExist(videolink);
        }

        /// <summary>
        /// Get full information of video.</summary>
        /// <returns>
        /// Returns video object</returns>
        /// <param name="videolink">Video link to search for</param>
        public Video GetVideo(string videolink)
        {
            return this.repository.GetVideo(videolink);
        }

        /// <summary>
        /// Get basic info of channel.</summary>
        /// <returns>
        /// Returns basic info of channel</returns>
        /// <param name="channelId">ChannelId to get info of</param>
        public Channel GetChannel(int channelId)
        {
            return this.repository.GetChannel(channelId);
        }
    }
}