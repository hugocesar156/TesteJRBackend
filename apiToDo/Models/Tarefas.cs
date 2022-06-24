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
                        ID_TAREFA = 1,
                        DS_TAREFA = "Fazer Compras"
                    },
                    new TarefaDTO
                    {
                        ID_TAREFA = 2,
                        DS_TAREFA = "Fazer Atividad Faculdade"
                    },
                    new TarefaDTO
                    {
                        ID_TAREFA = 3,
                        DS_TAREFA = "Subir Projeto de Teste no GitHub"
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

        public List<TarefaDTO> Deletar(int idTarefa)
        {
            try
            {
                var lista = Listar();
                var tarefa = lista.FirstOrDefault(l => l.ID_TAREFA == idTarefa);

                lista.Remove(tarefa);
                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
