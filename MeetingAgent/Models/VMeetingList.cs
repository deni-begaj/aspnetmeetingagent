using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingAgent.Models
{
    public class VMeetingList
    {
        public List<v_meeting> VMeetingModelListRels { get; set; }
        public VMeetingList()
        {
            VMeetingModelListRels = new List<v_meeting>();
        }


    }
}