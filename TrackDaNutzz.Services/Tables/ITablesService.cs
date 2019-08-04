using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Services.Dtos.Tables;

namespace TrackDaNutzz.Services.Tables
{
    public interface ITablesService
    {
        int AddTable(ImportTableDto tableDto, int clientId, int stakeId, int variantId);
        bool IsExist(int tableId);
        IQueryable<int> GetTablesIdsByStakeId(params int[] stakeIds);
        IQueryable<int> GetStakeIdsByTableId(params int[] tableIds);
        TableDto GetTableById(long tableId);
        IEnumerable<TableDto> GetTableById(params int[] tableIds);
    }
}
