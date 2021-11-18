using Domain.Models;
using Domain.Responses;
using MediatR;

namespace Handlers.Purchases.Get
{
    public class GetPurchaseQuery : IRequest<CommandResponse<PurchaseModel>>
    {
        public string Id { get; set; }
    }
}
