using Orders.BusinessLogic.Services.Postamats.Interfaces;
using Orders.Data.Postamats.Interfaces;
using Orders.Domain.Models;

namespace Orders.BusinessLogic.Services.Postamats
{
    public class PostamatsService : IPostamatsService
    {
        private readonly IPostamatsRepository _postamatsRepository;

        public PostamatsService(
            IPostamatsRepository postamatsRepository
            )
        {
            _postamatsRepository = postamatsRepository;
        }

        public Postamat GetPostamat(string postamatNumber)
        {
            return _postamatsRepository.Get(postamatNumber);
        }
    }
}
