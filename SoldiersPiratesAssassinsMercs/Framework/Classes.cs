﻿using System.Collections.Generic;
using BattleTech.Framework;

namespace SoldiersPiratesAssassinsMercs.Framework
{
    public class Classes
    {
        public class SPAMTeamOverride
        {
            public TeamOverride TeamOverride { get; set; }
            public string TeamOverrideFallback;

            public SPAMTeamOverride()
            {
                TeamOverride = null;
                TeamOverrideFallback = null;
            }
            public SPAMTeamOverride(TeamOverride teamOverride, string teamOverrideFallback)
            {
                TeamOverride = teamOverride;
                TeamOverrideFallback = teamOverrideFallback;
            }
        }
        public class ConfigOptions
        {
            public class OpforReplacementConfig
            {
                public float BaseReplaceChance = 0f;
                public Dictionary<string, float> FactionsReplaceOverrides = new Dictionary<string, float>(); //faction-specific values completely override base chance
                //public List<string> BlacklistContractTypes = new List<string>();
                //public List<string> BlacklistContractIDs = new List<string>();
                //public float MercFactionReputationFactor = 0f; // merc faction will lose rep as function of target team rep
            }
            public class MercLanceAdditionConfig // will take place of "additional lance" or MC support lances
            {
                public float BaseReplaceChance = 0f;
                public Dictionary<string, float> FactionsReplaceOverrides = new Dictionary<string, float>(); //faction-specific values completely override base chance
                //public List<string> BlacklistContractTypes = new List<string>();
                //public List<string> BlacklistContractIDs = new List<string>();
                public float MercFactionReputationFactor = 0f;
            }
            public class MercFactionConfig
            {
                //public string MercFactionName = ""; //e,g, KellHounds or RazorbackMercs
                public string MercFactionFallbackTag = "";
                public int AppearanceWeight = 0; //base "weight" for selection
                //public float AppearanceWeightRepFactor = 0f; //additional "weight" as factor of times previously faced (internal counter)
                public List<string> EmployerRestrictions= new List<string>();
                public bool RestrictionIsWhitelist = true;
                public float UnitRating = 1; //higher rating means less likely to take bribe to disengage or switch sides
                public List<string> PersonalityAttributes = new List<string>();
            }

            public class AlternateOpforConfig // these are alternate factions for specific factions which are NOT mercenaries.
                                              // part of setting, where dictionary key = faction name being replaced
            {
                public float FactionReplaceChance = 0f;
                public float FactionMCAdditionalLanceReplaceChance = 0f;
                public List<FactionWeightAndFallback> AlternateOpforWeights = new List<FactionWeightAndFallback>();
            }
        }

        public class FactionWeightAndFallback
        {
            public string FactionName = "";
            public int FactionWeight = 0;
            public string FactionFallback = "";
        } 
        public class MercDialogueBucket //is value for dictionary where key = PersonalityAttributes
        {
            public List<string> Dialogue = new List<string>();
            //public List<string> BribeCriticalSuccessDialogue = new List<string>();
            public List<string> BribeSuccessDialogue = new List<string>();
            public List<string> BribeFailureDialogue = new List<string>();
            public int MinTimesEncountered = 0;
            public int MaxTimesEncountered = 0;
            public float BribeAcceptanceMultiplier = 1f;
        }
    }
}
