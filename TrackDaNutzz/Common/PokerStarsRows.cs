namespace TrackDaNutzz.Common
{
    public static class PokerStarsRows
    {
        public static string HandRow = $@"^(?'ClientName'{GlobalConstants.ClientNamePattern}) Hand #" +
                $@"(?'HandNumber'{GlobalConstants.HandNumberPattern}):\s\s" +
                $@"(?'VariantName'{GlobalConstants.VariantNamePattern}) " +
                $@"(?'Limit'{GlobalConstants.LimitPattern}) \(" +
                $@"(?'CurrencySymbol'{GlobalConstants.CurrencySymbolPattern})?" +
                $@"(?'SmallBlind'{GlobalConstants.MoneyPattern})\/" +
                $@"({GlobalConstants.CurrencySymbolPattern})?" +
                $@"(?'BigBlind'{GlobalConstants.MoneyPattern}) ?" +
                $@"(?'Currency'{GlobalConstants.CurrencyPattern})?\) - " +
                $@"(?'LocalTime'{GlobalConstants.TimePattern}) " +
                $@"(?'LocalTimeZone'{GlobalConstants.TimeZonePattern}) \[" +
                $@"(?'Time'{GlobalConstants.TimePattern}) " +
                $@"(?'TimeZone'{GlobalConstants.TimeZonePattern})\]$";

        public static string TableRow = $@"^Table '" +
                $@"(?'TableName'{GlobalConstants.TableNamePattern})' " +
                $@"(?'TableSize'{GlobalConstants.TableSizePattern}) ?\(?" +
                $@"(?'PlayMoney'{GlobalConstants.PlayMoneyPattern})?\)? Seat #" +
                $@"(?'ButtonSeat'{GlobalConstants.ButtonSeatPattern}) is the button$";

        public static string SeatInfoRow = $@"^Seat (?'SeatNumber'{GlobalConstants.SeatNumberPattern}): " +
                $@"(?'PlayerName'{GlobalConstants.PlayerNamePattern}) \(" +
                $@"(?'CurrencySymbol'{GlobalConstants.CurrencySymbolPattern})?" +
                $@"(?'Money'{GlobalConstants.MoneyPattern}) in chips\)$";

        public static string BettingActionRow = $@"^(?'PlayerName'{GlobalConstants.PlayerNamePattern}): " +
            $@"(?'Action'{GlobalConstants.ActionPattern}) ?" +
            $@"(?'CurrencySymbol'{GlobalConstants.CurrencySymbolPattern})?" +
            $@"(?'Value'{GlobalConstants.MoneyPattern})?( to )?" +
            $@"({GlobalConstants.CurrencySymbolPattern})?" +
            $@"(?'RaiseTo'{GlobalConstants.MoneyPattern})?" +
            $@"(?'IsAllIn'{GlobalConstants.IsAllInPattern})?$";

        public static string PostingBlindsAndAnteRow = $@"^(?'PlayerName'{GlobalConstants.PlayerNamePattern}): posts " +
            $@"(?'AnteOrBlind'{GlobalConstants.AnteOrBlindPattern}) " +
            $@"(?'CurrencySymbol'{GlobalConstants.CurrencySymbolPattern})?" +
            $@"(?'Value'{GlobalConstants.MoneyPattern})$";

        public static string DealtCardsRow = $@"^Dealt to (?'PlayerName'{GlobalConstants.PlayerNamePattern}) \[" +
            $@"(?'FirstCard'{GlobalConstants.CardPattern}) " +
            $@"(?'SecondCard'{GlobalConstants.CardPattern})\]$";

        public static string RoundRow = $@"^\*\*\* (?'RoundName'{GlobalConstants.RoundPattern}) \*\*\* \[" +
            $@"(?'FirstCard'{GlobalConstants.CardPattern}) " +
            $@"(?'SecondCard'{GlobalConstants.CardPattern}) " +
            $@"(?'ThirdCard'{GlobalConstants.CardPattern})\]? ?\[?" +
            $@"(?'FourthCard'{GlobalConstants.CardPattern})?\]? ?\[?" +
            $@"(?'FifthCard'{GlobalConstants.CardPattern})?\]$";

        public static string ShowCardsRow = $@"^(?'PlayerName'{GlobalConstants.PlayerNamePattern}): shows \[" +
            $@"(?'FirstCard'{GlobalConstants.CardPattern}) " +
            $@"(?'SecondCard'{GlobalConstants.CardPattern})\] \(" +
            $@"(?'HandStrength'{GlobalConstants.HandStrengthPattern})\)$";

        public static string UncalledBetsRow = $@"^Uncalled bet \((?'CurrencySymbol'{GlobalConstants.CurrencySymbolPattern})?" +
            $@"(?'Value'{GlobalConstants.MoneyPattern})\) returned to " +
            $@"(?'PlayerName'{GlobalConstants.PlayerNamePattern})$";

        public static string CollectMoneyRow = $@"^(?'PlayerName'{GlobalConstants.PlayerNamePattern}) collected " +
            $@"(?'CurrencySymbol'{GlobalConstants.CurrencySymbolPattern})?" +
            $@"(?'Value'{GlobalConstants.MoneyPattern}) from pot$";

        public static string MuckHandRow = $@"^(?'PlayerName'{GlobalConstants.PlayerNamePattern}): (doesn't show hand|mucks hand)$";

        public static string PotRakeSummaryRow = $@"^Total pot (?'CurrencySymbol'{GlobalConstants.CurrencySymbolPattern})?" +
            $@"(?'Pot'{GlobalConstants.MoneyPattern}) \| Rake " +
            $@"({GlobalConstants.CurrencySymbolPattern})?" +
            $@"(?'Rake'{GlobalConstants.MoneyPattern})$";

        public static string BoardSummaryRow = $@"^Board \[(?'FirstCard'{GlobalConstants.CardPattern})? ?" +
            $@"(?'SecondCard'{GlobalConstants.CardPattern})? ?" +
            $@"(?'ThirdCard'{GlobalConstants.CardPattern})? ?" +
            $@"(?'FourthCard'{GlobalConstants.CardPattern})? ?" +
            $@"(?'FifthCard'{GlobalConstants.CardPattern})?\]$";

        public static string FoldSummaryRow = $@"^Seat (?'SeatNumber'{GlobalConstants.SeatNumberPattern}): " +
            $@"(?'PlayerName'{GlobalConstants.PlayerNamePattern}) ?\(?" +
            $@"(?'Position'{GlobalConstants.PositionPattern})?\)? folded " +
            $@"(?'IsBeforeRound'{GlobalConstants.BeforeOrOnPattern}) " +
            $@"(?'Round'{GlobalConstants.RoundSummaryPattern}) ?" +
            $@"(?'DidNotBet'{GlobalConstants.DidNotBetPattern})?$";

        public static string MuckSummaryRow = $@"^Seat (?'SeatNumber'{GlobalConstants.SeatNumberPattern}): " +
            $@"(?'PlayerName'{GlobalConstants.PlayerNamePattern}) ?\(?" +
            $@"(?'Position'{GlobalConstants.PositionPattern})?\)? mucked \[" +
            $@"(?'FirstCard'{GlobalConstants.CardPattern}) " +
            $@"(?'SecondCard'{GlobalConstants.CardPattern})\]$";

        public static string CollectSummaryRow = $@"^Seat (?'SeatNumber'{GlobalConstants.SeatNumberPattern}): " +
            $@"(?'PlayerName'{GlobalConstants.PlayerNamePattern}) ?\(?" +
            $@"(?'Position'{GlobalConstants.PositionPattern})?\)? collected \(" +
            $@"(?'CurrencySymbol'{GlobalConstants.CurrencySymbolPattern})?" +
            $@"(?'Value'{GlobalConstants.MoneyPattern})\)$";

        public static string ShowSummaryRow = $@"^Seat (?'SeatNumber'{GlobalConstants.SeatNumberPattern}): " +
            $@"(?'PlayerName'{GlobalConstants.PlayerNamePattern}) ?\(?" +
            $@"(?'Position'{GlobalConstants.PositionPattern})?\)? showed \[" +
            $@"(?'FirstCard'{GlobalConstants.CardPattern}) " +
            $@"(?'SecondCard'{GlobalConstants.CardPattern})\] and (lost|won) ?(\(" +
            $@"(?'CurrencySymbol'{GlobalConstants.CurrencySymbolPattern})?" +
            $@"(?'Value'{GlobalConstants.MoneyPattern})\))? with " +
            $@"(?'HandStrength'{GlobalConstants.HandStrengthPattern})$";

    }
}
