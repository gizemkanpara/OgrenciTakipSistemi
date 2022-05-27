using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Hata:BaseEntity
    {
        public string Message { get; set; }
        public string RequestUri { get; set; }
        public string Error { get; set; }
        public DateTime Tarih { get; set; }

    }
}
