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

        private DAL dal = new DAL(new OracleRepository());

        public User(String email, Channel channel)
        {
            Email = email;
            Channels = new List<Channel>();
            Channels.Add(channel);
        }

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
    }
}