using System;
using System.Collections.Generic;

namespace minNumOfWorkers_leetcode
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] due = new int[]
            {
                2,4,5,6,8,8
            };
            int[] length = new int[]
            {
                1,4,1,4,2,2
            };

            Console.WriteLine("Final: " + minNumOfWorkers(due, length));

            Console.ReadLine();

        }

        static int minNumOfWorkers(int[] due, int[] length)
        {
            Console.WriteLine("size of due (should be 6): " + due.Length);

            int final = 0;
            
            //here should be the sorting of array in ascending due length, already done.
            //Array should also be sorted where the lengths are in ascending order inside of the dues.

            List<int[]> workers = new List<int[]>();

            int currentworker = 0;

            workers.Add(new int[1 + due.Length]); //1 for current hours worked
            Console.WriteLine("size of workers (should be 1): " + workers.Count);

            for(int i = 0; i < due.Length; i++)
            {
                Console.WriteLine("i = " + i + ", length[i]: " + length[i] + ", due[i]: " + due[i]);
                if(workers[currentworker][0] + length[i] <= due[i])
                {
                    Console.WriteLine("Current worker passed. i = " + i);
                    workers[currentworker][0] += length[i];
                    workers[currentworker][1 + i] = 1; //i + 1 because the 0 is reserved, i+1 is the first job and 1 is true.
                }
                else
                {
                    Console.WriteLine("   Current worker failed. Initiating loop check, i = " + i);
                    int highestcapableworker = -1;
                    for(int c = 0; c < workers.Count; c++)
                    {
                        Console.WriteLine("   c is " + c);
                        Console.WriteLine("   Searching for suitable worker. c = " + c + ", workers[c][0] = " + workers[c][0] + ", length[i] = " + length[i] + ", due[i] = " + due[i]);
                        if (workers[c][0] + length[i] <= due[i])
                        {
                           Console.WriteLine("     *highest capable worker in loop i = " + i + ": " + c);
                           highestcapableworker = c;
                        }
                    }
                    if(highestcapableworker == -1)
                    {
                        Console.WriteLine("     Have to make a new worker at loop i = " + i);
                       //make new work task
                       currentworker = workers.Count;
                        int[] newint = new int[1 + due.Length];
                        newint[0] = length[i];
                        workers.Add(newint);
                        workers[currentworker][1 + i] = 1;
                    }
                    else
                    {
                        Console.WriteLine("     Adding new job to worker list in loop i = " + i + ", highestcapableworker= " + highestcapableworker);
                       workers[highestcapableworker][0] += length[i];
                        currentworker = highestcapableworker;
                        workers[currentworker][1 + i] = 1;
                        
                    }
                }
            }

            final = workers.Count;

            int r = 0;
            foreach(int[] intarray in workers)
            {
                r++;
                Console.WriteLine("foreach intarray in workers, array r (starts at 1): " + r);
                foreach (int i in intarray)
                {
                    Console.WriteLine(i);
                }
            }

            return final;
        }

    }
}
