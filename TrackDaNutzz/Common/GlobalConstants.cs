namespace TrackDaNutzz.Common
{
    public class GlobalConstants
    {
        public const string ClientNamePattern = "[A-Za-z]+";
        public const string HandNumberPattern = "[0-9]+";
        public const string VariantNamePattern = "[A-Za-z']+";
        public const string LimitPattern = "[A-Z][a-z]{1,4} Limit";
        public const string CurrencySymbolPattern = @"\D";
        public const string MoneyPattern = @"[0-9]+\.?[0-9]*";
        public const string CurrencyPattern = "[A-Z]{2,3}";
        public const string TimePattern = @"[0-9]{4,4}\/[0-9]{2,2}\/[0-9]{2,2} [0-9]{1,2}:[0-9]{2,2}:[0-9]{2,2}";
        public const string TimeZonePattern = @"[A-Z]{2,3}";
        //private static string FirstRowPattern = $@"^({clientNamePattern}) Hand #({handNumberPattern}):\s\s({variantNamePattern}) ({limitPattern}) \(({currencySymbolPattern})?({moneyPattern})\/({currencySymbolPattern})?({moneyPattern}) ?({currencyPattern})?\) - ({timePattern}) \[({timePattern})\]$";

        public const string TableNamePattern = "[A-Za-z0-9 ]+";
        public const string TableSizePattern = "[0-9]{1,2}-max|Heads-Up";
        public const string PlayMoneyPattern = "Play Money";
        public const string ButtonSeatPattern = "[0-9]{1,2}";
        //private static string SecondRowPattern = $@"^Table '({tableNamePattern})' ({tableSizePattern}) ?\(?({playMoneyPattern})?\)? Seat #({buttonSeatPattern}) is the button$";

        public const string SeatNumberPattern = "[0-9]{1,2}";
        public const string PlayerNamePattern = @"[A-Za-z0-9\.\-\# `´_]+";
        //private static string SeatInfoPattern = $@"^Seat ({seatNumberPattern}): ({playerNamePattern}) \(({currencySymbolPattern})?({moneyPattern}) in chips\)$";

        //private static string joiningPlayersPattern = $@"^({playerNamePattern}) will be allowed to play after the button$";

        public const string AnteOrBlindPattern = "[a-z]{3,5} blind|ante";
        //private static string PostingBlindsAndAntePattern = $@"^({playerNamePattern}): posts ({anteOrBlindPattern}) ({currencySymbolPattern})?({moneyPattern})$";

        public const string PreflopRow = "*** HOLE CARDS ***";

        public const string CardPattern = "[1-9AKQJT]{1}[cdsh]{1}";
        //private static string DealtCardsPattern = $@"^Dealt to ({playerNamePattern}) \[({cardPattern}) ({cardPattern})\]$";

        public const string ActionPattern = "[a-z ]+";
        public const string IsAllInPattern = " and is all-in";
        //private static string BettingActionsPattern = $@"^({playerNamePattern}): ({actionPattern}) ?({currencySymbolPattern})?({moneyPattern})?( to )?({currencySymbolPattern})?({moneyPattern})?({isAllInPattern})?$";

        public const string RoundPattern = "[A-Z]+";

        //private static string StreetPattern = $@"^\*\*\* ({streetTypePattern}) \*\*\* \[({cardPattern}) ({cardPattern}) ({cardPattern})\]? ?\[?({cardPattern})?\]? ?\[?({cardPattern})?\]$";

        public const string ShowdownRow = "*** SHOW DOWN ***";

        public const string HandStrengthPattern = "[A-Za-z ,-]+";

        //private static string ShowCardsPattern = $@"^({playerNamePattern}): shows \[({cardPattern}) ({cardPattern})\] \(({handStrengthPattern})\)$";

        //private static string UncalledBetPattern = $@"^Uncalled bet \(({currencySymbolPattern})?({moneyPattern})\) returned to ({playerNamePattern})$";

        //private static string CollectPattern = $@"^({playerNamePattern}) collected ({currencySymbolPattern})?({moneyPattern}) from pot$";

        //private static string MuckHandPattern = $@"^({playerNamePattern}): (doesn't show hand|mucks hand)$";

        public const string SummaryRow = "*** SUMMARY ***";

        //private static string PotRakeSummaryPattern = $@"^Total pot ({currencySymbolPattern})?({moneyPattern}) \| Rake ({currencySymbolPattern})?({moneyPattern})$";

        //private static string BoardSummaryPattern = $@"^Board \[({cardPattern})? ?({cardPattern})? ?({cardPattern})? ?({cardPattern})? ?({cardPattern})?\]$";

        public const string PositionPattern = "[a-z ]+";
        public const string BeforeOrOnPattern = "on the|before";
        public const string RoundSummaryPattern = "[A-Z][a-z]+";
        public const string DidNotBetPattern = @"\(didn't bet\)";
        //private static string FoldSummaryPattern = $@"^Seat ({seatNumberPattern}): ({playerNamePattern}) ?\(?({positionPattern})?\)? folded ({beforeOrOnPattern}) ({streetSummaryPattern}) ?({didNotBetPattern})?$";
        //private static string MuckSummaryPattern = $@"^Seat ({seatNumberPattern}): ({playerNamePattern}) ?\(?({positionPattern})?\)? mucked \[({cardPattern}) ({cardPattern})\]$";

        //private static string CollectSummaryPattern = $@"^Seat ({seatNumberPattern}): ({playerNamePattern}) ?\(?({positionPattern})?\)? collected \(({currencySymbolPattern})?({moneyPattern})\)$";
        //private static string ShowSummaryPattern = $@"^Seat ({seatNumberPattern}): ({playerNamePattern}) ?\(?({positionPattern})?\)? showed \[({cardPattern}) ({cardPattern})\] and (lost|won) ?(\(({currencySymbolPattern})?({moneyPattern})\))? with ({handStrengthPattern})$";

        public const string NewLine = "\r\n";
        public const int EmptyRowsCount = 3;
        public const string PlayMoney = "Play Money";
        public const string HeadsUp = "Heads-Up";
        public const string PreflopRound = "PREFLOP";


    }
}
