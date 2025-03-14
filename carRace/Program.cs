using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace carRace
{
    internal class Program
    {

        static bool raceOver = false; 
        static readonly object lockObject = new object();

        static void Main(string[] args)
        {

            //Luis Gabriel Stedile Portella
            //Id: 0490083

                Console.WriteLine("Race Starting!\n");

                
                Thread car = new Thread(() => Race("Car"));
                Thread bike = new Thread(() => Race("Bike"));
                Thread runner = new Thread(() => Race("Runner"));

                
                car.Start();
                bike.Start();
                runner.Start();

                
                car.Join();
                bike.Join();
                runner.Join();

                Console.WriteLine("\nRace Completed!");
            }

            static void Race(string racer)
            {
                int distance = 0;
                Random rand = new Random();

                while (distance < 100 && !raceOver)
                {

                    //Reference https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-integer-in-c
                    distance += rand.Next(5, 15); 

                    Console.WriteLine($"{racer} is at {distance} meters...");

                    Thread.Sleep(rand.Next(200, 500)); 

                    lock (lockObject)
                    {
                        if (distance >= 100 && !raceOver)
                        {
                            raceOver = true;
                            Console.WriteLine($"\n{racer} WINS THE RACE!");
                        }
                    }
                }
            }
        }
    }

    

