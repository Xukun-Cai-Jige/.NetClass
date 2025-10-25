using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal interface IGenericRepository<T> where T : class
    {
        void Add(T item);
        void Remove(T item);

        void Save(T item);

        IEnumerable<T> GetAll();

        T GetById(int id);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private List<T> data;
        public GenericRepository()
        {
            data = new List<T>();
        }

        public void Add(T item) { 
            data.Add(item);
        }

        public void Remove(T item) { 
            data.Remove(item);

        }

        public void Save() { 
        }

        public IEnumerable<T> GetAll() {
            return data;
        }

        public T GetById(int id) {
            foreach (T d in data) {
                if (id == d.id) {
                    return d;
                }
            }
            return null;
        }

}
