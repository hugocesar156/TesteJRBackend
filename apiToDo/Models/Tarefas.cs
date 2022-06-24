using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        public List<TarefaDTO> Listar()
        {
            try
            {
                return new List<TarefaDTO>
                {
                    new TarefaDTO
                    {
                        IdTarefa = 1,
                        Descricao = "Fazer Compras"
                    },
                    new TarefaDTO
                    {
                        IdTarefa = 2,
                        Descricao = "Fazer Atividad Faculdade"
                    },
                    new TarefaDTO
                    {
                        IdTarefa = 3,
                        Descricao = "Subir Projeto de Teste no GitHub"
                    }
                };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<TarefaDTO> Inserir(TarefaDTO tarefa)
        {
            try
            {
                var lista = Listar();
                lista.Add(tarefa);

                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Deletar(int idTarefa)
        {
            try
            {
                var lista = Listar();
                var tarefa = lista.FirstOrDefault(l => l.IdTarefa == idTarefa);

                if (lista.Remove(tarefa))
                    return true;

                throw new Exception("Falha ao remover registro de tarefa, tente novamente.");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
