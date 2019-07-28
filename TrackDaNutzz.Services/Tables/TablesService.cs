using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Common;
using TrackDaNutzz.Services.Dtos.Tables;

namespace TrackDaNutzz.Services.Tables
{
    public class TablesService : ITablesService
    {
        private readonly TrackDaNutzzDbContext context;

        public TablesService(TrackDaNutzzDbContext context)
        {
            this.context = context;
        }

        public int AddTable(TableDto tableDto, int clientId, int stakeId, int variantId)
        {
            int tableSize = this.GetTableSize(tableDto);

            Table table = this.context.Tables
                .SingleOrDefault(t => t.Name == tableDto.TableName && t.Size == tableSize &&
                                      t.ClientId == clientId && t.StakeId == stakeId &&
                                      t.VariantId == variantId);
            if (table != null)
            {
                return table.Id;
            }
            table = new Table()
            {
                Name = tableDto.TableName,
                Size = tableSize,
                ClientId = clientId,
                StakeId = stakeId,
                VariantId = variantId,
            };
            this.context.Tables.Add(table);
            this.context.SaveChanges();
            return table.Id;
        }

        public bool IsExist(int tableId)
        {
            Table table = this.context.Tables.SingleOrDefault(t => t.Id == tableId);
            if (table == null)
            {
                return false;
            }
            return true;
        }

        private int GetTableSize(TableDto tableDto)
        {
            int tableSize = 0;
            if (tableDto.TableSize.EndsWith(GlobalConstants.TableSizeEnding))
            {
                tableSize = int.Parse(tableDto.TableSize.Replace(GlobalConstants.TableSizeEnding, string.Empty));
            }
            else if (tableDto.TableSize == GlobalConstants.HeadsUp)
            {
                tableSize = 2;
            }

            return tableSize;
        }
    }
}
