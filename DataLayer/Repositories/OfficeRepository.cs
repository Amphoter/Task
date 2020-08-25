using AutoMapper;
using DataLayer.EF;
using DataLayer.Interfaces;
using DataLayer.Models;

using System.Collections.Generic;
using System.Linq;


namespace DataLayer.Repositories
{
   public class OfficeRepository: IRepository<Office>
    {
        private readonly ApplicationContext db;
        private readonly IMapper _mapper;


        public OfficeRepository(ApplicationContext context,IMapper mapper)
        {
            db = context;
            _mapper = mapper;
            

        }

        public Office Get(int id)
        {
            return db.Offices.FirstOrDefault(p => p.Id == id);
        }
        public IEnumerable<Office> GetAll()
        {
            return db.Offices.ToList();
        }

        public void Create(Office office)
        {

            db.Offices.Add(office);
            db.SaveChanges();
        }

        public void Update(Office office,int idToUpdate)
        {
            //db.Entry(office).State = EntityState.Modified;
            //db.Entry(office).State = EntityState.Modified;
            db.SaveChanges();
        }


        public void Delete(int id)
        {
            Office office = db.Offices.Find(id);
            if (office != null)
                db.Offices.Remove(office);
            db.SaveChanges();
        }
    }
}
