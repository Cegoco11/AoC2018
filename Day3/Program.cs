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
            SecondPart();

            DateTime dt2 = DateTime.Now;

            Console.WriteLine();
            Console.WriteLine("Time " + dt2.Subtract(dt).TotalSeconds);

            Console.ReadKey();
        }

        static void FirstPart() {
            string[] lines = System.IO.File.ReadAllLines("..\\..\\datos.txt");
            string[] datos;

            Dictionary<string, int[]> magic = new Dictionary<string, int[]>();

            foreach (string line in lines) {

                datos = line.Split(new char[] { '@', ',', ':', 'x' });

                magic = generateCoor(datos, magic);

            }

            int solapados = magic.Where(x => x.Value[0] > 0).Count();

            Console.WriteLine("FirstPart " + solapados);
        }

        static void SecondPart() {
            string[] lines = System.IO.File.ReadAllLines("..\\..\\datos.txt");
            string[] datos;

            Dictionary<string, int[]> magic = new Dictionary<string, int[]>();
            int lineasFichero = 1;

            foreach (string line in lines) {
                lineasFichero++;

                datos = line.Split(new char[] { '@', ',', ':', 'x' });

                magic = generateCoor(datos, magic);

            }

            // TODO Se necesita agregar una lista en vez de una tupla para saber todas las ids de las figuras que convergen en un punto

            HashSet<int> idsFigurasSolapacion = new HashSet<int>();
            foreach (var entry in magic) {
                if (entry.Value[0] > 0) {
                    idsFigurasSolapacion.Add(entry.Value[1]);
                }
            }

            foreach (var entry in magic) {
                if (!idsFigurasSolapacion.Contains(entry.Value[1])) {
                    Console.WriteLine(entry.Value[1]);
                }
            }

            Console.WriteLine("SecondPart ");
        }

        private static Dictionary<string, int[]> generateCoor(string[] m, Dictionary<string, int[]> dict) {
            Dictionary<string, int[]> aux = dict;

            int id = int.Parse(m[0].Substring(1));
            int a = int.Parse(m[1]);
            int b = int.Parse(m[2]);
            int c = int.Parse(m[3]);
            int d = int.Parse(m[4]);

            for (int coorX = a; coorX < a + c; coorX++) {

                for (int coorY = b; coorY < b + d; coorY++) {

                    if (dict.TryGetValue(string.Concat(coorX, ":", coorY), out int[] value)) {
                        dict[string.Concat(coorX, ":", coorY)][0] = value[0] + 1;
                    } else {
                        int[] tupla = new int[] { 0, id };
                        aux.Add(string.Concat(coorX, ":", coorY), tupla);
                    }

                }

            }

            return aux;
        }

    }
}
