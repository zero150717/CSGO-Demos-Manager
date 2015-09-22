﻿using DemoInfo;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using CSGO_Demos_Manager.Models.Events;

namespace CSGO_Demos_Manager.Models
{
	/// <summary>
	/// Represent a player
	/// </summary>
	public class PlayerExtended : ObservableObject
	{
		#region Properties

		/// <summary>
		/// Number of 1 Kill that the player made during the match
		/// </summary>
		private int _onekillCount;

		/// <summary>
		/// Number of 2 kills that the player made during the match
		/// </summary>
		private int _twokillCount;

		/// <summary>
		/// Number of 3 kills that the player made during the match
		/// </summary>
		private int _threekillCount;

		/// <summary>
		/// Number of 4 kills that the player made during the match
		/// </summary>
		private int _fourKillCount;

		/// <summary>
		/// Number of 5 kills that the player made during the match
		/// </summary>
		private int _fiveKillCount;

		/// <summary>
		/// Number of heashots that the player made during the match
		/// </summary>
		private int _headshotCount;

		/// <summary>
		/// Number of assists that the player made during the match
		/// </summary>
		private int _assistCount;

		/// <summary>
		/// Number of deaths that the player had during the match
		/// </summary>
		private int _deathCount;

		/// <summary>
		/// Total number of kills that the player made during the match
		/// </summary>
		private int _killCount;

		/// <summary>
		/// Number of teamkill that the player made during the match
		/// </summary>
		private int _teamKillCount;

		/// <summary>
		/// Number MVP that the player had during the match
		/// </summary>
		private int _roundMvpCount;

		/// <summary>
		/// Number of bomb which the player had planted during the match
		/// </summary>
		private int _bombPlantedCount;

		/// <summary>
		/// Number of bomb which the player had defused during the match
		/// </summary>
		private int _bombDefusedCount;

		/// <summary>
		/// Score of the player (calculated by the game)
		/// </summary>
		private int _score;

		/// <summary>
		/// Indicate if the player is controlling a BOT
		/// </summary>
		private bool _isControllingBot;

		/// <summary>
		/// Number of opponents if the player is in clutch
		/// </summary>
		private int _opponentClutchCount;

		/// <summary>
		/// Indicate if the player is alive
		/// </summary>
		private bool _isAlive = true;

		/// <summary>
		/// Player kills / Deaths ratio
		/// </summary>
		private decimal _killsDeathsRatio;

		/// <summary>
		/// Player's current team (change when half side is over)
		/// </summary>
		private Team _team;

		/// <summary>
		/// Player's SteamID 64
		/// </summary>
		private long _steamId;

		/// <summary>
		/// Player's nickname used when he was playing
		/// </summary>
		private string _name = "";

		/// <summary>
		/// Number of 1v1 the player made during the match
		/// </summary>
		private int _1V1Count;

		/// <summary>
		/// Number of 1v2 the player made during the match
		/// </summary>
		private int _1V2Count ;

		/// <summary>
		/// Number of 1v3 the player made during the match
		/// </summary>
		private int _1V3Count;

		/// <summary>
		/// Number of 1v4 the player made during the match
		/// </summary>
		private int _1V4Count;

		/// <summary>
		/// Number of 1v5 the player made during the match
		/// </summary>
		private int _1V5Count;

		/// <summary>
		/// Flag to know if the player had an entry kill during a round
		/// </summary>
		private bool _hasEntryKill;

		/// <summary>
		/// Flag to know if the player had the open kill during a round
		/// </summary>
		private bool _hasOpeningKill;

		/// <summary>
		/// Rating based on hltv.org formula that the player made during the match
		/// </summary>
		private float _ratingHltv;

		/// <summary>
		/// Indicates if the player has the bomb, used for the overview animation
		/// </summary>
		private bool _hasBomb = false;

		/// <summary>
		/// Indicates if the player has been VAC banned
		/// </summary>
		private bool _isVacBanned;

		/// <summary>
		/// Indicates if the player has been overwatch banned
		/// </summary>
		private bool _isOverwatchBanned;

		private int _rankNumberOld = 0;

		private int _rankNumberNew = 0;

		private int _winCount = 0;

		/// <summary>
		/// Number of flashbang throwed by the player
		/// </summary>
		private int _flashbangThrowedCount;

		/// <summary>
		/// Number of smoke throwed by the player
		/// </summary>
		private int _smokeThrowedCount;

		/// <summary>
		/// Number of HE Grenade throwed by the player
		/// </summary>
		private int _heGrenadeThrowedCount;

		/// <summary>
		/// Number of molotov throwed by the player
		/// </summary>
		private int _molotovThrowedCount;

		/// <summary>
		/// Number of incendiary throwed by the player
		/// </summary>
		private int _incendiaryThrowedCount;

		/// <summary>
		/// Number of decoy throwed by the player
		/// </summary>
		private int _decoyThrowedCount;

		/// <summary>
		/// Number of round that the player played
		/// </summary>
		private int _roundPlayedCount = 0;

		/// <summary>
		/// Avatar URL of the player (get from Steam API)
		/// </summary>
		private string _avatarUrl = "../resources/images/avatar.jpg";
		#endregion

		#region Accessors

		[JsonIgnore]
		public string AvatarUrl
		{
			get { return _avatarUrl; }
			set { Set(() => AvatarUrl, ref _avatarUrl, value); }
		}

		[JsonIgnore]
		public bool HasEntryKill
		{
			get { return _hasEntryKill; }
			set { Set(() => HasEntryKill, ref _hasEntryKill, value); }
		}

		[JsonIgnore]
		public bool HasOpeningKill
		{
			get { return _hasOpeningKill; }
			set { Set(() => HasOpeningKill, ref _hasOpeningKill, value); }
		}

		[JsonIgnore]
		public bool IsControllingBot
		{
			get { return _isControllingBot; }
			set { Set(() => IsControllingBot, ref _isControllingBot, value); }
		}

		[JsonProperty("score")]
		public int Score
		{
			get { return _score; }
			set { Set(() => Score, ref _score, value); }
		}

		[JsonProperty("teamkill_count")]
		public int TeamKillCount
		{
			get { return _teamKillCount; }
			set { Set(() => TeamKillCount, ref _teamKillCount, value); }
		}

		[JsonProperty("assist_count")]
		public int AssistCount
		{
			get { return _assistCount; }
			set { Set(() => AssistCount, ref _assistCount, value); }
		}

		[JsonProperty("bomb_planted_count")]
		public int BombPlantedCount
		{
			get { return _bombPlantedCount; }
			set { Set(() => BombPlantedCount, ref _bombPlantedCount, value); }
		}

		[JsonProperty("bomb_defused_count")]
		public int BombDefusedCount
		{
			get { return _bombDefusedCount; }
			set { Set(() => BombDefusedCount, ref _bombDefusedCount, value); }
		}

		[JsonProperty("death_count")]
		public int DeathCount
		{
			get { return _deathCount; }
			set {
				RaisePropertyChanged(() => KillDeathRatio);
				Set(() => DeathCount, ref _deathCount, value);
			}
		}

		[JsonProperty("five_kills_count")]
		public int FiveKillCount
		{
			get { return _fiveKillCount; }
			set { Set(() => FiveKillCount, ref _fiveKillCount, value); }
		}

		[JsonProperty("four_kills_count")]
		public int FourKillCount
		{
			get { return _fourKillCount; }
			set { Set(() => FourKillCount, ref _fourKillCount, value); }
		}

		[JsonProperty("three_kills_count")]
		public int ThreekillCount
		{
			get { return _threekillCount; }
			set { Set(() => ThreekillCount, ref _threekillCount, value); }
		}

		[JsonProperty("two_kills_count")]
		public int TwokillCount
		{
			get { return _twokillCount; }
			set { Set(() => TwokillCount, ref _twokillCount, value); }
		}

		[JsonProperty("one_kill_count")]
		public int OnekillCount
		{
			get { return _onekillCount; }
			set { Set(() => OnekillCount, ref _onekillCount, value); }
		}

		[JsonProperty("headshot_count")]
		public int HeadshotCount
		{
			get { return _headshotCount; }
			set
			{
				RaisePropertyChanged(() => HeadshotAsString);
				Set(() => HeadshotCount, ref _headshotCount, value);
			}
		}

		[JsonProperty("kd_ratio")]
		public decimal KillDeathRatio
		{
			get
			{
				if (_killCount != 0 && _deathCount != 0) return Math.Round((decimal)_killCount / (decimal)_deathCount, 2);
				return 0;
			}
			set { Set(() => KillDeathRatio, ref _killsDeathsRatio, value); }
		}

		[JsonProperty("mvp_count")]
		public int RoundMvpCount
		{
			get { return _roundMvpCount; }
			set { Set(() => RoundMvpCount, ref _roundMvpCount, value); }
		}

		[JsonIgnore]
		public Team Team
		{
			get { return _team; }
			set { Set(() => Team, ref _team, value); }
		}

		[JsonProperty("steamid")]
		public long SteamId
		{
			get { return _steamId; }
			set { Set(() => SteamId, ref _steamId, value); }
		}

		[JsonProperty("name")]
		public string Name
		{
			get { return _name; }
			set { Set(() => Name, ref _name, value); }
		}

		[JsonProperty("kill_count")]
		public int KillsCount
		{
			get { return _killCount; }
			set
			{
				RaisePropertyChanged(() =>KillDeathRatio);
				RaisePropertyChanged(() => HeadshotAsString);
				Set(() => KillsCount, ref _killCount, value);
			}
		}

		[JsonProperty("rating_hltv")]
		public float RatingHltv
		{
			get { return _ratingHltv; }
			set { Set(() => RatingHltv, ref _ratingHltv, value); }
		}

		[JsonIgnore]
		public bool IsAlive
		{
			get { return _isAlive; }
			set { Set(() => IsAlive, ref _isAlive, value); }
		}

		[JsonIgnore]
		public int OpponentClutchCount
		{
			get { return _opponentClutchCount; }
			set { Set(() => OpponentClutchCount, ref _opponentClutchCount, value); }
		}

		[JsonProperty("1v1_count")]
		public int Clutch1V1Count
		{
			get { return _1V1Count; }
			set { Set(() => Clutch1V1Count, ref _1V1Count, value); }
		}

		[JsonProperty("1v2_count")]
		public int Clutch1V2Count
		{
			get { return _1V2Count; }
			set { Set(() => Clutch1V2Count, ref _1V2Count, value); }
		}

		[JsonProperty("1v3_count")]
		public int Clutch1V3Count
		{
			get { return _1V3Count; }
			set { Set(() => Clutch1V3Count, ref _1V3Count, value); }
		}

		[JsonProperty("1v4_count")]
		public int Clutch1V4Count
		{
			get { return _1V4Count; }
			set { Set(() => Clutch1V4Count, ref _1V4Count, value); }
		}

		[JsonProperty("1v5_count")]
		public int Clutch1V5Count
		{
			get { return _1V5Count; }
			set { Set(() => Clutch1V5Count, ref _1V5Count, value); }
		}

		[JsonProperty("vac_banned")]
		public bool IsVacBanned
		{
			get { return _isVacBanned; }
			set { Set(() => IsVacBanned, ref _isVacBanned, value); }
		}

		[JsonProperty("overwatch_banned")]
		public bool IsOverwatchBanned
		{
			get { return _isOverwatchBanned; }
			set { Set(() => IsOverwatchBanned, ref _isOverwatchBanned, value); }
		}

		[JsonProperty("flashbang_throwed_count")]
		public int FlashbangThrowedCount
		{
			get { return _flashbangThrowedCount; }
			set { Set(() => FlashbangThrowedCount, ref _flashbangThrowedCount, value); }
		}

		[JsonProperty("smoke_throwed_count")]
		public int SMokeThrowedCount
		{
			get { return _smokeThrowedCount; }
			set { Set(() => SMokeThrowedCount, ref _smokeThrowedCount, value); }
		}

		[JsonProperty("hegrenade_throwed_count")]
		public int HeGrenadeThrowedCount
		{
			get { return _heGrenadeThrowedCount; }
			set { Set(() => HeGrenadeThrowedCount, ref _heGrenadeThrowedCount, value); }
		}

		[JsonProperty("molotov_throwed_count")]
		public int MolotovThrowedCount
		{
			get { return _molotovThrowedCount; }
			set { Set(() => MolotovThrowedCount, ref _molotovThrowedCount, value); }
		}

		[JsonProperty("incendiary_throwed_count")]
		public int IncendiaryThrowedCount
		{
			get { return _incendiaryThrowedCount; }
			set { Set(() => IncendiaryThrowedCount, ref _incendiaryThrowedCount, value); }
		}

		[JsonProperty("decoy_throwed_count")]
		public int DecoyThrowedCount
		{
			get { return _decoyThrowedCount; }
			set { Set(() => DecoyThrowedCount, ref _decoyThrowedCount, value); }
		}

		[JsonProperty("round_played_count")]
		public int RoundPlayedCount
		{
			get { return _roundPlayedCount; }
			set { Set(() => RoundPlayedCount, ref _roundPlayedCount, value); }
		}

		[JsonProperty("entry_kills")]
		public ObservableCollection<EntryKillEvent> EntryKills { get; set; }

		[JsonProperty("opening_kills")]
		public ObservableCollection<OpenKillEvent> OpeningKills { get; set; }

		/// <summary>
		/// List of PlayerHurtedEvent in which the player is involved
		/// </summary>
		[JsonProperty("players_hurted")]
		public ObservableCollection<PlayerHurtedEvent> PlayersHurted { get; set; }

		[JsonProperty("rank_number_old")]
		public int RankNumberOld
		{
			get { return _rankNumberOld; }
			set { Set(() => RankNumberOld, ref _rankNumberOld, value); }
		}

		[JsonProperty("rank_number_new")]
		public int RankNumberNew
		{
			get { return _rankNumberNew; }
			set { Set(() => RankNumberNew, ref _rankNumberNew, value); }
		}

		[JsonProperty("number_wins")]
		public int WinCount
		{
			get { return _winCount; }
			set { Set(() => WinCount, ref _winCount, value); }
		}

		/// <summary>
		/// Total health damage made by the player
		/// </summary>
		[JsonIgnore]
		public int TotalDamageHealthCount => PlayersHurted.ToList()
			.Where(playerHurtedEvent => playerHurtedEvent?.Attacker != null && playerHurtedEvent.Attacker.SteamId == SteamId)
			.Sum(playerHurtedEvent => playerHurtedEvent.HealthDamage);

		/// <summary>
		/// Total armor damage made by the player
		/// </summary>
		[JsonIgnore]
		public int TotalDamageArmorCount => PlayersHurted.ToList()
			.Where(playerHurtedEvent => playerHurtedEvent?.Attacker != null && playerHurtedEvent.Attacker.SteamId == SteamId)
			.Sum(playerHurtedEvent => playerHurtedEvent.ArmorDamage);

		/// <summary>
		/// Total health damage the player has received
		/// </summary>
		[JsonIgnore]
		public int TotalDamageHealthReceivedCount => PlayersHurted.ToList()
			.Where(playerHurtedEvent => playerHurtedEvent?.Hurted != null && playerHurtedEvent.Hurted.SteamId == SteamId)
			.Sum(playerHurtedEvent => playerHurtedEvent.HealthDamage);

		/// <summary>
		/// Total armor damage the player has received
		/// </summary>
		[JsonIgnore]
		public int TotalDamageArmorReceivedCount => PlayersHurted.ToList()
			.Where(playerHurtedEvent => playerHurtedEvent?.Hurted != null && playerHurtedEvent.Hurted.SteamId == SteamId)
			.Sum(playerHurtedEvent => playerHurtedEvent.ArmorDamage);

		/// <summary>
		/// Average damage (Health + armor) the player has done during the match
		/// </summary>
		[JsonIgnore]
		public double AverageDamageByRoundCount
		{
			get
			{
				double total = 0;

				if (PlayersHurted.Any())
				{
					int roundNumber = 1;
					foreach (PlayerHurtedEvent playerHurtedEvent in PlayersHurted.ToList().Where(
						playerHurtedEvent => playerHurtedEvent?.Attacker != null && playerHurtedEvent.Attacker.SteamId == SteamId))
					{
						total += playerHurtedEvent.HealthDamage + playerHurtedEvent.ArmorDamage;
						roundNumber = playerHurtedEvent.RoundNumber;
					}
					if (Math.Abs(total) < 0.1) return total;
					total = Math.Round(total / roundNumber, 1);
				}

				return total;
			}
		}

		[JsonIgnore]
		public decimal HeadshotPercent
		{
			get
			{
				decimal headshotPercent = 0;
				if (_headshotCount <= 0) return headshotPercent;
				if(_killCount > 0) headshotPercent = (_headshotCount * 100) / (decimal)_killCount;
				headshotPercent = Math.Round(headshotPercent, 2);

				return headshotPercent;
			}
		}

		[JsonProperty("entry_kill_win_count")]
		public int EntryKillWinCount
		{
			get { return EntryKills.Count(e => e.HasWin); }
		}

		[JsonProperty("entry_kill_loss_count")]
		public int EntryKillLossCount
		{
			get { return EntryKills.Count(e => e.HasWin == false); }
		}

		[JsonProperty("open_kill_win_count")]
		public int OpenKillWinCount
		{
			get { return OpeningKills.Count(e => e.HasWin); }
		}

		[JsonProperty("open_kill_loss_count")]
		public int OpenKillLossCount
		{
			get { return OpeningKills.Count(e => e.HasWin == false); }
		}

		[JsonIgnore]
		public decimal RatioEntryKill
		{
			get
			{
				int entryKillCount = EntryKills.Count();
				int entryKillWin = EntryKills.Count(e => e.HasWin);
				int entryKillLoss = EntryKills.Count(e => e.HasWin == false);

				decimal entryKillPercent = 0;
				if (entryKillWin == 0) return entryKillPercent;
				if (entryKillLoss == 0) return 100;
				entryKillPercent = (entryKillWin / (decimal)entryKillCount) * 100;
				entryKillPercent = Math.Round(entryKillPercent, 0);

				return entryKillPercent;
			}
		}

		[JsonIgnore]
		public decimal RatioOpenKill
		{
			get
			{
				int openKillCount = OpeningKills.Count();
				int openKillWin = OpeningKills.Count(e => e.HasWin);
				int openKillLoss = OpeningKills.Count(e => e.HasWin == false);

				decimal openKillPercent = 0;
				if (openKillWin == 0) return openKillPercent;
				if (openKillLoss == 0) return 100;
				openKillPercent = (openKillWin / (decimal)openKillCount) * 100;
				openKillPercent = Math.Round(openKillPercent, 0);

				return openKillPercent;
			}
		}

		[JsonIgnore]
		public string RatioEntryKillAsString => RatioEntryKill + " %";

		[JsonIgnore]
		public string RatioOpenKillAsString => RatioOpenKill + " %";

		[JsonIgnore]
		public string HeadshotAsString => _headshotCount + " (" + HeadshotPercent + "%)";

		[JsonIgnore]
		public bool HasBomb
		{
			get { return _hasBomb; }
			set { Set(() => HasBomb, ref _hasBomb, value); }
		}

		[JsonIgnore]
		public double KillPerRound
		{
			get
			{
				if (RoundPlayedCount > 0) return Math.Round((double)KillsCount / RoundPlayedCount, 2);
				return 0;
			}
		}

		[JsonIgnore]
		public double AssistPerRound
		{
			get
			{
				if (RoundPlayedCount > 0) return Math.Round((double)AssistCount / RoundPlayedCount, 2);
				return 0;
			}
		}

		[JsonIgnore]
		public double DeathPerRound
		{
			get
			{
				if (RoundPlayedCount > 0) return Math.Round((double)DeathCount / RoundPlayedCount, 2);
				return 0;
			}
		}

		#endregion

		public override bool Equals(object obj)
		{
			var item = obj as PlayerExtended;

			return item != null && SteamId.Equals(item.SteamId);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public PlayerExtended()
		{
			EntryKills = new ObservableCollection<EntryKillEvent>();
			OpeningKills = new ObservableCollection<OpenKillEvent>();
			PlayersHurted = new ObservableCollection<PlayerHurtedEvent>();
			EntryKills.CollectionChanged += OnEntryKillsCollectionChanged;
			OpeningKills.CollectionChanged += OnOpeningKillsCollectionChanged;
			PlayersHurted.CollectionChanged += OnPlayersHurtedCollectionChanged;
		}

		private void OnPlayersHurtedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			RaisePropertyChanged(() => TotalDamageHealthCount);
			RaisePropertyChanged(() => TotalDamageArmorCount);
			RaisePropertyChanged(() => AverageDamageByRoundCount);
		}

		private void OnEntryKillsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			RaisePropertyChanged(() => EntryKills);
			RaisePropertyChanged(() => EntryKillWinCount);
			RaisePropertyChanged(() => EntryKillLossCount);
			RaisePropertyChanged(() => RatioEntryKillAsString);
		}

		private void OnOpeningKillsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			RaisePropertyChanged(() => EntryKills);
			RaisePropertyChanged(() => OpenKillWinCount);
			RaisePropertyChanged(() => OpenKillLossCount);
			RaisePropertyChanged(() => RatioOpenKillAsString);
		}

		public void ResetStats()
		{
			KillsCount = 0;
			DeathCount = 0;
			AssistCount = 0;
			HeadshotCount = 0;
			TeamKillCount = 0;
			RoundMvpCount = 0;
			OnekillCount = 0;
			TwokillCount = 0;
			ThreekillCount = 0;
			FourKillCount = 0;
			FiveKillCount = 0;
			Clutch1V1Count = 0;
			Clutch1V2Count = 0;
			Clutch1V3Count = 0;
			Clutch1V4Count = 0;
			Clutch1V5Count = 0;
			BombDefusedCount = 0;
			BombPlantedCount = 0;
			Score = 0;
			OpponentClutchCount = 0;
			HasEntryKill = false;
			HasOpeningKill = false;
			RatingHltv = 0;
			OpeningKills.Clear();
			EntryKills.Clear();
			PlayersHurted.Clear();
			RoundPlayedCount = 0;
		}

		public PlayerExtended Clone()
		{
			return (PlayerExtended)MemberwiseClone();
		}
	}
}