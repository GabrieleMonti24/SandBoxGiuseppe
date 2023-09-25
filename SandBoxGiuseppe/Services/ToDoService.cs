using Microsoft.AspNetCore.Mvc;
using SandBoxGiuseppe.Database;
using SandBoxGiuseppe.Interfaces;
using SandBoxGiuseppe.Model;
using System.Data;

namespace SandBoxGiuseppe.Services
{


    public class ToDoService : IToDoService
    {
        int counterId;
        public void CreaToDo(ToDo toDo)
        {
            int newId = ToDoStoreStatic.toDos.Count > 0 ? ToDoStoreStatic.toDos.Max(td => td.Id) + 1 : 1;
            toDo.Id = newId;
            toDo.DataCreazione = DateTime.Now;
            toDo.Done = false;
            ToDoStoreStatic.toDos.Add(toDo);
        }

        List<ToDo> IToDoService.GetToDo()
        {

            return ToDoStoreStatic.toDos;
        }

        public ToDo GetToDoById(int id)
        {
            var todo =  ToDoStoreStatic.toDos.FirstOrDefault(todo => todo.Id == id);

            if (todo == null) {

              return null;
            
            }
            return todo;
        }

        public List<ToDo> GetToDoByNoNCompletato()
        {
            List<ToDo> nonCompletatiTodos = ToDoStoreStatic.toDos.Where(todo => todo.Done == false).ToList();
            return nonCompletatiTodos;
            
        }

        public List<ToDo> GetToDoByScadenza()
        {
            DateTime currentDate = DateTime.Now;

            var toDosScaduti = ToDoStoreStatic.toDos
                .Where(todo => todo.DataScadenza != null && todo.DataScadenza < currentDate)
                .ToList();

            return toDosScaduti;
        }

        public ToDo ModificaToDo(ToDo todo, int id)
        {
             todo = ToDoStoreStatic.toDos.FirstOrDefault(todo => todo.Id == id);

            string titolo = todo.Titolo;
            string descrizione = todo.Descrizione;
            DateTime dataScadenza = todo.DataScadenza;

            ToDo newTodo = new ToDo(todo.Id,titolo,descrizione,todo.DataCreazione,dataScadenza,todo.Done,todo.DataCompletamento);
            return newTodo;
        }
         public void EliminaToDo(string deleteWith)
        {
            ToDoStoreStatic.toDos.RemoveAll(x => x.Titolo.Contains(deleteWith));
        }

        public List<ToDo> GetToDoByCompleto()
        {
            List<ToDo> completatiTodos = ToDoStoreStatic.toDos.Where(todo => todo.Done == false).ToList();
            return completatiTodos;
        }

        ToDo IToDoService.CompletaToDo(ToDo todo) {

            todo.Done = true;
            todo.DataCompletamento = DateTime.Now;

            return todo;
        
        }

        
        }
    }  
