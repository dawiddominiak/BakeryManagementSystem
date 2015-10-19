using System;

namespace Domain.Route
{
    public struct RouteName : IEquatable<RouteName>
    {
        public string Name { get; private set; }

        public RouteName(string name) : this()
        {
            Name = name;
        }

        public bool Equals(RouteName other)
        {
            return Name == other.Name;
        }
    }
}
