using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.UI.Models
{
    public class MasterPhoto
    {
        public int Id { get; set; }
        public string PathToFile { get; set; }
        public int MasterId { get; set; }

        public Master Master { get; set; }
    }
}
