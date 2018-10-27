using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterConverter.Classes {
    class Converter {
        public Converter() {
            this.name = "hi";
            this._Modulo = 10;
        }

        public string name { get; set; }
        public int _Modulo { get; set; }

        public int myMethod () {
            var testInput = 41;

            var mod = testInput % this._Modulo;

            return mod;
        }
    }
}
