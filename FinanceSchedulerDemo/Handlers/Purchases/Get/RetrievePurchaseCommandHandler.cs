using AutoMapper;
using Domain.Models;
using Domain.Purchases;
using Domain.Responses;
using MediatR;
using Services.Purchases;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Purchases.Get
{
    public class RetrievePurchaseCommandHandler : IRequestHandler<GetPurchaseQuery, CommandResponse<PurchaseModel>>
    {
        private readonly PurchasesService service;
        private readonly IMapper mapper;

        public RetrievePurchaseCommandHandler(PurchasesService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<PurchaseModel>> Handle(GetPurchaseQuery request, CancellationToken cancellationToken)
        {
            var purchase = await service.GetPurchaseAsync(request.Id);
            var purchaseModel = mapper.Map<Purchase, PurchaseModel>(purchase);
            var response = new CommandResponse<PurchaseModel>(purchaseModel, "Purchase have been retrieved successfully.");

            return response;
        }
    }
}
