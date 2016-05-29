using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTube.Types;

namespace YouTube.Repository
{
    public interface IRepository
    {
        void AddChannelToUser(String email, Channel channel);

        void AddPlaylistToChannel(int channelId, Playlist playlist);

        void AddSubscriptionToChannel(int channelId, int subscriptionId);

        void AddVideoToChannel(int channelId, Video video);

        void EditAboutOfChannel(int channelId, String about);

        void RemoveSubscriptionFromChannel(int channelId, int subscriptionId);

        void AddVideoToPlaylist(int playlistId, Video video);

        void EditDescriptionOfPlaylist(int playlistId, String description);

        void EditTitleOfPlaylist(int playlistId, String title);

        void RemoveVideoFromPlaylist(int playlistId, int videoId);

        void AddCommentToVideo(int videoId, Comment comment);

        void AddDownVoteToVideo(int videoId);

        void AddUpVoteToVideo(int videoId);

        void AddViewToVideo(int videoId);

        void EditDescriptionOfVideo(int videoId, String description);

        void EditTitleOfVideo(int videoId, String title);

        void RemoveDownVoteToVideo(int videoId);

        void RemoveUpVoteToVideo(int videoId);

        void AddDownVoteToComment(int commentId, int videoId);

        void AddReplytoComment(int commentId, int videoId, Comment reply);

        void AddUpVoteToComment(int commentId, int videoId);

        void EditContentOfComment(int commentId, int videoId, String content);

        void RemoveDownVoteToComment(int commentId, int videoId);

        void RemoveUpVoteToComment(int commentId, int videoId);
    }
}
