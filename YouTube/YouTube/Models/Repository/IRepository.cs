//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="YouTube">
//     Copyright (c) YouTube. All rights reserved
// </copyright>
//-----------------------------------------------------------------------

namespace YouTube.Repository
{
    using System.Collections.Generic;
    using Types;

    /// <summary>
    /// Interface for database suppliers</summary>
    public interface IRepository
    {
        /// <summary>
        /// Add channel to user.</summary>
        /// <param name="email">Email of user</param>
        /// <param name="channel">Channel to add</param>
        void AddChannelToUser(string email, Channel channel);

        /// <summary>
        /// Add playlist to channel (playlist already contains channelId).</summary>
        /// <param name="playlist">Playlist to add</param>
        void AddPlaylistToChannel(Playlist playlist);

        /// <summary>
        /// Add subscription to channel.</summary>
        /// <param name="channelId">ChannelId to add subscription to</param>
        /// <param name="subscriptionId">ChannelId of subscription</param>
        void AddSubscriptionToChannel(int channelId, int subscriptionId);

        /// <summary>
        /// Add video to channel (video already contains channelId).</summary>
        /// <param name="video">Video to add</param>
        void AddVideoToChannel(Video video);

        /// <summary>
        /// Change about of channel.</summary>
        /// <param name="channelId">ChannelId who's about must change</param>
        /// <param name="about">New about</param>
        void EditAboutOfChannel(int channelId, string about);

        /// <summary>
        /// Remove subscription from channel.</summary>
        /// <param name="channelId">ChannelId who removes subscription</param>
        /// <param name="subscriptionId">ChannelId of subscription</param>
        void RemoveSubscriptionFromChannel(int channelId, int subscriptionId);

        /// <summary>
        /// Add video to playlist.</summary>
        /// <param name="playlistId">PlaylistId to add video to</param>
        /// <param name="videoId">Video to add</param>
        void AddVideoToPlaylist(int playlistId, int videoId);

        /// <summary>
        /// Change description of playlist.</summary>
        /// <param name="playlistId">PlaylistId to change description of</param>
        /// <param name="description">New description</param>
        void EditDescriptionOfPlaylist(int playlistId, string description);

        /// <summary>
        /// Change title of playlist.</summary>
        /// <param name="playlistId">PlaylistId to change title of</param>
        /// <param name="title">New title</param>
        void EditTitleOfPlaylist(int playlistId, string title);

        /// <summary>
        /// Remove video to playlist.</summary>
        /// <param name="playlistId">PlaylistId to add video to</param>
        /// <param name="videoId">Video to remove</param>
        void RemoveVideoFromPlaylist(int playlistId, int videoId);

        /// <summary>
        /// Add comment to video (comment contains videoId).</summary>
        /// <param name="comment">Comment to add to video</param>
        void AddCommentToVideo(Comment comment);

        /// <summary>
        /// Add down vote to video.</summary>
        /// <param name="videoId">VideoId to add down vote to</param>
        void AddDownVoteToVideo(int videoId);

        /// <summary>
        /// Add up vote to video.</summary>
        /// <param name="videoId">VideoId to add up vote to</param>
        void AddUpVoteToVideo(int videoId);

        /// <summary>
        /// Add view to video.</summary>
        /// <param name="videoId">VideoId to add view to</param>
        void AddViewToVideo(int videoId);

        /// <summary>
        /// Change description of video.</summary>
        /// <param name="videoId">VideoId to change description of</param>
        /// <param name="description">New description</param>
        void EditDescriptionOfVideo(int videoId, string description);

        /// <summary>
        /// Change title of video.</summary>
        /// <param name="videoId">VideoId to change title of</param>
        /// <param name="title">New description</param>
        void EditTitleOfVideo(int videoId, string title);

        /// <summary>
        /// Remove down vote from video.</summary>
        /// <param name="videoId">VideoId to remove down vote from</param>
        void RemoveDownVoteFromVideo(int videoId);

        /// <summary>
        /// Remove up vote from video.</summary>
        /// <param name="videoId">VideoId to remove up vote from</param>
        void RemoveUpVoteFromVideo(int videoId);

        /// <summary>
        /// Add down vote to comment.</summary>
        /// <param name="commentId">CommentId to add down vote to</param>
        /// <param name="videoId">VideoId comment is placed on</param>
        void AddDownVoteToComment(int commentId, int videoId);

        /// <summary>
        /// Add reply to comment (reply contains videoId).</summary>
        /// <param name="commentId">CommentId to add reply to</param>
        /// <param name="reply">Reply to add to comment</param>
        void AddReplytoComment(int commentId, Comment reply);

        /// <summary>
        /// Add up vote to comment.</summary>
        /// <param name="commentId">CommentId to add up vote to</param>
        /// <param name="videoId">VideoId comment is placed on</param>
        void AddUpVoteToComment(int commentId, int videoId);

        /// <summary>
        /// Edit content of comment.</summary>
        /// <param name="commentId">CommentId to change content of</param>
        /// <param name="videoId">VideoId comment was placed on</param>
        /// <param name="content">New content</param>
        void EditContentOfComment(int commentId, int videoId, string content);

        /// <summary>
        /// Remove down vote from comment.</summary>
        /// <param name="commentId">CommentId to remove down vote from</param>
        /// <param name="videoId">VideoId comment is placed on</param>
        void RemoveDownVoteFromComment(int commentId, int videoId);

        /// <summary>
        /// Remove up vote from comment.</summary>
        /// <param name="commentId">CommentId to remove up vote from</param>
        /// <param name="videoId">VideoId comment is placed on</param>
        void RemoveUpVoteFromComment(int commentId, int videoId);

        /// <summary>
        /// Returns [amount] amount of most popular videos of [channelId].</summary>
        /// <returns>
        /// Returns [amount] amount of most popular videos of [channelId]</returns>
        /// <param name="channelId">Channel to get videos from</param>
        /// <param name="amount">Max amount of videos to get</param>
        List<Video> GetPopularVideosOfChannel(int channelId, int amount);

        /// <summary>
        /// Returns [amount] amount of newest videos of [channelId].</summary>
        /// <returns>
        /// Returns [amount] amount of newest videos of [channelId]</returns>
        /// <param name="channelId">Channel to get videos from</param>
        /// <param name="amount">Max amount of videos to get</param>
        List<Video> GetNewVideosOfChannel(int channelId, int amount);

        /// <summary>
        /// Returns [amount] amount of most popular videos.</summary>
        /// <returns>
        /// Returns [amount] amount of most popular videos</returns>
        /// <param name="amount">Max amount of videos to get</param>
        List<Video> GetPopularVideos(int amount);

        /// <summary>
        /// Returns [amount] amount of most popular videos.</summary>
        /// <returns>
        /// Returns [amount] amount of most popular videos</returns>
        /// <param name="amount">Max amount of videos to get</param>
        List<Video> GetNewVideos(int amount);

        /// <summary>
        /// Validate credentials of login attempt.</summary>
        /// <returns>
        /// Returns if credentials are valid</returns>
        /// <param name="email">Email to check</param>
        /// <param name="password">Password to check</param>
        bool ValidateLogin(string email, string password);

        /// <summary>
        /// Get basic info of all the channels of user.</summary>
        /// <returns>
        /// Returns basic info of all channels of user</returns>
        /// <param name="email">Email of user</param>
        List<Channel> GetUserChannels(string email);

        /// <summary>
        /// Get full info of channel.</summary>
        /// <returns>
        /// Returns full info of channel</returns>
        /// <param name="channelId">ChannelId of channel</param>
        Channel GetFullChannel(int channelId);

        /// <summary>
        /// Get whether video link exists or not.</summary>
        /// <returns>
        /// Returns whether video link exists or not</returns>
        /// <param name="videolink">Video link to search for</param>
        bool DoesVideoLinkExist(string videolink);

        /// <summary>
        /// Get full information of video.</summary>
        /// <returns>
        /// Returns video object</returns>
        /// <param name="videolink">Video link to search for</param>
        Video GetVideo(string videolink);

        /// <summary>
        /// Get basic info of channel.</summary>
        /// <returns>
        /// Returns basic info of channel</returns>
        /// <param name="channelId">ChannelId to get info of</param>
        Channel GetChannel(int channelId);
    }
}
