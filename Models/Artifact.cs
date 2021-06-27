using System;
using System.Collections.Generic;

namespace to_the_moon
{
    public class Artifact
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; set; } 
        public Action<CombatState> Execute { get; set; }
        public Artifact(string name)
        {
            Name = name;
            Id = Guid.NewGuid().ToString();
        }        

        public override string ToString()
        {            
            return $"{Name}. {Description}";
        }
    }
}