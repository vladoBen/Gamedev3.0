using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game.entities.paceable
{
    public abstract class Organism
    {
        public double constant { get; set; }
        public string name { get; set; }
        public Harmness.Harmony harmness { get; set; }

        public Organism(double constant, Harmness.Harmony harmness)
        {
            this.constant = constant;
            this.harmness = harmness;
        }

        public Organism(double constant, string name)
        {
            this.constant = constant;
            this.name = name;
        }

        public Organism(double constant)
        {
            this.constant = constant;
        }
    }

}
