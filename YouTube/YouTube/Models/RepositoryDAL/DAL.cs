﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouTube.Repository;
using YouTube.Types;

namespace YouTube.RepositoryDAL
{
    public class DAL
    {
        private IRepository repository;

        public DAL(IRepository repository)
        {
            this.repository = repository;
        }

        public void AddChannelToUser(string email, Channel channel)
        {
            repository.AddChannelToUser(email, channel);
        }

        public void AddCommentToVideo(Comment comment)
        {
            repository.AddCommentToVideo(comment);
        }

        public void AddDownVoteToComment(int commentId, int videoId)
        {
            repository.AddDownVoteToComment(commentId, videoId);
        }

        public void AddDownVoteToVideo(int videoId)
        {
            repository.AddDownVoteToVideo(videoId);
        }

        public void AddPlaylistToChannel(Playlist playlist)
        {
            repository.AddPlaylistToChannel(playlist);
        }

        public void AddReplytoComment(int commentId, Comment reply)
        {
            repository.AddReplytoComment(commentId, reply);
        }

        public void AddSubscriptionToChannel(int channelId, int subscriptionId)
        {
            repository.AddSubscriptionToChannel(channelId, subscriptionId);
        }

        public void AddUpVoteToComment(int commentId, int videoId)
        {
            repository.AddUpVoteToComment(commentId, videoId);
        }

        public void AddUpVoteToVideo(int videoId)
        {
            repository.AddUpVoteToVideo(videoId);
        }

        public void AddVideoToChannel(Video video)
        {
            repository.AddVideoToChannel(video);
        }

        public void AddVideoToPlaylist(int playlistId, int videoId)
        {
            repository.AddVideoToPlaylist(playlistId, videoId);
        }

        public void AddViewToVideo(int videoId)
        {
            repository.AddViewToVideo(videoId);
        }

        public void EditAboutOfChannel(int channelId, string about)
        {
            repository.EditAboutOfChannel(channelId, about);
        }

        public void EditContentOfComment(int commentId, int videoId, string content)
        {
            repository.EditContentOfComment(commentId, videoId, content);
        }

        public void EditDescriptionOfVideo(int videoId, string description)
        {
            repository.EditDescriptionOfVideo(videoId, description);
        }

        public void EditDescriptionOfPlaylist(int playlistId, string description)
        {
            repository.EditDescriptionOfPlaylist(playlistId, description);
        }

        public void EditTitleOfVideo(int videoId, string title)
        {
            repository.EditTitleOfVideo(videoId, title);
        }

        public void EditTitleOfPlaylist(int playlistId, string title)
        {
            EditTitleOfPlaylist(playlistId, title);
        }

        public void RemoveDownVoteToComment(int commentId, int videoId)
        {
            repository.RemoveDownVoteToComment(commentId, videoId);
        }

        public void RemoveDownVoteToVideo(int videoId)
        {
            repository.RemoveDownVoteToVideo(videoId);
        }

        public void RemoveSubscriptionFromChannel(int channelId, int subscriptionId)
        {
            repository.RemoveSubscriptionFromChannel(channelId, subscriptionId);
        }

        public void RemoveUpVoteToComment(int commentId, int videoId)
        {
            repository.RemoveUpVoteToComment(commentId, videoId);
        }

        public void RemoveUpVoteToVideo(int videoId)
        {
            repository.RemoveUpVoteToVideo(videoId);
        }

        public void RemoveVideoFromPlaylist(int playlistId, int videoId)
        {
            repository.RemoveVideoFromPlaylist(playlistId, videoId);
        }

        public List<Video> GetPopularVideosOfChannel(int channelId, int amount)
        {
            return repository.GetPopularVideosOfChannel(channelId, amount);
        }

        public List<Video> GetNewVideosOfChannel(int channelId, int amount)
        {
            return repository.GetNewVideosOfChannel(channelId, amount);
        }

        public List<Video> GetPopularVideos(int amount)
        {
            return repository.GetPopularVideos(amount);
        }

        public List<Video> GetNewVideos(int amount)
        {
            return repository.GetNewVideos(amount);
        }

        public bool ValidateLogin(String email, String password)
        {
            return repository.ValidateLogin(email, password);
        }

        public List<Channel> GetUserChannels(String email)
        {
            return repository.GetUserChannels(email);
        }

        public Channel GetFullChannel(int channelId)
        {
            return repository.GetFullChannel(channelId);
        }
    }
}