﻿using System.Threading.Tasks;
using CSGO_Demos_Manager.Models;
using CSGO_Demos_Manager.Services.Excel.Sheets.Single;
using NPOI.SS.UserModel;

namespace CSGO_Demos_Manager.Services.Excel
{
	public class SingleExport : AbstractExport
	{
		private readonly Demo _demo;

		private GeneralSheet _generalSheet;

		private PlayersSheet _playersSheet;

		private RoundsSheet _roundsSheet;

		private EntryHoldKillsRoundSheet _entryHoldKillsRoundSheet;

		private EntryHoldKillsPlayerSheet _entryHoldKillsPlayerSheet;

		private EntryHoldKillsTeamSheet _entryHoldKillsTeamSheet;

		private EntryKillsRoundSheet _entryKillsRoundSheet;

		private EntryKillsPlayerSheet _entryKillsPlayerSheet;

		private EntryKillsTeamSheet _entryKillsTeamSheet;

		public SingleExport(Demo demo)
		{
			_demo = demo;
		}

		public override async Task<IWorkbook> Generate()
		{
			CacheService cacheService = new CacheService();
			_demo.WeaponFired = await cacheService.GetDemoWeaponFiredAsync(_demo);
			_generalSheet = new GeneralSheet(Workbook, _demo);
			await _generalSheet.Generate();
			_playersSheet = new PlayersSheet(Workbook, _demo);
			await _playersSheet.Generate();
			_roundsSheet = new RoundsSheet(Workbook, _demo);
			await _roundsSheet.Generate();
			_entryHoldKillsRoundSheet = new EntryHoldKillsRoundSheet(Workbook, _demo);
			await _entryHoldKillsRoundSheet.Generate();
			_entryHoldKillsPlayerSheet = new EntryHoldKillsPlayerSheet(Workbook, _demo);
			await _entryHoldKillsPlayerSheet.Generate();
			_entryHoldKillsTeamSheet = new EntryHoldKillsTeamSheet(Workbook, _demo);
			await _entryHoldKillsTeamSheet.Generate();
			_entryKillsRoundSheet = new EntryKillsRoundSheet(Workbook, _demo);
			await _entryKillsRoundSheet.Generate();
			_entryKillsPlayerSheet = new EntryKillsPlayerSheet(Workbook, _demo);
			await _entryKillsPlayerSheet.Generate();
			_entryKillsTeamSheet = new EntryKillsTeamSheet(Workbook, _demo);
			await _entryKillsTeamSheet.Generate();

			return Workbook;
		}
	}
}
