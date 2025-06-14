﻿using InterfaceLayer;
using InterfaceLayer.DALInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class SeasonService
    {
        private readonly ISeasonRepo _data;

        public SeasonService(ISeasonRepo data)
        {
            _data = data;
        }

        public async Task<List<SeasonsDTO>> GetSeasonsAsync()
        {
            return await _data.FetchSeasonsAsync();
        }

        public async Task AddSeasonAsync(string name, DateTime start, DateTime end)
        {
            if (start >= end)
                throw new ArgumentException("Start date must be before end date");

            await _data.InsertSeasonAsync(name, start, end);
        }

    }
}
