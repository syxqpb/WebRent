

namespace WebTest2ebt.DataAccessLayer.Models
{
    public class PhotoAndVideoDto
    {
        public int Id { get; set; }
        public string PathToFile { get; set; }
        public int MasterId { get; set; }

        public MasterDto Master { get; set; }
    }
}
