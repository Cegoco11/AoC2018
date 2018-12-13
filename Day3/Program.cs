using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3 {
    class Program {
        static void Main(string[] args) {
            DateTime dt = DateTime.Now;

            FirstPart();
            //SecondPart();

            DateTime dt2 = DateTime.Now;

            Console.WriteLine();
            Console.WriteLine("Time " + dt2.Subtract(dt).TotalSeconds);

            Console.ReadKey();
        }

        static void FirstPart() {
            string[] lines = System.IO.File.ReadAllLines("..\\..\\datos.txt");
            string[] datos;

            Dictionary<string, int> magic = new Dictionary<string, int>(); //generateCompleteMatrix();

            foreach (string line in lines) {

                datos = line.Split(new char[] { '@', ',', ':', 'x' });
                datos = datos.Where(x => x.Substring(0, 1) != "#").ToArray();

                magic = generateCoor(datos, magic);

            }

            int contador = 0;

            foreach (var entry in magic) {
                if (entry.Value > 0) {
                    contador++;
                }
            }

            Console.WriteLine(contador);
        }

        private static Dictionary<string, int> generateCoor(string[] m, Dictionary<string, int> dict) {
            Dictionary<string, int> aux = dict;

            int a = int.Parse(m[0]);
            int b = int.Parse(m[1]);
            int c = int.Parse(m[2]);
            int d = int.Parse(m[3]);

            for (int coorX = a; coorX < a + c; coorX++) {

                for (int coorY = b; coorY < b + d; coorY++) {

                    if (dict.TryGetValue(string.Concat(coorX, ":", coorY), out int value)) {
                        dict[string.Concat(coorX, ":", coorY)] = value + 1;
                    } else {
                        aux.Add(string.Concat(coorX, ":", coorY), 0);
                    }

                }

            }

            return aux;
        }

    }
}
