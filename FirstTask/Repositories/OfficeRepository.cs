using AutoMapper;
using FirstTask.EF;
using FirstTask.Interfaces;
using FirstTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Repositories
{
    public class OfficeRepository : IRepository<Office>
    {
        private readonly ApplicationContext db;
        //private readonly IMapper _mapper;

        public OfficeRepository(ApplicationContext context)
        {
            db = context;
            //_mapper = mapper;
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

        public void Update(Office office)
        {
            db.Entry(office).State = EntityState.Modified;
            db.SaveChanges();
        }


        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
