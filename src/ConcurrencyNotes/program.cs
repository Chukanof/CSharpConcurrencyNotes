﻿using ConcurrencyNotes.Infrastructure;
using System;
using System.Linq;
using System.Threading;


namespace ConcurrencyNotes
{
    public class Program
    {
        public static void Main()
        {
            var selectedExample = Example.AutoResetEventOverview.GetExampleType();
            
            ExampleHelper.Run(selectedExample);
            
            Console.Read();
        }
    }
}