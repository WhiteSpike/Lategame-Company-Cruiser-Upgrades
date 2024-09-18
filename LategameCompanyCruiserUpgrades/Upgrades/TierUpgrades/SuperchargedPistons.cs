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
        internal const string PRICES_DEFAULT = "200,350";

        public override void Start()
        {
            upgradeName = UPGRADE_NAME;
            overridenUpgradeName = Plugin.Config.SUPERCHARGED_PISTONS_OVERRIDE_NAME;
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
            UpdateCurrentVehicleEngineTorque(Plugin.Config.SUPERCHARGED_PISTONS_ENGINE_TORQUE_INCREMENTAL_INCREASE, add: true);
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
            return Plugin.Config.SUPERCHARGED_PISTONS_ENGINE_TORQUE_INITIAL_INCREASE + (GetUpgradeLevel(UPGRADE_NAME) * Plugin.Config.SUPERCHARGED_PISTONS_ENGINE_TORQUE_INCREMENTAL_INCREASE);
        }
        public static float GetAdditionalEngineTorque(float defaultValue)
        {
            if (!Plugin.Config.SUPERCHARGED_PISTONS_ENABLED) return defaultValue;
            if (!GetActiveUpgrade(UPGRADE_NAME)) return defaultValue;
            float additionalValue = ComputeAdditionalEngineTorque();
            return Mathf.Clamp(defaultValue + additionalValue, defaultValue, float.MaxValue);
        }
        public override bool CanInitializeOnStart
        {
            get
            {
                string[] prices = Plugin.Config.SUPERCHARGED_PISTONS_PRICES.Value.Split(',');
                return Plugin.Config.SUPERCHARGED_PISTONS_PRICE.Value <= 0 && prices.Length == 1 && (prices[0] == "" || prices[0] == "0");
            }
        }
        public override string GetDisplayInfo(int initialPrice = -1, int maxLevels = -1, int[] incrementalPrices = null)
        {
            Func<int, float> infoFunction = level => Plugin.Config.SUPERCHARGED_PISTONS_ENGINE_TORQUE_INITIAL_INCREASE.Value + level * Plugin.Config.SUPERCHARGED_PISTONS_ENGINE_TORQUE_INCREMENTAL_INCREASE.Value;
            const string infoFormat = "LVL {0} - ${1} - Company Cruiser vehicle's maximum speed is increased by {2}.\n";
            return Tools.GenerateInfoForUpgrade(infoFormat, initialPrice, incrementalPrices, infoFunction);
        }
        public new static (string, string[]) RegisterScrapToUpgrade()
        {
            return (UPGRADE_NAME, Plugin.Config.SUPERCHARGED_PISTONS_ITEM_PROGRESSION_ITEMS.Value.Split(","));
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
            PluginConfig configuration = Plugin.Config;

            return UpgradeBus.Instance.SetupMultiplePurchasableTerminalNode(UPGRADE_NAME,
                                                shareStatus: true,
                                                configuration.SUPERCHARGED_PISTONS_ENABLED.Value,
                                                configuration.SUPERCHARGED_PISTONS_PRICE.Value,
                                                UpgradeBus.ParseUpgradePrices(configuration.SUPERCHARGED_PISTONS_PRICES.Value),
                                                UpgradeBus.Instance.PluginConfiguration.OVERRIDE_UPGRADE_NAMES ? configuration.SUPERCHARGED_PISTONS_OVERRIDE_NAME : "",
                                                Plugin.networkPrefabs[UPGRADE_NAME]);
        }
    }
}
