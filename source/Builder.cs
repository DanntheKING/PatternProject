using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class RoomBuilder
    {   
        // Creates the private fields needed to create  a room
        private string subject;
        private int roomNum;
        private string instructor;

        // This method is used to set and change the subject attribute of the room
        public RoomBuilder WithSubject(string Subject)
        {
            subject = Subject;
            return this;
        }

        // This method is used to set and change the room number attribute of the room
        public RoomBuilder WithRoomNum(int RoomNum)
        {
            roomNum = RoomNum;
            return this;
        }

        // This method is used to set and change the instructor attribute of the room
        public RoomBuilder WithInstructor(string Instructor)
        {
            instructor = Instructor;
            return this;
        }

        // This is the main build method that returns all the requirements
        public RoomBuilder Build()
        {
            return this;
        }
    }
}
