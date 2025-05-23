﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IPlayerData
    {
        Task InsertPlayerAsync(string firstName, string lastName, bool gender, int federationNumber);
        IAsyncEnumerable<DTOPlayers> FetchPlayersAsync();
    }
}
