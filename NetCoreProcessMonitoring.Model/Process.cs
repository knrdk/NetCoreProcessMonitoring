namespace NetCoreProcessMonitoring.Model{
    public class Process{
        public int Id {get;}
        public string Name {get;} 

        public Process(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}