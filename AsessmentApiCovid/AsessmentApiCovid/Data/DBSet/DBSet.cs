using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsessmentApiCovid.Data.DBSet
{
    public class DBSet<T> : IDBSet<T>
    {
        static List<T> _table;

        public int Count => _table.Count;

        public DBSet(){
            _table = new List<T>();
        }

        public bool IsReadOnly => false;

        T IList<T>.this[int index] { get => _table[index]; set => new DBSet<T>(); }
           

        public int IndexOf(T item)
        {
            return _table.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _table.Insert(index, item);
        }


        public void RemoveAt(int index)
        {
            _table.RemoveAt(index);
        }

        public void Add(T item)
        {
            _table.Add(item);
        }

        public void Clear()
        {
            _table.Clear();
        }

        public bool Contains(T item)
        {
            return _table.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _table.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _table.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _table.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
