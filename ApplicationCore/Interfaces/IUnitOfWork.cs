using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork
    {
        //Database Tables
        public IGenericRepository<Player>  Players { get; }

        // return how many rows affected in db
        int Commit();

        // same as above by async action 
        Task<int> CommitAsync();
    }
}
