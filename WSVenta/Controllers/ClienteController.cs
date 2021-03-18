using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSVenta.DBModels;
using WSVenta.DBModels.Response;
using WSVenta.DBModels.SerializableModels;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var respuesta = new Respuesta();
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    var query = db.Clientes.OrderByDescending(c => c.Id).ToList();
                    respuesta.Success = 1;
                    respuesta.Data = query;
                }
            }
            catch (Exception ex)
            {
                respuesta.Message = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPost]
        public IActionResult Add(Cliente_Serializable cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    var modelCliente = new Cliente()
                    {
                        Nombre = cliente.Nombre
                    };
                    db.Clientes.Add(modelCliente);
                    db.SaveChanges();
                    respuesta.Success = 1;
                }
            }
            catch (Exception ex)
            {
                respuesta.Message = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPut]
        public IActionResult Update(Cliente_Serializable cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    var modelCliente = db.Clientes.Where(c => c.Id == cliente.Id).FirstOrDefault();
                    if (modelCliente != null)
                    {
                        modelCliente.Nombre = cliente.Nombre;
                        db.SaveChanges();
                        respuesta.Success = 1;
                        respuesta.Message = "Datos modificados";
                    }
                    else
                    {
                        respuesta.Message = "No existe el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.Message = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var respuesta = new Respuesta();
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    var modelCliente = db.Clientes.Where(c => c.Id == id).FirstOrDefault();
                    if (modelCliente != null)
                    {
                        db.Clientes.Remove(modelCliente);
                        db.SaveChanges();
                        respuesta.Success = 1;
                        respuesta.Message = "Cliente eliminado";
                    }
                    else
                    {
                        respuesta.Message = "No existe el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.Message = ex.Message;
            }
            return Ok(respuesta);
        }
    }
}
