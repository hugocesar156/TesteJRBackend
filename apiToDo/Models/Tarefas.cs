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

        public void Deletar(int ID_TAREFA)
        {
            try
            {
                List<TarefaDTO> lstResponse = Listar();
                var Tarefa = lstResponse.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                TarefaDTO Tarefa2 = lstResponse.Where(x=> x.ID_TAREFA == Tarefa.ID_TAREFA).FirstOrDefault();
                lstResponse.Remove(Tarefa2);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
