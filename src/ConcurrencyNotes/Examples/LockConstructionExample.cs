using ConcurrencyNotes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyNotes
{
    internal class LockConstructionExample : ISyncAsyncThreadExample
    {
        private int n = 500;

        public async Task StartAsync()
        {
            var task = Task.Run(() => write("x"));

            write("y");

            await task;

            void write(object c)
            {
                string s = (string)c;
                for (int i = 0; i < n; i++)
                {
                    if (s == "x")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    Console.Write(s);
                    Console.ResetColor();
                }
            }
        }

        public async Task StartSync()
        {
            object syncRoot = new object();

            Console.WriteLine("\n\n");
            var task = Task.Run(() => write("x"));

            write("y");

            await task;


            void write(object c)
            {
                lock (syncRoot)
                {
                    string s = (string)c;
                    for (int i = 0; i < n; i++)
                    {
                        if (s == "x")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }

                        Console.Write(s);
                        Console.ResetColor();

                    }
                }
            }
        }


    }
}
