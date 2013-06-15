using System;

namespace GenogramGenerator.Core
{
    public class Person
    {
        public Guid Id { get; private set; }
        public Family Family { get; set; }
        public string Name { get; set; }
        public Year BirthYear { get; set; }

        public Relationship Is { get { return Family.Add(this); } }

        public float XPosition { get; set; }
        public int Generation { get; set; }
        public int DistanceToPrimaryLineage { get; set; }

        public Person()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}