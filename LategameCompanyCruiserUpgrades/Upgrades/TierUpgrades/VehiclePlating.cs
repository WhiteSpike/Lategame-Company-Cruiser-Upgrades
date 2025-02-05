using MoreShipUpgrades.Managers;
using MoreShipUpgrades.UI.TerminalNodes;
using MoreShipUpgrades.Misc.Upgrades;
using MoreShipUpgrades.Misc.Util;
using UnityEngine;
using LategameCompanyCruiserUpgrades.Misc;

namespace LategameCompanyCruiserUpgrades.Upgrades.TierUpgrades
{
    internal class VehiclePlating : TierUpgrade
    {
        internal const string UPGRADE_NAME = "Vehicle Plating";
        internal const string PRICES_DEFAULT = "150,300,400,500,600";

        public override void Start()
        {
            upgradeName = UPGRADE_NAME;
            overridenUpgradeName = Plugin.Config.VehiclePlatingConfiguration.OverrideName;
            base.Start();
        }
        public override void Load()
        {
            base.Load();
            UpdateCurrentVehicleHealth(ComputeAdditionalMaximumHealth(), add: true);
        }

        public override void Increment()
        {
            base.Increment();
            UpdateCurrentVehicleHealth(Plugin.Config.VehiclePlatingConfiguration.IncrementalEffect, add: true);
        }

        public override void Unwind()
        {
            UpdateCurrentVehicleHealth(ComputeAdditionalMaximumHealth(), add: false);
            base.Unwind();
        }
        public static int GetAdditionalMaximumHealth(int defaultValue)
        {
            if (!Plugin.Config.VehiclePlatingConfiguration.Enabled) return defaultValue;
            if (!GetActiveUpgrade(UPGRADE_NAME)) return defaultValue;
            int additionalValue = ComputeAdditionalMaximumHealth();
            return Mathf.Clamp(defaultValue + additionalValue, defaultValue, int.MaxValue);
        }

        void UpdateCurrentVehicleHealth(int additionalHealth, bool add)
        {
            foreach (VehicleController vehicle in FindObjectsOfType<VehicleController>())
            {
                if (vehicle == null) continue;
                if (add)
                    vehicle.carHP += additionalHealth;
                else
                    vehicle.carHP -= additionalHealth;
            }
        }

        public static int ComputeAdditionalMaximumHealth()
        {
            return Plugin.Config.VehiclePlatingConfiguration.InitialEffect + (GetUpgradeLevel(UPGRADE_NAME) * Plugin.Config.VehiclePlatingConfiguration.IncrementalEffect);
        }
        public override bool CanInitializeOnStart
        {
            get
            {
                string[] prices = Plugin.Config.VehiclePlatingConfiguration.Prices.Value.Split(',');
                return prices.Length == 0 || (prices.Length == 1 && (prices[0].Length == 0 || prices[0] == "0"));
            }
        }
        public override string GetDisplayInfo(int initialPrice = -1, int maxLevels = -1, int[] incrementalPrices = null)
        {
            System.Func<int, float> infoFunction = level => Plugin.Config.VehiclePlatingConfiguration.InitialEffect.Value + level * Plugin.Config.VehiclePlatingConfiguration.IncrementalEffect.Value;
            const string infoFormat = "LVL {0} - ${1} - Company Cruiser vehicle's maximum health is increased by {2}.\n";
            return Tools.GenerateInfoForUpgrade(infoFormat, initialPrice, incrementalPrices, infoFunction);
        }
        public new static (string, string[]) RegisterScrapToUpgrade()
        {
            return (UPGRADE_NAME, Plugin.Config.VehiclePlatingConfiguration.ItemProgressionItems.Value.Split(","));
        }
        public new static void RegisterUpgrade()
        {
            GameObject prefab = LethalLib.Modules.NetworkPrefabs.CreateNetworkPrefab(UPGRADE_NAME);
            prefab.AddComponent<VehiclePlating>();
            LethalLib.Modules.NetworkPrefabs.RegisterNetworkPrefab(prefab);
            Plugin.networkPrefabs[UPGRADE_NAME] = prefab;
        }
        public new static CustomTerminalNode RegisterTerminalNode()
        {
            return UpgradeBus.Instance.SetupMultiplePurchaseableTerminalNode(UPGRADE_NAME, Plugin.Config.VehiclePlatingConfiguration, Plugin.networkPrefabs[UPGRADE_NAME]);
        }
    }
}
