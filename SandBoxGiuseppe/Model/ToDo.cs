namespace SandBoxGiuseppe.Model
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Titolo { get; set; }
        public string Descrizione { get; set; }

        //Data creazione
        public DateTime DataCreazione { get; set; }

        //Termine di consegna
        public DateTime DataScadenza { get; set; }

        //Fatto
        public bool Done { get; set; }

        //Data completamento
        public DateTime DataCompletamento { get; set; }
    }

    /*
    Operazioni di aggiunta:
    1 - Creare un todo
        - Input -> Titolo, Descrizione, DataScadenza
        - Dovrai inserire anche DataCreazione, Done su false, Id
        - Ritorna un codice 201 -> Created

    Operatori di visualizzazione:
    2 - Visualizzare tutti i todo
        - Input -> Nessuno
        - Output -> Lista di todo
    3 - Visualizzare un todo per id
        - Input -> Id
        - Output -> Todo
        - Caso in cui non ci sia il todo richiesto, ritorna error 404
    4 - Visualizzare tutti i todo completati
        - Input -> Nessuno
        - Output -> Lista di todo completati
    5 - Visualizzare tutti i todo non completati
        - Input -> Nessuno
        - Output -> Lista di todo non completati
    6 - Visualizzare tutti i todo scaduti
        - Input -> Nessuno
        - Output -> Lista di todo non completati

    Operazioni di modifica:
    7 - Modificare un todo by id
        - Input -> Id, Titolo, Descrizione, DataScadenza, Done
        - Dovrai aggiornare la data di completamento se è done
        - Ritorna codice idoneo

    8 - Imposto todo fatto
        - Input -> Id
        - Dovrai aggiornare la data di completamento se è done
        - Ritorna codice idoneo

    Operazioni di eliminazione:
    9 - Eliminare un todo by id
        - Input -> Id
        - Output -> Nessuno
        - Caso in cui non ci sia il todo richiesto, ritorna error 404
        - Ritorna codice idoneo


    Appunti di Giuseppe:


     */


}
