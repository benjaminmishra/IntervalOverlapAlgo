/*
 * Timings already present in the database
 * 
 * { StartDay - 1 StartTime - 11:20 hrs | EndDay - 3 EndTime - 00:10 hrs }
 * { StartDay - 4 StartTime - 22:30 hrs | EndDay - 4 EndTime - 23:50 hrs }
 * { StartDay - 6 StartTime - 08:00 hrs | EndDay - 6 EndTime - 09:40 hrs }
 * 
 * Inputs 
 * 
 * { StartDay - 2 StartTime - 10:00 hrs | EndDay - 4 EndTime - 02:30 hrs }
 * { StartDay - 5 StartTime - 00:00 hrs | EndDay - 5 EndTime - 05:30 hrs }
 * 
 */

using System;
using System.Collections.Generic;

namespace IntervalOverlapAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            //--- available intervals
            List<Timing> arry = new List<Timing> {
                new Timing(11120,30010),
                new Timing(42230,42350),
                new Timing(60800,60940)
            };

            //--- both the inputs
            Timing input1 = new Timing(21000, 40230);
            Timing input2 = new Timing(50000, 50530);


            //--- First add input1 to the array
            arry.Add(input1);
            arry.Sort(new Comparision());
            //--- check if adding the new record resulted in overlap
            if (PorcessList.CheckOverLap(arry))
            {
                Console.WriteLine("overlap found; not safe to insert");
            }
            else
            {
                Console.WriteLine("no overlap found; safe to insert");
            }
            arry.Remove(input1);


            arry.Add(input2);
            arry.Sort(new Comparision());
            if (PorcessList.CheckOverLap(arry))
            {
                Console.WriteLine("overlap found; not safe to insert");
            }
            else
            {
                Console.WriteLine("no overlap found; safe to insert");
            }
            arry.Remove(input2);


            Console.ReadLine();
        }
    }

    public class Timing
    {
        public Timing(int a, int b)
        {
            this.StartTime = a;
            this.EndTime = b;
        }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }

    public static class PorcessList
    {
        private static bool _overlap { get; set; }
        public static bool CheckOverLap(List<Timing> array)
        {
            for (int i = 1; i < array.Count; i++)
            {
                if (array[i - 1].EndTime > array[i].StartTime)
                {
                    _overlap = true;
                    break;
                }
                else
                {
                    _overlap = false;
                }
            }

            return _overlap;
        }
    }

    public class Comparision : IComparer<Timing>
    {
        public int Compare(Timing a, Timing b)
        {
            if (a.StartTime < b.StartTime)
                return -1;
            else if (a.StartTime == b.StartTime)
                return -1;
            else
                return 1;
        }
    }

}


