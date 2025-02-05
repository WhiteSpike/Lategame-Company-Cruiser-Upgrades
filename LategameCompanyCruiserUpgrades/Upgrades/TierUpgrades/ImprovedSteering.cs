using MoreShipUpgrades.Managers;
using MoreShipUpgrades.UI.TerminalNodes;
using MoreShipUpgrades.Misc.Upgrades;
using MoreShipUpgrades.Misc.Util;
using UnityEngine;
using LategameCompanyCruiserUpgrades.Misc;

namespace LategameCompanyCruiserUpgrades.Upgrades.TierUpgrades
{
    internal class ImprovedSteering : TierUpgrade
    {
        internal const string UPGRADE_NAME = "Improved Steering";
        internal const string PRICES_DEFAULT = "100,100,150,250";

        public override void Start()
        {
            upgradeName = UPGRADE_NAME;
            overridenUpgradeName = Plugin.Config.ImprovedSteeringConfiguration.OverrideName;
            base.Start();
        }
        public override void Load()
        {
            base.Load();
            UpdateCurrentVehicleTurningSpeed(ComputeAdditionalAcceleration(), add: true);
        }

        public override void Increment()
        {
            base.Increment();
            UpdateCurrentVehicleTurningSpeed(Plugin.Config.ImprovedSteeringConfiguration.IncrementalEffect, add: true);
        }

        public override void Unwind()
        {
            UpdateCurrentVehicleTurningSpeed(ComputeAdditionalAcceleration(), add: false);
            base.Unwind();
        }
        void UpdateCurrentVehicleTurningSpeed(float additionalTurningSpeed, bool add)
        {
            foreach (VehicleController vehicle in FindObjectsOfType<VehicleController>())
            {
                if (vehicle == null) continue;
                if (add)
                    vehicle.steeringWheelTurnSpeed += additionalTurningSpeed;
                else
                    vehicle.steeringWheelTurnSpeed -= additionalTurningSpeed;
            }
        }
        public static float ComputeAdditionalAcceleration()
        {
            return Plugin.Config.ImprovedSteeringConfiguration.InitialEffect + (GetUpgradeLevel(UPGRADE_NAME) * Plugin.Config.ImprovedSteeringConfiguration.IncrementalEffect);
        }
        public static float GetAdditionalTurningSpeed(float defaultValue)
        {
            if (!Plugin.Config.ImprovedSteeringConfiguration.Enabled) return defaultValue;
            if (!GetActiveUpgrade(UPGRADE_NAME)) return defaultValue;
            float additionalValue = ComputeAdditionalAcceleration();
            return Mathf.Clamp(defaultValue + additionalValue, defaultValue, float.MaxValue);
        }
        public override bool CanInitializeOnStart
        {
            get
            {
                string[] prices = Plugin.Config.ImprovedSteeringConfiguration.Prices.Value.Split(',');
                return prices.Length == 0 || (prices.Length == 1 && (prices[0].Length == 0 || prices[0] == "0"));
            }
        }
        public override string GetDisplayInfo(int initialPrice = -1, int maxLevels = -1, int[] incrementalPrices = null)
        {
            System.Func<int, float> infoFunction = level => Plugin.Config.ImprovedSteeringConfiguration.InitialEffect.Value + level * Plugin.Config.ImprovedSteeringConfiguration.IncrementalEffect.Value;
            const string infoFormat = "LVL {0} - ${1} - Company Cruiser vehicle's steering speed (turning speed) is increased by {2}.\n";
            return Tools.GenerateInfoForUpgrade(infoFormat, initialPrice, incrementalPrices, infoFunction);
        }
        public new static (string, string[]) RegisterScrapToUpgrade()
        {
            return (UPGRADE_NAME, Plugin.Config.ImprovedSteeringConfiguration.ItemProgressionItems.Value.Split(","));
        }
        public new static void RegisterUpgrade()
        {
            GameObject prefab = LethalLib.Modules.NetworkPrefabs.CreateNetworkPrefab(UPGRADE_NAME);
            prefab.AddComponent<ImprovedSteering>();
            LethalLib.Modules.NetworkPrefabs.RegisterNetworkPrefab(prefab);
            Plugin.networkPrefabs[UPGRADE_NAME] = prefab;
        }
        public new static CustomTerminalNode RegisterTerminalNode()
        {
            return UpgradeBus.Instance.SetupMultiplePurchaseableTerminalNode(UPGRADE_NAME, Plugin.Config.ImprovedSteeringConfiguration, Plugin.networkPrefabs[UPGRADE_NAME]);
        }
    }
}
