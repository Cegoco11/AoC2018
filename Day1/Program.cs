using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day1 {
    class Program {
        static void Main(string[] args) {
            //FirstPart();
            SecondPart();
        }

        static void FirstPart() {
            string[] lines = System.IO.File.ReadAllLines("..\\..\\datos.txt");

            int total = 0;

            foreach (string line in lines) {
                total += int.Parse(line);
            }

            Console.WriteLine("Total: " + total);

            Console.ReadKey();
        }

        static void SecondPart() {
            string[] lines = System.IO.File.ReadAllLines("..\\..\\datos.txt");
            List<int> linesInt = lines.Select(x => int.Parse(x)).ToList();

            int aux = 0;
            List<int> resultados = new List<int>();

            bool condition = true;

            DateTime dt = DateTime.Now;

            while (condition) {

                foreach (int line in linesInt) {
                    aux += line;

                    if (resultados.Contains(aux)) {
                        condition = false;
                    } else {
                        resultados.Add(aux);
                    }

                }

            }

            DateTime dt2 = DateTime.Now;
            Console.WriteLine(dt2.Subtract(dt).TotalSeconds);

            Console.WriteLine("Frequency  " + aux);

            Console.ReadKey();

        }

    }
}
