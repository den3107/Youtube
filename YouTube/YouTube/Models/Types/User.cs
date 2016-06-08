//-----------------------------------------------------------------------
// <copyright file="User.cs" company="YouTube">
//     Copyright (c) YouTube. All rights reserved
// </copyright>
//-----------------------------------------------------------------------

namespace YouTube.Types
{
    using System.Collections.Generic;
    using Repository;
    using RepositoryDAL;

    /// <summary>
    /// User object</summary>
    public class User
    {
        /// <summary>
        /// DAL for database access</summary>
        private DAL dal = new DAL(new OracleRepository());

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.</summary>
        /// <param name="email">User's email</param>
        /// <param name="channels">User's channels</param>
        public User(string email, List<Channel> channels)
        {
            this.Email = email;
            this.Channels = channels;
            this.SetActivechannel(0);
        }

        /// <summary>
        /// Gets user's email</summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets user's channels</summary>
        public List<Channel> Channels { get; private set; }

        /// <summary>
        /// Gets user's active channel</summary>
        public Channel ActiveChannel { get; private set; }

        /// <summary>
        /// Adds channel to User's channels.</summary>
        /// <param name="channel">Channel to add</param>
        public void AddChannel(Channel channel)
        {
            this.dal.AddChannelToUser(this.Email, channel);
            this.Channels.Add(channel);
        }

        /// <summary>
        /// Sets active channel of user.</summary>
        /// <param name="index">Index of channel in user's channel list to set to active</param>
        public void SetActivechannel(int index)
        {
            this.ActiveChannel = this.dal.GetFullChannel(this.Channels[index].ChannelId);
        }
    }
}