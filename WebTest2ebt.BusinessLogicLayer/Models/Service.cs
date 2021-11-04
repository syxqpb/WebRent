using System.Collections.Generic;

namespace WebTest2ebt.BusinessLogicLayer.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Master> Masters { get; set; }
    }
}
