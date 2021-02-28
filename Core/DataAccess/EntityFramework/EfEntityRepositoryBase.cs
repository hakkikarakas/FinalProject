using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where  TEntity: class, IEntity, new()
        where  TContext: DbContext ,new ()
    {
        public void Add(TEntity entity)
        {
            //IDissposable pattern implementation C# belleği hızlıca temizle
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);//Veri kaynağıile ilişkilendirildi.
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);//Veri kaynağıile ilişkilendirildi.
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {//Tek data getirecektir.
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {//Bütün tabloyu listeye çevir ver
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);//Veri kaynağıile ilişkilendirildi.
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}