﻿using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.DTO;

namespace TaskManagementAPI.Interfaces
{
    public interface ICategoryAppService
    {
        ActionResult<JsonResponseDTO> getCategories();
    }
}
