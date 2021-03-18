using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSVenta.DBModels.Response
{
    public class Respuesta
    {
        public int Success { get; set; } = 0;
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
