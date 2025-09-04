using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.FileIO;
using TalentNode.Domain.Entities;
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

        public async Task<int> DeleteFoodData(int foodId)
        {
            using var transaction = await dbContext.Database.BeginTransactionAsync();

            try
            {
                // 1. Find the FoodMenu by Id
                var food = await dbContext.FoodMenu.FindAsync(foodId);
                if (food == null)
                    return 0; // Not found

                // 2. Find the linked Document
                var document = await dbContext.Documents.FindAsync(food.DocId);

                // 3. Remove FoodMenu
                dbContext.FoodMenu.Remove(food);

                // 4. Remove Document if exists
                if (document != null)
                    dbContext.Documents.Remove(document);

                // 5. Save changes
                await dbContext.SaveChangesAsync();

                // 6. Commit transaction
                await transaction.CommitAsync();

                return 1; // success
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                // log exception
                return 0;
            }
        }

        public async Task<int> UpdateFoodData(FoodData updateFood)
        {
            using var transaction = await dbContext.Database.BeginTransactionAsync();

            try
            {
                // 1. Find the FoodMenu by Id
                var food = await dbContext.FoodMenu.FindAsync(updateFood.Id);
                if (food == null)
                    return 0; // Not found

                // 2. Update Food fields
                food.FoodDescription = updateFood.FoodDescription;
                food.Quantity = updateFood.Quantity;
                food.Rate = updateFood.Rate;
                food.Category = updateFood.Category;
                food.UpdatedOn = DateTime.Now;

                // 3. If new image uploaded → update Document
                if (!string.IsNullOrEmpty(updateFood.FileBase64String) && !string.IsNullOrEmpty(updateFood.FileType))
                {
                    // Validate jpg/jpeg
                   

                    var document = await dbContext.Documents.FindAsync(food.DocId);
                    if (document != null)
                    {
                        document.FileBase64String = updateFood.FileBase64String;
                        document.FileType = updateFood.FileType;
                        document.UpdatedOn = DateTime.Now;
                    }
                }

                // 4. Save changes
                await dbContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return 1; // success
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                // log exception here
                return 0;
            }
        }

        public async Task<int> saveFoodData(SaveFoodData savefood)
        {
            using var transaction = await dbContext.Database.BeginTransactionAsync();

            try
            {
                // 1. Save Document first
                var doc = new Document
                {
                    FileBase64String = savefood.FileBase64String,
                    FileType = savefood.FileType,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                };

                dbContext.Documents.Add(doc);
                await dbContext.SaveChangesAsync(); // ✅ This will generate DocId
                int newDocid = doc.Id;              // ✅ Now populated

                // 2. Save Food with new DocId
                var food = new FoodMenu
                {
                    FoodDescription = savefood.FoodDescription,
                    Quantity = savefood.Quantity,
                    Rate = savefood.Rate,
                    Category = savefood.Category,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    DocId = newDocid   // FK reference
                };

                dbContext.FoodMenu.Add(food);
                await dbContext.SaveChangesAsync();

                // 3. Commit transaction
                await transaction.CommitAsync();

                return 1;
            }
            catch (Exception ex)
            {
                // Rollback on error
                await transaction.RollbackAsync();
                return 0;
            }
        }

    }

}
