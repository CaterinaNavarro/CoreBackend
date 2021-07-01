using CoreProject.Data;
using CoreProject.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CoreProjectContext _context;
        public GenericRepository(CoreProjectContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                return entity;
            }

            catch (Exception ex)
            {
                throw new Exception($"{nameof(GetByIdAsync)} Could not retrieve entity: {ex.Message}");
            }
        }
        public IQueryable<T> GetAll()
        {
            try
            {
                return _context.Set<T>();
            }

            catch (Exception ex)
            {
                throw new Exception($"{nameof(GetAll)} Could not retrieve entities: {ex.Message}");
            }
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            try
            {
                var entities = _context.Set<T>().Where(expression);
                return entities;
            }

            catch (Exception ex)
            {
                throw new Exception($"{nameof(Find)} Could not not retrive entities: {ex.Message}");
            }
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
       
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task Update(int id, T entity)
        {
            var entry = await _context.Set<T>().FindAsync(id);
            _context.Entry(entry).State = EntityState.Detached;
            _context.Set<T>().Update(entity);
        }

    }
}
