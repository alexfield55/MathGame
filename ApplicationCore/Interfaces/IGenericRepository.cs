using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // get obj by its key id
        T GetById(int id);

        //Get obj by it's guid
        T GetById(string id);

        // used to get (SELECT/WHERE)
        // A Func<T, bool> represents a funciton that takes an obj of type T and return bool, Called predicate
        // used to verify a condition on an obj
        // expression <Func<T>> is a desc of a fun as an expression tree.
        // it can be compiled at run time that gen Func<T>
        // it can also be translated to other langs e.g. SQL in LINQ to SQL.
        // NoTracking is ReadOnly results, and includes is Join of other objs
        T Get(Expression<Func<T, bool>> predicate, bool asNoTracking = false, string includes = null);

        // same as above by async action 
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false, string includes = null);

        // returns an enum list of results to iterate
        IEnumerable<T> List();

        // returns an enum list of results to iterate, Expression is the query, optional orderby, optional includes (join) other objs
        IEnumerable<T> List(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy = null, string includes = null);

        // same as above by async action
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy = null, string includes = null);

        // add (insert) a new record instance
        void Add(T entity);

        // delete (remove) a single record instance 
        void Delete(T entity);

        // delete (remove) a multiple record instance 
        void Delete(IEnumerable<T> entity);

        // update all changes in an obj
        void Update(T entity);
    }
}
