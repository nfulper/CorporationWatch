namespace CorpWatchApi.Models
{
    public class Job
    {
        public long Id { get; set; } 
        public Employee Employee { get; set; }
        public string Name { get; set; }   
        public bool IsComplete { get; set; } 
    }
}