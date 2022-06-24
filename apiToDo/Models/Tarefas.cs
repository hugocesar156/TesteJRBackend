using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        public static List<TarefaDTO> listaTaerfas = new List<TarefaDTO>
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

        public bool Atualizar(TarefaDTO tarefa)
        {
            try
            {
                var lista = Listar();
                var item = lista.FirstOrDefault(l => l.IdTarefa == tarefa.IdTarefa);

                if (item != null)
                {
                    item.Descricao = tarefa.Descricao;
                    return true;
                }

                throw new Exception("Falha ao atualizar registro de tarefa, tente novamente.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TarefaDTO Buscar(int idTarefa)
        {
            try
            {
                return Listar().FirstOrDefault(l => l.IdTarefa == idTarefa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //o método de remoção recebe o ID do registro que deve ser removido na lista
        public bool Deletar(int idTarefa)
        {
            try
            {
                //a lista é carregada
                var lista = Listar();

                //é feito a busca do item na lista com o ID informado
                var tarefa = lista.FirstOrDefault(l => l.IdTarefa == idTarefa);

                /* é feito a validação de remoção, em caso de sucesso o método retornará true, 
                indicando que o registro foi removido com sucesso */
                if (lista.Remove(tarefa))
                    return true;

                //em caso de falha uma exceção será lançada
                throw new Exception("Falha ao remover registro de tarefa, tente novamente.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Inserir(TarefaDTO tarefa)
        {
            try
            {
                var lista = Listar();

                tarefa.IdTarefa = lista.Last().IdTarefa + 1;
                lista.Add(tarefa);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TarefaDTO> Listar()
        {
            try
            {
                return listaTaerfas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
