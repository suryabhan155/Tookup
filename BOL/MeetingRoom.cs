//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class MeetingRoom
    {
        public int Id { get; set; }
        public string MeetingId { get; set; }
        public string MeetingName { get; set; }
        public string SharedWith { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public string HostName { get; set; }
        public string HostAccountId { get; set; }
        public string InviteLink { get; set; }
        public Nullable<int> ParticipantNo { get; set; }
        public string Message { get; set; }
        public string Password { get; set; }
    }
}