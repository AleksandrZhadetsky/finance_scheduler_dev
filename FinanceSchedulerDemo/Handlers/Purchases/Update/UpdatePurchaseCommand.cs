using Domain.Models;
using Domain.Responses;
using MediatR;

namespace Handlers.Purchases.Update
{
    public class UpdatePurchaseCommand : IRequest<CommandResponse<PurchaseModel>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }
        public string CategoryId { get; set; }
    }
}
