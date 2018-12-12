using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day1 {
    class Program {
        static void Main(string[] args) {
            DateTime dt = DateTime.Now;

            FirstPart();
            SecondPart();

            DateTime dt2 = DateTime.Now;

            Console.WriteLine();
            Console.WriteLine("Time " + dt2.Subtract(dt).TotalSeconds);

            Console.ReadKey();
        }

        static void FirstPart() {
            string[] lines = System.IO.File.ReadAllLines("..\\..\\datos.txt");

            int total = 0;

            foreach (string line in lines) {
                total += int.Parse(line);
            }

            Console.WriteLine("FirstPart " + total);

        }

        static void SecondPart() {
            string[] lines = System.IO.File.ReadAllLines("..\\..\\datos.txt");
            List<int> linesInt = lines.Select(x => int.Parse(x)).ToList();

            int aux = 0;
            HashSet<int> resultados = new HashSet<int>();

            bool condition = true;

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

            Console.WriteLine("SecondPart  " + aux);

        }

    }
}
