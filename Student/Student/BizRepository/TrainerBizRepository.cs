using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Student.Models;

namespace Student.BizRepository
{
    public class TrainerBizRepository:IBizRepository<Trainer,int>
    {
        RHealDbContext ctx;

        public TrainerBizRepository()
        {
            ctx = new RHealDbContext();
        }

        public Trainer Create(Trainer entity)
        {
            entity = ctx.Trainers.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var res = ctx.Trainers.Find(id);
            if (res == null) return false;
            ctx.Trainers.Remove(res);
            ctx.SaveChanges();
            return true;

        }
        public List<Trainer> GetData()
        {
            var res = ctx.Trainers.ToList();
            return res;
        }

        public Trainer GetData(int id)
        {
            var res = ctx.Trainers.Find(id);
            return res;
        }

        public Trainer Update(int id, Trainer entity)
        {
            var res = ctx.Trainers.Find(id);
            if (res != null)
            {

                res.TrainerId = entity.TrainerId;
                res.TrainerName = entity.TrainerName;
                res.Expertise = entity.Expertise;
                ctx.SaveChanges();
                return res;
            }
            return entity;
        }

    }
}
