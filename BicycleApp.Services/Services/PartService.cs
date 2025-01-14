﻿namespace BicycleApp.Services.Services
{
    using BicycleApp.Data;
    using BicycleApp.Data.Models.EntityModels;
    using BicycleApp.Services.Contracts;
    using BicycleApp.Services.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class PartService : IPartService
    {
        private readonly BicycleAppDbContext dbContext;
        private readonly IModelsFactory modelFactory;

        public PartService(BicycleAppDbContext dbContext, IModelsFactory modelFactory)
        {
            this.dbContext = dbContext;
            this.modelFactory = modelFactory;
        }

        /// <summary>
        /// Add Part entity to the database
        /// </summary>
        /// <param name="partAddDto">Info</param>
        /// <returns>True/False</returns>
        public async Task<bool> AddNewPart(PartAddDto partAddDto)
        {
            if (partAddDto == null)
            {
                return false;
            }

            Part part = modelFactory.CreatePart(partAddDto);

            await dbContext.Parts.AddAsync(part);
            await dbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Edits a part entity in the database
        /// </summary>
        /// <param name="partEditDto">Info</param>
        /// <returns>True/False</returns>
        public async Task<bool> EditPart(PartEditDto partEditDto)
        {
            if (partEditDto == null)
            {
                return false;
            }

            Part? part = await dbContext.Parts
                .FirstOrDefaultAsync(p => p.Id == partEditDto.Id);

            if (part == null)
            {
                return false;
            }

            part.Name = partEditDto.Name;
            part.Description = partEditDto.Description;
            part.Intend = partEditDto.Intend;
            part.OEMNumber = partEditDto.OEMNumber;
            part.Type = partEditDto.Type;
            part.CategoryId = partEditDto.CategoryId;
            part.Quantity = partEditDto.Quantity;
            part.SalePrice = partEditDto.SalePrice;
            part.VATCategoryId = partEditDto.VATCategoryId;
            part.DateUpdated = DateTime.UtcNow;

            await dbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Get all categories for the dropdowns
        /// </summary>
        /// <returns>DTO</returns>
        public async Task<PartGetDto> GetCategoties()
        {
            List<ObjectDto> partCategories = await dbContext.PartCategories
                .Select(p => new ObjectDto()
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();

            List<ObjectDto> vatCategories = await dbContext.VATCategories
                .Select(v => new ObjectDto()
                {
                    Id = v.Id,
                    Name = v.VATPercent.ToString()
                })
                .ToListAsync();

            return new PartGetDto()
            {
                PartCategories = partCategories,
                VatCategories = vatCategories
            };
        }

        /// <summary>
        /// Returns full info for a part
        /// </summary>
        /// <param name="partId">Id of the part</param>
        /// <returns>Dto or null</returns>
        public async Task<PartFullInfoDto?> GetPartById(int partId)
        {
            PartFullInfoDto? partDto = await dbContext.Parts
                 .Where(p => p.Id == partId)
                 .Select(p => new PartFullInfoDto()
                 {
                     Name = p.Name,
                     Description = p.Description,
                     Intend = p.Intend,
                     OEMNumber = p.OEMNumber,
                     SalePrice = p.SalePrice,
                     Type = p.Type,
                     Category = p.Category.Name
                 })
                 .FirstOrDefaultAsync();

            if (partDto == null)
            {
                return null;
            }

            partDto.Images = await dbContext.ImagesParts
                .Where(p => p.Id == partId)
                .Select(i => i.ImageUrl)
                .ToListAsync();

            return partDto;
        }
    }
}
