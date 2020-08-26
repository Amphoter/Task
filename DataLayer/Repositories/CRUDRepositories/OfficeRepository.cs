using AutoMapper;
using DataLayer.EF;
using DataLayer.Interfaces;
using DataLayer.Models;

using System.Collections.Generic;
using System.Linq;


namespace DataLayer.Repositories
{
   public class OfficeRepository: ICrudRepository<Office>
    {
        private readonly ApplicationContext db;


        public OfficeRepository(ApplicationContext context)
        {
            db = context;
                        
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
            Office officeToUpdate = db.Offices.FirstOrDefault(o => o.Id == idToUpdate);
            officeToUpdate.Name = office.Name;
            db.Update(officeToUpdate);
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
