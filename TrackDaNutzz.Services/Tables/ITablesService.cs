using System;
using System.Collections.Generic;
using System.Text;
using TrackDaNutzz.Services.Dtos.Tables;

namespace TrackDaNutzz.Services.Tables
{
    public interface ITablesService
    {
        int AddTable(TableDto tableDto, int clientId, int stakeId, int variantId);
        bool IsExist(int tableId);
    }
}
