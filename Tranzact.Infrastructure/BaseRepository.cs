using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Infrastructure.Models;
using Tranzact.Transversal;

namespace Tranzact.Infrastructure
{
    public class BaseRepository<T> where T : class
    {
        protected DbContext Context = new AppDbContext();
        protected DbSet<T> DbSet;

        public BaseRepository()
        {
            DbSet = Context.Set<T>();
        }

        public async Task<T> Save(T entidad)
        {
            try
            {
                DbSet.Add(entidad);
                await Context.SaveChangesAsync();
                return entidad;
  
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<T> GetById(int id)
        {
            try
            {
                var result = await DbSet.FindAsync(id);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public async Task<List<T>> GetAll()
        {
            try
            {
                var list = await Context.Set<T>().ToListAsync();

                return list;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Boolean> Update(T entidad)
        {
            try
            {
                DbSet.Update(entidad);
                
                await Context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<Boolean> Delete(int id)
        {
            try
            {
                var entidad = await DbSet.FindAsync(id);
                DbSet.Remove(entidad);
                await Context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
