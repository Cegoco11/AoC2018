using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4 {
    class Program {
        private static int guardId;

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
            List<Line> listaLineas = leeFichero();
            listaLineas.Sort((x, y) => x.fecha.CompareTo(y.fecha));
            listaLineas = arrastraIds(listaLineas);



            Console.ReadKey();
        }

        static List<Line> leeFichero() {
            string[] lines = System.IO.File.ReadAllLines("..\\..\\test.txt");

            List<Line> listaLineas = new List<Line>();

            DateTime fechaAux;
            int guardId;
            string actionAux;

            foreach (string s in lines) {
                fechaAux = creaFecha(s);
                guardId = creaGuardId(s);
                actionAux = creaAction(s);

                Line a = new Line(fechaAux, guardId, actionAux);

                listaLineas.Add(a);
            }

            return listaLineas;
        }

        private static DateTime creaFecha(string s) {
            int anno = int.Parse(s.Substring(1, 4));
            int month = int.Parse(s.Substring(6, 2));
            int day = int.Parse(s.Substring(9, 2));

            int hours = int.Parse(s.Substring(12, 2));
            int minutes = int.Parse(s.Substring(15, 2));

            return new DateTime(anno, month, day, hours, minutes, 0); ;
        }

        private static int creaGuardId(string s) {
            int posStartId = s.IndexOf('#');
            int guardId;

            if (posStartId == -1) {
                return -1;
            } else {
                string auxSubstring = s.Substring(posStartId);
                int posEndId = auxSubstring.IndexOf(' ');

                guardId = int.Parse(s.Substring(posStartId + 1, posEndId - 1));
            }

            return guardId;
        }

        private static string creaAction(string s) {
            int posHastag = s.IndexOf('#');
            string result;

            if (posHastag == -1) {
                result = s.Substring(19);
            } else {
                result = "begins shift";
            }

            return result;
        }

        private static List<Line> arrastraIds(List<Line> aux) {

            for (int i = 0; i < aux.Count(); i++) {
                if (aux[i].guardId == -1) {
                    aux[i].guardId = aux[i - 1].guardId;
                }
            }

            return aux;
        }

        private static List<Line> calculaEstadoDelGuardia(List<Line> aux) {

            for (int i = 0; i < aux.Count(); i++) {



            }

            return aux;
        }
    }
}
