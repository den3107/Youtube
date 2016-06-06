using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouTube.Repository;
using YouTube.RepositoryDAL;

namespace YouTube.Types
{
    public class Playlist
    {
        public String Description { get; private set; }
        public int PlaylistId { get; private set; }
        public String Title { get; private set; }
        public DateTime UploadDate { get; private set; }
        public List<Video> Videos { get; private set; }
        public Channel Creator { get; private set; }

        private DAL dal = new DAL(new OracleRepository());

        public Playlist(String description, int playlistId, String title, DateTime uploadDate, Channel creator, List<Video> videos = null)
        {
            Description = description;
            PlaylistId = playlistId;
            Title = title;
            UploadDate = uploadDate;
            Creator = creator;
            Videos = videos ?? new List<Video>();
        }

        public void AddVideo(Video video)
        {
            dal.AddVideoToPlaylist(PlaylistId, video.VideoId);
            Videos.Add(video);
        }

        public void EditDescription(String description)
        {
            dal.EditDescriptionOfPlaylist(PlaylistId, description);
            Description = description;
        }

        public void EditTitle(String title)
        {
            dal.EditTitleOfPlaylist(PlaylistId, title);
            Title = title;
        }

        public void RemoveVideo(Video video)
        {
            dal.RemoveVideoFromPlaylist(PlaylistId, video.VideoId);
            Videos.Remove(video);
        }
    }
}