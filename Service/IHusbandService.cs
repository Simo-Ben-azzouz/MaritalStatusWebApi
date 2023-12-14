using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patrickLearn.DTOs.Husband;
using patrickLearn.Models;

namespace patrickLearn.Service
{
    public interface IHusbandService
    {
        Task<ServiceResponse<List<GetHusbandDTO>>> GetAllHusband(string? filterOn = null , string? filterQuery = null);
        Task<ServiceResponse<GetHusbandDTO>> GetHusbandById(int id);
        Task<ServiceResponse<List<GetHusbandDTO>>> AddHusband(AddHusbandDTO newHusband);
        Task<ServiceResponse<GetHusbandDTO>> UpdateHusband(UpdateHusbandDTO updateHusband);
        Task<ServiceResponse<List<GetHusbandDTO>>> DeleteHusband(int id);

    }
}