using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2 {
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

            int total_cont2 = 0;
            int total_cont3 = 0;

            int cont2 = 0;
            int cont3 = 0;
            int aux = 0;

            string[] lines = System.IO.File.ReadAllLines("..\\..\\datos.txt");
            for (int a = 0; a < lines.Count(); a++) {
                string line = lines[a];

                cont2 = 0;
                cont3 = 0;

                for (int i = 0; i < line.Count(); i++) {

                    aux = 0;

                    for (int j = 0; j < line.Count(); j++) {

                        if (line[i] == line[j]) {
                            aux++;
                        }
                    }

                    if (aux == 2) {
                        cont2++;
                    } else if (aux == 3) {
                        cont3++;
                    }

                }

                if (cont2 >= 1) {
                    total_cont2++;
                }

                if (cont3 >= 1) {
                    total_cont3++;
                }

            }

            Console.WriteLine("FirstPart " + total_cont2 * total_cont3);
        }

        static void SecondPart() {
            string[] lines = System.IO.File.ReadAllLines("..\\..\\datos.txt");

            List<string> resultadoAProcesar = new List<string>();
            int contDiff = 0;

            for (int a = 0; a < lines.Count() - 1; a++) {

                for (int b = 1; b < lines.Count(); b++) {

                    contDiff = 0;

                    for (int i = 0; i < lines[a].Length; i++) {

                        if (lines[a][i] != lines[b][i]) {
                            contDiff++;
                        }
                    }

                    if (contDiff == 1) {
                        resultadoAProcesar.Add(lines[a]);
                        break;
                    }

                }

            }

            string resultado = "";
            for (int i = 0; i< resultadoAProcesar[0].Length; i++) {
                if (resultadoAProcesar[0][i] == resultadoAProcesar[1][i]) {
                    resultado += resultadoAProcesar[0][i];
                }
            }

            Console.WriteLine("SecondPart" + resultado);

        }

    }
}
