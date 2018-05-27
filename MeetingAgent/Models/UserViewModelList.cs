using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingAgent.Models
{
    public class UserViewModelList
    {

        public List<UserViewModel> UserViewModelListRels { get; set; }
        public UserViewModelList()
        {
            UserViewModelListRels = new List<UserViewModel>();
        }
    }
}