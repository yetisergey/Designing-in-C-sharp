using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Incapsulation.Weights
{
    class Indexer
    {
        private static double[] Array;
        public int Length;
        private int Start;

        public Indexer(double[] array, int start, int length)
        {
            if (start < 0 || length < 0 || length > array.Length)
                throw new ArgumentException();

            Array = array;
            Start = start;
            Length = length;
        }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index + Start >= Start + Length)
                    throw new IndexOutOfRangeException();

                return Array[index + Start];
            }
            set
            {
                if (index < 0 || index + Start >= Start + Length)
                    throw new IndexOutOfRangeException();

                Array[index + Start] = value;
            }
        }

    }
}
