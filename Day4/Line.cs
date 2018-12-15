using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4 {
    class Line {

        public DateTime fecha { get; set; }
        public int guardId { get; set; }
        public string action { get; set; }
        public bool[] estadoHora;

        public Line(DateTime fecha, int guardId, string action) {
            this.fecha = fecha;
            this.guardId = guardId;
            this.action = action;
            this.estadoHora = new bool[60];
        }

        public override string ToString() {
            return string.Format("{0}-{1}-{2} {3}:{4} Guard {5} {6}", fecha.Year, fecha.Month, fecha.Day, fecha.Hour, fecha.Minute, guardId, action);
        }
    }
}
