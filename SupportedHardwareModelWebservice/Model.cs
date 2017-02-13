namespace SupportedHardwareModelWebservice
{
    public class Model
    {
        public string Name { get; set; }
        public string ModelAlias { get; set; }
        public string[] OsVersions { get; set; }

        public Model()
        {

        }

        public Model(string name, string modelAlias, string[] osVersions)
        {
            Name = name;
            ModelAlias = modelAlias;
            OsVersions = osVersions;
        }
    }
}