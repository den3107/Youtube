using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouTube.RepositoryDAL;
using YouTube.Repository;

namespace YouTube.Types
{
    public class User
    {
        public String Email { get; private set; }

        public List<Channel> Channels { get; private set; }

        public Channel ActiveChannel { get; private set; }

        private DAL dal = new DAL(new OracleRepository());

        public User(String email, List<Channel> channels)
        {
            Email = email;
            Channels = channels;
        }

        public void AddChannel(Channel channel)
        {
            dal.AddChannelToUser(Email, channel);
            Channels.Add(channel);
        }

        public void SetActivechannel(int index)
        {
            ActiveChannel = dal.GetFullChannel(Channels[index].ChannelId);
        }
    }
}