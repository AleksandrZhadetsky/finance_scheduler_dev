using AutoMapper;
using Domain.Models;
using Domain.Purchases;
using Domain.Responses;
using MediatR;
using Services.Purchases;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Purchases.Update
{
    public class UpdatePurchaseCommandHandler : IRequestHandler<UpdatePurchaseCommand, CommandResponse<PurchaseModel>>
    {
        private readonly PurchasesService service;
        private readonly IMapper mapper;

        public UpdatePurchaseCommandHandler(PurchasesService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<PurchaseModel>> Handle(UpdatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var purchase = mapper.Map<UpdatePurchaseCommand, Purchase>(request);
            var updatedPurchaseEntity = await service.UpdatePurchaseAsync(purchase);
            var updatedPurchaseModel = mapper.Map<Purchase, PurchaseModel>(updatedPurchaseEntity);
            var response = new CommandResponse<PurchaseModel>(updatedPurchaseModel, "Purchase have been updated successfully.");

            return response;
        }
    }
}
