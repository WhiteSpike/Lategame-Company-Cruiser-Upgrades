using BepInEx.Configuration;
using CSync.Extensions;
using CSync.Lib;
using LategameCompanyCruiserUpgrades.Upgrades.TierUpgrades;
using LategameCompanyCruiserUpgrades.Util;
using MoreShipUpgrades.Configuration.Abstractions.TIerUpgrades;
using MoreShipUpgrades.Configuration.Interfaces.TierUpgrades;
using MoreShipUpgrades.Managers;
using MoreShipUpgrades.Misc.Upgrades;
using MoreShipUpgrades.Misc.Util;
using System;
using System.Runtime.Serialization;

namespace LategameCompanyCruiserUpgrades.Misc
{
    [DataContract]
    public class PluginConfig : SyncedConfig2<PluginConfig>
    {
        public ITierEffectUpgradeConfiguration<int> BrakeFluidConfiguration { get; set; }
        public ITierEffectUpgradeConfiguration<int> TurboTankConfiguration {  get; set; }
        public ITierEffectUpgradeConfiguration<int> IgnitionCoilConfiguration {  get; set; }
        public ITierEffectUpgradeConfiguration<int> FluffySeatsConfiguration {  get; set; }
        public ITierEffectUpgradeConfiguration<float> ImprovedSteeringConfiguration { get; set; }
        public ITierEffectUpgradeConfiguration<float> SuperchargedPistonsConfiguration { get; set; }
        public ITierEffectUpgradeConfiguration<float> RapidMotorsConfiguration {  get; set; }
        public ITierEffectUpgradeConfiguration<int> VehiclePlatingConfiguration {  get; set; }

        #region Configuration Constructor
        public PluginConfig(ConfigFile cfg) : base(Metadata.GUID)
        {
            string topSection = BrakeFluid.UPGRADE_NAME;
            BrakeFluidConfiguration = new TierPrimitiveUpgradeConfiguration<int>(cfg, topSection, Constants.BRAKE_FLUID_ENABLED_DESCRIPTION, BrakeFluid.PRICES_DEFAULT)
            {
                InitialEffect = cfg.BindSyncedEntry(topSection, Constants.BRAKE_FLUID_CAPACITY_INITIAL_INCREASE_KEY, Constants.BRAKE_FLUID_CAPACITY_INITIAL_INCREASE_DEFAULT, Constants.BRAKE_FLUID_CAPACITY_INITIAL_INCREASE_DESCRIPTION),
                IncrementalEffect = cfg.BindSyncedEntry(topSection, Constants.BRAKE_FLUID_CAPACITY_INCREMENTAL_INCREASE_KEY, Constants.BRAKE_FLUID_CAPACITY_INCREMENTAL_INCREASE_DEFAULT, Constants.BRAKE_FLUID_CAPACITY_INCREMENTAL_INCREASE_DESCRIPTION)
            };

            topSection = TurboTank.UPGRADE_NAME;
            TurboTankConfiguration = new TierPrimitiveUpgradeConfiguration<int>(cfg, topSection, Constants.TURBO_TANK_ENABLED_DESCRIPTION, TurboTank.PRICES_DEFAULT)
            {
                InitialEffect = cfg.BindSyncedEntry(topSection, Constants.TURBO_TANK_CAPACITY_INITIAL_INCREASE_KEY, Constants.TURBO_TANK_CAPACITY_INITIAL_INCREASE_DEFAULT, Constants.TURBO_TANK_CAPACITY_INITIAL_INCREASE_DESCRIPTION),
                IncrementalEffect = cfg.BindSyncedEntry(topSection, Constants.TURBO_TANK_CAPACITY_INCREMENTAL_INCREASE_KEY, Constants.TURBO_TANK_CAPACITY_INCREMENTAL_INCREASE_DEFAULT, Constants.TURBO_TANK_CAPACITY_INCREMENTAL_INCREASE_DESCRIPTION)
            };

            topSection = IgnitionCoil.UPGRADE_NAME;
            IgnitionCoilConfiguration = new TierPrimitiveUpgradeConfiguration<int>(cfg, topSection, Constants.IGNITION_COIL_ENABLED_DESCRIPTION, IgnitionCoil.PRICES_DEFAULT)
            {
                InitialEffect = cfg.BindSyncedEntry(topSection, Constants.IGNITION_COIL_IGNITION_INITIAL_CHANCE_INCREASE_KEY, Constants.IGNITION_COIL_IGNITION_INITIAL_CHANCE_INCREASE_DEFAULT, Constants.IGNITION_COIL_IGNITION_INITIAL_CHANCE_INCREASE_DESCRIPTION),
                IncrementalEffect = cfg.BindSyncedEntry(topSection, Constants.IGNITION_COIL_IGNITION_INCREMENTAL_CHANCE_INCREASE_KEY, Constants.IGNITION_COIL_IGNITION_INCREMENTAL_CHANCE_INCREASE_DEFAULT, Constants.IGNITION_COIL_IGNITION_INCREMENTAL_CHANCE_INCREASE_DESCRIPTION),
            };

            topSection = FluffySeats.UPGRADE_NAME;
            FluffySeatsConfiguration = new TierPrimitiveUpgradeConfiguration<int>(cfg, topSection, Constants.FLUFFY_SEATS_ENABLED_DESCRIPTION, FluffySeats.PRICES_DEFAULT)
            {
                InitialEffect = cfg.BindSyncedEntry(topSection, Constants.FLUFFY_SEATS_DAMAGE_MITIGATION_INITIAL_INCREASE_KEY, Constants.FLUFFY_SEATS_DAMAGE_MITIGATION_INITIAL_INCREASE_DEFAULT, Constants.FLUFFY_SEATS_DAMAGE_MITIGATION_INITIAL_INCREASE_DESCRIPTION),
                IncrementalEffect = cfg.BindSyncedEntry(topSection, Constants.FLUFFY_SEATS_DAMAGE_MITIGATION_INCREMENTAL_INCREASE_KEY, Constants.FLUFFY_SEATS_DAMAGE_MITIGATION_INCREMENTAL_INCREASE_DEFAULT, Constants.FLUFFY_SEATS_DAMAGE_MITIGATION_INCREMENTAL_INCREASE_DESCRIPTION),
            };

            topSection = ImprovedSteering.UPGRADE_NAME;
            ImprovedSteeringConfiguration = new TierPrimitiveUpgradeConfiguration<float>(cfg, topSection, Constants.IMPROVED_STEERING_ENABLED_DESCRIPTION, ImprovedSteering.PRICES_DEFAULT)
            {
                InitialEffect = cfg.BindSyncedEntry(topSection, Constants.IMPROVED_STEERING_TURNING_SPEED_INITIAL_INCREASE_KEY, Constants.IMPROVED_STEERING_TURNING_SPEED_INITIAL_INCREASE_DEFAULT, Constants.IMPROVED_STEERING_TURNING_SPEED_INITIAL_INCREASE_DESCRIPTION),
                IncrementalEffect = cfg.BindSyncedEntry(topSection, Constants.IMPROVED_STEERING_TURNING_SPEED_INCREMENTAL_INCREASE_KEY, Constants.IMPROVED_STEERING_TURNING_SPEED_INCREMENTAL_INCREASE_DEFAULT, Constants.IMPROVED_STEERING_TURNING_SPEED_INCREMENTAL_INCREASE_DESCRIPTION)
            };

            topSection = SuperchargedPistons.UPGRADE_NAME;
            SuperchargedPistonsConfiguration = new TierPrimitiveUpgradeConfiguration<float>(cfg, topSection, Constants.SUPERCHARGED_PISTONS_ENABLED_DESCRIPTION, SuperchargedPistons.PRICES_DEFAULT)
            {
                InitialEffect = cfg.BindSyncedEntry(topSection, Constants.SUPERCHARGED_PISTONS_ENGINE_TORQUE_INITIAL_INCREASE_KEY, Constants.SUPERCHARGED_PISTONS_ENGINE_TORQUE_INITIAL_INCREASE_DEFAULT, Constants.SUPERCHARGED_PISTONS_ENGINE_TORQUE_INITIAL_INCREASE_DESCRIPTION),
                IncrementalEffect = cfg.BindSyncedEntry(topSection, Constants.SUPERCHARGED_PISTONS_ENGINE_TORQUE_INCREMENTAL_INCREASE_KEY, Constants.SUPERCHARGED_PISTONS_ENGINE_TORQUE_INCREMENTAL_INCREASE_DEFAULT, Constants.SUPERCHARGED_PISTONS_ENGINE_TORQUE_INCREMENTAL_INCREASE_DESCRIPTION),
            };

            topSection = RapidMotors.UPGRADE_NAME;
            RapidMotorsConfiguration = new TierPrimitiveUpgradeConfiguration<float>(cfg, topSection, Constants.RAPID_MOTORS_ENABLED_DESCRIPTION, RapidMotors.PRICES_DEFAULT)
            {
                InitialEffect = cfg.BindSyncedEntry(topSection, Constants.RAPID_MOTORS_ACCELERATION_INITIAL_INCREASE_KEY, Constants.RAPID_MOTORS_ACCELERATION_INITIAL_INCREASE_DEFAULT, Constants.RAPID_MOTORS_ACCELERATION_INITIAL_INCREASE_DESCRIPTION),
                IncrementalEffect = cfg.BindSyncedEntry(topSection, Constants.RAPID_MOTORS_ACCELERATION_INCREMENTAL_INCREASE_KEY, Constants.RAPID_MOTORS_ACCELERATION_INCREMENTAL_INCREASE_DEFAULT, Constants.RAPID_MOTORS_ACCELERATION_INCREMENTAL_INCREASE_DESCRIPTION),
            };

            topSection = VehiclePlating.UPGRADE_NAME;
            VehiclePlatingConfiguration = new TierPrimitiveUpgradeConfiguration<int>(cfg, topSection, Constants.VEHICLE_PLATING_ENABLED_DESCRIPTION, VehiclePlating.PRICES_DEFAULT)
            {
                InitialEffect = cfg.BindSyncedEntry(topSection, Constants.VEHICLE_PLATING_HEALTH_INITIAL_INCREASE_KEY, Constants.VEHICLE_PLATING_HEALTH_INITIAL_INCREASE_DEFAULT, Constants.VEHICLE_PLATING_HEALTH_INITIAL_INCREASE_DESCRIPTION),
                IncrementalEffect = cfg.BindSyncedEntry(topSection, Constants.VEHICLE_PLATING_HEALTH_INCREMENTAL_INCREASE_KEY, Constants.VEHICLE_PLATING_HEALTH_INCREMENTAL_INCREASE_DEFAULT, Constants.VEHICLE_PLATING_HEALTH_INCREMENTAL_INCREASE_DESCRIPTION),
            };

            InitialSyncCompleted += PluginConfig_InitialSyncCompleted;
            ConfigManager.Register(this);
        }
        private void PluginConfig_InitialSyncCompleted(object sender, EventArgs e)
        {
            UpgradeBus.Instance.Reconstruct();
        }
        #endregion
    }
}
