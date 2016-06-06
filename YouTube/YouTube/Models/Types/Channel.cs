using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouTube.Repository;
using YouTube.RepositoryDAL;

namespace YouTube.Types
{
    public class Channel
    {
        public String About { get; private set; }
        public int ChannelId { get; private set; }
        public String Name { get; private set; }
        public List<Playlist> Playlists { get; private set; }
        public List<Video> Videos { get; private set; }
        public List<Channel> Subscriptions { get; private set; }

        private DAL dal = new DAL(new OracleRepository());

        public Channel(String about, int channelId, String name, List<Playlist> playlists = null, List<Video> videos = null, List<Channel> subscriptions = null)
        {
            About = about;
            ChannelId = channelId;
            Name = name;

            // If given value is null, grab an empty list
            Playlists = playlists ?? new List<Playlist>();
            Videos = videos ?? new List<Video>();
            Subscriptions = subscriptions ?? new List<Channel>();
        }

        public void AddPlaylist(Playlist playlist)
        {
            dal.AddPlaylistToChannel(playlist);
            Playlists.Add(playlist);
        }

        public void AddSubscription(Channel channel)
        {
            dal.AddSubscriptionToChannel(ChannelId, channel.ChannelId);
            Subscriptions.Add(channel);
        }

        public void AddVideo(Video video)
        {
            dal.AddVideoToChannel(video);
            Videos.Add(video);
        }

        public void EditAbout(String about)
        {
            dal.EditAboutOfChannel(ChannelId, about);
            About = about;
        }

        public void RemoveSubscription(Channel channel)
        {
            dal.RemoveSubscriptionFromChannel(ChannelId, channel.ChannelId);
            Subscriptions.Remove(channel);
        }

        public List<Video> GetPopularVideos(int amount)
        {
            return dal.GetPopularVideosOfChannel(ChannelId, amount);
        }

        public List<Video> GetNewVideos(int amount)
        {
            return dal.GetNewVideosOfChannel(ChannelId, amount);
        }
    }
}