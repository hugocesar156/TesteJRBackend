using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly Tarefas _tarefas;

        public TarefasController(Tarefas tarefas)
        {
            _tarefas = tarefas;
        }

        //[Authorize]
        [HttpGet("Listar")]
        public ActionResult Listar()
        {
            try
            {
                var lista = _tarefas.Listar();

                return new ContentResult
                {
                    StatusCode = 200,
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(lista)
                };
            }
            catch (Exception ex)
            {
                return new ContentResult
                {
                    StatusCode = 400,
                    ContentType = "application/json",
                    Content = $"Ocorreu um erro em sua API {ex.Message}"
                };
            }
        }

        [HttpPost("Inserir")]
        public ActionResult Inserir([FromBody] TarefaDTO tarefa)
        {
            try
            {
                var lista = _tarefas.Inserir(tarefa);

                return new ContentResult
                {
                    StatusCode = 200,
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(lista)
                };
            }
            catch (Exception ex)
            {
                return new ContentResult
                {
                    StatusCode = 400,
                    ContentType = "application/json",
                    Content = $"Ocorreu um erro em sua API {ex.Message}"
                };
            }
        }

        [HttpDelete("Deletar/{idTarefa}")]
        public ActionResult Deletar(int idTarefa)
        {
            try
            {
                var lista = _tarefas.Deletar(idTarefa);

                return new ContentResult
                {
                    StatusCode = 200,
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(lista)
                };
            }
            catch (Exception ex)
            {
                return new ContentResult
                {
                    StatusCode = 400,
                    ContentType = "application/json",
                    Content = $"Ocorreu um erro em sua API {ex.Message}"
                };
            }
        }
    }
}
