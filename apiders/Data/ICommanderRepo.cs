using apiders.Models;

namespace apiders.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<Commad> GetCommads();
        Commad GetCommad(int id);
        void Create(Commad cm);
        void update(Commad cm);
        void getDelete(int id);
    }
}
