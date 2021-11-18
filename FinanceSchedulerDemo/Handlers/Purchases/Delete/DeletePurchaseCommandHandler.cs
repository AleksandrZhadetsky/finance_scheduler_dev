using AutoMapper;
using Domain.Models;
using Domain.Responses;
using MediatR;
using Services.Purchases;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Purchases.Delete
{
    public class DeletePurchaseCommandHandler : IRequestHandler<DeletePurchaseCommand, CommandResponse<PurchaseModel>>
    {
        private readonly PurchasesService service;
        private readonly IMapper mapper;

        public DeletePurchaseCommandHandler(PurchasesService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<PurchaseModel>> Handle(DeletePurchaseCommand request, CancellationToken cancellationToken)
        {
            await service.DeletePurchaseAsync(request.Id);

            return new CommandResponse<PurchaseModel>(null, "Purchase have been deletet successfully.");
        }
    }
}
