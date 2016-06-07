//-----------------------------------------------------------------------
// <copyright file="OracleRepository.cs" company="YouTube">
//     Copyright (c) YouTube. All rights reserved
// </copyright>
//-----------------------------------------------------------------------

namespace YouTube.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Globalization;
    using Oracle.ManagedDataAccess.Client;
    using Types;

    /// <summary>
    /// Default Oracle database context</summary>
    public class OracleRepository : IRepository
    {
        /// <summary>
        /// Connection string used to connect to database</summary>
        //// private readonly string connectionstring  = "User Id=YOUTUBE;Password=YOUTUBE;Data Source=192.168.0.15";
        private readonly string connectionstring = "User Id=YOUTUBE;Password=YOUTUBE;Data Source=localhost";

        /// <summary>
        /// Add channel to user.</summary>
        /// <param name="email">Email of user</param>
        /// <param name="channel">Channel to add</param>
        public void AddChannelToUser(string email, Channel channel)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "INSERT INTO \"CHANNEL\"(\"USERID\", \"NAME\", \"ABOUT\") VALUES (:userID, :name, :about)"
                };
                command.Parameters.Add("userID", this.GetUserId(email));
                command.Parameters.Add("name", channel.Name);
                command.Parameters.Add("about", channel.About);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Add comment to video (comment contains videoId).</summary>
        /// <param name="comment">Comment to add to video</param>
        public void AddCommentToVideo(Comment comment)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "INSERT INTO \"COMMENT\"(\"VIDEOID\", \"CHANNELID\", \"CONTENT\") VALUES (:videoId, :channelId, :content)"
                };
                command.Parameters.Add("videoId", comment.VideoId);
                command.Parameters.Add("channelId", comment.Author);
                command.Parameters.Add("content", comment.Content);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Add down vote to comment.</summary>
        /// <param name="commentId">CommentId to add down vote to</param>
        /// <param name="videoId">VideoId comment is placed on</param>
        public void AddDownVoteToComment(int commentId, int videoId)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"COMMENT\" SET \"DOWNVOTES\" = \"DOWNVOTES\" + 1 WHERE \"COMMENTID\" = :commentId AND \"VIDEOID\" = :videoId"
                };
                command.Parameters.Add("commentId", commentId);
                command.Parameters.Add("videoId", videoId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Add down vote to video.</summary>
        /// <param name="videoId">VideoId to add down vote to</param>
        public void AddDownVoteToVideo(int videoId)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"VIDEO\" SET \"DOWNVOTES\" = \"DOWNVOTES\" + 1 WHERE \"VIDEOID\" = :videoId"
                };
                command.Parameters.Add("videoId", videoId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Add playlist to channel (playlist already contains channelId).</summary>
        /// <param name="playlist">Playlist to add</param>
        public void AddPlaylistToChannel(Playlist playlist)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "INSERT INTO \"PLAYLIST\"(\"CHANNELID\", \"TITLE\", \"DESCRIPTION\") VALUES (:channelId, :title, :description)"
                };
                command.Parameters.Add("channelId", playlist.Creator);
                command.Parameters.Add("title", playlist.Title);
                command.Parameters.Add("description", playlist.Description);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Add reply to comment (reply contains videoId).</summary>
        /// <param name="commentId">CommentId to add reply to</param>
        /// <param name="reply">Reply to add to comment</param>
        public void AddReplytoComment(int commentId, Comment reply)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "INSERT INTO \"REPLY\" VALUES (:commentId, :replyId, :videoId)"
                };
                command.Parameters.Add("commentId", commentId);
                command.Parameters.Add("replyId", reply.CommentId);
                command.Parameters.Add("videoId", reply.VideoId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Add subscription to channel.</summary>
        /// <param name="channelId">ChannelId to add subscription to</param>
        /// <param name="subscriptionId">ChannelId of subscription</param>
        public void AddSubscriptionToChannel(int channelId, int subscriptionId)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "INSERT INTO \"SUBSCRIBER\" VALUES (:channelId, :subscribedId)"
                };
                command.Parameters.Add("channelId", channelId);
                command.Parameters.Add("subscribedId", subscriptionId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Add up vote to comment.</summary>
        /// <param name="commentId">CommentId to add up vote to</param>
        /// <param name="videoId">VideoId comment is placed on</param>
        public void AddUpVoteToComment(int commentId, int videoId)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"COMMENT\" SET \"UPVOTES\" = \"UPVOTES\" + 1 WHERE \"VIDEOID\" = :videoId AND \"COMMENTID\" = :commentId"
                };
                command.Parameters.Add("videoId", videoId);
                command.Parameters.Add("commentId", commentId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Add up vote to video.</summary>
        /// <param name="videoId">VideoId to add up vote to</param>
        public void AddUpVoteToVideo(int videoId)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"VIDEO\" SET \"UPVOTES\" = \"UPVOTES\" + 1 WHERE \"VIDEOID\" = :videoId"
                };
                command.Parameters.Add("videoId", videoId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Add video to channel (video already contains channelId).</summary>
        /// <param name="video">Video to add</param>
        public void AddVideoToChannel(Video video)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "INSERT INTO \"VIDEO\"(\"CHANNELID\", \"TITLE\", \"DESCRIPTION\", \"VIDEOLINK\") VALUES (:channelId, :title, :description, :videoLink)"
                };
                command.Parameters.Add("channelId", video.Creator);
                command.Parameters.Add("title", video.Title);
                command.Parameters.Add("description", video.Description);
                command.Parameters.Add("videoLink", video.VideoLink);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Add video to playlist.</summary>
        /// <param name="playlistId">PlaylistId to add video to</param>
        /// <param name="videoId">Video to add</param>
        public void AddVideoToPlaylist(int playlistId, int videoId)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "INSERT INTO \"PLAYLISTVIDEO\" VALUES (:playlistId, :videoId)"
                };
                command.Parameters.Add("playlistId", playlistId);
                command.Parameters.Add("videoId", videoId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Add view to video.</summary>
        /// <param name="videoId">VideoId to add view to</param>
        public void AddViewToVideo(int videoId)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"VIDEO\" SET \"VIEWS\" = \"VIEWS\" + 1 WHERE \"VIDEOID\" = :videoId"
                };
                command.Parameters.Add("videoId", videoId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Change about of channel.</summary>
        /// <param name="channelId">ChannelId who's about must change</param>
        /// <param name="about">New about</param>
        public void EditAboutOfChannel(int channelId, string about)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"CHANNEL\" SET \"ABOUT\" = :about WHERE \"CHANNELID\" = :channelId"
                };
                command.Parameters.Add("about", about);
                command.Parameters.Add("channelId", channelId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Edit content of comment.</summary>
        /// <param name="commentId">CommentId to change content of</param>
        /// <param name="videoId">VideoId comment was placed on</param>
        /// <param name="content">New content</param>
        public void EditContentOfComment(int commentId, int videoId, string content)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"COMMENT\" SET \"CONTENT\" = :content WHERE \"VIDEOID\" = :videoId AND \"COMMENTID\" = :commentId"
                };
                command.Parameters.Add("content", content);
                command.Parameters.Add("videoId", videoId);
                command.Parameters.Add("commentId", commentId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Change description of playlist.</summary>
        /// <param name="playlistId">PlaylistId to change description of</param>
        /// <param name="description">New description</param>
        public void EditDescriptionOfPlaylist(int playlistId, string description)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"PLAYLIST\" SET \"DESCRIPTION\" = :description WHERE \"PLAYLISTID\" = :playlistId"
                };
                command.Parameters.Add("description", description);
                command.Parameters.Add("playlistId", playlistId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Change description of video.</summary>
        /// <param name="videoId">VideoId to change description of</param>
        /// <param name="description">New description</param>
        public void EditDescriptionOfVideo(int videoId, string description)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"VIDEO\" SET \"DESCRIPTION\" = :description WHERE \"VIDEOID\" = :videoId"
                };
                command.Parameters.Add("description", description);
                command.Parameters.Add("videoId", videoId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Change title of playlist.</summary>
        /// <param name="playlistId">PlaylistId to change title of</param>
        /// <param name="title">New title</param>
        public void EditTitleOfPlaylist(int playlistId, string title)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"PLAYLIST\" SET \"TITLE\" = :title WHERE \"PLAYLISTID\" = :playlistId"
                };
                command.Parameters.Add("title", title);
                command.Parameters.Add("playlistId", playlistId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Change title of video.</summary>
        /// <param name="videoId">VideoId to change title of</param>
        /// <param name="title">New description</param>
        public void EditTitleOfVideo(int videoId, string title)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"VIDEO\" SET \"TITLE\" = :title WHERE \"VIDEOID\" = :videoId"
                };
                command.Parameters.Add("title", title);
                command.Parameters.Add("videoId", videoId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Remove down vote from comment.</summary>
        /// <param name="commentId">CommentId to remove down vote from</param>
        /// <param name="videoId">VideoId comment is placed on</param>
        public void RemoveDownVoteFromComment(int commentId, int videoId)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"COMMENT\" SET \"DOWNVOTES\" = \"DOWNVOTES\" - 1 WHERE \"COMMENTID\" = :commentId AND \"VIDEOID\" = :videoId"
                };
                command.Parameters.Add("commentId", commentId);
                command.Parameters.Add("videoId", videoId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Remove down vote from video.</summary>
        /// <param name="videoId">VideoId to remove down vote from</param>
        public void RemoveDownVoteFromVideo(int videoId)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"VIDEO\" SET \"DOWNVOTES\" = \"DOWNVOTES\" - 1 WHERE \"VIDEOID\" = :videoId"
                };
                command.Parameters.Add("videoId", videoId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Remove subscription from channel.</summary>
        /// <param name="channelId">ChannelId who removes subscription</param>
        /// <param name="subscriptionId">ChannelId of subscription</param>
        public void RemoveSubscriptionFromChannel(int channelId, int subscriptionId)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "DELETE FROM \"SUBSCRIBER\" WHERE \"CHANNELID\" = :channelId AND \"SUBSCRIBEDID\" = :subscriptionId"
                };
                command.Parameters.Add("channelId", channelId);
                command.Parameters.Add("subscriptionId", subscriptionId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Remove up vote from comment.</summary>
        /// <param name="commentId">CommentId to remove up vote from</param>
        /// <param name="videoId">VideoId comment is placed on</param>
        public void RemoveUpVoteFromComment(int commentId, int videoId)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"COMMENT\" SET \"UPVOTES\" = \"UPVOTES\" - 1 WHERE \"VIDEOID\" = :videoId AND \"COMMENTID\" = :commentId"
                };
                command.Parameters.Add("videoId", videoId);
                command.Parameters.Add("commentId", commentId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Remove up vote from video.</summary>
        /// <param name="videoId">VideoId to remove up vote from</param>
        public void RemoveUpVoteFromVideo(int videoId)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"VIDEO\" SET \"UPVOTES\" = \"UPVOTES\" - 1 WHERE \"VIDEOID\" = :videoId"
                };
                command.Parameters.Add("videoId", videoId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Remove video to playlist.</summary>
        /// <param name="playlistId">PlaylistId to add video to</param>
        /// <param name="videoId">Video to remove</param>
        public void RemoveVideoFromPlaylist(int playlistId, int videoId)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "DELETE FROM \"PLAYLISTVIDEO\" WHERE \"PLAYLISTID\" = :playlistId AND \"VIDEOID\" = :videoId"
                };
                command.Parameters.Add("playlistId", playlistId);
                command.Parameters.Add("videoId", videoId);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Returns [amount] amount of most popular videos of [channelId].</summary>
        /// <returns>
        /// Returns [amount] amount of most popular videos of [channelId]</returns>
        /// <param name="channelId">Channel to get videos from</param>
        /// <param name="amount">Max amount of videos to get</param>
        public List<Video> GetPopularVideosOfChannel(int channelId, int amount)
        {
            List<Video> videos = new List<Video>();

            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "SELECT * FROM (SELECT DESCRIPTION, TITLE, UPLOADDATE, VIDEOID, VIDEOLINK, CHANNELID, VIEWS FROM \"VIDEO\" WHERE \"CHANNELID\" = :channelId AND \"VIDEOTYPE\" = 'RECORDED' ORDER BY \"VIEWS\" DESC) WHERE ROWNUM <= :amount"
                };

                command.Parameters.Add("channelId", channelId);
                command.Parameters.Add("amount", amount);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string description = reader["DESCRIPTION"].ToString();
                        string title = reader["TITLE"].ToString();
                        DateTime uploadDate = DateTime.ParseExact(reader["UPLOADDATE"].ToString(), "yy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
                        int videoId = int.Parse(reader["VIDEOID"].ToString());
                        string videoLink = reader["VIDEOLINK"].ToString();
                        Channel creator = this.GetChannel(channelId);
                        int views = int.Parse(reader["VIEWS"].ToString());

                        videos.Add(new Video(description: description, title: title, uploadDate: uploadDate, videoId: videoId, videoLink: videoLink, creator: creator, views: views));
                    }
                }
            }

            return videos;
        }

        /// <summary>
        /// Returns [amount] amount of newest videos of [channelId].</summary>
        /// <returns>
        /// Returns [amount] amount of newest videos of [channelId]</returns>
        /// <param name="channelId">Channel to get videos from</param>
        /// <param name="amount">Max amount of videos to get</param>
        public List<Video> GetNewVideosOfChannel(int channelId, int amount)
        {
            List<Video> videos = new List<Video>();

            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "SELECT * FROM (SELECT DESCRIPTION, TITLE, UPLOADDATE, VIDEOID, VIDEOLINK, CHANNELID, VIEWS FROM \"VIDEO\" WHERE \"CHANNELID\" = :channelId AND \"VIDEOTYPE\" = 'RECORDED' ORDER BY \"UPLOADDATE\" DESC) WHERE ROWNUM <= :amount"
                };

                command.Parameters.Add("channelId", channelId);
                command.Parameters.Add("amount", amount);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string description = reader["DESCRIPTION"].ToString();
                        string title = reader["TITLE"].ToString();
                        DateTime uploadDate = DateTime.ParseExact(reader["UPLOADDATE"].ToString(), "yy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
                        int videoId = int.Parse(reader["VIDEOID"].ToString());
                        string videoLink = reader["VIDEOLINK"].ToString();
                        Channel creator = this.GetChannel(channelId);
                        int views = int.Parse(reader["VIEWS"].ToString());

                        videos.Add(new Video(description: description, title: title, uploadDate: uploadDate, videoId: videoId, videoLink: videoLink, creator: creator, views: views));
                    }
                }
            }

            return videos;
        }

        /// <summary>
        /// Returns [amount] amount of most popular videos.</summary>
        /// <returns>
        /// Returns [amount] amount of most popular videos</returns>
        /// <param name="amount">Max amount of videos to get</param>
        public List<Video> GetPopularVideos(int amount)
        {
            List<Video> videos = new List<Video>();

            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "SELECT * FROM (SELECT DESCRIPTION, TITLE, UPLOADDATE, VIDEOID, VIDEOLINK, CHANNELID, VIEWS FROM \"VIDEO\" WHERE \"VIDEOTYPE\" = 'RECORDED' ORDER BY \"VIEWS\" DESC) WHERE ROWNUM <= :amount"
                };
                
                command.Parameters.Add("amount", amount);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string description = reader["DESCRIPTION"].ToString();
                        string title = reader["TITLE"].ToString();
                        DateTime uploadDate = DateTime.ParseExact(reader["UPLOADDATE"].ToString(), "yy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
                        int videoId = int.Parse(reader["VIDEOID"].ToString());
                        string videoLink = reader["VIDEOLINK"].ToString();
                        Channel creator = this.GetChannel(int.Parse(reader["CHANNELID"].ToString()));
                        int views = int.Parse(reader["VIEWS"].ToString());

                        videos.Add(new Video(description: description, title: title, uploadDate: uploadDate, videoId: videoId, videoLink: videoLink, creator: creator, views: views));
                    }
                }
            }

            return videos;
        }

        /// <summary>
        /// Returns [amount] amount of most popular videos.</summary>
        /// <returns>
        /// Returns [amount] amount of most popular videos</returns>
        /// <param name="amount">Max amount of videos to get</param>
        public List<Video> GetNewVideos(int amount)
        {
            List<Video> videos = new List<Video>();

            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "SELECT * FROM (SELECT DESCRIPTION, TITLE, UPLOADDATE, VIDEOID, VIDEOLINK, CHANNELID, VIEWS FROM \"VIDEO\" WHERE \"VIDEOTYPE\" = 'RECORDED' ORDER BY \"UPLOADDATE\" DESC) WHERE ROWNUM <= :amount"
                };
                
                command.Parameters.Add("amount", amount);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string description = reader["DESCRIPTION"].ToString();
                        string title = reader["TITLE"].ToString();
                        DateTime uploadDate = DateTime.ParseExact(reader["UPLOADDATE"].ToString(), "yy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
                        int videoId = int.Parse(reader["VIDEOID"].ToString());
                        string videoLink = reader["VIDEOLINK"].ToString();
                        Channel creator = this.GetChannel(int.Parse(reader["CHANNELID"].ToString()));
                        int views = int.Parse(reader["VIEWS"].ToString());

                        videos.Add(new Video(description: description, title: title, uploadDate: uploadDate, videoId: videoId, videoLink: videoLink, creator: creator, views: views));
                    }
                }
            }

            return videos;
        }

        /// <summary>
        /// Validate credentials of login attempt.</summary>
        /// <returns>
        /// Returns if credentials are valid</returns>
        /// <param name="email">Email to check</param>
        /// <param name="password">Password to check</param>
        public bool ValidateLogin(string email, string password)
        {
            bool success = false;

            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "SELECT COUNT(*) FROM \"USER\" WHERE \"EMAIL\" = :email AND \"PASSWORD\" = :password"
                };

                command.Parameters.Add("email", email);
                command.Parameters.Add("password", password);

                if (int.Parse(command.ExecuteScalar().ToString()) > 0)
                {
                    success = true;
                }
            }

            return success;
        }

        /// <summary>
        /// Get basic info of all the channels of user.</summary>
        /// <returns>
        /// Returns basic info of all channels of user</returns>
        /// <param name="email">Email of user</param>
        public List<Channel> GetUserChannels(string email)
        {
            List<Channel> channels = new List<Channel>();
            int userId = this.GetUserId(email);

            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "SELECT * FROM \"CHANNEL\" WHERE \"USERID\" = :userId"
                };

                command.Parameters.Add("userId", userId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int channelId = int.Parse(reader["CHANNELID"].ToString());
                        string name = reader["NAME"].ToString();
                        string about = reader["ABOUT"].ToString();

                        channels.Add(new Channel(about, channelId, name));
                    }
                }
            }

            return channels;
        }

        /// <summary>
        /// Get full info of channel.</summary>
        /// <returns>
        /// Returns full info of channel</returns>
        /// <param name="channelId">ChannelId of channel</param>
        public Channel GetFullChannel(int channelId)
        {
            Channel channel = null;

            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "SELECT * FROM \"CHANNEL\" WHERE \"CHANNELID\" = :channelId"
                };

                command.Parameters.Add("channelId", channelId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader["NAME"].ToString();
                        string about = reader["ABOUT"].ToString();

                        List<Playlist> playlists = this.GetPlaylists(channelId);
                        List<Channel> subscriptions = this.GetSubscriptions(channelId);

                        channel = new Channel(about: about, channelId: channelId, name: name, playlists: playlists, subscriptions: subscriptions);
                    }
                }
            }

            return channel;
        }

        /// <summary>
        /// Get userId from email.</summary>
        /// <returns>
        /// Returns UserId</returns>
        /// <param name="email">Email of user</param>
        private int GetUserId(string email)
        {
            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "SELECT \"USERID\" FROM \"USER\" WHERE \"EMAIL\" = :email"
                };

                command.Parameters.Add("email", email);
                return int.Parse(command.ExecuteScalar().ToString());
            }
        }

        /// <summary>
        /// Get basic info of channel.</summary>
        /// <returns>
        /// Returns basic info of channel</returns>
        /// <param name="channelId">ChannelId to get info of</param>
        private Channel GetChannel(int channelId)
        {
            Channel channel = null;

            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "SELECT * FROM \"CHANNEL\" WHERE \"CHANNELID\" = :channelId"
                };

                command.Parameters.Add("channelId", channelId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        channelId = int.Parse(reader["CHANNELID"].ToString());
                        string name = reader["NAME"].ToString();
                        string about = reader["ABOUT"].ToString();

                        channel = new Channel(about, channelId, name);
                    }
                }
            }

            return channel;
        }

        /// <summary>
        /// Get playlists of channel.</summary>
        /// <returns>
        /// Returns playlists of channel</returns>
        /// <param name="channelId">ChannelId to get playlists of</param>
        private List<Playlist> GetPlaylists(int channelId)
        {
            List<Playlist> playlists = new List<Playlist>();

            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "SELECT * FROM \"PLAYLIST\" WHERE \"CHANNELID\" = :channelId"
                };

                command.Parameters.Add("channelId", channelId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string description = reader["DESCRIPTION"].ToString();
                        int playlistId = int.Parse(reader["PLAYLISTID"].ToString());
                        string title = reader["TITLE"].ToString();
                        DateTime uploadDate = DateTime.ParseExact(reader["UPLOADDATE"].ToString(), "yy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
                        Channel channel = this.GetChannel(channelId);

                        playlists.Add(new Playlist(description, playlistId, title, uploadDate, channel));
                    }
                }
            }

            return playlists;
        }

        /// <summary>
        /// Get subscriptions of channel.</summary>
        /// <returns>
        /// Returns subscriptions of channel</returns>
        /// <param name="channelId">ChannelId to get subscriptions of</param>
        private List<Channel> GetSubscriptions(int channelId)
        {
            List<Channel> channels = new List<Channel>();

            var conn = new OracleConnection(this.connectionstring);
            using (conn)
            {
                conn.Open();
                var command = new OracleCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "SELECT * FROM \"PLAYLIST\" WHERE \"CHANNELID\" = :channelId"
                };

                command.Parameters.Add("channelId", channelId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string about = reader["ANOUT"].ToString();
                        int channelIdSubscription = int.Parse(reader["CHANNELID"].ToString());
                        string name = reader["TITLE"].ToString();

                        channels.Add(new Channel(about, channelIdSubscription, name));
                    }
                }
            }

            return channels;
        }
    }
}