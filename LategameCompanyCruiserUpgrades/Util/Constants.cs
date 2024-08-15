using LategameCompanyCruiserUpgrades.Upgrades.TierUpgrades;
using MoreShipUpgrades.Misc.Util;

namespace LategameCompanyCruiserUpgrades.Util
{
    internal static class Constants
    {
        internal static readonly string BRAKE_FLUID_OVERRIDE_NAME_KEY = string.Format(LguConstants.OVERRIDE_NAME_KEY_FORMAT, BrakeFluid.UPGRADE_NAME);
        internal static readonly string TURBO_TANK_OVERRIDE_NAME_KEY = string.Format(LguConstants.OVERRIDE_NAME_KEY_FORMAT, TurboTank.UPGRADE_NAME);
        internal static readonly string IGNITION_COIL_OVERRIDE_NAME_KEY = string.Format(LguConstants.OVERRIDE_NAME_KEY_FORMAT, IgnitionCoil.UPGRADE_NAME);
        internal static readonly string FLUFFY_SEATS_OVERRIDE_NAME_KEY = string.Format(LguConstants.OVERRIDE_NAME_KEY_FORMAT, FluffySeats.UPGRADE_NAME);
        internal static readonly string IMPROVED_STEERING_OVERRIDE_NAME_KEY = string.Format(LguConstants.OVERRIDE_NAME_KEY_FORMAT, ImprovedSteering.UPGRADE_NAME);
        internal static readonly string SUPERCHARGED_PISTONS_OVERRIDE_NAME_KEY = string.Format(LguConstants.OVERRIDE_NAME_KEY_FORMAT, SuperchargedPistons.UPGRADE_NAME);
        internal static readonly string RAPID_MOTORS_OVERRIDE_NAME_KEY = string.Format(LguConstants.OVERRIDE_NAME_KEY_FORMAT, RapidMotors.UPGRADE_NAME);
        internal static readonly string VEHICLE_PLATING_OVERRIDE_NAME_KEY = string.Format(LguConstants.OVERRIDE_NAME_KEY_FORMAT, VehiclePlating.UPGRADE_NAME);

        #region Brake Fluid

        internal const string BRAKE_FLUID_ENABLED_KEY = $"Enable {BrakeFluid.UPGRADE_NAME} Upgrade";
        internal const bool BRAKE_FLUID_ENABLED_DEFAULT = true;
        internal const string BRAKE_FLUID_ENABLED_DESCRIPTION = "Tier upgrade which increases the braking capability of the Company Cruiser vehicle.";

        internal const string BRAKE_FLUID_PRICE_KEY = $"Price of {BrakeFluid.UPGRADE_NAME} Upgrade";
        internal const int BRAKE_FLUID_PRICE_DEFAULT = 100;

        internal const string BRAKE_FLUID_CAPACITY_INITIAL_INCREASE_KEY = "Initial Break Power Increase";
        internal const int BRAKE_FLUID_CAPACITY_INITIAL_INCREASE_DEFAULT = 25;
        internal const string BRAKE_FLUID_CAPACITY_INITIAL_INCREASE_DESCRIPTION = "Percentage of break power increased when first purchasing the upgrade on the Company Cruiser Vehicle";

        internal const string BRAKE_FLUID_CAPACITY_INCREMENTAL_INCREASE_KEY = "Incremental Break Power Increase";
        internal const int BRAKE_FLUID_CAPACITY_INCREMENTAL_INCREASE_DEFAULT = 25;
        internal const string BRAKE_FLUID_CAPACITY_INCREMENTAL_INCREASE_DESCRIPTION = "Percentage of break power increased when purchasing further levels of the upgrade on the Company Cruiser Vehicle";

        #endregion

        #region Turbo Tank

        internal const string TURBO_TANK_ENABLED_KEY = $"Enable {TurboTank.UPGRADE_NAME} Upgrade";
        internal const bool TURBO_TANK_ENABLED_DEFAULT = true;
        internal const string TURBO_TANK_ENABLED_DESCRIPTION = "Tier upgrade which increases the maximum capacity of Company Cruiser Vehicle's turbo";

        internal const string TURBO_TANK_PRICE_KEY = $"Price of {TurboTank.UPGRADE_NAME} Upgrade";
        internal const int TURBO_TANK_PRICE_DEFAULT = 200;

        internal const string TURBO_TANK_CAPACITY_INITIAL_INCREASE_KEY = "Initial Turbo Capacity Increase";
        internal const int TURBO_TANK_CAPACITY_INITIAL_INCREASE_DEFAULT = 2;
        internal const string TURBO_TANK_CAPACITY_INITIAL_INCREASE_DESCRIPTION = "Amount of turbo capacity increased when first purchasing the upgrade on the Company Cruiser Vehicle";

        internal const string TURBO_TANK_CAPACITY_INCREMENTAL_INCREASE_KEY = "Incremental Turbo Capacity Increase";
        internal const int TURBO_TANK_CAPACITY_INCREMENTAL_INCREASE_DEFAULT = 1;
        internal const string TURBO_TANK_CAPACITY_INCREMENTAL_INCREASE_DESCRIPTION = "Amount of turbo capacity increased when purchasing further levels of the upgrade on the Company Cruiser Vehicle";

        #endregion

        #region Ignition Coil

        internal const string IGNITION_COIL_ENABLED_KEY = $"Enable {IgnitionCoil.UPGRADE_NAME} Upgrade";
        internal const bool IGNITION_COIL_ENABLED_DEFAULT = true;
        internal const string IGNITION_COIL_ENABLED_DESCRIPTION = "Tier upgrade which increases the chance of ignition to turn on the Company Cruiser Vehicle.";

        internal const string IGNITION_COIL_PRICE_KEY = $"Price of {IgnitionCoil.UPGRADE_NAME} Upgrade";
        internal const int IGNITION_COIL_PRICE_DEFAULT = 50;

        internal const string IGNITION_COIL_IGNITION_INITIAL_CHANCE_INCREASE_KEY = "Initial Ignition Chance Increase";
        internal const int IGNITION_COIL_IGNITION_INITIAL_CHANCE_INCREASE_DEFAULT = 25;
        internal const string IGNITION_COIL_IGNITION_INITIAL_CHANCE_INCREASE_DESCRIPTION = "Amount of chance (%) increased when first purchasing the upgrade to ignite on the Company Cruiser Vehicle";

        internal const string IGNITION_COIL_IGNITION_INCREMENTAL_CHANCE_INCREASE_KEY = "Incremental Ignition Chance Increase";
        internal const int IGNITION_COIL_IGNITION_INCREMENTAL_CHANCE_INCREASE_DEFAULT = 25;
        internal const string IGNITION_COIL_IGNITION_INCREMENTAL_CHANCE_INCREASE_DESCRIPTION = "Amount of chance (%) increased when purchasing further levels of the upgrade to ignite on the Company Cruiser Vehicle";

        #endregion

        #region Fluffy Seats

        internal const string FLUFFY_SEATS_ENABLED_KEY = $"Enable {FluffySeats.UPGRADE_NAME} Upgrade";
        internal const bool FLUFFY_SEATS_ENABLED_DEFAULT = true;
        internal const string FLUFFY_SEATS_ENABLED_DESCRIPTION = "Tier upgrade which provides player damage mitigation when bumping too hard with the Company Cruiser Vehicle.";

        internal const string FLUFFY_SEATS_PRICE_KEY = $"Price of {FluffySeats.UPGRADE_NAME} Upgrade";
        internal const int FLUFFY_SEATS_PRICE_DEFAULT = 100;

        internal const string FLUFFY_SEATS_DAMAGE_MITIGATION_INITIAL_INCREASE_KEY = "Initial Player Damage Mitigation Increase";
        internal const int FLUFFY_SEATS_DAMAGE_MITIGATION_INITIAL_INCREASE_DEFAULT = 25;
        internal const string FLUFFY_SEATS_DAMAGE_MITIGATION_INITIAL_INCREASE_DESCRIPTION = "Amount of damage mitigation (%) increased when first purchasing the upgrade when riding the Company Cruiser Vehicle.";

        internal const string FLUFFY_SEATS_DAMAGE_MITIGATION_INCREMENTAL_INCREASE_KEY = "Incremental Player Damage Mitigation Increase";
        internal const int FLUFFY_SEATS_DAMAGE_MITIGATION_INCREMENTAL_INCREASE_DEFAULT = 25;
        internal const string FLUFFY_SEATS_DAMAGE_MITIGATION_INCREMENTAL_INCREASE_DESCRIPTION = "Amount of damage mitigation (%) increased when purchasing further levels of the upgrade when riding the Company Cruiser Vehicle.";
        #endregion

        #region Improved Steering

        internal const string IMPROVED_STEERING_ENABLED_KEY = $"Enable {ImprovedSteering.UPGRADE_NAME} Upgrade";
        internal const bool IMPROVED_STEERING_ENABLED_DEFAULT = true;
        internal const string IMPROVED_STEERING_ENABLED_DESCRIPTION = "Tier upgrade which increases the turning speed of the Company Cruiser vehicle";

        internal const string IMPROVED_STEERING_PRICE_KEY = $"Price of {ImprovedSteering.UPGRADE_NAME} Upgrade";
        internal const int IMPROVED_STEERING_PRICE_DEFAULT = 100;

        internal const string IMPROVED_STEERING_TURNING_SPEED_INITIAL_INCREASE_KEY = "Initial Turning Speed Increase";
        internal const float IMPROVED_STEERING_TURNING_SPEED_INITIAL_INCREASE_DEFAULT = 1f;
        internal const string IMPROVED_STEERING_TURNING_SPEED_INITIAL_INCREASE_DESCRIPTION = "Amount of turning speed increased when first purchasing the upgrade to the Company Cruiser vehicle.";

        internal const string IMPROVED_STEERING_TURNING_SPEED_INCREMENTAL_INCREASE_KEY = "Incremental Turning Speed Increase";
        internal const float IMPROVED_STEERING_TURNING_SPEED_INCREMENTAL_INCREASE_DEFAULT = 0.5f;
        internal const string IMPROVED_STEERING_TURNING_SPEED_INCREMENTAL_INCREASE_DESCRIPTION = "Amount of turning speed increased when purchasing further levels of the upgrade to the Company Cruiser vehicle.";

        #endregion

        #region Supercharged Pistons

        internal const string SUPERCHARGED_PISTONS_ENABLED_KEY = $"Enable {SuperchargedPistons.UPGRADE_NAME} Upgrade";
        internal const bool SUPERCHARGED_PISTONS_ENABLED_DEFAULT = true;
        internal const string SUPERCHARGED_PISTONS_ENABLED_DESCRIPTION = "Tier upgrade which increases the company cruiser's maximum speed when driving";

        internal const string SUPERCHARGED_PISTONS_PRICE_KEY = $"Price of {SuperchargedPistons.UPGRADE_NAME} Upgrade";
        internal const int SUPERCHARGED_PISTONS_PRICE_DEFAULT = 250;

        internal const string SUPERCHARGED_PISTONS_ENGINE_TORQUE_INITIAL_INCREASE_KEY = "Initial Engine Torque Increase";
        internal const float SUPERCHARGED_PISTONS_ENGINE_TORQUE_INITIAL_INCREASE_DEFAULT = 40f;
        internal const string SUPERCHARGED_PISTONS_ENGINE_TORQUE_INITIAL_INCREASE_DESCRIPTION = "Amount of maximum speed increased when first purchasing the upgrade to the Company Cruiser vehicle.";

        internal const string SUPERCHARGED_PISTONS_ENGINE_TORQUE_INCREMENTAL_INCREASE_KEY = "Incremental Engine Torque Increase";
        internal const float SUPERCHARGED_PISTONS_ENGINE_TORQUE_INCREMENTAL_INCREASE_DEFAULT = 20f;
        internal const string SUPERCHARGED_PISTONS_ENGINE_TORQUE_INCREMENTAL_INCREASE_DESCRIPTION = "Amount of maximum speed increased when purchasing further levels of the upgrade to the Company Cruiser vehicle.";

        #endregion

        #region Rapid Motors

        internal const string RAPID_MOTORS_ENABLED_KEY = $"Enable {RapidMotors.UPGRADE_NAME} Upgrade";
        internal const bool RAPID_MOTORS_ENABLED_DEFAULT = true;
        internal const string RAPID_MOTORS_ENABLED_DESCRIPTION = "Tier upgrade which increases the company cruiser's acceleration when driving.";

        internal const string RAPID_MOTORS_PRICE_KEY = $"Price of {RapidMotors.UPGRADE_NAME} Upgrade";
        internal const int RAPID_MOTORS_PRICE_DEFAULT = 150;

        internal const string RAPID_MOTORS_ACCELERATION_INITIAL_INCREASE_KEY = "Initial Acceleration Increase";
        internal const float RAPID_MOTORS_ACCELERATION_INITIAL_INCREASE_DEFAULT = 2f;
        internal const string RAPID_MOTORS_ACCELERATION_INITIAL_INCREASE_DESCRIPTION = "Amount of acceleration increased when first purchasing the upgrade to the company cruiser vehicle.";

        internal const string RAPID_MOTORS_ACCELERATION_INCREMENTAL_INCREASE_KEY = "Incremental Acceleration Increase";
        internal const float RAPID_MOTORS_ACCELERATION_INCREMENTAL_INCREASE_DEFAULT = 0.5f;
        internal const string RAPID_MOTORS_ACCELERATION_INCREMENTAL_INCREASE_DESCRIPTION = "Amount of acceleration increased when purchasing further levels of the upgrade to the company cruiser vehicle.";

        #endregion

        #region Vehicle Plating

        internal const string VEHICLE_PLATING_ENABLED_KEY = $"Enable {VehiclePlating.UPGRADE_NAME} Upgrade";
        internal const bool VEHICLE_PLATING_ENABLED_DEFAULT = true;
        internal const string VEHICLE_PLATING_ENABLED_DESCRIPTION = "Tier upgrade which increases the company cruiser's maximum health to sustain damage from outside sources.";

        internal const string VEHICLE_PLATING_PRICE_KEY = $"Price of {VehiclePlating.UPGRADE_NAME} Upgrade";
        internal const int VEHICLE_PLATING_PRICE_DEFAULT = 150;

        internal const string VEHICLE_PLATING_HEALTH_INITIAL_INCREASE_KEY = "Initial Health Increase";
        internal const int VEHICLE_PLATING_HEALTH_INITIAL_INCREASE_DEFAULT = 10;
        internal const string VEHICLE_PLATING_HEALTH_INITIAL_INCREASE_DESCRIPTION = "Amount of health increased when first purchasing the upgrade to the company cruiser vehicle.";

        internal const string VEHICLE_PLATING_HEALTH_INCREMENTAL_INCREASE_KEY = "Incremental Health Increase";
        internal const int VEHICLE_PLATING_HEALTH_INCREMENTAL_INCREASE_DEFAULT = 5;
        internal const string VEHICLE_PLATING_HEALTH_INCREMENTAL_INCREASE_DESCRIPTION = "Amount of health increased when purchasing further levels of the upgrade to the company cruiser vehicle.";

        #endregion
    }
}
