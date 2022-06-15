﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleTech;
using BattleTech.Data;
using BattleTech.Framework;
using Harmony;
using HBS.Collections;

namespace SoldiersPiratesAssassinsMercs.Patches
{
    internal class DebugPatches
    {
        [HarmonyPatch(typeof(LanceOverride), "RequestLance", new Type[] { typeof(MetadataDatabase), typeof(int), typeof(DateTime?), typeof(TagSet), typeof(Contract)})]
        public static class LanceOverride_RequestLance_DEBUG
        {
            static bool Prepare() => true;
            public static void Prefix(LanceOverride __instance, MetadataDatabase mdd, DateTime? currentDate, TagSet companyTags, LanceDef ___loadedLanceDef)
            {
                ModInit.modLog?.Info?.Write(
                    $"[LanceOverride_RequestLance_DEBUG- PREFIX] lanceDefId: {__instance?.lanceDefId}. Shouldnt be null; selected lancedefID: {__instance?.selectedLanceDefId} ");
            }
            public static void Postfix(LanceOverride __instance, MetadataDatabase mdd, DateTime? currentDate, TagSet companyTags, LanceDef ___loadedLanceDef)
            {
                ModInit.modLog?.Info?.Write(
                    $"[LanceOverride_RequestLance_DEBUG -POSTFIX] lanceDefId: {__instance?.lanceDefId}. Shouldnt be null; selected lancedefID: {__instance?.selectedLanceDefId} loaded lanceDef: {___loadedLanceDef?.Description?.Id}");
            }
        }

        [HarmonyPatch(typeof(LanceOverride), "RunMadLibsOnLanceDef",
            new Type[] { typeof(Contract), typeof(LanceDef) })]
        public static class LanceOverride_RunMadLibsOnLanceDef
        {
            static bool Prepare() => true;

            public static void Postfix(LanceOverride __instance, Contract contract, LanceDef lanceDef)
            {
                ModInit.modLog?.Info?.Write($"[LanceOverride_RunMadLibsOnLanceDef] lancedef: {lanceDef.Description.Id}, lancedef units: {lanceDef.LanceUnits.Length}");
            }
        }

        [HarmonyPatch(typeof(LanceOverride), "RequestLanceComplete", new Type[]{typeof(MetadataDatabase), typeof(DateTime?), typeof(TagSet)})]
        public static class LanceOverride_RequestLanceComplete_DEBUG
        {
            static bool Prepare() => true;

            public static void Postfix(LanceOverride __instance, MetadataDatabase mdd, DateTime? currentDate, TagSet companyTags, LanceDef ___loadedLanceDef)
            {
                ModInit.modLog?.Info?.Write(
                    $"[LanceOverride_RequestLanceComplete_DEBUG] Processing lance: {__instance.lanceDefId}{__instance?.selectedLanceDefId}\n is LoadedLanceDef null? {___loadedLanceDef == null}\n unitSpawnPointOverrideCount? {__instance.unitSpawnPointOverrideList?.Count} \n is first unit in loadedlancedef null? {___loadedLanceDef?.LanceUnits?.First() == null}");
            }
        }

        [HarmonyPatch(typeof(UnitSpawnPointOverride), "GenerateUnit", new Type[] { typeof(MetadataDatabase), typeof(DataManager), typeof(int), typeof(string), typeof(string), typeof(int), typeof(DateTime?), typeof(TagSet) })]
        public static class UnitSpawnPointOverride_GenerateUnit_DEBUG
        {
            static bool Prepare() => true;

            public static void Postfix(UnitSpawnPointOverride __instance, MetadataDatabase mdd, DataManager dataManager, int contractDifficulty, string lanceName, string lanceDefId, int unitIndex, DateTime? currentDate, TagSet companyTags)
            {
                ModInit.modLog?.Info?.Write(
                    $"[UnitSpawnPointOverride_GenerateUnit_DEBUG] should not be UnitDefNone: IsUnitDefNone? {__instance.IsUnitDefNone}. Unitname: {string.Format("{0}-{1}", lanceName, unitIndex)} Proceeding to UnitSpawnPointOverride.RequestUnit");
            }
        }
        [HarmonyPatch(typeof(UnitSpawnPointOverride), "RequestUnit", new Type[] { typeof(LoadRequest), typeof(MetadataDatabase), typeof(string), typeof(string), typeof(string), typeof(int), typeof(DateTime?), typeof(TagSet) })]
        public static class UnitSpawnPointOverride_RequestUnit_DEBUG
        {
            static bool Prepare() => true;

            public static void Postfix(UnitSpawnPointOverride __instance, LoadRequest request, MetadataDatabase mdd, string lanceName, string lanceDefId, string unitName, int unitIndex, DateTime? currentDate, TagSet companyTags)
            {
                ModInit.modLog?.Info?.Write(
                    $"[UnitSpawnPointOverride_RequestUnit_DEBUG] should be IsUnitDefTagged: IsUnitDefTagged? {__instance.IsUnitDefTagged}.");
            }
        }

        [HarmonyPatch(typeof(TeamOverride), "GenerateTeam", new Type[] { typeof(MetadataDatabase), typeof(DataManager), typeof(int), typeof(DateTime?), typeof(TagSet) })]
        public static class TeamOverride_GenerateTeam_DEBUG
        {
            static bool Prepare() => true;

            public static void Postfix(TeamOverride __instance, MetadataDatabase mdd, DataManager dataManager, int contractDifficulty, DateTime? currentDate, TagSet companyTags)
            {
                ModInit.modLog?.Info?.Write(
                    $"[TeamOverride_GenerateTeam_DEBUG] lanceoverride count for {__instance?.faction}: {__instance.lanceOverrideList.Count}");
            }
        }
        
    }
}
