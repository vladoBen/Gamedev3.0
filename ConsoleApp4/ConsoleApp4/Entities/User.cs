using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Entities
{
    public class User
    {
        public string name { get; set; }
        public int score  { get; set; }

        public User(string name)
        {
            this.name = name;
            this.score = 0;
        }

    }

}
