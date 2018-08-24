using System.Collections.Generic;

namespace CorpWatchApi.Models
{
    public class Employee
    {
       
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public string Department { get; set; }
    }
}