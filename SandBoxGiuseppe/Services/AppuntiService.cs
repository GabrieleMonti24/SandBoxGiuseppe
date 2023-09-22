using SandBoxGiuseppe.Database;
using SandBoxGiuseppe.Interfaces;
using SandBoxGiuseppe.Model;

namespace SandBoxGiuseppe.Services
{

    public class AppuntiService : IAppuntiService
    {

        public void AggiungiAppunto(Appunto appunto)
        {
            AppuntiStoreStatic.appunti.Add(appunto);
        }

        public void EliminaAppunto(string deleteWith)
        {
            AppuntiStoreStatic.appunti.RemoveAll(x => x.Titolo.Contains(deleteWith));
        }
    }
}
