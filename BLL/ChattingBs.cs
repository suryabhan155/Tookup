using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TookUp.BOL.ViewModels.CommonModels;

namespace BLL
{
    public class ChattingBs
    {
        private ChattingDb user_obj;
        ResponseModel response;
        public ChattingBs()
        {
            user_obj = new ChattingDb();
        }
        /// <summary>
        /// meeting creation
        /// </summary>
        /// <param name="meet"></param>
        /// <returns></returns>
        public ResponseModel CreateRoom(MeetingRoom meet)
        {
            return user_obj.CreateRoom(meet);
        }
        public ResponseModel JoinMeeting(ParticipantDetail participant)
        {
            return user_obj.JoinMeeting(participant);
        }
        /// <summary>
        /// Session Description protocols
        /// </summary>
        /// <param name="meet"></param>
        /// <returns></returns>
        public ResponseModel GetSDP(SdpMessage sdp)
        {
            return user_obj.GetSDP(sdp);
        }
        public ResponseModel PostSDP(SdpMessage sdp)
        {
            return user_obj.PostSDP(sdp);
        }

        /// <summary>
        /// ice candidate
        /// </summary>
        /// <param name="meet"></param>
        /// <returns></returns>
        public ResponseModel GetICE(CandidateTable candidate)
        {
            return user_obj.GetICE(candidate);
        }
        public ResponseModel PostICE(CandidateTable candidate)
        {
            return user_obj.PostICE(candidate);
        }

        public ResponseModel GetParticipants(ParticipantDetail participant) 
        {
            return user_obj.GetParticipants(participant);
        }
    }
}
