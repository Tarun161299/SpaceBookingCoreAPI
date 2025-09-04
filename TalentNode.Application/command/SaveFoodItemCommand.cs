using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TalentNode.Domain.interfaces;
using TalentNode.Domain.Models;

namespace TalentNode.Application.command
{
    public record SaveFoodItemCommand(SaveFoodData saveFoodData) : IRequest<int>;

    public class SaveFoodItemCommandHandler(IFoodRepository IFoodRepository) : IRequestHandler<SaveFoodItemCommand, int>
    {


        public async Task<int> Handle(SaveFoodItemCommand request, CancellationToken cancellationToken)
        {
            return await IFoodRepository.saveFoodData(request.saveFoodData);
        }
    }
}
