using System;
using System.Linq;

namespace TDDProject
{
    public class RoomAssignment
    {
        private readonly IMsTeamsAPI msTeamsAPI;
        private int RoomId;

        public RoomAssignment(IMsTeamsAPI msTeamsAPI)
        {
            this.msTeamsAPI = msTeamsAPI;
        }

        public bool Assign(Pair pair)
        {
            if (pair.Developers.Count < 2)
            {
                return false;
            }

            GetID();
            return msTeamsAPI.AssignRoom(RoomId, pair.Developers.ToList());
        }

        private void GetID()
        {
            RoomId = msTeamsAPI.GetRoomID();
            if (RoomId < 1)
            {
                throw new Exception("No room available at the moment");
            }
        }
    }
}
