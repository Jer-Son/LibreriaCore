using TestDb.Data;
using TestDb.Models;

namespace TestDb.Services
{
    public class EditorialService
    {

        private readonly EditorialRepository EditorialRepository;
        public EditorialService(EditorialRepository EditorialRepository)
        {
            this.EditorialRepository = EditorialRepository;
        }

        public IEnumerable<Editorial> listar()
        {
            return EditorialRepository.ListEditorial();
        }
        public void Crear(int id,string name)
        {
            Editorial editorial = new Editorial();


            if (name == null)
                throw new Exception("Nombre invalido");

            else if (
            EditorialRepository.EditorialExists(id))
                throw new Exception("id repetido");
            editorial.IdEditorial = id;
            editorial.NombreEditorial = name;
            EditorialRepository.CreateEditorial(editorial);

        }

    }
}
