using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MathGameContext _dbContext;

        public UnitOfWork(MathGameContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<Player> _Players { get; set; }

        public IGenericRepository<Player> Players
        {
            get
            {
                if (_Players == null) _Players = new GenericRepository<Player>(_dbContext);
                return _Players;
            }
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose() => _dbContext.Dispose();
    }
}
