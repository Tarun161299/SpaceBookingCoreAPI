using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.FileIO;
using TalentNode.Domain.interfaces;
using TalentNode.Domain.Models;
using TalentNode.Infrastructure.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TalentNode.Infrastructure.Repositories
{
    public class FoodRepository(TalentNodeDbContext dbContext): IFoodRepository
    {
        public async Task<List<FoodData>> GetAllFoodItems()
        {
            var FoodMenu = (from fm in dbContext.FoodMenu
                            join
                            dc in dbContext.Documents on fm.DocId equals dc.Id
                            join
                            cm in dbContext.FoodCategoryMaster on fm.Category equals cm.CategoryId
                            select new FoodData
                            {
                                Id = fm.Id,
                                FoodDescription = fm.FoodDescription,
                                Quantity = fm.Quantity,
                                Rate = fm.Rate,
                                Category = cm.CategoryName,
                                CreatedOn = fm.CreatedOn,
                                UpdatedOn = fm.UpdatedOn,
                                FileBase64String = dc.FileBase64String,
                                FileType = dc.FileType
                            }).ToList();
            return FoodMenu;

        }
        
    }

}
