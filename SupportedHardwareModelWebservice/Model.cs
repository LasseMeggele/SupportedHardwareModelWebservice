using System;

namespace SupportedHardwareModelWebservice
{
    public class Model : IEquatable<Model>
    {
        public string Name { get; set; }
        public string ModelAlias { get; set; }
        public string[] OsVersions { get; set; }

        public Model() {}

        public Model(string name, string modelAlias, string[] osVersions)
        {
            Name = name;
            ModelAlias = modelAlias;
            OsVersions = osVersions;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = 0;
                result = (result * 397) ^ Name.GetHashCode();
                result = (result * 397) ^ ModelAlias.GetHashCode();
                result = (result * 397) ^ OsVersions.GetHashCode();
                return result;
            }
        }

        public override bool Equals(object obj)
        {
            var model = obj as Model;
            if (model == null)
                return false;

            return Name.Equals(model.Name) && 
                   ModelAlias.Equals(model.ModelAlias) && 
                   OsVersions.Equals(model.OsVersions);
        }

        public bool Equals(Model other)
        {
            return other != null &&
                   Name.Equals(other.Name) &&
                   ModelAlias.Equals(other.ModelAlias) &&
                   OsVersions.Equals(other.OsVersions);
        }
    }
}