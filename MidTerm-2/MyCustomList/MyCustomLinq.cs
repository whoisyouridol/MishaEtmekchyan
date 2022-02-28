using MyCustomList.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCustomList
{
    public static class MyCustomLinq
    {
        public static MyList<T> Where<T>(this MyList<T> list,Func<T, bool> func)
        {
            MyList<T> result = new MyList<T>(new T[] { });
            for (int i = 0; i < list.Count; i++)
            {
                if(func(list[i]))
                {
                    result.Add(list[i]);
                }
            }
            return result;
        }

        public static T Single<T>(this MyList<T> list, Func<T, bool> func)
        {
            int counter = 0;
            T result = default;
            foreach (var item in list)
            {
                if (func((T)item))
                {
                    result = (T)item;
                    counter++;
                }
            }
            if (counter == 1)
            {
                return result;
            }
            else throw new NotSingleElementException();
        }

        public static T SingleOrDefault<T>(this MyList<T> list, Func<T, bool> func)
        {
            int counter = 0;
            T result = default;
            foreach (var item in list)
            {
                if (func((T)item))
                {
                    result = (T)item;
                    counter++;
                }
            }
            if (counter == 1)
            {
                return result;
            }
            else return default;
        }


        public static T Find<T>(this MyList<T> list,Predicate<T> predicate)
        {
            foreach (var item in list)
            {
                if (predicate((T)item))
                {
                    return (T)item;
                }
            }
            return default;
        }
    }
}
