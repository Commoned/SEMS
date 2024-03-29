﻿namespace SEMS.Domain
{
    public class Role
    {
        public Role(string name, string description, int id)
        {
            Name = name;
            Description = description;
            Id = id;
        }
        public Role(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}