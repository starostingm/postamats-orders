using Orders.Data.Postamats.Interfaces;
using Orders.Domain.Models;
using System.Linq;

namespace Orders.Data.Postamats
{
    public class PostamatsRepository : IPostamatsRepository
    {
        private static readonly Postamat[] _data =
        {
            new Postamat() { PostamatNumber = "PT-0001", Address = "ул. Пушкина, д. 1", IsActual = true },
            new Postamat() { PostamatNumber = "PT-0002", Address = "просп. Ленина, д. 23", IsActual = true },
            new Postamat() { PostamatNumber = "PT-0003", Address = "пер. Молочный, д. 18", IsActual = false },
        };

        public Postamat Get(string postamatNumber)
        {
            return _data.FirstOrDefault(x => x.PostamatNumber == postamatNumber);
        }
    }
}
