using Domain.Models;
using Domain.Responses;
using MediatR;

namespace Handlers.Purchases.Delete
{
    public class DeletePurchaseCommand : IRequest<CommandResponse<PurchaseModel>>
    {
        public string Id { get; set; }
    }
}
