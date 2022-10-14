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
        private string subject;
        private int roomNum;
        private string instructor;

        public RoomBuilder WithSubject(string Subject)
        {
            subject = Subject;
            return this;
        }

        public RoomBuilder WithRoomNum(int RoomNum)
        {
            roomNum = RoomNum;
            return this;
        }

        public RoomBuilder WithInstructor(string Instructor)
        {
            instructor = Instructor;
            return this;
        }

        public RoomBuilder Build()
        {
            return this;
        }
    }
}
