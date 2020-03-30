using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoticiasAPI.Models;
using NoticiasAPI.Services;

namespace NoticiasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private NoticiaService _noticiaService;
        public NoticiaController(NoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
        }

        [HttpGet]
        [Route("prueba")]
        public IActionResult Prueba()
        {
            return Ok("Esto es una prueba");
        }

        [HttpGet]
        [Route("obtener")]
        public IActionResult Obtener()
        {
            var resultado = _noticiaService.Obtener();
            return Ok(resultado);
        }

        [HttpPost]
        [Route("agregar")]
        public IActionResult Agregar([FromBody] Noticia _noticia)
        {
            var resultado = _noticiaService.AgregarNoticia(_noticia);
            if(resultado)
            {
                return Ok();
            } else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("editar")]
        public IActionResult Editar([FromBody] Noticia _noticia)
        {
            var resultado = _noticiaService.EditarNoticia(_noticia);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("eliminar/{NoticiaID}")]
        public IActionResult Eliminar(int NoticiaID)
        {
            var resultado = _noticiaService.EliminarNoticia(NoticiaID);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}