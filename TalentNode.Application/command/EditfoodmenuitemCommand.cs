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
  
    public record EditfoodmenuitemCommand(FoodData foodData) : IRequest<int>;

    public class EditfoodmenuitemCommandHandler(IFoodRepository IFoodRepository) : IRequestHandler<EditfoodmenuitemCommand, int>
    {


        public async Task<int> Handle(EditfoodmenuitemCommand request, CancellationToken cancellationToken)
        {
            return await IFoodRepository.UpdateFoodData(request.foodData);
        }
    }
}
