using MoreShipUpgrades.Managers;
using MoreShipUpgrades.UI.TerminalNodes;
using MoreShipUpgrades.Misc.Upgrades;
using MoreShipUpgrades.Misc.Util;
using System;
using UnityEngine;
using LategameCompanyCruiserUpgrades.Misc;

namespace LategameCompanyCruiserUpgrades.Upgrades.TierUpgrades
{
    internal class SuperchargedPistons : TierUpgrade
    {
        internal const string UPGRADE_NAME = "Supercharged Pistons";
        internal const string PRICES_DEFAULT = "250,200,350";

        public override void Start()
        {
            upgradeName = UPGRADE_NAME;
            overridenUpgradeName = Plugin.Config.SuperchargedPistonsConfiguration.OverrideName;
            base.Start();
        }
        public override void Load()
        {
            base.Load();
            UpdateCurrentVehicleEngineTorque(ComputeAdditionalEngineTorque(), add: true);
        }

        public override void Increment()
        {
            base.Increment();
            UpdateCurrentVehicleEngineTorque(Plugin.Config.SuperchargedPistonsConfiguration.IncrementalEffect, add: true);
        }

        public override void Unwind()
        {
            UpdateCurrentVehicleEngineTorque(ComputeAdditionalEngineTorque(), add: false);
            base.Unwind();
        }
        void UpdateCurrentVehicleEngineTorque(float additionalEngineTorque, bool add)
        {
            foreach (VehicleController vehicle in FindObjectsOfType<VehicleController>())
            {
                if (vehicle == null) continue;
                if (add)
                    vehicle.EngineTorque += additionalEngineTorque;
                else
                    vehicle.EngineTorque -= additionalEngineTorque;
            }
        }

        public static float ComputeAdditionalEngineTorque()
        {
            return Plugin.Config.SuperchargedPistonsConfiguration.InitialEffect + (GetUpgradeLevel(UPGRADE_NAME) * Plugin.Config.SuperchargedPistonsConfiguration.IncrementalEffect);
        }
        public static float GetAdditionalEngineTorque(float defaultValue)
        {
            if (!Plugin.Config.SuperchargedPistonsConfiguration.Enabled) return defaultValue;
            if (!GetActiveUpgrade(UPGRADE_NAME)) return defaultValue;
            float additionalValue = ComputeAdditionalEngineTorque();
            return Mathf.Clamp(defaultValue + additionalValue, defaultValue, float.MaxValue);
        }
        public override bool CanInitializeOnStart
        {
            get
            {
                string[] prices = Plugin.Config.SuperchargedPistonsConfiguration.Prices.Value.Split(',');
                return prices.Length == 0 || (prices.Length == 1 && (prices[0].Length == 0 || prices[0] == "0"));
            }
        }
        public override string GetDisplayInfo(int initialPrice = -1, int maxLevels = -1, int[] incrementalPrices = null)
        {
            Func<int, float> infoFunction = level => Plugin.Config.SuperchargedPistonsConfiguration.InitialEffect.Value + level * Plugin.Config.SuperchargedPistonsConfiguration.IncrementalEffect.Value;
            const string infoFormat = "LVL {0} - ${1} - Company Cruiser vehicle's maximum speed is increased by {2}.\n";
            return Tools.GenerateInfoForUpgrade(infoFormat, initialPrice, incrementalPrices, infoFunction);
        }
        public new static (string, string[]) RegisterScrapToUpgrade()
        {
            return (UPGRADE_NAME, Plugin.Config.SuperchargedPistonsConfiguration.ItemProgressionItems.Value.Split(","));
        }
        public new static void RegisterUpgrade()
        {
            GameObject prefab = LethalLib.Modules.NetworkPrefabs.CreateNetworkPrefab(UPGRADE_NAME);
            prefab.AddComponent<SuperchargedPistons>();
            LethalLib.Modules.NetworkPrefabs.RegisterNetworkPrefab(prefab);
            Plugin.networkPrefabs[UPGRADE_NAME] = prefab;
        }
        public new static CustomTerminalNode RegisterTerminalNode()
        {
            return UpgradeBus.Instance.SetupMultiplePurchaseableTerminalNode(UPGRADE_NAME, Plugin.Config.SuperchargedPistonsConfiguration, Plugin.networkPrefabs[UPGRADE_NAME]);
        }
    }
}
