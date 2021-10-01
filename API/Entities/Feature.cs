namespace API.Entities
{
    public class Feature
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public bool Activity { get; set; }
        public int? EndTime { get; set; }
    }
}