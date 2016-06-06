using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using YouTube.Types;

namespace YouTube.Repository
{
    public class OracleRepository : IRepository
    {
        private readonly String connectionString  = "User Id=YOUTUBE;Password=YOUTUBE;Data Source=192.168.0.15";

        private int GetUserId(string email)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "SELECT \"USERID\" FROM \"USER\" WHERE \"EMAIL\" = :email"
                };

                command.Parameters.Add("email", email);
                return (int) command.ExecuteScalar();
            }
        }

        private Channel GetChannel(int channelId)
        {
            Channel channel = null;

            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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
                        String name = reader["NAME"].ToString();
                        String about = reader["ABOUT"].ToString();

                        channel = new Channel(about, channelId, name);
                    }
                }
            }

            return channel;
        }

        private List<Playlist> GetPlaylists(int channelId)
        {
            List<Playlist> playlists = new List<Playlist>();

            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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
                        String description = reader["DESCRIPTION"].ToString();
                        int playlistId = int.Parse(reader["PLAYLISTID"].ToString());
                        String title = reader["TITLE"].ToString();
                        DateTime uploadDate = DateTime.ParseExact(reader["UPLOADDATE"].ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                        Channel channel = GetChannel(channelId);

                        playlists.Add(new Playlist(description, playlistId, title, uploadDate, channel));
                    }
                }
            }

            return playlists;
        }

        private List<Channel> GetSubscriptions(int channelId)
        {
            List<Channel> channels = new List<Channel>();

            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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
                        String about = reader["ANOUT"].ToString();
                        int channelIdSubscription = int.Parse(reader["CHANNELID"].ToString());
                        String name = reader["TITLE"].ToString();

                        channels.Add(new Channel(about, channelIdSubscription, name));
                    }
                }
            }

            return channels;
        }

        public void AddChannelToUser(string email, Channel channel)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "INSERT INTO \"CHANNEL\"(\"USERID\", \"NAME\", \"ABOUT\") VALUES (:userID, :name, :about)"
                };
                command.Parameters.Add("userID", GetUserId(email));
                command.Parameters.Add("name", channel.Name);
                command.Parameters.Add("about", channel.About);

                command.ExecuteNonQuery();
            }
        }

        public void AddCommentToVideo(Comment comment)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public void AddDownVoteToComment(int commentId, int videoId)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public void AddDownVoteToVideo(int videoId)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"VIDEO\" SET \"DOWNVOTES\" = \"DOWNVOTES\" + 1 WHERE \"VIDEOID\" = :videoId"
                };
                command.Parameters.Add("videoId", videoId);

                command.ExecuteNonQuery();
            }
        }

        public void AddPlaylistToChannel(Playlist playlist)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public void AddReplytoComment(int commentId, Comment reply)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public void AddSubscriptionToChannel(int channelId, int subscriptionId)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public void AddUpVoteToComment(int commentId, int videoId)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public void AddUpVoteToVideo(int videoId)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"VIDEO\" SET \"UPVOTES\" = \"UPVOTES\" + 1 WHERE \"VIDEOID\" = :videoId"
                };
                command.Parameters.Add("videoId", videoId);

                command.ExecuteNonQuery();
            }
        }

        public void AddVideoToChannel(Video video)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public void AddVideoToPlaylist(int playlistId, int videoId)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public void AddViewToVideo(int videoId)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"VIDEO\" SET \"VIEWS\" = \"VIEWS\" + 1 WHERE \"VIDEOID\" = :videoId"
                };
                command.Parameters.Add("videoId", videoId);

                command.ExecuteNonQuery();
            }
        }

        public void EditAboutOfChannel(int channelId, string about)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public void EditContentOfComment(int commentId, int videoId, string content)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public void EditDescriptionOfPlaylist(int playlistId, string description)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public void EditDescriptionOfVideo(int videoId, string description)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public void EditTitleOfPlaylist(int playlistId, string title)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public void EditTitleOfVideo(int videoId, string title)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public void RemoveDownVoteToComment(int commentId, int videoId)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public void RemoveDownVoteToVideo(int videoId)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"VIDEO\" SET \"DOWNVOTES\" = \"DOWNVOTES\" - 1 WHERE \"VIDEOID\" = :videoId"
                };
                command.Parameters.Add("videoId", videoId);

                command.ExecuteNonQuery();
            }
        }

        public void RemoveSubscriptionFromChannel(int channelId, int subscriptionId)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public void RemoveUpVoteToComment(int commentId, int videoId)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public void RemoveUpVoteToVideo(int videoId)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "UPDATE \"VIDEO\" SET \"UPVOTES\" = \"UPVOTES\" - 1 WHERE \"VIDEOID\" = :videoId"
                };
                command.Parameters.Add("videoId", videoId);

                command.ExecuteNonQuery();
            }
        }

        public void RemoveVideoFromPlaylist(int playlistId, int videoId)
        {
            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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

        public List<Video> GetPopularVideosOfChannel(int channelId, int amount)
        {
            List<Video> videos = new List<Video>();

            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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
                        String description = reader["DESCRIPTION"].ToString();
                        String title = reader["TITLE"].ToString();
                        DateTime uploadDate = DateTime.ParseExact(reader["UPLOADDATE"].ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                        int videoId = int.Parse(reader["VIDEOID"].ToString());
                        String videoLink = reader["VIDEOLINK"].ToString();
                        Channel creator = GetChannel(channelId);
                        int views = int.Parse(reader["VIEWS"].ToString());

                        videos.Add(new Video(description:description, title:title, uploadDate:uploadDate, videoId:videoId, videoLink:videoLink, creator:creator, views:views));
                    }
                }
            }

            return videos;
        }

        public List<Video> GetNewVideosOfChannel(int channelId, int amount)
        {
            List<Video> videos = new List<Video>();

            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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
                        String description = reader["DESCRIPTION"].ToString();
                        String title = reader["TITLE"].ToString();
                        DateTime uploadDate = DateTime.ParseExact(reader["UPLOADDATE"].ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                        int videoId = int.Parse(reader["VIDEOID"].ToString());
                        String videoLink = reader["VIDEOLINK"].ToString();
                        Channel creator = GetChannel(channelId);
                        int views = int.Parse(reader["VIEWS"].ToString());

                        videos.Add(new Video(description: description, title: title, uploadDate: uploadDate, videoId: videoId, videoLink: videoLink, creator: creator, views: views));
                    }
                }
            }

            return videos;
        }

        public bool ValidateLogin(String email, String password)
        {
            bool success = false;

            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText =
                        "SELECT COUNT(*) FROM \"USER\" WHERE \"EMAIL\" = :email AND \"PASSWORD\" = :password"
                };

                command.Parameters.Add("email", email);
                command.Parameters.Add("password", password);

                if((int) command.ExecuteScalar() > 0)
                {
                    success = true;
                }
            }

            return success;
        }

        public List<Channel> GetUserChannels(String email)
        {
            List<Channel> channels = new List<Channel>();
            int userId = GetUserId(email);

            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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
                        String name = reader["NAME"].ToString();
                        String about = reader["ABOUT"].ToString();

                        channels.Add(new Channel(about, channelId, name));
                    }
                }
            }

            return channels;
        }

        public Channel GetFullChannel(int channelId)
        {
            Channel channel = null;

            var conn = new OracleConnection(connectionString);
            using (conn)
            {
                var command = new OracleCommand {
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
                        String name = reader["NAME"].ToString();
                        String about = reader["ABOUT"].ToString();

                        List<Playlist> playlists = GetPlaylists(channelId);
                        List<Channel> subscriptions = GetSubscriptions(channelId);

                        channel = new Channel(about:about, channelId:channelId, name:name, playlists:playlists, subscriptions:subscriptions);
                    }
                }
            }

            return channel;
        }
    }
}