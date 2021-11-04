using System.Collections.Generic;


namespace WebTest2ebt.DataAccessLayer.Models
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MasterDto> Masters { get; set; }
    }
}
