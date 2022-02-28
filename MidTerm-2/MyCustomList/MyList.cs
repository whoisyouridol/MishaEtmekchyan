using MyCustomList.Exceptions;
using System;
using System.Collections;

namespace MyCustomList
{
    public class MyList<T> : IEnumerable
    {
        private T[] Array { get; set; }

        public int Count
        {
            get { return Array.Length; }
        }

        public MyList(T[] elements)
        {
            Array = elements;
        }

        public MyList() { }

        public void Add(T element)
        {
            try
            {
                if (Array.Length > 0)
                {
                    var _temp_Array = new T[Array.Length + 1];

                    for (int i = 0; i < _temp_Array.Length; i++)
                    {
                        if (i < Array.Length)
                            _temp_Array[i] = Array[i];

                        if (i == _temp_Array.Length - 1)
                        {
                            _temp_Array[i] = element;
                        }
                    }
                    if (_temp_Array.Length != Array.Length + 1)
                    {
                        throw new AddingElementsCrashedException();
                    }
                    Array = _temp_Array;
                }

                else Array = new T[1] { element };
            }
            catch (AddingElementsCrashedException)
            {
                throw;
            }
        
        }

        public void AddRange(params T[] newElements)
        {
            var _temp_Array = new T[Array.Length + newElements.Length];

            Array.CopyTo(_temp_Array, 0);
            newElements.CopyTo(_temp_Array, Array.Length);

            Array = _temp_Array;
            //for (int i = 0; i < _temp_Array.Length; i++)
            //{
            //    if (i < Array.Length)
            //        _temp_Array[i] = Array[i];
            //    else
            //    {
            //        for (int j = 0; j < newElements.Length; j++)
            //        {
            //            _temp_Array[i] = newElements[j];
            //            break;
            //        }
            //    }
            //}
           
        }

        public void Remove(T element)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i].Equals(element))
                    RemoveAt(i);
                break;
            }
        }

        public void RemoveAt(int index)
        {
            if (index > Count - 1)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < Count- 1; i++)
                Array[i] = Array[i + 1];

            var result = new T[Array.Length - 1];
            for (int i = 0; i < Count; i++)
            {
                if (i == Count - 1)
                    break;
                else
                    result[i] = Array[i];
            }


            Array = result;
        }

        public void RemoveRange(params T[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                try
                {
                    Remove(elements[i]);
                }
                catch (Exception ex)
                {
                    throw ex;
                }            
            }
        }

        public T this [int index]
        {
            get
            {
                return Array[index];
            }
            set
            {
                Array[index] = value;
            }
        }

        public bool Contains(T element)
        {
            int counter = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                if (element.Equals(Array[i]))
                {
                    counter++;
                }
            }
            if (counter == 0)
            {
                return false;
            }
            else return true;
        }

        public IEnumerator GetEnumerator()
        {
            return Array.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Array.GetEnumerator();
        }
       
    }
}