using System;
using System.Collections;
using System.Collections.Generic;

namespace OOPS_Concepts
{
    public class MyCollectionClass : IEnumerable<int>
    {
        private List<int> _myList;
        private MyEnumerator _iterator = null;

        public MyCollectionClass()
        {
            _myList = new List<int>();
        }

        public IEnumerator<int> GetEnumerator()
        {
            _iterator = new MyEnumerator(_myList);
            return _iterator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            _iterator = new MyEnumerator(_myList);
            return _iterator;
        }

        public void Add(int number)
        {
            _myList.Add(number);
            _iterator = new MyEnumerator(_myList);
        }

        public void RemoveAt(int index)
        {
            _myList.RemoveAt(index);
            _iterator = new MyEnumerator(_myList);
        }
    }

    internal class MyEnumerator : IEnumerator<int>
    {
        private List<int> _myList = null;
        private int index;
        public MyEnumerator(List<int> myList)
        {
            _myList = myList;
            index = -1;
        }
        public int Current => _myList[index];

        object IEnumerator.Current => _myList[index];

        public void Dispose()
        {
            _myList = null;
            _myList = new List<int>();
        }

        public bool MoveNext()
        {
            if (index == _myList.Count - 1)
                return false;

            index++;
            return true;
        }

        public void Reset() => index = 0;
    }
}