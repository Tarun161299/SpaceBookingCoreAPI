using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TalentNode.Domain.interfaces;

namespace TalentNode.Application.command
{
    
    public record DeleteFoodItemCommand(int foodId) : IRequest<int>;

    public class DeleteFoodItemCommandHandler(IFoodRepository IFoodRepository) : IRequestHandler<DeleteFoodItemCommand, int>
    {


        public async Task<int> Handle(DeleteFoodItemCommand request, CancellationToken cancellationToken)
        {
            return await IFoodRepository.DeleteFoodData(request.foodId);
        }
    }
}
