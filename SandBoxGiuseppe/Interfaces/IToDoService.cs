using SandBoxGiuseppe.Database;
using SandBoxGiuseppe.Model;

namespace SandBoxGiuseppe.Interfaces
{
    public interface IToDoService
    {

        void CreaToDo(ToDo todo);
        
        List<ToDo>GetToDo();
        //altri metodi get?
        ToDo GetToDoById(int id);
        List<ToDo> GetToDoByCompleto();
        List<ToDo> GetToDoByNoNCompletato();
        List<ToDo> GetToDoByScadenza();


        ToDo ModificaToDo(ToDo todo, int id);

        ToDo CompletaToDo(ToDo todo);

        void EliminaToDo(string deleteWith);

    }
}