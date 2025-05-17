using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.DALInterfaces
{
    public interface ISeasonData
    {
        Task<List<DTOSeasons>> FetchSeasonsAsync();
        Task InsertSeasonAsync(string name, DateTime start, DateTime end);
    }
}
