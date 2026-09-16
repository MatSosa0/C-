using System;

namespace Generic
{
    class Progam
    {
        static void Main(string[] args)
        {
            MyList<int> numbers = new MyList<int>(10);
            numbers.Add(10);
            numbers.Add(6);

            MyList<string> strings = new MyList<string>(10);
            strings.Add("Matias");
        }
    }


    public class MyList<T>
    {
        private T[] _elements;
        private int _index = 0;

        public MyList(int n)
        {
            _elements = new T[n];
        }

        public void Add(T e)
        {
            if(_index < _elements.Length)
            {
                _elements[_index] = e;
                _index++;
            }
        }

        public T GetElement(int i)
        {
            if(i <= _index && i >= 0)
            {
                return _elements[i];
            }
            return default(T);
        }
    }
}