using TestDb.Models;

namespace TestDb.Data
{
    public class EditorialRepository
    {

        private readonly TestDbContext _context;

        public EditorialRepository(TestDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Editorial> ListEditorial()
        {
            return _context.Editorial.ToList();
        }
        public bool CreateEditorial(Editorial EditorialToCreate)
        {
            try
            {
                _context.Editorial.Add(EditorialToCreate);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool   EditorialExists(int id)
        {
            return (_context.Editorial?.Any(e => e.IdEditorial == id)).GetValueOrDefault();
        }
    }
}
