//-----------------------------------------------------------------------
// <copyright file="Channel.cs" company="YouTube">
//     Copyright (c) YouTube. All rights reserved
// </copyright>
//-----------------------------------------------------------------------

namespace YouTube.Types
{
    using System.Collections.Generic;
    using Repository;
    using RepositoryDAL;

    /// <summary>
    /// Channel object</summary>
    public class Channel
    {
        /// <summary>
        /// DAL for database access</summary>
        private DAL dal = new DAL(new OracleRepository());

        /// <summary>
        /// Initializes a new instance of the <see cref="Channel"/> class.</summary>
        /// <param name="about">Text about channel</param>
        /// <param name="channelId">Channel's ID</param>
        /// <param name="name">Channel's name</param>
        /// <param name="playlists">Channel's playlists</param>
        /// <param name="videos">Channel's videos</param>
        /// <param name="subscriptions">Channel's subscriptions</param>
        public Channel(string about, int channelId, string name, List<Playlist> playlists = null, List<Video> videos = null, List<Channel> subscriptions = null)
        {
            this.About = about;
            this.ChannelId = channelId;
            this.Name = name;

            // If given value is null, grab an empty list
            this.Playlists = playlists ?? new List<Playlist>();
            this.Videos = videos ?? new List<Video>();
            this.Subscriptions = subscriptions ?? new List<Channel>();
        }

        /// <summary>
        /// Gets text about channel</summary>
        public string About { get; private set; }

        /// <summary>
        /// Gets channel's ID</summary>
        public int ChannelId { get; private set; }

        /// <summary>
        /// Gets channel's name</summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets channel's playlists</summary>
        public List<Playlist> Playlists { get; private set; }

        /// <summary>
        /// Gets channel's videos</summary>
        public List<Video> Videos { get; private set; }

        /// <summary>
        /// Gets channel's subscriptions</summary>
        public List<Channel> Subscriptions { get; private set; }

        /// <summary>
        /// Adds playlist to channel's playlist.</summary>
        /// <param name="playlist">Playlist to add</param>
        public void AddPlaylist(Playlist playlist)
        {
            this.dal.AddPlaylistToChannel(playlist);
            this.Playlists.Add(playlist);
        }

        /// <summary>
        /// Adds subscription to channel's subscriptions.</summary>
        /// <param name="channel">Channel to add</param>
        public void AddSubscription(Channel channel)
        {
            this.dal.AddSubscriptionToChannel(this.ChannelId, channel.ChannelId);
            this.Subscriptions.Add(channel);
        }

        /// <summary>
        /// Adds video to channel's videos.</summary>
        /// <param name="video">Video to add</param>
        public void AddVideo(Video video)
        {
            this.dal.AddVideoToChannel(video);
            this.Videos.Add(video);
        }

        /// <summary>
        /// Change channel's about text.</summary>
        /// <param name="about">About to change to</param>
        public void EditAbout(string about)
        {
            this.dal.EditAboutOfChannel(this.ChannelId, about);
            this.About = about;
        }

        /// <summary>
        /// Removes subscription from channel's subscriptions.</summary>
        /// <param name="channel">Channel to remove</param>
        public void RemoveSubscription(Channel channel)
        {
            this.dal.RemoveSubscriptionFromChannel(this.ChannelId, channel.ChannelId);
            this.Subscriptions.Remove(channel);
        }

        /// <summary>
        /// Gets most popular videos of channel.</summary>
        /// <returns>
        /// Returns [amount] amount of most popular videos of channel</returns>
        /// <param name="amount">Amount of videos to get</param>
        public List<Video> GetPopularVideos(int amount)
        {
            return this.dal.GetPopularVideosOfChannel(this.ChannelId, amount);
        }

        /// <summary>
        /// Gets newest videos of channel.</summary>
        /// <returns>
        /// Returns [amount] amount of new videos of channel</returns>
        /// <param name="amount">Amount of videos to get</param>
        public List<Video> GetNewVideos(int amount)
        {
            return this.dal.GetNewVideosOfChannel(this.ChannelId, amount);
        }
    }
}