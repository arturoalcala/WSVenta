using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSVenta.DBModels.Response
{
    public class VentaRequest
    {
        public VentaRequest()
        {
            this.Detalle = new List<Detalle>();
        }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "El valor debe ser mayor que 0")]
        [ExisteCliente(ErrorMessage = "El cliente no existe")]
        public int IdCliente { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "La venta debe tener productos")]
        public List<Detalle> Detalle { get; set; }
    }

    public class Detalle
    {
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public int IdProducto { get; set; }
    }

    #region Validaciones

    public class ExisteClienteAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var isValid = false;
            if (value != null && int.TryParse(value.ToString(), out int idCliente))
            {
                using (var db = new VentasContext())
                {
                    isValid = db.Clientes.Find(idCliente) != null;
                }
            }
            return isValid;
        }
    }

    #endregion
}