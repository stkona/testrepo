using System.Collections.Generic;

namespace TDDProject
{
    public interface IMsTeamsAPI
    {
        int GetRoomID();

        bool AssignRoom(int roomID, List<IDeveloper> developers);
    }
}