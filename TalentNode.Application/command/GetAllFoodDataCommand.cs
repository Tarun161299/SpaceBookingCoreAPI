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
    
    public record GetAllFoodDataCommand() : IRequest<List<FoodData>>;

    public class GetAllFoodDataCommandHandler(IFoodRepository IFoodRepository) : IRequestHandler<GetAllFoodDataCommand, List<FoodData>>
    {


        public async Task<List<FoodData>> Handle(GetAllFoodDataCommand request, CancellationToken cancellationToken)
        {
            return await IFoodRepository.GetAllFoodItems();
        }
    }
}
