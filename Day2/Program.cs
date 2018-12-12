using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2 {
    class Program {
        static void Main(string[] args) {
            FirstPart();
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

                if (cont2>=1) {
                    total_cont2++;
                }

                if (cont3 >= 1) {
                    total_cont3++;
                }

            }

            Console.WriteLine("CheckSum " + total_cont2 * total_cont3);

            Console.ReadKey();
        }

        static void SecondPart() {
            // TODO
        }
    }
}
