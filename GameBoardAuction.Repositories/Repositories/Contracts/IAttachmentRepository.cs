using GameBoardAuction.Entities.Models;
using GameBoardAuction.Repositories.Base.Contracts;
using System.Threading.Tasks;

namespace GameBoardAuction.Repositories.Repositories.Contracts
{
    public interface IAttachmentRepository : IBaseRepository<Attachment>
    {
        Task<Attachment> AddAttachment(Attachment entity, string addedBy);
    }
}
