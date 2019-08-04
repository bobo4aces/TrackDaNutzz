using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Clients;
using TrackDaNutzz.Services.Common;
using TrackDaNutzz.Services.Dtos.Stakes;
using TrackDaNutzz.Services.Dtos.Statistics;
using TrackDaNutzz.Services.Dtos.Tables;
using TrackDaNutzz.Services.Dtos.Variants;
using TrackDaNutzz.Services.Stakes;
using TrackDaNutzz.Services.Variant;

namespace TrackDaNutzz.Services.Tables
{
    public class TablesService : ITablesService
    {
        private readonly TrackDaNutzzDbContext context;
        private readonly IStakesService stakesService;
        private readonly IVariantsService variantsService;
        private readonly IClientsService clientsService;

        public TablesService(TrackDaNutzzDbContext context, IStakesService stakesService, IVariantsService variantsService, IClientsService clientsService)
        {
            this.context = context;
            this.stakesService = stakesService;
            this.variantsService = variantsService;
            this.clientsService = clientsService;
        }

        public int AddTable(ImportTableDto tableDto, int clientId, int stakeId, int variantId)
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
        public IQueryable<int> GetTablesIdsByStakeId(params int[] stakeIds)
        {
            IQueryable<int> tableIds = this.context.Tables
                .Where(t => stakeIds.Contains(t.StakeId))
                .Select(t => t.Id);
            return tableIds;
        }

        public IQueryable<int> GetStakeIdsByTableId(params int[] tableIds)
        {
            IQueryable<int> stakeIds = this.context.Tables
                .Where(t => tableIds.Contains(t.Id))
                .Select(t => t.StakeId);
            return stakeIds;
        }

        public TableDto GetTableById(long tableId)
        {
            Table table = this.context.Tables.FirstOrDefault(t => t.Id == tableId);
            if (table == null)
            {
                throw new ArgumentException($"Invalid table id - {tableId}");
            }
            TableDto tableDto = new TableDto()
            {
                ClientName = this.clientsService.GetClientNameById(table.ClientId),
                Id = table.Id,
                Size = table.Size,
                Stake = this.stakesService.GetStakeByStakeId(table.StakeId)
                        .Select(s => new StakeDto()
                        {
                            BigBlind = s.BigBlind,
                            Currency = s.Currency,
                            CurrencySymbol = s.CurrencySymbol,
                            Id = s.Id,
                            SmallBlind = s.SmallBlind
                        })
                        .FirstOrDefault(),
                StakeId = table.StakeId,
                TableName = table.Name,
                Variant = this.variantsService.GetVariantById(table.VariantId),
            };
            return tableDto;
        }
        //TO DO: don't use stakes context
        public IEnumerable<TableDto> GetTableById(params int[] tableIds)
        {
            IEnumerable<TableDto> tables = this.context.Tables
                .Where(t => tableIds.Contains(t.Id))
                .Select(t => new TableDto()
                {
                    ClientName = t.Client.Name,
                    Id = t.Id,
                    Size = t.Size,
                    Stake = this.context.Stakes
                        .Where(x=>x.Id == t.StakeId)
                        .Select(s => new StakeDto()
                        {
                            BigBlind = s.BigBlind,
                            Currency = s.Currency,
                            CurrencySymbol = s.CurrencySymbol,
                            Id = s.Id,
                            SmallBlind = s.SmallBlind
                        })
                        .FirstOrDefault(),
                    StakeId = t.StakeId,
                    TableName = t.Name,
                    Variant = this.context.Variants
                        .Where(x => x.Id == t.VariantId)
                        .Select(v=>new VariantDto()
                        {
                            Id = v.Id,
                            Limit = v.Limit,
                            Name = v.Name
                        })
                        .FirstOrDefault(),
                    VariantId = t.VariantId,
                })
                .ToList();
            return tables;
        }
        private int GetTableSize(ImportTableDto tableDto)
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
