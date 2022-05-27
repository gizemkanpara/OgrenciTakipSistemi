using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OgrRepository:BaseRepository<Ogrenci>, IRepository<Ogrenci>
    {
        public OgrRepository(OgrDbContext ctx):base(ctx)
        {
           
        }

        public override Ogrenci GetById(int id)
        {
           return _ctx.Ogrenciler.Include(c=>c.Nots).FirstOrDefault(c => c.Id==id);
        }

        public OgrenciListDto Search(string aranacakAd="", string AranacakSoyad="",int pageNum=1)
        {
            var query = _ctx.Ogrenciler.Where(c=>1==1);
          
            if (!String.IsNullOrEmpty(aranacakAd))
            {
                query = query.Where(c => c.Ad == aranacakAd);
            }
            if(!String.IsNullOrEmpty(AranacakSoyad))
            {
                query = query.Where(c => c.Soyad == AranacakSoyad);
            }

            OgrenciListDto result = new OgrenciListDto();
            result.TotalCount= query.Count();
            result.OgrList= query.Skip((pageNum - 1) * 5).Take(5).ToList();
            return result;
        }

      

        public List<myConfig> listCfg()
        {
            return _ctx.MyConfigs.ToList();
        }

    }
}
