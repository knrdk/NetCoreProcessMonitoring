namespace NetCoreProcessMonitoring.Model{
    public class Module{
        public string Name {get;} 
        public string Version {get;}

        public Module(string name, string version)
        {
            Name = name;
            Version = version;
        }
    }
}