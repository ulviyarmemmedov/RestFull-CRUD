using apiders.Connection;
using apiders.Models;
using apiders.Connection;

namespace apiders.Data
{
    public class MockCOmmanderRepo : ICommanderRepo
    {
        private readonly MyDbContext _context;
        public MockCOmmanderRepo(MyDbContext context)
        {
            _context = context;
        }

        public Commad GetCommad(int id)
        {
            var com = _context.Commads.FirstOrDefault(x => x.Id == id);
            return com;
        }

        public IEnumerable<Commad> GetCommads()
        {
            return _context.Commads.ToList();
        }



        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Create(Commad cm)
        {
            if (cm == null)
            {
                throw new ArgumentNullException(nameof(cm));
            }
            _context.Commads.Add(cm);
        }

        public void update(Commad cm)
        {
            _context.Update(cm);
        }


        public void getDelete(int id)
        {
            var deleteitem = _context.Commads.FirstOrDefault(x => x.Id == id);
            _context.Remove(deleteitem);
        }
    }
}
