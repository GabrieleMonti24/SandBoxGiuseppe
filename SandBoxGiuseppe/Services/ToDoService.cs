using SandBoxGiuseppe.Database;
using SandBoxGiuseppe.Interfaces;
using SandBoxGiuseppe.Model;
using System.Data;

namespace SandBoxGiuseppe.Services
{


    public class ToDoService : IToDoService
    {
        
        public void CreaToDo(ToDoSemplice toDoSemplice)
        {

            ToDo toDo = new ToDo();
            int newId = ToDoStoreStatic.toDos.Count > 0 ? ToDoStoreStatic.toDos.Max(td => td.Id) + 1 : 1;
            toDo.Id = newId;
            toDo.Titolo = toDoSemplice.Titolo;
            toDo.Descrizione = toDoSemplice.Descrizione;
            toDo.DataScadenza = toDoSemplice.DataScadenza;
            toDo.DataCreazione = DateTime.Now;
            toDo.Done = false;
            ToDoStoreStatic.toDos.Add(toDo);
            
        }

        public List<ToDo> GetToDo()
        {

            return ToDoStoreStatic.toDos;
        }

        public ToDo GetToDoById(int id)
        {
            var todo = ToDoStoreStatic.toDos.FirstOrDefault(todo => todo.Id == id);

            if (todo == null)
            {

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

        public ToDo ModificaToDo(ToDo todoToEdit, int id)
        {
            var originalTodo = ToDoStoreStatic.toDos.FirstOrDefault(todo => todo.Id == id);


            if (originalTodo == null)
            {
                throw new Exception("ToDo non trovato");
            }

            originalTodo.Titolo = todoToEdit.Titolo;
            originalTodo.Descrizione = todoToEdit.Descrizione;
            originalTodo.DataScadenza = todoToEdit.DataScadenza;

            int ToRemove = ToDoStoreStatic.toDos.FindIndex(todo => todo.Id == id);
            ToDoStoreStatic.toDos.RemoveAt(ToRemove);

            ToDoStoreStatic.toDos.Add(originalTodo);


            return originalTodo;
        }

        public List<ToDo> GetToDoByCompleto()
        {
            List<ToDo> completatiTodos = ToDoStoreStatic.toDos.Where(todo => todo.Done == false).ToList();
            return completatiTodos;
        }

        public void CompletaToDo(int id)
        {
            var todo = ToDoStoreStatic.toDos.FirstOrDefault(todo => todo.Id == id);
            int index = ToDoStoreStatic.toDos.FindIndex(todo => todo.Id == id);

            if (todo == null)
            {
                throw new Exception("ToDo non trovato");
            }
            else { 
             
                todo.Done = true;
                todo.DataCompletamento = DateTime.Now;   
                ToDoStoreStatic.toDos.RemoveAt(index);
                ToDoStoreStatic.toDos.Add(todo);
            }
        }
        public void EliminaToDo(string deleteWith)
        {
            ToDoStoreStatic.toDos.RemoveAll(x => x.Titolo.Contains(deleteWith));
        }

        public void EliminaToDoById(int id)
        {
            ToDoStoreStatic.toDos.RemoveAll(x => x.Id == id);
        }
    }
}
