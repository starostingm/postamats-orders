using Orders.Domain.Models;

namespace Orders.BusinessLogic.Services.Postamats.Interfaces
{
    public interface IPostamatsService
    {
        Postamat GetPostamat(string postamatNumber);
    }
}
