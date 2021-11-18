using Domain.Models;
using Domain.Responses;
using MediatR;

namespace Handlers.Purchases.Create
{
    public class CreatePurchaseCommand : IRequest<CommandResponse<PurchaseModel>>
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }
        public string CategoryId { get; set; }
    }
}
