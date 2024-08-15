using BepInEx.Configuration;
using CSync.Extensions;
using CSync.Lib;
using LategameCompanyCruiserUpgrades.Upgrades.TierUpgrades;
using LategameCompanyCruiserUpgrades.Util;
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
        [field: SyncedEntryField] public SyncedEntry<bool> BRAKE_FLUID_ENABLED {  get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> BRAKE_FLUID_PRICE {  get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> BRAKE_FLUID_PRICES {  get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> BRAKE_FLUID_OVERRIDE_NAME {  get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> BRAKE_FLUID_POWER_INITIAL_INCREASE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> BRAKE_FLUID_POWER_INCREMENTAL_INCREASE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> BRAKE_FLUID_ITEM_PROGRESSION_ITEMS {  get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> TURBO_TANK_ENABLED { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> TURBO_TANK_PRICE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> TURBO_TANK_PRICES { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> TURBO_TANK_OVERRIDE_NAME { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> TURBO_TANK_CAPACITY_INITIAL_INCREASE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> TURBO_TANK_CAPACITY_INCREMENTAL_INCREASE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> TURBO_TANK_ITEM_PROGRESSION_ITEMS { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> IGNITION_COIL_ENABLED { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> IGNITION_COIL_PRICES { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> IGNITION_COIL_OVERRIDE_NAME { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> IGNITION_COIL_IGNITION_INITIAL_CHANCE_INCREASE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> IGNITION_COIL_IGNITION_INCREMENTAL_CHANCE_INCREASE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> IGNITION_COIL_PRICE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> IGNITION_COIL_ITEM_PROGRESSION_ITEMS { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> FLUFFY_SEATS_ENABLED { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> FLUFFY_SEATS_PRICE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> FLUFFY_SEATS_PRICES { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> FLUFFY_SEATS_OVERRIDE_NAME { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> FLUFFY_SEATS_DAMAGE_MITIGATION_INITIAL_INCREASE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> FLUFFY_SEATS_DAMAGE_MITIGATION_INCREMENTAL_INCREASE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> FLUFFY_SEATS_ITEM_PROGRESSION_ITEMS { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> IMPROVED_STEERING_ENABLED { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> IMPROVED_STEERING_PRICE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> IMPROVED_STEERING_PRICES { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> IMPROVED_STEERING_OVERRIDE_NAME { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> IMPROVED_STEERING_TURNING_SPEED_INITIAL_INCREASE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> IMPROVED_STEERING_TURNING_SPEED_INCREMENTAL_INCREASE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> IMPROVED_STEERING_ITEM_PROGRESSION_ITEMS { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> SUPERCHARGED_PISTONS_ENABLED { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> SUPERCHARGED_PISTONS_PRICE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> SUPERCHARGED_PISTONS_PRICES { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> SUPERCHARGED_PISTONS_OVERRIDE_NAME { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> SUPERCHARGED_PISTONS_ENGINE_TORQUE_INITIAL_INCREASE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> SUPERCHARGED_PISTONS_ENGINE_TORQUE_INCREMENTAL_INCREASE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> SUPERCHARGED_PISTONS_ITEM_PROGRESSION_ITEMS { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> RAPID_MOTORS_ENABLED { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> RAPID_MOTORS_PRICE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> RAPID_MOTORS_PRICES { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> RAPID_MOTORS_OVERRIDE_NAME { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> RAPID_MOTORS_ACCELERATION_INITIAL_INCREASE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> RAPID_MOTORS_ACCELERATION_INCREMENTAL_INCREASE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> RAPID_MOTORS_ITEM_PROGRESSION_ITEMS { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> VEHICLE_PLATING_ENABLED { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> VEHICLE_PLATING_PRICE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> VEHICLE_PLATING_PRICES { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> VEHICLE_PLATING_OVERRIDE_NAME { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> VEHICLE_PLATING_HEALTH_INITIAL_INCREASE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> VEHICLE_PLATING_HEALTH_INCREMENTAL_INCREASE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<string> VEHICLE_PLATING_ITEM_PROGRESSION_ITEMS { get; set; }

        #region Configuration Constructor
        public PluginConfig(ConfigFile cfg) : base(Metadata.GUID)
        {
            #region Brake Fluid

            string topSection = BrakeFluid.UPGRADE_NAME;
            BRAKE_FLUID_ENABLED = cfg.BindSyncedEntry(topSection, Constants.BRAKE_FLUID_ENABLED_KEY, Constants.BRAKE_FLUID_ENABLED_DEFAULT, Constants.BRAKE_FLUID_ENABLED_DESCRIPTION);
            BRAKE_FLUID_PRICE = cfg.BindSyncedEntry(topSection, Constants.BRAKE_FLUID_PRICE_KEY, Constants.BRAKE_FLUID_PRICE_DEFAULT);
            BRAKE_FLUID_PRICES = cfg.BindSyncedEntry(topSection, BaseUpgrade.PRICES_SECTION, BrakeFluid.PRICES_DEFAULT, BaseUpgrade.PRICES_DESCRIPTION);
            BRAKE_FLUID_POWER_INITIAL_INCREASE = cfg.BindSyncedEntry(topSection, Constants.BRAKE_FLUID_CAPACITY_INITIAL_INCREASE_KEY, Constants.BRAKE_FLUID_CAPACITY_INITIAL_INCREASE_DEFAULT, Constants.BRAKE_FLUID_CAPACITY_INITIAL_INCREASE_DESCRIPTION);
            BRAKE_FLUID_POWER_INCREMENTAL_INCREASE = cfg.BindSyncedEntry(topSection, Constants.BRAKE_FLUID_CAPACITY_INCREMENTAL_INCREASE_KEY, Constants.BRAKE_FLUID_CAPACITY_INCREMENTAL_INCREASE_DEFAULT, Constants.BRAKE_FLUID_CAPACITY_INCREMENTAL_INCREASE_DESCRIPTION);
            BRAKE_FLUID_ITEM_PROGRESSION_ITEMS = cfg.BindSyncedEntry(topSection, LguConstants.ITEM_PROGRESSION_ITEMS_KEY, LguConstants.ITEM_PROGRESSION_ITEMS_DEFAULT, LguConstants.ITEM_PROGRESSION_ITEMS_DESCRIPTION);

            #endregion

            #region Turbo Tank

            topSection = TurboTank.UPGRADE_NAME;
            TURBO_TANK_ENABLED = cfg.BindSyncedEntry(topSection, Constants.TURBO_TANK_ENABLED_KEY, Constants.TURBO_TANK_ENABLED_DEFAULT, Constants.TURBO_TANK_ENABLED_DESCRIPTION);
            TURBO_TANK_PRICE = cfg.BindSyncedEntry(topSection, Constants.TURBO_TANK_PRICE_KEY, Constants.TURBO_TANK_PRICE_DEFAULT);
            TURBO_TANK_PRICES = cfg.BindSyncedEntry(topSection, BaseUpgrade.PRICES_SECTION, TurboTank.PRICES_DEFAULT, BaseUpgrade.PRICES_DESCRIPTION);
            TURBO_TANK_CAPACITY_INITIAL_INCREASE = cfg.BindSyncedEntry(topSection, Constants.TURBO_TANK_CAPACITY_INITIAL_INCREASE_KEY, Constants.TURBO_TANK_CAPACITY_INITIAL_INCREASE_DEFAULT, Constants.TURBO_TANK_CAPACITY_INITIAL_INCREASE_DESCRIPTION);
            TURBO_TANK_CAPACITY_INCREMENTAL_INCREASE = cfg.BindSyncedEntry(topSection, Constants.TURBO_TANK_CAPACITY_INCREMENTAL_INCREASE_KEY, Constants.TURBO_TANK_CAPACITY_INCREMENTAL_INCREASE_DEFAULT, Constants.TURBO_TANK_CAPACITY_INCREMENTAL_INCREASE_DESCRIPTION);
            TURBO_TANK_ITEM_PROGRESSION_ITEMS = cfg.BindSyncedEntry(topSection, LguConstants.ITEM_PROGRESSION_ITEMS_KEY, LguConstants.ITEM_PROGRESSION_ITEMS_DEFAULT, LguConstants.ITEM_PROGRESSION_ITEMS_DESCRIPTION);

            #endregion

            #region Ignition Coil

            topSection = IgnitionCoil.UPGRADE_NAME;
            IGNITION_COIL_ENABLED = cfg.BindSyncedEntry(topSection, Constants.IGNITION_COIL_ENABLED_KEY, Constants.IGNITION_COIL_ENABLED_DEFAULT, Constants.IGNITION_COIL_ENABLED_DESCRIPTION);
            IGNITION_COIL_PRICE = cfg.BindSyncedEntry(topSection, Constants.IGNITION_COIL_PRICE_KEY, Constants.IGNITION_COIL_PRICE_DEFAULT);
            IGNITION_COIL_PRICES = cfg.BindSyncedEntry(topSection, BaseUpgrade.PRICES_SECTION, IgnitionCoil.PRICES_DEFAULT, BaseUpgrade.PRICES_DESCRIPTION);
            IGNITION_COIL_IGNITION_INITIAL_CHANCE_INCREASE = cfg.BindSyncedEntry(topSection, Constants.IGNITION_COIL_IGNITION_INITIAL_CHANCE_INCREASE_KEY, Constants.IGNITION_COIL_IGNITION_INITIAL_CHANCE_INCREASE_DEFAULT, Constants.IGNITION_COIL_IGNITION_INITIAL_CHANCE_INCREASE_DESCRIPTION);
            IGNITION_COIL_IGNITION_INCREMENTAL_CHANCE_INCREASE = cfg.BindSyncedEntry(topSection, Constants.IGNITION_COIL_IGNITION_INCREMENTAL_CHANCE_INCREASE_KEY, Constants.IGNITION_COIL_IGNITION_INCREMENTAL_CHANCE_INCREASE_DEFAULT, Constants.IGNITION_COIL_IGNITION_INCREMENTAL_CHANCE_INCREASE_DESCRIPTION);
            IGNITION_COIL_ITEM_PROGRESSION_ITEMS = cfg.BindSyncedEntry(topSection, LguConstants.ITEM_PROGRESSION_ITEMS_KEY, LguConstants.ITEM_PROGRESSION_ITEMS_DEFAULT, LguConstants.ITEM_PROGRESSION_ITEMS_DESCRIPTION);

            #endregion

            #region Fluffy Seats

            topSection = FluffySeats.UPGRADE_NAME;
            FLUFFY_SEATS_ENABLED = cfg.BindSyncedEntry(topSection, Constants.FLUFFY_SEATS_ENABLED_KEY, Constants.FLUFFY_SEATS_ENABLED_DEFAULT, Constants.FLUFFY_SEATS_ENABLED_DESCRIPTION);
            FLUFFY_SEATS_PRICE = cfg.BindSyncedEntry(topSection, Constants.FLUFFY_SEATS_PRICE_KEY, Constants.FLUFFY_SEATS_PRICE_DEFAULT);
            FLUFFY_SEATS_PRICES = cfg.BindSyncedEntry(topSection, BaseUpgrade.PRICES_SECTION, FluffySeats.PRICES_DEFAULT, BaseUpgrade.PRICES_DESCRIPTION);
            FLUFFY_SEATS_DAMAGE_MITIGATION_INITIAL_INCREASE = cfg.BindSyncedEntry(topSection, Constants.FLUFFY_SEATS_DAMAGE_MITIGATION_INITIAL_INCREASE_KEY, Constants.FLUFFY_SEATS_DAMAGE_MITIGATION_INITIAL_INCREASE_DEFAULT, Constants.FLUFFY_SEATS_DAMAGE_MITIGATION_INITIAL_INCREASE_DESCRIPTION);
            FLUFFY_SEATS_DAMAGE_MITIGATION_INCREMENTAL_INCREASE = cfg.BindSyncedEntry(topSection, Constants.FLUFFY_SEATS_DAMAGE_MITIGATION_INCREMENTAL_INCREASE_KEY, Constants.FLUFFY_SEATS_DAMAGE_MITIGATION_INCREMENTAL_INCREASE_DEFAULT, Constants.FLUFFY_SEATS_DAMAGE_MITIGATION_INCREMENTAL_INCREASE_DESCRIPTION);
            FLUFFY_SEATS_ITEM_PROGRESSION_ITEMS = cfg.BindSyncedEntry(topSection, LguConstants.ITEM_PROGRESSION_ITEMS_KEY, LguConstants.ITEM_PROGRESSION_ITEMS_DEFAULT, LguConstants.ITEM_PROGRESSION_ITEMS_DESCRIPTION);

            #endregion

            #region Improved Steering

            topSection = ImprovedSteering.UPGRADE_NAME;
            IMPROVED_STEERING_ENABLED = cfg.BindSyncedEntry(topSection, Constants.IMPROVED_STEERING_ENABLED_KEY, Constants.IMPROVED_STEERING_ENABLED_DEFAULT, Constants.IMPROVED_STEERING_ENABLED_DESCRIPTION);
            IMPROVED_STEERING_PRICE = cfg.BindSyncedEntry(topSection, Constants.IMPROVED_STEERING_PRICE_KEY, Constants.IMPROVED_STEERING_PRICE_DEFAULT);
            IMPROVED_STEERING_PRICES = cfg.BindSyncedEntry(topSection, BaseUpgrade.PRICES_SECTION, ImprovedSteering.PRICES_DEFAULT, BaseUpgrade.PRICES_DESCRIPTION);
            IMPROVED_STEERING_TURNING_SPEED_INITIAL_INCREASE = cfg.BindSyncedEntry(topSection, Constants.IMPROVED_STEERING_TURNING_SPEED_INITIAL_INCREASE_KEY, Constants.IMPROVED_STEERING_TURNING_SPEED_INITIAL_INCREASE_DEFAULT, Constants.IMPROVED_STEERING_TURNING_SPEED_INITIAL_INCREASE_DESCRIPTION);
            IMPROVED_STEERING_TURNING_SPEED_INCREMENTAL_INCREASE = cfg.BindSyncedEntry(topSection, Constants.IMPROVED_STEERING_TURNING_SPEED_INCREMENTAL_INCREASE_KEY, Constants.IMPROVED_STEERING_TURNING_SPEED_INCREMENTAL_INCREASE_DEFAULT, Constants.IMPROVED_STEERING_TURNING_SPEED_INCREMENTAL_INCREASE_DESCRIPTION);
            IMPROVED_STEERING_ITEM_PROGRESSION_ITEMS = cfg.BindSyncedEntry(topSection, LguConstants.ITEM_PROGRESSION_ITEMS_KEY, LguConstants.ITEM_PROGRESSION_ITEMS_DEFAULT, LguConstants.ITEM_PROGRESSION_ITEMS_DESCRIPTION);

            #endregion

            #region Supercharged Pistons

            topSection = SuperchargedPistons.UPGRADE_NAME;
            SUPERCHARGED_PISTONS_ENABLED = cfg.BindSyncedEntry(topSection, Constants.SUPERCHARGED_PISTONS_ENABLED_KEY, Constants.SUPERCHARGED_PISTONS_ENABLED_DEFAULT, Constants.SUPERCHARGED_PISTONS_ENABLED_DESCRIPTION);
            SUPERCHARGED_PISTONS_PRICE = cfg.BindSyncedEntry(topSection, Constants.SUPERCHARGED_PISTONS_PRICE_KEY, Constants.SUPERCHARGED_PISTONS_PRICE_DEFAULT);
            SUPERCHARGED_PISTONS_PRICES = cfg.BindSyncedEntry(topSection, BaseUpgrade.PRICES_SECTION, SuperchargedPistons.PRICES_DEFAULT, BaseUpgrade.PRICES_DESCRIPTION);
            SUPERCHARGED_PISTONS_ENGINE_TORQUE_INITIAL_INCREASE = cfg.BindSyncedEntry(topSection, Constants.SUPERCHARGED_PISTONS_ENGINE_TORQUE_INITIAL_INCREASE_KEY, Constants.SUPERCHARGED_PISTONS_ENGINE_TORQUE_INITIAL_INCREASE_DEFAULT, Constants.SUPERCHARGED_PISTONS_ENGINE_TORQUE_INITIAL_INCREASE_DESCRIPTION);
            SUPERCHARGED_PISTONS_ENGINE_TORQUE_INCREMENTAL_INCREASE = cfg.BindSyncedEntry(topSection, Constants.SUPERCHARGED_PISTONS_ENGINE_TORQUE_INCREMENTAL_INCREASE_KEY, Constants.SUPERCHARGED_PISTONS_ENGINE_TORQUE_INCREMENTAL_INCREASE_DEFAULT, Constants.SUPERCHARGED_PISTONS_ENGINE_TORQUE_INCREMENTAL_INCREASE_DESCRIPTION);
            SUPERCHARGED_PISTONS_ITEM_PROGRESSION_ITEMS = cfg.BindSyncedEntry(topSection, LguConstants.ITEM_PROGRESSION_ITEMS_KEY, LguConstants.ITEM_PROGRESSION_ITEMS_DEFAULT, LguConstants.ITEM_PROGRESSION_ITEMS_DESCRIPTION);

            #endregion

            #region Rapid Motors

            topSection = RapidMotors.UPGRADE_NAME;
            RAPID_MOTORS_ENABLED = cfg.BindSyncedEntry(topSection, Constants.RAPID_MOTORS_ENABLED_KEY, Constants.RAPID_MOTORS_ENABLED_DEFAULT, Constants.RAPID_MOTORS_ENABLED_DESCRIPTION);
            RAPID_MOTORS_PRICE = cfg.BindSyncedEntry(topSection, Constants.RAPID_MOTORS_PRICE_KEY, Constants.RAPID_MOTORS_PRICE_DEFAULT);
            RAPID_MOTORS_PRICES = cfg.BindSyncedEntry(topSection, BaseUpgrade.PRICES_SECTION, RapidMotors.PRICES_DEFAULT, BaseUpgrade.PRICES_DESCRIPTION);
            RAPID_MOTORS_ACCELERATION_INITIAL_INCREASE = cfg.BindSyncedEntry(topSection, Constants.RAPID_MOTORS_ACCELERATION_INITIAL_INCREASE_KEY, Constants.RAPID_MOTORS_ACCELERATION_INITIAL_INCREASE_DEFAULT, Constants.RAPID_MOTORS_ACCELERATION_INITIAL_INCREASE_DESCRIPTION);
            RAPID_MOTORS_ACCELERATION_INCREMENTAL_INCREASE = cfg.BindSyncedEntry(topSection, Constants.RAPID_MOTORS_ACCELERATION_INCREMENTAL_INCREASE_KEY, Constants.RAPID_MOTORS_ACCELERATION_INCREMENTAL_INCREASE_DEFAULT, Constants.RAPID_MOTORS_ACCELERATION_INCREMENTAL_INCREASE_DESCRIPTION);
            RAPID_MOTORS_ITEM_PROGRESSION_ITEMS = cfg.BindSyncedEntry(topSection, LguConstants.ITEM_PROGRESSION_ITEMS_KEY, LguConstants.ITEM_PROGRESSION_ITEMS_DEFAULT, LguConstants.ITEM_PROGRESSION_ITEMS_DESCRIPTION);

            #endregion

            #region Vehicle Plating

            topSection = VehiclePlating.UPGRADE_NAME;
            VEHICLE_PLATING_ENABLED = cfg.BindSyncedEntry(topSection, Constants.VEHICLE_PLATING_ENABLED_KEY, Constants.VEHICLE_PLATING_ENABLED_DEFAULT, Constants.VEHICLE_PLATING_ENABLED_DESCRIPTION);
            VEHICLE_PLATING_PRICE = cfg.BindSyncedEntry(topSection, Constants.VEHICLE_PLATING_PRICE_KEY, Constants.VEHICLE_PLATING_PRICE_DEFAULT);
            VEHICLE_PLATING_PRICES = cfg.BindSyncedEntry(topSection, BaseUpgrade.PRICES_SECTION, VehiclePlating.PRICES_DEFAULT, BaseUpgrade.PRICES_DESCRIPTION);
            VEHICLE_PLATING_HEALTH_INITIAL_INCREASE = cfg.BindSyncedEntry(topSection, Constants.VEHICLE_PLATING_HEALTH_INITIAL_INCREASE_KEY, Constants.VEHICLE_PLATING_HEALTH_INITIAL_INCREASE_DEFAULT, Constants.VEHICLE_PLATING_HEALTH_INITIAL_INCREASE_DESCRIPTION);
            VEHICLE_PLATING_HEALTH_INCREMENTAL_INCREASE = cfg.BindSyncedEntry(topSection, Constants.VEHICLE_PLATING_HEALTH_INCREMENTAL_INCREASE_KEY, Constants.VEHICLE_PLATING_HEALTH_INCREMENTAL_INCREASE_DEFAULT, Constants.VEHICLE_PLATING_HEALTH_INCREMENTAL_INCREASE_DESCRIPTION);
            VEHICLE_PLATING_ITEM_PROGRESSION_ITEMS = cfg.BindSyncedEntry(topSection, LguConstants.ITEM_PROGRESSION_ITEMS_KEY, LguConstants.ITEM_PROGRESSION_ITEMS_DEFAULT, LguConstants.ITEM_PROGRESSION_ITEMS_DESCRIPTION);

            #endregion

            #region Override Names

            topSection = "Override Names";
            BRAKE_FLUID_OVERRIDE_NAME = cfg.BindSyncedEntry(topSection, Constants.BRAKE_FLUID_OVERRIDE_NAME_KEY, BrakeFluid.UPGRADE_NAME);
            TURBO_TANK_OVERRIDE_NAME = cfg.BindSyncedEntry(topSection, Constants.TURBO_TANK_OVERRIDE_NAME_KEY, TurboTank.UPGRADE_NAME);
            IGNITION_COIL_OVERRIDE_NAME = cfg.BindSyncedEntry(topSection, Constants.IGNITION_COIL_OVERRIDE_NAME_KEY, IgnitionCoil.UPGRADE_NAME);
            FLUFFY_SEATS_OVERRIDE_NAME = cfg.BindSyncedEntry(topSection, Constants.FLUFFY_SEATS_OVERRIDE_NAME_KEY, FluffySeats.UPGRADE_NAME);
            IMPROVED_STEERING_OVERRIDE_NAME = cfg.BindSyncedEntry(topSection, Constants.IMPROVED_STEERING_OVERRIDE_NAME_KEY, ImprovedSteering.UPGRADE_NAME);
            SUPERCHARGED_PISTONS_OVERRIDE_NAME = cfg.BindSyncedEntry(topSection, Constants.SUPERCHARGED_PISTONS_OVERRIDE_NAME_KEY, SuperchargedPistons.UPGRADE_NAME);
            RAPID_MOTORS_OVERRIDE_NAME = cfg.BindSyncedEntry(topSection, Constants.RAPID_MOTORS_OVERRIDE_NAME_KEY, RapidMotors.UPGRADE_NAME);
            VEHICLE_PLATING_OVERRIDE_NAME = cfg.BindSyncedEntry(topSection, Constants.VEHICLE_PLATING_OVERRIDE_NAME_KEY, VehiclePlating.UPGRADE_NAME);

            #endregion

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
