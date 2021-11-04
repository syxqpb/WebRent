

namespace WebTest2ebt.BusinessLogicLayer.Models
{
    public class PhotoAndVideo
    {
        public int Id { get; set; }
        public string PathToFile { get; set; }
        public int MasterId { get; set; }
        //public int PortfolioId { get; set; }

        public Master Master { get; set; }
        //public Portfolio Portfolio { get; set; }
    }
}
