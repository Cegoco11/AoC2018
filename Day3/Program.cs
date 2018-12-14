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

            Dictionary<string, List<int>> magic = new Dictionary<string, List<int>>();

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

            Dictionary<string, List<int>> magic = new Dictionary<string, List<int>>();
            int lineasFichero = 1;

            foreach (string line in lines) {
                lineasFichero++;

                datos = line.Split(new char[] { '@', ',', ':', 'x' });

                magic = generateCoor(datos, magic);

            }

            HashSet<int> idsFigurasSolapacion = buscaIdsFigurasConSolapacion(magic);

            int result = 0;
            foreach (var entry in magic) {
                for (int i = 1; i < entry.Value.Count(); i++) {
                    if (!idsFigurasSolapacion.Contains(entry.Value[i])) {
                        result = entry.Value[i];
                    }
                }
            }

            Console.WriteLine("SecondPart " + result);
        }

        private static HashSet<int> buscaIdsFigurasConSolapacion(Dictionary<string, List<int>> magic) {
            HashSet<int> aux = new HashSet<int>();
            foreach (var entry in magic) {
                if (entry.Value[0] > 0) {
                    for (int i = 1; i < entry.Value.Count; i++) {
                        aux.Add(entry.Value[i]);
                    }
                }
            }

            return aux;
        }

        private static Dictionary<string, List<int>> generateCoor(string[] m, Dictionary<string, List<int>> dict) {
            Dictionary<string, List<int>> aux = dict;

            int id = int.Parse(m[0].Substring(1));
            int a = int.Parse(m[1]);
            int b = int.Parse(m[2]);
            int c = int.Parse(m[3]);
            int d = int.Parse(m[4]);

            List<int> listaAux = new List<int>();

            for (int coorX = a; coorX < a + c; coorX++) {

                for (int coorY = b; coorY < b + d; coorY++) {

                    if (dict.TryGetValue(string.Concat(coorX, ":", coorY), out List<int> value)) {
                        dict[string.Concat(coorX, ":", coorY)][0] = value[0] + 1;
                        aux[string.Concat(coorX, ":", coorY)].Add(id);
                    } else {
                        listaAux = new List<int>();
                        listaAux.Add(0);
                        listaAux.Add(id);
                        aux.Add(string.Concat(coorX, ":", coorY), listaAux);
                    }

                }

            }

            return aux;
        }

    }
}
