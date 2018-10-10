using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Helpers.Operators
{

    public static class OperadoresParaCombosDeFiltros
    {
        public static SortedList GetOperadoresString()
        {
            return new SortedList()
      {
        {
          (object) "",
          (object) ""
        },
        {
          (object) "=",
          (object) "Igual"
        },
        {
          (object) "<>",
          (object) "Distinto"
        },
        {
          (object) ">",
          (object) "Mayor"
        },
        {
          (object) ">=",
          (object) "Mayor Igual"
        },
        {
          (object) "<",
          (object) "Menor"
        },
        {
          (object) "<=",
          (object) "Menor Igual"
        },
        {
          (object) "%%",
          (object) "Contiene a"
        },
        {
          (object) "_%",
          (object) "Comienza con"
        },
        {
          (object) "%_",
          (object) "Finaliza con"
        }
      };
        }

        public static SortedList GetOperadoresDateTime()
        {
            return new SortedList()
      {
        {
          (object) "",
          (object) ""
        },
        {
          (object) "=",
          (object) "Igual"
        },
        {
          (object) "<>",
          (object) "Distinto"
        },
        {
          (object) ">",
          (object) "Mayor"
        },
        {
          (object) ">=",
          (object) "Mayor Igual"
        },
        {
          (object) "<",
          (object) "Menor"
        },
        {
          (object) "<=",
          (object) "Menor Igual"
        },
        {
          (object) "[]",
          (object) "Entre"
        }
      };
        }

        public static SortedList GetOperadoresNumeric()
        {
            return new SortedList()
      {
        {
          (object) "",
          (object) ""
        },
        {
          (object) "=",
          (object) "Igual"
        },
        {
          (object) "<>",
          (object) "Distinto"
        },
        {
          (object) ">",
          (object) "Mayor"
        },
        {
          (object) ">=",
          (object) "Mayor Igual"
        },
        {
          (object) "<",
          (object) "Menor"
        },
        {
          (object) "<=",
          (object) "Menor Igual"
        }
      };
        }
    }
}
