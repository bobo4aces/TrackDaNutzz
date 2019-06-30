using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TrackDaNutzz.Services
{
    public class ParserService
    {
        private const string clientNamePattern = "[A-Za-z]+";
        private const string handNumberPattern = "[0-9]+";
        private const string variantTypePattern = "[A-Za-z']+";
        private const string limitPattern = "[A-Z][a-z]{1,4} Limit";
        private const string currencySymbolPattern = @"\D";
        private const string moneyPattern = @"[0-9]+\.?[0-9]*";
        private const string currencyPattern = "[A-Z]{2,3}";
        private const string timePattern = @"[0-9]{4,4}\/[0-9]{2,2}\/[0-9]{2,2} [0-9]{2,2}:[0-9]{2,2}:[0-9]{2,2} [A-Z]{2,3}";
        private string firstRowPattern = $@"^({clientNamePattern}) Hand #({handNumberPattern}): ({variantTypePattern}) ({limitPattern}) \(({currencySymbolPattern})?({moneyPattern})\/({currencySymbolPattern})?({moneyPattern})( ({currencyPattern}))?\) - ({timePattern}) \[({timePattern})\]$";
        
        private const string tableNamePattern = "[A-Za-z0-9 ]+";
        private const string tableSizePattern = "[0-9]{1,2}-max|Heads-Up";
        private const string playMoneyPattern = "Play Money";
        private const string buttonSeatPattern = "[0-9]{1,2}";
        private string secondRowPattern = $@"^Table '({tableNamePattern})' ({tableSizePattern})( \(({playMoneyPattern})\))? Seat #({buttonSeatPattern}) is the button$";

        private const string seatNumberPattern = "[0-9]{1,2}";
        private const string playerNamePattern = @"[A-Za-z0-9\.\-\#]+";
        private string seatInfoPattern = $@"^Seat ({seatNumberPattern}): ({playerNamePattern}) \(({currencySymbolPattern})?({moneyPattern}) in chips\)$";

        private string joiningPlayersPattern = $@"^({playerNamePattern}) will be allowed to play after the button$";

        private const string anteOrBlindPattern = "[a-z]{3,5} blind|ante";
        private string postingBlindsAndAntePattern = $@"^({playerNamePattern}): posts ({anteOrBlindPattern}) ({currencySymbolPattern})?({moneyPattern})$";

        private const string preflopRow = "*** HOLE CARDS ***";

        private const string cardPattern = "[1-9AKQJT]{1}[cdsh]{1}";
        private string dealtCardsPattern = $@"^Dealt to ({playerNamePattern}) \[({cardPattern}) ({cardPattern})\]$";

        private const string actionPattern = "[a-z]+";
        private const string isAllInPattern = " and is all-in";
        private string bettingActionsPattern = $@"^({playerNamePattern}): ({actionPattern}) ?({currencySymbolPattern})?({moneyPattern})?( to )?({currencySymbolPattern})?({moneyPattern})?({isAllInPattern})?$";


        private string flopPattern = $@"^\*\*\* FLOP \*\*\* \[({cardPattern}) ({cardPattern}) ({cardPattern})\]$";

        private string turnPattern = $@"^\*\*\* TURN \*\*\* \[({cardPattern}) ({cardPattern}) ({cardPattern})\] \[({cardPattern})\]$";

        private string riverPattern = $@"^\*\*\* RIVER \*\*\* \[({cardPattern}) ({cardPattern}) ({cardPattern}) ({cardPattern})\] \[({cardPattern})\]$";

        private string uncalledBetPattern = $@"^Uncalled bet \(({currencySymbolPattern})?({moneyPattern})\) returned to ({playerNamePattern})$";

        private string collectPattern = $@"^({playerNamePattern}) collected (({currencySymbolPattern})?{moneyPattern}) from pot$";

        private string muckHandPattern = $@"^({playerNamePattern}): doesn't show hand$";

        private const string summaryRow = "*** SUMMARY ***";

        private string potRakeSummaryPattern = $@"^Total pot ({currencySymbolPattern})?({moneyPattern}) \| Rake ({currencySymbolPattern})?({moneyPattern})$";

        private string boardSummaryPattern = $@"^Board \[({cardPattern})? ?({cardPattern})? ?({cardPattern})? ?({cardPattern})? ?({cardPattern})?\]$";

        private const string positionPattern = "[a-z ]+";
        private const string beforeOrOnPattern = "on the|before";
        private const string streetPattern = "[A-Z][a-z]+";
        private const string didNotBetPattern = @"\(didn't bet\)";
        private string foldSummaryPattern = $@"^Seat ({seatNumberPattern}): ({playerNamePattern}) ?\(?({positionPattern})?\)? folded ({beforeOrOnPattern}) ({streetPattern}) ?({didNotBetPattern})?$";

        private string collectSummaryPattern = $@"^Seat ({seatNumberPattern}): ({playerNamePattern}) ?\(?({positionPattern})\)? collected \(({currencySymbolPattern})?({moneyPattern})\)$";

        public void Something(string handHistoryText)
        {
            char[] threeEmptyRows = { '\r', '\n', '\r', '\n', '\r', '\n' };
            char[] oneEmptyRow = { '\r', '\n' };
            string[] handHistory = handHistoryText.Split(threeEmptyRows).ToArray();
            for (int i = 0; i < handHistory.Length; i++)
            {
                string[] hand = handHistory[i].Split(oneEmptyRow).ToArray();
                ParseHand(hand);
            }
        }
        public void ParseHand(string[] hand)
        {
            Regex firstRowRegex = new Regex(firstRowPattern);
            string clientName = firstRowRegex.GroupNameFromNumber(1);
            string handNumber = firstRowRegex.GroupNameFromNumber(2);
            string variantType = firstRowRegex.GroupNameFromNumber(3);
            string limit = firstRowRegex.GroupNameFromNumber(4);
            string currencySymbol = firstRowRegex.GroupNameFromNumber(5);
            string smallBlind = firstRowRegex.GroupNameFromNumber(6);
            string bigBlind = firstRowRegex.GroupNameFromNumber(8);
            string timeET = firstRowRegex.GroupNameFromNumber(8);
            Regex secondRowRegex = new Regex(secondRowPattern);

            int index = 2;

            Regex seatInfoRegex = new Regex(seatInfoPattern);
	
	        while (seatInfoRegex.IsMatch(hand[index]))
	        {
		        //TODO Parse;
		        index++;
	        }

            Regex joiningPlayersRegex = new Regex(joiningPlayersPattern);
	
	        while (joiningPlayersRegex.IsMatch(hand[index]))
	        {
		        //TODO Parse;
		        index++;
	        }

            Regex postingBlindsAndAnteRegex = new Regex(postingBlindsAndAntePattern);
	
	        while (postingBlindsAndAnteRegex.IsMatch(hand[index]))
	        {
		        //TODO Parse;
		        index++;
	        }
	
	        if(hand[index] != preflopRow)
	        {
		        throw new InvalidHand();
	        }
	
	        Regex dealtCardsRegex = new Regex(dealtCardsPattern);
	
	        while (dealtCardsRegex.IsMatch(hand[index]))
	        {
		        //TODO Parse;
		        index++;
	        }
	
	        ////////////////////PREFLOP/////////////////

	        Regex bettingActionsRegex = new Regex(bettingActionsPattern);
            List<BettingAction> bettingActions = new List<BettingAction>();
	        while (bettingActionsRegex.IsMatch(hand[index]))
	        {
		        string playerName = group 1;
		        string actionName = group 2;
		        decimal money = decimal.Parse(group 3);
                bool isAllIn = group 4;
		        BettingAction bettingAction = new BettingAction(playerName, actionName, money, isAllIn);
                bettingActions.Add(bettingAction);
		        //TODO Parse;
		        index++;
	        }
	
	        ////////////////////FLOP/////////////////
	
	        Regex flopRegex = new Regex(flopPattern);
	
	        if(flopRegex.IsMatch(hand[index]))
	        {
		        while (bettingActionsRegex.IsMatch(hand[index]))
		        {
			        //TODO Parse;
			        index++;
		        }	
	        }
	
	        ////////////////////TURN/////////////////
	
	        Regex turnRegex = new Regex(turnPattern);
	        if(turnRegex.IsMatch(hand[index]))
	        {
		        while (bettingActionsRegex.IsMatch(hand[index]))
		        {
			        //TODO Parse;
			        index++;
		        }	
	        }
	
	        ////////////////////RIVER/////////////////
	
	        Regex riverRegex = new Regex(riverPattern);
	
	        if(riverRegex.IsMatch(hand[index]))
	        {
		        while (bettingActionsRegex.IsMatch(hand[index]))
		        {
			        //TODO Parse;
			        index++;
		        }	
	        }
	
	        Regex uncalledBetRegex = new Regex(uncalledBetPattern);
	
	        if(uncalledBetRegex.IsMatch(hand[index]))
	        {
		        //TODO;
		        index++;
	        }
	
	        Regex collectRegex = new Regex(collectPattern);
	
	        if(collectRegex.IsMatch(hand[index]))
	        {
		        //TODO;
		        index++;
	        }
	
	        Regex muckHandRegex = new Regex(muckHandPattern);
	
	        if(muckHandRegex.IsMatch(hand[index]))
	        {
		        //TODO;
		        index++;
	        }
	
	        ////////////////////SUMMARY/////////////////
	
	        if(hand[index] != summaryRow)
	        {
		        throw new InvalidHand();
	        }
	
	        Regex potRakeSummaryRegex = new Regex(potRakeSummaryPattern);
            //TODO

            Regex boardSummaryRegex = new Regex(boardSummaryPattern);
            //TODO

            Regex foldSummaryRegex = new Regex(foldSummaryPattern);

            Regex collectSummaryRegex = new Regex(collectSummaryPattern);
	        //TODO
        }
    }
}