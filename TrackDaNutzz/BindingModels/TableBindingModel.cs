﻿using System.ComponentModel.DataAnnotations;
using TrackDaNutzz.Common;

namespace TrackDaNutzz.BindingModels
{
    public class TableBindingModel
    {
        //public string SecondRow => $@"^Table '({GlobalConstants.TableNamePattern})' ({GlobalConstants.TableSizePattern}) ?\(?({GlobalConstants.PlayMoneyPattern})?\)? Seat #({GlobalConstants.ButtonSeatPattern}) is the button$";

        [RegularExpression(GlobalConstants.TableNamePattern)]
        public string TableName { get; set; }
        [RegularExpression(GlobalConstants.TableSizePattern)]
        public string TableSize { get; set; }

        [RegularExpression(GlobalConstants.PlayMoneyPattern)]
        public bool PlayMoney { get; set; }

        [RegularExpression(GlobalConstants.ButtonSeatPattern)]
        public int ButtonSeat { get; set; }
    }
}
