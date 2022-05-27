using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    [NotMapped]
    public class OgrenciListDto
    {
        public int TotalCount { get; set; }
        public List<Ogrenci> OgrList { get; set; }
    }
}
