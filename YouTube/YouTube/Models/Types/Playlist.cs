//-----------------------------------------------------------------------
// <copyright file="Playlist.cs" company="YouTube">
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
    /// Playlist object</summary>
    public class Playlist
    {
        /// <summary>
        /// DAL for database access</summary>
        private DAL dal = new DAL(new OracleRepository());

        /// <summary>
        /// Initializes a new instance of the <see cref="Playlist"/> class.</summary>
        /// <param name="description">Playlist's description</param>
        /// <param name="playlistId">Playlist's ID</param>
        /// <param name="title">Playlist's title</param>
        /// <param name="uploadDate">Playlist's upload date</param>
        /// <param name="creator">Playlist's creator/uploader</param>
        /// <param name="videos">Playlist's videos</param>
        public Playlist(string description, int playlistId, string title, DateTime uploadDate, Channel creator, List<Video> videos = null)
        {
            this.Description = description;
            this.PlaylistId = playlistId;
            this.Title = title;
            this.UploadDate = uploadDate;
            this.Creator = creator;
            this.Videos = videos ?? new List<Video>();
        }

        /// <summary>
        /// Gets playlist's description</summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets playlist's ID</summary>
        public int PlaylistId { get; private set; }

        /// <summary>
        /// Gets playlist's title</summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets playlist's upload date</summary>
        public DateTime UploadDate { get; private set; }

        /// <summary>
        /// Gets playlist's videos</summary>
        public List<Video> Videos { get; private set; }

        /// <summary>
        /// Gets playlist's creator</summary>
        public Channel Creator { get; private set; }

        /// <summary>
        /// Adds video to playlist.</summary>
        /// <param name="video">Video to add</param>
        public void AddVideo(Video video)
        {
            this.dal.AddVideoToPlaylist(this.PlaylistId, video.VideoId);
            this.Videos.Add(video);
        }

        /// <summary>
        /// Changes playlist's description.</summary>
        /// <param name="description">New description</param>
        public void EditDescription(string description)
        {
            this.dal.EditDescriptionOfPlaylist(this.PlaylistId, description);
            this.Description = description;
        }

        /// <summary>
        /// Changes playlist's title.</summary>
        /// <param name="title">New title</param>
        public void EditTitle(string title)
        {
            this.dal.EditTitleOfPlaylist(this.PlaylistId, title);
            this.Title = title;
        }

        /// <summary>
        /// Removes video from playlist.</summary>
        /// <param name="video">Video to remove</param>
        public void RemoveVideo(Video video)
        {
            this.dal.RemoveVideoFromPlaylist(this.PlaylistId, video.VideoId);
            this.Videos.Remove(video);
        }
    }
}