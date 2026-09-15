using System;

namespace Generic
{
    class Progam
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cada vez me acuerdo mas de la sintaxis");
        }
    }


    public class MyList
    {
        private int[] _elements;
        private int _index = 0;

        public MyList(int n)
        {
            _elements = new int[n];
        }

        public void Add(int e)
        {
            if(_index < _elements.Length)
            {
                _elements[_index] = e;
                _index++;
            }
        }
    }
}