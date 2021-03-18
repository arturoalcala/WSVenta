using System;
using System.Collections.Generic;

#nullable disable

namespace WSVenta.DBModels
{
    public partial class Ventum
    {
        public Ventum()
        {
            Detalles = new HashSet<Detalle>();
        }

        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<Detalle> Detalles { get; set; }
    }
}
