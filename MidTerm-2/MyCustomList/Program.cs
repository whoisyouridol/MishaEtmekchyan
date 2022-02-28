using System;

namespace MyCustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyList<int>(new int []{ 10,214,1});

            #region Add
            list.Add(10);
            list.AddRange(26, 31, 174, 10);
            #endregion

            #region Count and indexes
            Console.WriteLine(list.Count);

            Console.WriteLine(list[2]);
            #endregion

            #region Where
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Where example : ");
            var temp2 = list.Where(x => x > 30);
            foreach (var item in temp2)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Single
            Console.WriteLine("Single example : ");
            var result1 = list.Single(x => x > 200);

            Console.WriteLine(result1);
            #endregion

            #region SingleOrDefault
            Console.WriteLine("Single or default example : ");

            var result2 = list.SingleOrDefault(x => x > 9000);

            Console.WriteLine(result2);
            #endregion

            #region Find
            Console.WriteLine("Example of Find : ");

            Console.WriteLine(list.Find(x => x > 10));
            #endregion

            #region RemoveAt
            Console.WriteLine("Example of RemoveAt : ");
            list.RemoveAt(0);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Remove
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Example of Remove : ");

            list.Remove(10);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region RemoveRange
            list.RemoveRange(new int[] { 26, 1 });
            #endregion
        }
    }
}
