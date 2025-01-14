﻿using BicycleApp.Services.Models;

namespace BicycleApp.Services.Contracts
{
    public interface IDropdownsContentService
    {
        Task<ICollection<PartInfoDto>> GetAllFrames();
        Task<ICollection<PartDto>> GetAllCompatibleParts(int id);
        Task<PartDto> GetPartByIdAsync(int id);
    }
}
