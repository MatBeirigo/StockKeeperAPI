﻿using Domain.Interfaces.IUnidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesController : ControllerBase
    {
        private readonly InterfaceUnidades _InterfaceUnidades;
        public UnidadesController(InterfaceUnidades InterfaceUnidades)
        {
            _InterfaceUnidades = InterfaceUnidades;
        }

        [HttpGet("/api/ListarUnidades")]
        [Produces("application/json")]
        public async Task<List<string>> ListarUnidades()
        {
            var categorias = await _InterfaceUnidades.ListarUnidades();
            return categorias.Select(unidades => unidades.Nome).ToList();
        }
    }
}
