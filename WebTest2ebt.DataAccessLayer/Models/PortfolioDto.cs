using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTest2ebt.DataAccessLayer.Models
{
    public class PortfolioDto
    {
        [Key]
        [ForeignKey("Master")]
        public int Id { get; set; }
        public string Description { get; set; }
        public int MasterId { get; set; }
        public List<PhotoAndVideoDto> PhotosAndVideos { get; set; }
        public List<FeedbackDto> FeedBack { get; set; }
        public MasterDto Master { get; set; }
    }
}
