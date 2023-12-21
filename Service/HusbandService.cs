using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using patrickLearn.Data;
using patrickLearn.DTOs.Husband;
using patrickLearn.Models;

namespace patrickLearn.Service
{
    public class HusbandService : IHusbandService
    {

        // private static List<Husband> husbands = new List<Husband>()
        // {
        //     new Husband(),
        //     new Husband{HusbandId=1 , Name = "anass" , CIN="ew121212"}
        // };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public HusbandService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetHusbandDTO>>> AddHusband(AddHusbandDTO newHusband)
        {
            var serviceResponse = new ServiceResponse<List<GetHusbandDTO>>();
            var husband = _mapper.Map<Husband>(newHusband);
            // husbands.Add(_mapper.Map<Husband>(newHusband));
            _context.husbands.Add(husband);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.husbands.Select(h => _mapper.Map<GetHusbandDTO>(h)).ToListAsync();
            return serviceResponse;
        }
// hna w9afna kan reglo filtring
        public async Task<ServiceResponse<List<GetHusbandDTO>>> GetAllHusband(string? filterOn = null , string? filterQuery = null)
        {
             var serviceResponse = new ServiceResponse<List<GetHusbandDTO>>();

    try
    {
        // Include wives for mapping
        var dbHusband = _context.husbands.Include(h => h.wives).AsQueryable();

        // Mapping to DTO
        serviceResponse.Data = await dbHusband.Select(h => _mapper.Map<GetHusbandDTO>(h)).ToListAsync();

        // Filtering
        if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
        {
            if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                serviceResponse.Data = serviceResponse.Data
                    .Where(x => x.Name.Contains(filterQuery, StringComparison.OrdinalIgnoreCase))
                     .ToList();
            }
            else
            {
                // Handle other filter conditions if needed
                serviceResponse.Message = "Invalid filterOn parameter.";
                serviceResponse.Success = false;
            }
        }
    }
    catch (Exception ex)
    {
        serviceResponse.Message = $"An error occurred: {ex.Message}";
        serviceResponse.Success = false;
    }

    return serviceResponse;   

            // var serviceResponse = new ServiceResponse<List<GetHusbandDTO>>();
            // // var dbHusband = await _context.husbands.Include(h => h.wives).ToListAsync();
            // var dbHusband =  _context.husbands.Include(h => h.wives).AsQueryable();
            // serviceResponse.Data = dbHusband.Select(h => _mapper.Map<GetHusbandDTO>(h)).ToList();
            // // filtering
            //     if (string.IsNullOrWhiteSpace(filterOn) == false
            //             && string.IsNullOrWhiteSpace(filterQuery)== false)
            //     {
            //         if (filterOn.Equals("Name",StringComparison.OrdinalIgnoreCase))
            //         {
            //             dbHusband = dbHusband.Where(x => x.Name.Contains(filterQuery));
            //         }
            //     }
            // return serviceResponse;
        }

        public async Task<ServiceResponse<GetHusbandDTO>> GetHusbandById(int id)
        {
            var serviceResponse = new ServiceResponse<GetHusbandDTO>();
            var dbHusband = await _context.husbands
            .Include(h => h.wives)
            .FirstOrDefaultAsync(h => h.HusbandId == id);
            serviceResponse.Data = _mapper.Map<GetHusbandDTO>(dbHusband);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetHusbandDTO>> UpdateHusband(UpdateHusbandDTO updateHusband)
        {
            var serviceResponse = new ServiceResponse<GetHusbandDTO>();

            try
            {
                var husband =await _context.husbands.FirstOrDefaultAsync(h => h.HusbandId == updateHusband.HusbandId);
                if (husband is null)
                    throw new Exception($"husband with Id '{updateHusband.HusbandId}' not found.");
                _mapper.Map(updateHusband, husband);
                husband.Name = updateHusband.Name;
                husband.BirthDay = updateHusband.BirthDay;
                husband.CIN = updateHusband.CIN;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetHusbandDTO>(husband);
            }
            catch (System.Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

          public async Task<ServiceResponse<List<GetHusbandDTO>>> DeleteHusband(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetHusbandDTO>>();

            try
            {
                var husband = await _context.husbands.FirstAsync(h => h.HusbandId == id);
                if (husband is null)
                    throw new Exception($"husband with Id '{id}' not found.");

                _context.husbands.Remove(husband);
                await _context.SaveChangesAsync();

                serviceResponse.Data = 
                    await _context.husbands
                    .Select(h => _mapper.Map<GetHusbandDTO>(h))
                    .ToListAsync();
            }
            catch (System.Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}