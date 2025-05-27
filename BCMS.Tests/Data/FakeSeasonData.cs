using InterfaceLayer;
using InterfaceLayer.DALInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FakeSeasonData : ISeasonRepo
{
    public List<SeasonsDTO> CreatedSeasons { get; } = new();

    public Task<List<SeasonsDTO>> FetchSeasonsAsync()
    {
        return Task.FromResult(CreatedSeasons);
    }

    public Task InsertSeasonAsync(string name, DateTime start, DateTime end)
    {
        CreatedSeasons.Add(new SeasonsDTO
        {
            ID = CreatedSeasons.Count + 1,
            Name = name,
            StartDate = start,
            EndDate = end
        });

        return Task.CompletedTask;
    }
}
