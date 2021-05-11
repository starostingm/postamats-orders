using Orders.Domain.Models;

namespace Orders.Data.Postamats.Interfaces
{
    public interface IPostamatsRepository
    {
        Postamat Get(string postamatNumber);
    }
}
