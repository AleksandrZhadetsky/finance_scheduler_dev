using AutoMapper;
using Domain.Models;
using Domain.Purchases;
using Domain.Responses;
using MediatR;
using Services.Purchases;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Purchases.Create
{
    public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, CommandResponse<PurchaseModel>>
    {
        private readonly PurchasesService service;
        private readonly IMapper mapper;

        public CreatePurchaseCommandHandler(PurchasesService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<PurchaseModel>> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var purchase = mapper.Map<CreatePurchaseCommand, Purchase>(request);

            try
            {
                var createdPurchase = await service.CreatePurchaseAsync(purchase);
                var purchaseModel = mapper.Map<Purchase, PurchaseModel>(createdPurchase);
                var response = new CommandResponse<PurchaseModel>(purchaseModel, "Purchase have been created successfully.");

                return response;
            }
            catch (System.Exception)
            {
                return new CommandResponse<PurchaseModel>("Purchase creation failed.");
            }
        }
    }
}
