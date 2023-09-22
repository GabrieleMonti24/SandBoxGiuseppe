using SandBoxGiuseppe.Model;

namespace SandBoxGiuseppe.Interfaces
{
    public interface IAppuntiService
    {

        void AggiungiAppunto(Appunto appunto);
        void EliminaAppunto(string deleteWith);

    }
}
