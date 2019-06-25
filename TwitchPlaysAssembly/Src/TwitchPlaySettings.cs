﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using UnityEngine;

public class TwitchPlaySettingsData
{
	public int SettingsVersion = 0;

	public bool AnarchyMode = false;

	public bool SkipModManagerInstructionScreen = false;
	public bool EnableRewardMultipleStrikes = true;
	public bool EnableWhispers = false;
	public bool WhisperCommandsRequireExclaimationPoint = false;
	public bool EnableMissionBinder = true;
	public bool EnableFreeplayBriefcase = true;
	public bool EnableFreeplayNeedy = true;
	public bool EnableFreeplayHardcore = true;
	public bool EnableFreeplayModsOnly = true;
	public bool EnableRunCommand = true;
	public bool EnableRankCommand = true;
	public bool EnableSoloPlayMode = true;
	public bool EnableRetryButton = true;
	public bool EnableWhiteList = false;
	public bool EnableInteractiveMode = false;
	public bool EnableAutomaticEdgework = false;
	public bool EnableEdgeworkCommand = true;
	public bool EnableAutomaticCameraWall = true;
	public string RepositoryUrl = "https://ktane.timwi.de/";
	public string AnalyzerUrl = "https://ktane.timwi.de/More/Logfile%20Analyzer.html";
	public bool EnableModeratorsCommand = true;
	public bool EnableTrollCommands = false;
	public bool EnableLetterCodes = false;
	public bool AllowSolvingCurrentBombWithCommandsDisabled = true;
	public int BombLiveMessageDelay = 0;
	public int ClaimCooldownTime = 30;
	public int ModuleClaimLimit = 2;
	public float DynamicScorePercentage = 0.5f;
	public bool EnableTwitchPlayShims = true;
	public float UnsubmittablePenaltyPercent = 0.3f;
	public Color UnclaimedColor = new Color(0.39f, 0.25f, 0.64f);
	public bool ShowModuleDifficulty = false;
	public bool ShowModuleType = false;
	public bool AllowTurnTheKeyEarlyLate = false;
	public bool DisableTurnTheKeysSoftLock = false;
	public bool EnforceSolveAllBeforeTurningKeys = true;
	public bool LogUploaderShortUrls = false;
	public bool SuperStreamerIgnoreClaimLimit = false;
	public int MinScoreForNewbomb = 100;

	public bool EnableTimeModeForEveryone = false;
	public int TimeModeStartingTime = 5;
	public float TimeModeStartingMultiplier = 9.0f;
	public float TimeModeMaxMultiplier = 10.0f;
	public float TimeModeMinMultiplier = 1.0f;
	public float TimeModeSolveBonus = 0.1f;
	public float TimeModeMultiplierStrikePenalty = 1.5f;
	public float TimeModeTimerStrikePenalty = 0.25f;
	public int TimeModeMinimumTimeLost = 15;
	public int TimeModeMinimumTimeGained = 20;
	public float AwardDropMultiplierOnStrike = 0.80f;

	public bool EnableFactoryZenModeCameraWall = true;
	public bool EnableFactoryAutomaticNextBomb = true;

	public bool EnableZenModeForEveryone = false;
	public bool EnableFilledgeworkForEveryone = false;

	public int MinTimeLeftForClaims = 60;
	public int MinUnsolvedModulesLeftForClaims = 3;

	public string IRCManagerBackgroundImage = Path.Combine(Application.persistentDataPath, "TwitchPlaysIRCManagerBackground.png");
	public Color IRCManagerTextColor = new Color(1.00f, 0.44f, 0.00f);

	public bool TwitchPlaysDebugEnabled = false;
	public string TwitchPlaysDebugUsername = "_TPDEBUG";
	public Color TwitchPlaysDebugUsernameColor = new Color(0.00f, 0.00f, 0.875f);

	public int InstantModuleClaimCooldown = 20;
	public int InstantModuleClaimCooldownExpiry = 3600;

	public Dictionary<string, string> CustomMissions = new Dictionary<string, string>();
	public List<string> ProfileWhitelist = new List<string>();

	public Dictionary<string, string> BombCustomMessages = new Dictionary<string, string>
	{
		{"ttks", "Turn the Keys is a module on this bomb. It dictates some modules be delayed until others are finished. Until Turn the Keys is finished, you should avoid doing the following modules:\nLeft Key: Maze, Memory, Complicated Wires, Wire Sequence, Cryptography\nRight Key: Simon Says, Semaphore, Combination Lock, Astrology, Switches, Plumbing"},
		{"ttksleft", "These modules need to be solved: Password, Who's on First, Keypad, Crazy Talk, Listening, Orientation Cube.\nAvoid solving these modules: Maze, Memory, Complicated Wires, Wire Sequences, Cryptography.\nLeft Key is turned from Low to High." },
		{"ttksright", "These modules need to be solved: Morse Code, Wires, The Button, Two Bits, Colour Flash, Round Keypad.\nAvoid solving these modules: Simon Says, Semaphore, Combination Lock, Astrology, Switches, Plumbing.\nRight Key is turned from High to Low." },
		{"infozen", "Zen Mode is a peaceful mode. The clock counts up instead of down. Strikes can't blow up the bomb (though they still count). Points are reduced by 75%, and if you don't like the modules, you can !newbomb to get new ones." }
	};

	public Dictionary<string, string> GeneralCustomMessages = new Dictionary<string, string>
	{
		{"welcome", "Welcome, this is a Twitch Plays version of Keep Talking and Nobody Explodes. For some basic info and how to get started, you may find this link useful: https://docs.google.com/document/d/1ESin9CKWtt4nT3oxDvYqCmbf3xyFLpjM1wcXL78v29A/edit?usp=sharing" },
		{"ktane", "Keep Talking and Nobody Explodes is developed by Steel Crate Games. It's available for Windows PC, Mac OS X, PlayStation VR, Samsung Gear VR and Google Daydream. See http://www.keeptalkinggame.com/ for more information!" },
		{"about", "Twitch Plays: KTaNE is an alternative way of playing !ktane. Unlike the original game, you play as both defuser and expert, and defuse the bomb by sending special commands to the chat. Try !help for more information!" },
		{"discord", "Join the KTaNE discord here: https://discord.gg/ktane" }
	};

	public List<string> IgnoreCommands = new List<string>(); //Commands to ignore, if you have another bot for example

	public Dictionary<string, bool> ModPermissions = new Dictionary<string, bool>();

	public Dictionary<string, ModuleDistributions> ModDistributions = new Dictionary<string, ModuleDistributions>()
	{
		{ "vanilla", new ModuleDistributions { Vanilla = 1f, Modded = 0f, DisplayName = "Vanilla", MinModules = 1, MaxModules = 101 } },
		{ "mods", new ModuleDistributions { Vanilla = 0f, Modded = 1f, DisplayName = "Modded", MinModules = 1, MaxModules = 101 } },
		{ "mixed", new ModuleDistributions { Vanilla = 0.5f, Modded = 0.5f, DisplayName = "Mixed", MinModules = 1, MaxModules = 101 } },
		{ "lightmixed", new ModuleDistributions { Vanilla = 0.67f, Modded = 0.33f, DisplayName = "Mixed Light", MinModules = 1, MaxModules = 101, Hidden = true } },
		{ "mixedlight", new ModuleDistributions { Vanilla = 0.67f, Modded = 0.33f, DisplayName = "Mixed Light", MinModules = 1, MaxModules = 101 } },
		{ "mixedheavy", new ModuleDistributions { Vanilla = 0.33f, Modded = 0.67f, DisplayName = "Mixed Heavy", MinModules = 1, MaxModules = 101 } },
		{ "heavymixed", new ModuleDistributions { Vanilla = 0.33f, Modded = 0.67f, DisplayName = "Mixed Heavy", MinModules = 1, MaxModules = 101, Hidden = true } },
		{ "light", new ModuleDistributions { Vanilla = 0.8f, Modded = 0.2f, DisplayName = "Light", MinModules = 1, MaxModules = 101 } },
		{ "heavy", new ModuleDistributions { Vanilla = 0.2f, Modded = 0.8f, DisplayName = "Heavy", MinModules = 1, MaxModules = 101 } },
		{ "extraheavy", new ModuleDistributions { Vanilla = 0.1f, Modded = 0.9f, DisplayName = "Extra Heavy", MinModules = 1, MaxModules = 101 } },
		{ "extralight", new ModuleDistributions { Vanilla = 0.9f, Modded = 0.1f, DisplayName = "Extra Light", MinModules = 1, MaxModules = 101 } },
	};

	public string TwitchBotColorOnQuit = string.Empty;

	public bool AllowSnoozeOnly = false;

	public bool EnableDebuggingCommands = false;

	public string TPSharedFolder = Path.Combine(Application.persistentDataPath, "TwitchPlaysShared");
	public string TPSolveStrikeLog = "TPLog.txt";

	public string InvalidCommand = "@{0}, that command for {1} ({2}) is invalid.";
	public string CommandError = "@{0}, Module {1} ({2}) responded with: {3}";

	public string HoldableInvalidCommand = "@{1}, that command for Holdable !{0} is invalid.";
	public string HoldableCommandError = "@{1}, Holdable !{0} responded with the following error: {2}";

	public string AwardSolve = "VoteYea {1} solved Module {0} ({3})! +{2} points. VoteYea";
	public string AwardVsSolve = "VoteYea {1} solved Module {0} ({3})! +{2} points. {4} HP from {5}. VoteYea";
	public string AwardStrike = "VoteNay Module {0} ({6}) got {1} strike{2}! {7} points from {4}{5} VoteNay";
	public string AwardVsStrike = "VoteNay Module {0} ({6}) got {1} strike{2}! {7} HP from {4}. {8} points from {9}{5} VoteNay";
	public string AwardHoldableStrike = "VoteNay Holdable !{0} got {1} strike{2}! {3} points from {4}{5} VoteNay";
	public string AwardRewardStrike = "VoteNay Module {0} ({3}) got {1} strike{2}{4}! VoteNay";

	public string BombLiveMessage = "The next bomb is now live! Start sending your commands! MrDestructoid";
	public string MultiBombLiveMessage = "The next set of bombs are now live! Start sending your commands! MrDestructoid";

	public string BombExplodedMessage = "KAPOW KAPOW The bomb has exploded, with {0} remaining! KAPOW KAPOW";

	public string BombDefusedMessage = "PraiseIt PraiseIt The bomb has been defused, with {0} remaining!";
	public string BombDefusedVsMessage = "PraiseIt PraiseIt The {0} team has won! The bomb had {1} remaining!";
	public string BombDefusedBonusMessage = " {0} reward points to everyone who helped with this success.";

	public string BombDefusedVsBonusMessage =
		" {0} reward points to everyone on the {1} team who helped with this success.";
	public string BombDefusedFooter = " PraiseIt PraiseIt";

	public string BombSoloDefusalMessage = "PraiseIt PraiseIt {0} completed a solo defusal in {1}:{2:00}!";
	public string BombSoloDefusalNewRecordMessage = " It's a new record! (Previous record: {0}:{1:00})";
	public string BombSoloDefusalFooter = " PraiseIt PraiseIt";

	public string BombAbortedMessage = "VoteNay VoteNay The bomb was aborted, with {0} remaining! VoteNay VoteNay";

	public string LogTooBig = "BibleThump The bomb log is too big to upload to any of the supported services, sorry!";

	public string RankTooLow = "Nobody here with that rank!";

	public string SolverAndSolo = "solver ";
	public string SoloRankQuery = ", and #{0} solo with a best time of {1}:{2:00.0}";
	public string RankQuery = "SeemsGood {0} is #{1} {4}with {2} solves and {3} strikes and a total score of {6}{5}";

	public string DoYouEvenPlayBro = "FailFish {0}, do you even play this game?";

	public string TurnBombOnSolve = "Turning to the other side when Module {0} ({1}) is solved";
	public string CancelBombTurn = "Bomb turn on Module {0} ({1}) solve cancelled";

	public string ModuleClaimed = "{1} has claimed Module {0} ({2}).";
	public string ModuleUnclaimed = "{1} has released Module {0} ({2}).";
	public string ModuleNotClaimed = "@{0}, nobody has claimed module {1} ({2}).";
	public string ModuleAlreadyOwned = "@{0}, you already have a claim on {1} ({2})";

	public string AssignModule = "Module {0} ({3}) assigned to {1} by {2}";
	public string ModuleReady = "{1} says module {0} ({2}) is ready to be submitted";

	public string TakeModule = "@{0}, {1} wishes to take module {2} ({3}). It will be freed up in one minute unless you type !{2} mine.";
	public string TakeInProgress = "@{0}, there is already a takeover attempt for module {1} ({2}) in progress.";
	public string ModuleAbandoned = "{1} has released Module {0} ({2}).";
	public string ModuleIsMine = "{0} confirms he/she is still working on {1} ({2})";
	public string TooManyClaimed = "ItsBoshyTime Sorry, {0}, you may only have {1} claimed modules. The claim has been queued.";
	public string NoUnclaimed = "{0}, There are no more unclaimed modules.";
	public string ModulePlayer = "Module {0} ({2}) was claimed by {1}";
	public string AlreadyClaimed = "@{2}, module {0} ({3}) is currently claimed by {1}. If you think they have abandoned it, you may type !{0} take to free it up.";
	public string AlreadySolved = "@{2}, module {0} ({3}) has already been solved by {1}";
	public string ClaimCooldown = "@{2}, module {0} ({3}) can still be claimed by someone else during the first {1} seconds of this bomb.";

	public string OwnedModule = "“{1}” ({0})";
	public string OwnedModuleList = "@{0}, your claimed modules are: {1}";
	public string NoOwnedModules = "@{0}, you have no claimed modules.";
	public string OwnedModuleListOther = "@{0}’s claimed modules are: {1}";
	public string NoOwnedModulesOther = "@{0} has no claimed modules.";

	public string TwitchPlaysDisabled = "@{0}, Twitch Plays is only enabled for Authorized defusers";
	public string MissionBinderDisabled = "@{0}, Only authorized users may access the mission binder";
	public string FreePlayDisabled = "@{0}, Only authorized users may access the freeplay briefcase";
	public string FreePlayNeedyDisabled = "@{0}, Only authorized users may enable/disable Needy modules";
	public string FreePlayHardcoreDisabled = "@{0}, Only authorized users may enable/disable Hardcore mode";
	public string FreePlayModsOnlyDisabled = "@{0}, Only authorized users may enable/disable Mods only mode";
	public string TimeModeCommandDisabled = "@{0}, Only authorized users may enable/disable Time Mode";
	public string VsModeCommandDisabled = "@{0}, Only authorized users may enable/disable VS Mode";
	public string ZenModeCommandDisabled = "@{0}, Only authorized users may enable/disable Zen Mode";
	public string RunCommandDisabled = "@{0}, Only authorized users may use the !run command.";
	public string ProfileCommandDisabled = "@{0}, profile management is currently disabled.";
	public string RetryInactive = "Retry is inactive. Returning to hallway instead.";

	public string ProfileActionUseless = "That profile ({0}) is already {1}.";
	public string ProfileNotWhitelisted = "That profile ({0}) cannot be enabled/disabled.";
	public string ProfileListEnabled = "Currently enabled profiles: {0}";
	public string ProfileListAll = "All profiles: {0}";

	public string AddedUserPower = "Added access levels ({0}) to user \"{1}\"";
	public string RemoveUserPower = "Removed access levels ({0}) from user \"{1}\"";

	public string BombHelp = "The Bomb: !bomb hold [pick up] | !bomb drop | !bomb turn [turn to the other side] | !bomb edgework [show the widgets on the sides] | !bomb top [show one side; sides are Top/Bottom/Left/Right | !bomb time [time remaining] | !bomb timestamp [bomb start time]";
	public string BlankBombEdgework = "Not set, use !edgework <edgework> to set!\nUse !bomb edgework or !bomb edgework 45 to view the bomb edges.";
	public string BombEdgework = "Edgework: {0}";
	public string BombTimeRemaining = "panicBasket [{0}] out of [{1}].";
	public string BombTimeStamp = "The Date/Time this bomb started is {0:F}";
	public string BombDetonateCommand = "panicBasket This bomb's gonna blow!";
	public string BombStatusTimeMode = "Time remaining: {0} out of {1}, Multiplier: {2:0.0}, Solves: {3}/{4}, Reward: {5}";
	public string BombStatusVsMode = "Time on clock: {0}, Starting time: {1}, Good HP: {2}, Evil HP: {3}, Reward: {4}";
	public string BombStatus = "Time remaining: {0} out of {1}, Strikes: {2}/{3}, Solves: {4}/{5}, Reward: {6}";

	public string NotesSpaceFree = "(Free Space)";
	public string ZenModeFreeSpace = "Zen mode in effect. Type !newbomb to get a new bomb worth of modules. Type !bomb endzenmode to detonate the bomb, and return to setup room.";
	public string Notes = "Notes {0}: {1}";
	public string NotesTaken = "Notes Taken for Note Slot {0}: {1}";
	public string NotesAppended = "Notes appended to Note Slot {0}: {1}";
	public string NoteSlotCleared = "Note Slot {0} Cleared.";

	public string GiveBonusPoints = "{0} awarded {1} points by {2}";
	public string GiveBonusSolves = "{0} awarded {1} solves by {2}";
	public string GiveBonusStrikes = "{0} awarded {1} strikes by {2}";

	public string UnsubmittableAnswerPenalty = "{0}, the answer for module {1} ({2}) couldn't be submitted! You lose {3} point{4}, please only submit correct answers.";

	public string UnsupportedNeedyWarning = "Found an unsupported Needy Component. Disabling it.";

	private bool ValidateString(ref string input, string def, int parameters, bool forceUpdate = false)
	{
		MatchCollection matches = Regex.Matches(input, @"(?<!\{)\{([0-9]+).*?\}(?!})");
		int count = matches.Count > 0
				? matches.Cast<Match>().Max(m => int.Parse(m.Groups[1].Value)) + 1
				: 0;

		if (count != parameters || forceUpdate)
		{
			DebugHelper.Log($"TwitchPlaySettings.ValidateString( {input}, {def}, {parameters} ) - {(forceUpdate ? "Updated because of version breaking changes" : "Updated because parameters didn't match expected count.")}");

			input = def;
			return false;
		}
		return true;
	}

	private bool ValidateFloat(ref float input, float def, bool forceUpdate) => ValidateFloat(ref input, def, float.MinValue, float.MaxValue, forceUpdate);
	private bool ValidateFloat(ref float input, float def, float min = float.MinValue, float max = float.MaxValue, bool forceUpdate = false)
	{
		if (input < min || input > max || forceUpdate)
		{
			DebugHelper.Log($"TwitchPlaySettings.ValidateFloat( {input}, {def}, {min}, {max}, {forceUpdate} ) - {(forceUpdate ? "Updated because of version breaking changes" : (input < min ? "Updated because value was less than minimum" : "Updated because value was greater than maximum"))}");
			input = def;
			return false;
		}
		return true;
	}

	private bool ValidateInt(ref int input, int def, bool forceUpdate) => ValidateInt(ref input, def, int.MinValue, int.MaxValue, forceUpdate);
	private bool ValidateInt(ref int input, int def, int min = int.MinValue, int max = int.MaxValue, bool forceUpdate = false)
	{
		if (input < min || input > max || forceUpdate)
		{
			DebugHelper.Log($"TwitchPlaySettings.ValidateFloat( {input}, {def}, {min}, {max}, {forceUpdate} ) - {(forceUpdate ? "Updated because of version breaking changes" : (input < min ? "Updated because value was less than minimum" : "Updated because value was greater than maximum"))}");
			input = def;
			return false;
		}
		return true;
	}

	private bool ValidateDictionaryEntry(string key, ref Dictionary<string, string> input, Dictionary<string, string> def, bool forceUpdate = false)
	{
		if (!input.ContainsKey(key) || forceUpdate)
		{
			DebugHelper.Log($"TwitchPlaySettings.ValidateDictionaryEntry( {key}, {def[key]}, {(forceUpdate ? "Updated because of version breaking changes" : "Updated because key doesn't exist")}");
			input[key] = def[key];
			return false;
		}
		return true;
	}

	private bool ValidateModDistribution(ref Dictionary<string, ModuleDistributions> distributions)
	{
		bool result = true;
		List<string> invalidKeys = new List<string>();

		foreach (string key in distributions.Keys)
		{
			ModuleDistributions distribution = distributions[key];
			result &= ValidateFloat(ref distribution.Vanilla, 0.5f, 0f, 1f);
			result &= ValidateFloat(ref distribution.Modded, 1f - distribution.Vanilla, 0f, 1f);
			if (distribution.MinModules > distribution.MaxModules)
			{
				result = false;
				int temp = distribution.MinModules;
				distribution.MinModules = distribution.MaxModules;
				distribution.MaxModules = temp;
			}
			result &= ValidateInt(ref distribution.MinModules, 1, 1);
			result &= ValidateInt(ref distribution.MaxModules, Math.Max(distribution.MinModules, 101), distribution.MinModules);

			if (!key.EqualsIgnoreCase(key) || key.Contains(" "))
				invalidKeys.Add(key);
		}
		if (invalidKeys.Any())
		{
			result = false;
			foreach (string key in invalidKeys)
			{
				distributions[key.ToLowerInvariant().Replace(" ", "")] = distributions[key];
				distributions.Remove(key);
			}
		}

		return result;
	}

	public bool ValidateStrings()
	{
		TwitchPlaySettingsData data = new TwitchPlaySettingsData();
		bool valid = true;

		valid &= ValidateString(ref InvalidCommand, data.InvalidCommand, 3);
		valid &= ValidateString(ref CommandError, data.CommandError, 4);

		valid &= ValidateString(ref HoldableInvalidCommand, data.HoldableInvalidCommand, 2);
		valid &= ValidateString(ref HoldableCommandError, data.HoldableCommandError, 3);

		valid &= ValidateString(ref AwardSolve, data.AwardSolve, 4);
		valid &= ValidateString(ref AwardVsSolve, data.AwardVsSolve, 6);
		valid &= ValidateString(ref AwardStrike, data.AwardStrike, 8);
		valid &= ValidateString(ref AwardVsStrike, data.AwardVsStrike, 10);
		valid &= ValidateString(ref AwardHoldableStrike, data.AwardHoldableStrike, 6);

		valid &= ValidateString(ref BombLiveMessage, data.BombLiveMessage, 0);
		valid &= ValidateString(ref MultiBombLiveMessage, data.MultiBombLiveMessage, 0);

		valid &= ValidateString(ref BombExplodedMessage, data.BombExplodedMessage, 1);

		valid &= ValidateString(ref BombDefusedMessage, data.BombDefusedMessage, 1);
		valid &= ValidateString(ref BombDefusedVsMessage, data.BombDefusedVsMessage, 2);
		valid &= ValidateString(ref BombDefusedBonusMessage, data.BombDefusedBonusMessage, 1);
		valid &= ValidateString(ref BombDefusedVsBonusMessage, data.BombDefusedVsBonusMessage, 2);
		valid &= ValidateString(ref BombDefusedFooter, data.BombDefusedFooter, 0);

		valid &= ValidateString(ref BombSoloDefusalMessage, data.BombSoloDefusalMessage, 3);
		valid &= ValidateString(ref BombSoloDefusalNewRecordMessage, data.BombSoloDefusalNewRecordMessage, 2);
		valid &= ValidateString(ref BombSoloDefusalFooter, data.BombSoloDefusalFooter, 0);

		valid &= ValidateString(ref BombAbortedMessage, data.BombAbortedMessage, 1);

		valid &= ValidateString(ref RankTooLow, data.RankTooLow, 0);

		valid &= ValidateString(ref SolverAndSolo, data.SolverAndSolo, 0);
		valid &= ValidateString(ref SoloRankQuery, data.SoloRankQuery, 3);
		valid &= ValidateString(ref RankQuery, data.RankQuery, 7);

		valid &= ValidateString(ref DoYouEvenPlayBro, data.DoYouEvenPlayBro, 1);

		valid &= ValidateString(ref TurnBombOnSolve, data.TurnBombOnSolve, 2);
		valid &= ValidateString(ref CancelBombTurn, data.CancelBombTurn, 2);

		valid &= ValidateString(ref ModuleClaimed, data.ModuleClaimed, 3);
		valid &= ValidateString(ref ModuleUnclaimed, data.ModuleUnclaimed, 3);
		valid &= ValidateString(ref ModuleNotClaimed, data.ModuleNotClaimed, 3);
		valid &= ValidateString(ref ModuleAlreadyOwned, data.ModuleAlreadyOwned, 3);

		valid &= ValidateString(ref AssignModule, data.AssignModule, 4);
		valid &= ValidateString(ref ModuleReady, data.ModuleReady, 3);

		valid &= ValidateString(ref TakeModule, data.TakeModule, 4);
		valid &= ValidateString(ref TakeInProgress, data.TakeInProgress, 3);
		valid &= ValidateString(ref ModuleAbandoned, data.ModuleAbandoned, 3);
		valid &= ValidateString(ref ModuleIsMine, data.ModuleIsMine, 3);
		valid &= ValidateString(ref TooManyClaimed, data.TooManyClaimed, 2);
		valid &= ValidateString(ref NoUnclaimed, data.NoUnclaimed, 1);
		valid &= ValidateString(ref ModulePlayer, data.ModulePlayer, 3);
		valid &= ValidateString(ref AlreadyClaimed, data.AlreadyClaimed, 4);
		valid &= ValidateString(ref AlreadySolved, data.AlreadySolved, 4);
		valid &= ValidateString(ref ClaimCooldown, data.ClaimCooldown, 4);

		valid &= ValidateString(ref OwnedModule, data.OwnedModule, 2);
		valid &= ValidateString(ref OwnedModuleList, data.OwnedModuleList, 2);
		valid &= ValidateString(ref NoOwnedModules, data.NoOwnedModules, 1);

		valid &= ValidateString(ref LogTooBig, data.LogTooBig, 0);

		valid &= ValidateString(ref TwitchPlaysDisabled, data.TwitchPlaysDisabled, 1);
		valid &= ValidateString(ref MissionBinderDisabled, data.MissionBinderDisabled, 1);
		valid &= ValidateString(ref FreePlayDisabled, data.FreePlayDisabled, 1);
		valid &= ValidateString(ref FreePlayNeedyDisabled, data.FreePlayNeedyDisabled, 1);
		valid &= ValidateString(ref FreePlayHardcoreDisabled, data.FreePlayHardcoreDisabled, 1);
		valid &= ValidateString(ref FreePlayModsOnlyDisabled, data.FreePlayModsOnlyDisabled, 1);
		valid &= ValidateString(ref TimeModeCommandDisabled, data.TimeModeCommandDisabled, 1);
		valid &= ValidateString(ref VsModeCommandDisabled, data.VsModeCommandDisabled, 1);
		valid &= ValidateString(ref ZenModeCommandDisabled, data.ZenModeCommandDisabled, 1);
		valid &= ValidateString(ref RetryInactive, data.RetryInactive, 0);

		valid &= ValidateString(ref AddedUserPower, data.AddedUserPower, 2, SettingsVersion < 1);
		valid &= ValidateString(ref RemoveUserPower, data.RemoveUserPower, 2, SettingsVersion < 1);

		valid &= ValidateString(ref BombHelp, data.BombHelp, 0);
		valid &= ValidateString(ref BlankBombEdgework, data.BlankBombEdgework, 0);
		valid &= ValidateString(ref BombEdgework, data.BombEdgework, 1);
		valid &= ValidateString(ref BombTimeRemaining, data.BombTimeRemaining, 2);
		valid &= ValidateString(ref BombTimeStamp, data.BombTimeStamp, 1);
		valid &= ValidateString(ref BombDetonateCommand, data.BombDetonateCommand, 0);
		valid &= ValidateString(ref BombStatusTimeMode, data.BombStatusTimeMode, 6);
		valid &= ValidateString(ref BombStatusVsMode, data.BombStatusVsMode, 5);
		valid &= ValidateString(ref BombStatus, data.BombStatus, 7);

		valid &= ValidateString(ref NotesSpaceFree, data.NotesSpaceFree, 0);
		valid &= ValidateString(ref Notes, data.Notes, 2);
		valid &= ValidateString(ref NotesTaken, data.NotesTaken, 2);
		valid &= ValidateString(ref NotesAppended, data.NotesTaken, 2);
		valid &= ValidateString(ref NoteSlotCleared, data.NoteSlotCleared, 1);

		valid &= ValidateString(ref GiveBonusPoints, data.GiveBonusPoints, 3);
		valid &= ValidateString(ref GiveBonusSolves, data.GiveBonusSolves, 3);
		valid &= ValidateString(ref GiveBonusStrikes, data.GiveBonusStrikes, 3);

		valid &= ValidateString(ref UnsubmittableAnswerPenalty, data.UnsubmittableAnswerPenalty, 5);

		valid &= ValidateString(ref UnsupportedNeedyWarning, data.UnsupportedNeedyWarning, 0, SettingsVersion < 2);

		valid &= ValidateFloat(ref AwardDropMultiplierOnStrike, data.AwardDropMultiplierOnStrike, 0, 1.0f);

		valid &= ValidateInt(ref InstantModuleClaimCooldown, data.InstantModuleClaimCooldown, 0);
		valid &= ValidateInt(ref InstantModuleClaimCooldownExpiry, data.InstantModuleClaimCooldownExpiry, 0);

		valid &= ValidateDictionaryEntry("infozen", ref BombCustomMessages, data.BombCustomMessages);

		valid &= ValidateModDistribution(ref ModDistributions);

		if (!TwitchPlaysDebugUsername.StartsWith("_"))
		{
			valid = false;
			DebugHelper.Log("The debugger user name Must begin with an underscore, to ensure that it is not a valid Twitch username.");
			TwitchPlaysDebugUsername = "_" + TwitchPlaysDebugUsername;
		}

		return valid;
	}
}

public static class TwitchPlaySettings
{
	public static int SettingsVersion = 2; //Bump this up each time there is a breaking file format change (like a change to the string formats themselves).
	public static TwitchPlaySettingsData data;

	private static List<string> Players = new List<string>();
	private static int ClearReward = 0;
	private static int RetryReward = 0;

	public static void WriteDataToFile()
	{
		string path = Path.Combine(Application.persistentDataPath, usersSavePath);
		DebugHelper.Log($"TwitchPlayStrings: Writing file {path}");
		try
		{
			data.SettingsVersion = SettingsVersion;
			File.WriteAllText(path, SettingsConverter.Serialize(data));//JsonConvert.SerializeObject(data, Formatting.Indented));
		}
		catch (FileNotFoundException)
		{
			DebugHelper.LogWarning($"TwitchPlayStrings: File {path} was not found.");
			return;
		}
		catch (Exception ex)
		{
			DebugHelper.LogException(ex);
			return;
		}
		DebugHelper.Log($"TwitchPlayStrings: Writing of file {path} completed successfully");
	}

	public static bool LoadDataFromFile()
	{
		string path = Path.Combine(Application.persistentDataPath, usersSavePath);
		try
		{
			DebugHelper.Log($"TwitchPlayStrings: Loading Custom strings data from file: {path}");
			data = SettingsConverter.Deserialize<TwitchPlaySettingsData>(File.ReadAllText(path));//JsonConvert.DeserializeObject<TwitchPlaySettingsData>(File.ReadAllText(path));
			data.ValidateStrings();
			WriteDataToFile();
		}
		catch (FileNotFoundException)
		{
			DebugHelper.LogWarning($"TwitchPlayStrings: File {path} was not found.");
			data = new TwitchPlaySettingsData();
			WriteDataToFile();
			return false;
		}
		catch (Exception ex)
		{
			data = new TwitchPlaySettingsData();
			DebugHelper.LogException(ex);
			return false;
		}
		return true;
	}

	private static bool CreateSharedDirectory()
	{
		if (string.IsNullOrEmpty(data.TPSharedFolder))
		{
			return false;
		}
		try
		{
			if (!Directory.Exists(data.TPSharedFolder))
			{
				Directory.CreateDirectory(data.TPSharedFolder);
			}
			return Directory.Exists(data.TPSharedFolder);
		}
		catch (Exception ex)
		{
			DebugHelper.LogException(ex, "TwitchPlaysStrings: Failed to Create shared Directory due to Exception:");
			return false;
		}
	}

	public static void AppendToSolveStrikeLog(string RecordMessageTone, int copies = 1)
	{
		if (!CreateSharedDirectory() || string.IsNullOrEmpty(data.TPSolveStrikeLog))
		{
			return;
		}
		try
		{
			using (StreamWriter file =
				new StreamWriter(Path.Combine(data.TPSharedFolder, data.TPSolveStrikeLog), true))
			{
				for (int i = 0; i < copies; i++)
				{
					file.WriteLine(RecordMessageTone);
				}
			}
		}
		catch (Exception ex)
		{
			DebugHelper.LogException(ex, "TwitchPlaysStrings: Failed to log due to Exception:");
		}
	}

	public static void AppendToPlayerLog(string userNickName)
	{
		if (!Players.Contains(userNickName) && !UserAccess.HasAccess(userNickName, AccessLevel.NoPoints))
		{
			Players.Add(userNickName);
		}
	}

	public static void ClearPlayerLog()
	{
		Players.Clear();
		ClearReward = 0;
	}

	public static string GiveBonusPoints()
	{
		if (ClearReward == 0 || Players.Count == 0)
		{
			return data.BombDefusedFooter;
		}

		string message;

		if (!OtherModes.VSModeOn)
		{
			int ClearReward2 = Mathf.CeilToInt(ClearReward / (float) Players.Count);
			message = string.Format(data.BombDefusedBonusMessage, ClearReward2) + data.BombDefusedFooter;
			foreach (string player in Players)
			{
				Leaderboard.Instance.AddScore(player, ClearReward2);
			}
		}
		else
		{
			OtherModes.Team winner = OtherModes.Team.Good;
			if (OtherModes.GetGoodHealth() == 0)
				winner = OtherModes.Team.Evil;
			else if (OtherModes.GetEvilHealth() == 0)
				winner = OtherModes.Team.Good;

			int ClearReward2 =
				Mathf.CeilToInt(ClearReward / (float) Players.Count(x => Leaderboard.Instance.GetTeam(x) == winner));
			message = string.Format(data.BombDefusedVsBonusMessage, ClearReward2,
				winner == OtherModes.Team.Good ? "good" : "evil") + data.BombDefusedFooter;

			foreach (string player in Players.Where(x => Leaderboard.Instance.GetTeam(x) == winner))
			{
				Leaderboard.Instance.AddScore(player, ClearReward2);
			}
		}

		ClearPlayerLog();
		return message;
	}

	public static void AddRewardBonus(int bonus) => ClearReward += bonus;

	public static void SetRewardBonus(int moduleCountBonus)
	{
		ClearReward = moduleCountBonus;
		RetryReward = moduleCountBonus;
	}

	public static int GetRewardBonus() => ClearReward;

	public static void SetRetryReward() => ClearReward = RetryReward;

	public static Tuple<bool, string> ResetSettingToDefault(string setting)
	{
		var split = setting.Split('.');
		Type tpdata = typeof(TwitchPlaySettingsData);
		var settingFields = tpdata.GetFields(BindingFlags.Public | BindingFlags.Instance).Where(x => x.Name.IndexOf(split[0], StringComparison.InvariantCultureIgnoreCase) >= 0).ToList();

		DebugHelper.Log($"Found {settingFields.Count} settings");
		if (!settingFields.Any())
		{
			return new Tuple<bool, string>(false, $"Setting {setting} not found.");
		}

		var settingField = settingFields[0];
		if (settingFields.Count > 1)
		{
			settingField = settingFields.FirstOrDefault(x => x.Name.Equals(split[0], StringComparison.InvariantCultureIgnoreCase));
			if (settingField == null)
				return new Tuple<bool, string>(false, $"More than one setting with the name {setting} was found. Here are the settings available with the specified name: {settingFields.Select(x => x.Name).Join(", ")}");
		}
		var originalValue = settingField.GetValue(data);
		DebugHelper.Log($"Found exactly one. Settings name is {settingField.Name}, Settings type is {originalValue.GetType().Name}");
		TwitchPlaySettingsData defaultData = new TwitchPlaySettingsData();
		var defaultValue = settingField.GetValue(defaultData);
		settingField.SetValue(data, defaultValue);
		return new Tuple<bool, string>(true, $"Setting {settingField.Name} reset to default value.");
	}

	public static Tuple<bool, string> ChangeSetting(string setting, string settingValue)
	{
		var split = setting.Split('.');
		Type tpdata = typeof(TwitchPlaySettingsData);
		var settingFields = tpdata.GetFields(BindingFlags.Public | BindingFlags.Instance).Where(x => x.Name.IndexOf(split[0], StringComparison.InvariantCultureIgnoreCase) >= 0).ToList();

		DebugHelper.Log($"Found {settingFields.Count} settings");
		if (!settingFields.Any())
		{
			return new Tuple<bool, string>(false, $"Setting {setting} not found.");
		}

		var settingField = settingFields[0];
		if (settingFields.Count > 1)
		{
			settingField = settingFields.FirstOrDefault(x => x.Name.Equals(split[0], StringComparison.InvariantCultureIgnoreCase));
			if (settingField == null)
				return new Tuple<bool, string>(false, $"More than one setting with the name {setting} was found. Here are the settings available with the specified name: {settingFields.Select(x => x.Name).Join(", ")}");
		}
		var originalValue = settingField.GetValue(data);
		DebugHelper.Log($"Found exactly one. Settings name is {settingField.Name}, Settings type is {originalValue.GetType().Name}");
		switch (originalValue)
		{
			case int settingInt:
				if (!int.TryParse(settingValue, out int newSettingInt))
					return new Tuple<bool, string>(false, $"Setting {settingField.Name} not changed. {settingValue} is not a valid value.");
				settingField.SetValue(data, newSettingInt);
				if (!data.ValidateStrings())
				{
					settingField.SetValue(data, originalValue);
					return new Tuple<bool, string>(false, $"Setting {settingField.Name} not changed to {settingValue}");
				}
				return new Tuple<bool, string>(true, $"Setting {settingField.Name} changed from {settingInt} to {settingValue}");
			case float settingFloat:
				if (!float.TryParse(settingValue, out float newSettingFloat))
					return new Tuple<bool, string>(false, $"Setting {settingField.Name} not changed. {settingValue} is not a valid value.");
				settingField.SetValue(data, newSettingFloat);
				if (!data.ValidateStrings())
				{
					settingField.SetValue(data, originalValue);
					return new Tuple<bool, string>(false, $"Setting {settingField.Name} not changed to {settingValue}");
				}
				return new Tuple<bool, string>(true, $"Setting {settingField.Name} changed from {settingFloat} to {settingValue}");
			case bool settingBool:
				if (!bool.TryParse(settingValue, out bool newSettingBool))
					return new Tuple<bool, string>(false, $"Setting {settingField.Name} not changed. {settingValue} is not a valid value.");
				settingField.SetValue(data, newSettingBool);
				return new Tuple<bool, string>(true, $"Setting {settingField.Name} changed from {settingBool} to {settingValue}");
			case Color settingColor:
				IEnumerable<int?> parts = settingValue.Split(',').Select(str => str.Trim().TryParseInt());
				if (parts.Any(x => x == null)) return new Tuple<bool, string>(false, $"Setting {settingField.Name} not changed. {settingValue} is not a valid value.");

				float[] values = parts.Select(i => (int) i / 255f).ToArray();
				switch (values.Length)
				{
					case 3:
						settingField.SetValue(data, new Color(values[0], values[1], values[2]));
						return new Tuple<bool, string>(true, $"Setting {settingField.Name} changed from Color({(int) (settingColor.r * 255)}, {(int) (settingColor.g * 255)}, {(int) (settingColor.b * 255)}) to Color({settingValue})");
					case 4:
						settingField.SetValue(data, new Color(values[0], values[1], values[2], values[3]));
						return new Tuple<bool, string>(true, $"Setting {settingField.Name} changed from Color({(int) (settingColor.r * 255)}, {(int) (settingColor.g * 255)}, {(int) (settingColor.b * 255)}, {(int) (settingColor.a * 255)}) to Color({settingValue})");
					default:
						return new Tuple<bool, string>(false, $"Setting {settingField.Name} not changed. {settingValue} is not a valid value.");
				}
			case string settingString:
				settingField.SetValue(data, settingValue.Replace("\\n", "\n"));
				if (!data.ValidateStrings())
				{
					settingField.SetValue(data, originalValue);
					return new Tuple<bool, string>(false, $"Setting {settingField.Name} not changed to {settingValue}");
				}
				return new Tuple<bool, string>(true, $"Setting {settingField.Name} changed from {settingString} to {settingValue}");
			case List<string> settingListString:

				switch (split.Length)
				{
					case 2 when int.TryParse(split[1], out int listIndex) && listIndex >= 0 && listIndex < settingListString.Count:
						//return $"Settings {settingField.Name}[{listIndex}]: {settingListString[listIndex]}";
						string origListValue = settingListString[listIndex];
						settingListString[listIndex] = settingValue;
						return new Tuple<bool, string>(true, $"Setting {settingField.Name}[{listIndex}] changed from {origListValue} to {settingValue}.");
					default:
						settingListString.Add(settingValue);
						return new Tuple<bool, string>(true, $"Setting {settingField.Name}.Add({settingField}) completed successfully.");
				}
			case Dictionary<string, string> settingsDictionaryStringString:
				switch (split.Length)
				{
					case 2 when !string.IsNullOrEmpty(split[1]):
						bool settingDssResult = settingsDictionaryStringString.TryGetValue(split[1], out string settingsDssString);
						settingsDictionaryStringString[split[1]] = settingValue.Replace("\\n", "\n");
						return settingDssResult
							? new Tuple<bool, string>(true, $"Setting {settingField.Name}[{split[1]}] changed from {settingsDssString} to {settingValue}")
							: new Tuple<bool, string>(true, $"Setting {settingField.Name}[{split[1]}] set to {settingValue}");
					case 2:
						return new Tuple<bool, string>(false, $"The second item cannot be empty or null");
					default:
						return new Tuple<bool, string>(false, $"You must specify a dictionary item you wish to set or change.");
				}
			case Dictionary<string, bool> settingsDictionaryStringBool:
				switch (split.Length)
				{
					case 2 when !string.IsNullOrEmpty(split[1]) && bool.TryParse(settingValue, out bool settingValueBool):
						bool settingDssResult = settingsDictionaryStringBool.TryGetValue(split[1], out bool settingsDssBool);
						settingsDictionaryStringBool[split[1]] = settingValueBool;
						return settingDssResult
							? new Tuple<bool, string>(true, $"Setting {settingField.Name}[{split[1]}] changed from {settingsDssBool} to {settingValue}")
							: new Tuple<bool, string>(true, $"Setting {settingField.Name}[{split[1]}] set to {settingValue}");
					case 2 when !string.IsNullOrEmpty(split[1]):
						return new Tuple<bool, string>(false, $"Could not parse {settingValue} as bool");
					case 2:
						return new Tuple<bool, string>(false, $"The second item cannot be empty or null");
					default:
						return new Tuple<bool, string>(false, $"You must specify a dictionary item you wish to set or change.");
				}
			case Dictionary<string, ModuleDistributions> settingsDictionaryStringModuleDistributions:
				switch (split.Length)
				{
					case 2 when !string.IsNullOrEmpty(split[1]):
						bool settingDssResult = settingsDictionaryStringModuleDistributions.TryGetValue(split[1], out ModuleDistributions settingsDssModuleDistribution);
						ModuleDistributions newModDist;
						try
						{
							newModDist = JsonConvert.DeserializeObject<ModuleDistributions>(settingValue);
						}
						catch
						{
							return new Tuple<bool, string>(false, $"Could not parse {settingValue} as ModuleDistributions");
						}

						settingsDictionaryStringModuleDistributions[split[1]] = newModDist;
						return settingDssResult
							? new Tuple<bool, string>(true, $"Setting {settingField.Name}[{split[1]}] changed from {JsonConvert.SerializeObject(settingsDssModuleDistribution, Formatting.None)} to {settingValue}")
							: new Tuple<bool, string>(true, $"Setting {settingField.Name}[{split[1]}] set to {settingValue}");
					case 2:
						return new Tuple<bool, string>(false, $"The second item cannot be empty or null");
					default:
						return new Tuple<bool, string>(false, $"You must specify a dictionary item you wish to set or change.");
				}
			default:
				return new Tuple<bool, string>(false, $"Setting {setting} was found, but I don't know how change its value to {settingValue}");
		}
	}

	public static string GetSetting(string setting)
	{
		DebugHelper.Log($"Attempting to read settings {setting}");
		var split = setting.Split('.');
		Type tpdata = typeof(TwitchPlaySettingsData);
		var settingFields = tpdata.GetFields(BindingFlags.Public | BindingFlags.Instance).Where(x => x.Name.IndexOf(split[0], StringComparison.InvariantCultureIgnoreCase) >= 0).ToList();

		DebugHelper.Log($"Found {settingFields.Count} settings");
		if (!settingFields.Any())
		{
			return $"Setting {setting} not found.";
		}

		var settingField = settingFields[0];
		if (settingFields.Count > 1)
		{
			settingField = settingFields.FirstOrDefault(x => x.Name.Equals(split[0], StringComparison.InvariantCultureIgnoreCase));
			if (settingField == null)
				return $"More than one setting with the name {setting} was found. Here are the settings available with the specified name: {settingFields.Select(x => x.Name).Join(", ")}";
		}

		var settingValue = settingField.GetValue(data);
		DebugHelper.Log($"Found exactly one. Settings name is {settingField.Name}, Settings type is {settingValue.GetType().Name}");
		switch (settingValue)
		{
			case int settingInt:
				return $"Setting {settingField.Name}: {settingInt}";
			case float settingFloat:
				return $"Setting {settingField.Name}: {settingFloat}";
			case bool settingBool:
				return $"Setting {settingField.Name}: {settingBool}";
			case Color settingColor:
				return $"Setting {settingField.Name}: Color({(int) (settingColor.r * 255)}, {(int) (settingColor.g * 255)}, {(int) (settingColor.b * 255)}, {(int) (settingColor.a * 255)})";
			case string settingString:
				return $"Setting {settingField.Name}: {settingString.Replace("\n", "\\n")}";
			case List<string> settingListString:
				switch (split.Length)
				{
					case 2 when int.TryParse(split[1], out int listIndex) && listIndex >= 0 && listIndex < settingListString.Count:
						return $"Settings {settingField.Name}[{listIndex}]: {settingListString[listIndex]}";
					case 2 when int.TryParse(split[1], out int listIndex):
						return $"Settings {settingField.Name}[{listIndex}]: Index out of range";
					default:
						return $"Setting {settingField.Name}: Count = {settingListString.Count}";
				}
			case Dictionary<string, string> settingsDictionaryStringString:
				switch (split.Length)
				{
					case 2 when !string.IsNullOrEmpty(split[1]) && settingsDictionaryStringString.TryGetValue(split[1], out string settingsDssString):
						return $"Setting {settingField.Name}[{split[1]}]: {settingsDssString.Replace("\n", "\\n")}";
					case 2 when !string.IsNullOrEmpty(split[1]):
						return $"Setting {settingField.Name}[{split[1]}]: does not exist";
					case 2:
						return $"Setting {settingField.Name}: The second item cannot be empty or null";
					default:
						return $"Setting {settingField.Name}: Count = {settingsDictionaryStringString.Count}";
				}
			case Dictionary<string, bool> settingsDictionaryStringBool:
				switch (split.Length)
				{
					case 2 when !string.IsNullOrEmpty(split[1]) && settingsDictionaryStringBool.TryGetValue(split[1], out bool settingsDsbBool):
						return $"Setting {settingField.Name}[{split[1]}]: {settingsDsbBool}";
					case 2 when !string.IsNullOrEmpty(split[1]):
						return $"Setting {settingField.Name}[{split[1]}]: does not exist";
					case 2:
						return $"Setting {settingField.Name}: The second item cannot be empty or null";
					default:
						return $"Setting {settingField.Name}: Count = {settingsDictionaryStringBool.Count}";
				}
			case Dictionary<string, ModuleDistributions> settingsDictionaryStringModuleDistributions:
				switch (split.Length)
				{
					case 2 when !string.IsNullOrEmpty(split[1]) && settingsDictionaryStringModuleDistributions.TryGetValue(split[1], out ModuleDistributions settingsDsmModuleDistributions):
						string moddistjson = JsonConvert.SerializeObject(settingsDsmModuleDistributions, Formatting.None);
						return $"Setting {settingField.Name}[{split[1]}]: {moddistjson}";
					case 2 when !string.IsNullOrEmpty(split[1]):
						return $"Setting {settingField.Name}[{split[1]}]: does not exist";
					case 2:
						return $"Setting {settingField.Name}: The second item cannot be empty or null";
					default:
						return $"Setting {settingField.Name}: Count = {settingsDictionaryStringModuleDistributions.Count}";
				}
			default:
				return $"Setting {setting} was found, but I don't know how to parse its type.";
		}
	}

	public static string usersSavePath = "TwitchPlaySettings.json";
}
