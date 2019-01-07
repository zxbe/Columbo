using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Columbo.Shared.Infrastructure.Attributes;
using Dapper;

namespace Columbo.Shared.Infrastructure.SqlTypes
{
    [SqlScript("StringList.sql")]
    public class StringList : ITableValuedType<string>
    {
        private IList<string> _stringList;
        public string this[int index] { get => _stringList[index]; set => _stringList[index] = value; }
        public int Count => _stringList.Count;
        public bool IsReadOnly => false;

        public StringList()
        {
            _stringList = new List<string>();
        }

        public StringList(IList<string> stringList)
        {
            _stringList = stringList;
        }

        public void Add(string item)
        {
            _stringList.Add(item);
        }

        public void Insert(int index, string item)
        {
            _stringList.Insert(index, item);
        }

        public bool Remove(string item)
        {
            return _stringList.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _stringList.RemoveAt(index);
        }

        public void Clear()
        {
            _stringList.Clear();
        }

        public int IndexOf(string item)
        {
            return _stringList.IndexOf(item);
        }

        public bool Contains(string item)
        {
            return _stringList.Contains(item);
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            _stringList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _stringList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _stringList.GetEnumerator();
        }

        public SqlMapper.ICustomQueryParameter AsTableValuedParameter()
        {
            throw new NotImplementedException();
        }
    }
}
