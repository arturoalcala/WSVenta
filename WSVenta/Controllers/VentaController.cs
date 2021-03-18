using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSVenta.DBModels;
using WSVenta.DBModels.Response;
using WSVenta.Services;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {
        private IVentaService _venta;

        public VentaController(IVentaService venta)
        {
            this._venta = venta;
        }

        [HttpPost]
        public IActionResult Add(VentaRequest model)
        {
            var respuesta = new Respuesta();
            try
            {
                _venta.Add(model);
                respuesta.Success = 1;
                respuesta.Message = "Venta agregada correctamente.";

            }
            catch (Exception ex)
            {
                respuesta.Success = 0;
                respuesta.Message = ex.Message;
            }
            return Ok(respuesta);
        }
    }
}
