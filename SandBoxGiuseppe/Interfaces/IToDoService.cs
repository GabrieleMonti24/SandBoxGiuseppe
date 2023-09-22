using SandBoxGiuseppe.Model;

namespace SandBoxGiuseppe.Interfaces
{
    public interface IToDoService
    {

        void CreaToDo();
        void AggiungiToDo();
        
        void GetToDo();
        //altri metodi get?

        void ModificaToDo();

        void CompleteToDo();

        void EliminaToDO();

    }
}