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


    }
}