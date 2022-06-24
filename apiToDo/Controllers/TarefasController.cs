﻿using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

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

        //aqui é definido o caminho para a rota de remoção de tarefa, o ID da tarefa é obrigatório
        [HttpDelete("Deletar/{idTarefa}")]
        public ActionResult Deletar(int idTarefa)
        {
            try
            {
                //aqui é feito a validação de remoção de registro
                if (_tarefas.Deletar(idTarefa))
                {
                    //em caso de sucesso, é carregado a lista atualizada 
                    var lista = _tarefas.Listar();

                    /* aqui é feito a remoção do item novamente, necessário somente
                    pelo motido da lista estar em hardcode */
                    lista.Remove(lista.FirstOrDefault(l => l.IdTarefa == idTarefa));

                    //então a lista é retornada
                    return new ContentResult
                    {
                        StatusCode = 200,
                        ContentType = "application/json",
                        Content = JsonConvert.SerializeObject(lista)
                    };
                }

                //em caso de erro, uma exceção é lançada 
                throw new Exception();
            }
            catch (Exception ex)
            {
                //será retornado uma mensagem de erro com o detalhamento do problema
                return new ContentResult
                {
                    StatusCode = 400,
                    ContentType = "application/json",
                    Content = $"Ocorreu um erro em sua API: {ex.Message}"
                };
            }
        }
    }
}
