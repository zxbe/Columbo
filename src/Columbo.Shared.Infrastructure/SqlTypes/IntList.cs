﻿using Columbo.Shared.Infrastructure.Attributes;
using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static Dapper.SqlMapper;

namespace Columbo.Shared.Infrastructure.SqlTypes
{
    [SqlScript("IntList.sql")]
    public class IntList : ITableValuedType<int>
    {
        private IList<int> _intList;
        public int this[int index] { get => _intList[index]; set => _intList[index] = value; }
        public int Count => _intList.Count;
        public bool IsReadOnly => false;

        public IntList()
        {
            _intList = new List<int>();
        }

        public IntList(IList<int> list)
        {
            _intList = list;
        }

        public void Add(int item)
        {
            _intList.Add(item);
        }

        public void Insert(int index, int item)
        {
            _intList.Insert(index, item);
        }

        public bool Remove(int item)
        {
            return _intList.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _intList.RemoveAt(index);
        }

        public void Clear()
        {
            _intList.Clear();
        }

        public int IndexOf(int item)
        {
            return _intList.IndexOf(item);
        }

        public bool Contains(int item)
        {
            return _intList.Contains(item);
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            _intList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return _intList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _intList.GetEnumerator();
        }

        public IDynamicParameters AsTableValuedParameter(string parameterName)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Value", typeof(int));

            foreach (var value in _intList)
            {
                dt.Rows.Add(value);
            }

            var parameter = new DynamicParameters();
            parameter.Add(parameterName, dt.AsTableValuedParameter(nameof(IntList)));

            return parameter;
        }
    }
}
