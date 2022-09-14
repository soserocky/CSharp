using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable_IComparable
{
    internal class My_IEnumberable<T> : IEnumerable<T>
    {
        private List<T> _list;

        public My_IEnumberable()
        {
            _list = new List<T>();
        }

        internal static void Demo()
        {
            var oddEnumerable = new My_IEnumberable<int>();
            oddEnumerable.Add(1);
            oddEnumerable.Add(3);
            oddEnumerable.Add(5);
            oddEnumerable.Add(7);
            oddEnumerable.Add(9);

            var evenEnumerable = new My_IEnumberable<int>();
            evenEnumerable.Add(0);
            evenEnumerable.Add(2);
            evenEnumerable.Add(4);
            evenEnumerable.Add(6);
            evenEnumerable.Add(8);

            //var oddEnumerator = oddEnumerable.GetEnumerator();

            //while (oddEnumerator.MoveNext())
            //{
            //    Console.WriteLine(oddEnumerator.Current);
            //}

            //var evenEnumerator = evenEnumerable.GetEnumerator();

            //while (evenEnumerator.MoveNext())
            //{
            //    Console.WriteLine(evenEnumerator.Current);
            //}

            foreach (var item in evenEnumerable)
            {
                Console.WriteLine(item);
            }
            
            foreach (var item in oddEnumerable)
            {
                Console.WriteLine(item);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new My_Enumerator<T>(_list);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => _list.Count;

        public void Add (T item) => _list.Add(item);
        public void Remove (int i) => _list.RemoveAt(i);
    }

    internal class My_Enumerator<T> : IEnumerator<T>
    {
        private List<T> _list;
        private int _current = -1;
        public My_Enumerator(List<T> list)
        {
            _list = list;
            _current = -1;
        }
        internal T Current
        { 
            get
            { 
                return _list[_current]; 
            } 
        }

        object IEnumerator.Current
        {
            get
            {
                return _list[_current];
            }
        }

        T IEnumerator<T>.Current
        {
            get
            {
                return _list[_current];
            }
        }

        public void Dispose()
        {
            _list = null;
        }

        public bool MoveNext()
        {
            if (_current + 1 < _list.Count)
            {
                _current++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _current = 0;
        }
    }
}
