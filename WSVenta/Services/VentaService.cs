using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVenta.DBModels;
using WSVenta.DBModels.Response;

namespace WSVenta.Services
{
    public class VentaService : IVentaService
    {
        public void Add(VentaRequest model)
        {
            using (var db = new VentasContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var venta = new Ventum()
                        {
                            Fecha = DateTime.UtcNow,
                            IdCliente = model.IdCliente,
                            Total = model.Detalle.Any() ? model.Detalle.Sum(c => c.Cantidad * c.PrecioUnitario) : 0
                        };

                        var detalle = model.Detalle.Select(c => new DBModels.Detalle()
                        {
                            IdProducto = c.IdProducto,
                            Cantidad = c.Cantidad,
                            PrecioUnitario = c.PrecioUnitario,
                            Importe = c.Cantidad * c.PrecioUnitario
                        });

                        venta.Detalles = detalle.ToList();

                        db.Venta.Add(venta);

                        db.SaveChanges();

                        transaction.Commit();
                        //respuesta.Success = 1;
                        //respuesta.Message = "Venta agregada correctamente.";
                    }
                    catch (Exception ex)
                    {
                        //respuesta.Success = 0;
                        //respuesta.Message = ex.Message;
                        transaction.Rollback();
                        throw new Exception("Ocurrió un error en la inserción. " + ex.Message);
                    }
                }
            }
        }
    }
}
