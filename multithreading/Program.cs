using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace multithreading
{
    public class Program
    {
        static void Main(string[] args)
        {

            //Luis Gabriel Stedile Portella
            //Id: 0490083

            CountingThread countingThreadNumbers = new CountingThread();
            CountingThread countingThreadLetters = new CountingThread();

            Thread threadNumbers = new Thread(new ThreadStart(countingThreadNumbers.countNumbers));
            Thread threadLetters = new Thread(new ThreadStart(countingThreadLetters.countNumbersReverse));

            threadNumbers.Start();
            threadLetters.Start();
        }
    }
}
