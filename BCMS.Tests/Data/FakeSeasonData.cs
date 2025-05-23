﻿using InterfaceLayer;
using InterfaceLayer.DALInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FakeSeasonData : ISeasonData
{
    public List<DTOSeasons> CreatedSeasons { get; } = new();

    public Task<List<DTOSeasons>> FetchSeasonsAsync()
    {
        return Task.FromResult(CreatedSeasons);
    }

    public Task InsertSeasonAsync(string name, DateTime start, DateTime end)
    {
        CreatedSeasons.Add(new DTOSeasons
        {
            ID = CreatedSeasons.Count + 1,
            Name = name,
            StartDate = start,
            EndDate = end
        });

        return Task.CompletedTask;
    }
}
