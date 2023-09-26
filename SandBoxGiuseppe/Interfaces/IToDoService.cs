using SandBoxGiuseppe.Model;

namespace SandBoxGiuseppe.Interfaces
{
    public interface IToDoService
    {

        void CreaToDo(ToDoSemplice todoSemplice);

        List<ToDo> GetToDo();
        //altri metodi get?
        ToDo GetToDoById(int id);
        List<ToDo> GetToDoByCompleto();
        List<ToDo> GetToDoByNoNCompletato();
        List<ToDo> GetToDoByScadenza();


        ToDo ModificaToDo(ToDo todo, int id);

        void CompletaToDo(int id);

        void EliminaToDo(string deleteWith);
        void EliminaToDoById(int id);
    }
}