﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerAndConsumer
{
    public class Consumer
    {


        public Consumer()
        {

        }
        // A method that consumes cookies from the array.
        public void ConsumeArray(object callback)
        {
            while (true)
            {

                try
                {
                    if (Monitor.TryEnter(Program.cookieArray))
                    {
                        if (Program.Index == 0)
                        {
                            Monitor.Wait(Program.cookieArray);
                        }
                        else
                        {


                            Program.consumedArrayCookies.Add(Program.cookieArray[Program.Index]);
                            Program.cookieArray[Program.Index] = null;
                            Program.Index--;
                            
                            Monitor.Exit(Program.cookieArray);
                        }

                    }

                }
                finally
                {
                    Thread.Sleep(200);
                }
            }
        }
        // A method that consumes cookies from the Queues.
        public void ConsumeQueue(object callback)
        {
            while (true)
            {
                try
                {
                    if (Monitor.TryEnter(Program.cookieQ))
                    {
                        if (Program.cookieQ.Count == 0)
                        {
                            Monitor.Wait(Program.cookieQ);
                        }
                        else
                        {
                            Program.consumedQueueCookies.Add(Program.cookieQ.Dequeue());
                        }
                        Monitor.Exit(Program.cookieQ);
                    }

                }
                finally
                {
                    Thread.Sleep(200);
                }
            }
        }
    }
}
