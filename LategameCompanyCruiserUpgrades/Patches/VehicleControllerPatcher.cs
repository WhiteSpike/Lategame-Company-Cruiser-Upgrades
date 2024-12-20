﻿using HarmonyLib;
using LategameCompanyCruiserUpgrades.Upgrades.TierUpgrades;
using MoreShipUpgrades.Misc.Util;
using System.Collections.Generic;
using System.Reflection;

namespace LategameCompanyCruiserUpgrades.Patches
{
    [HarmonyPatch(typeof(VehicleController))]
    internal static class VehicleControllerPatcher
    {
        [HarmonyTranspiler]
        [HarmonyPatch(nameof(VehicleController.Start))]
        [HarmonyPatch(nameof(VehicleController.AddEngineOil))]
        static IEnumerable<CodeInstruction> StartTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> codes = new(instructions);
            int index = 0;

            IncreaseMaximumHealthTranspile(ref index, ref codes);
            return codes;
        }

        [HarmonyPatch(nameof(VehicleController.Update))]
        static IEnumerable<CodeInstruction> UpdateTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> codes = new(instructions);
            int index = 0;

            IncreaseMaximumHealthTranspile(ref index, ref codes);
            IncreaseBreakingPowerTranspile(ref index, ref codes); // When pressing the brake pedal
            IncreaseBreakingPowerTranspile(ref index, ref codes); // When in park mode
            return codes;
        }

        [HarmonyTranspiler]
        [HarmonyPatch(nameof(VehicleController.ReactToDamage))]
        static IEnumerable<CodeInstruction> ReactToDamageTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> codes = new(instructions);
            int index = 0;

            IncreaseMaximumHealthTranspile(ref index, ref codes);
            IncreaseTurboCapacityTranspile(ref index, ref codes, isFloat: true);
            return codes;
        }

        static void IncreaseMaximumHealthTranspile(ref int index, ref List<CodeInstruction> codes)
        {
            FieldInfo baseCarHP = typeof(VehicleController).GetField(nameof(VehicleController.baseCarHP));
            MethodInfo getAdditionalMaximumHealth = typeof(VehiclePlating).GetMethod(nameof(VehiclePlating.GetAdditionalMaximumHealth));

            Tools.FindField(ref index, ref codes, findField: baseCarHP, addCode: getAdditionalMaximumHealth, errorMessage: "Couldn't find the baseCarHP field");
        }

        static void IncreaseBreakingPowerTranspile(ref int index, ref List<CodeInstruction> codes)
        {
            MethodInfo getAdditionalBrakePower = typeof(BrakeFluid).GetMethod(nameof(BrakeFluid.GetIncreasedBrakingPower));

            Tools.FindFloat(ref index, ref codes, findValue: 2000f, addCode: getAdditionalBrakePower, errorMessage: "Couldn't find the 2000f value for the first wheel");
            Tools.FindFloat(ref index, ref codes, findValue: 2000f, addCode: getAdditionalBrakePower, errorMessage: "Couldn't find the 2000f value for the second wheel");
            Tools.FindFloat(ref index, ref codes, findValue: 2000f, addCode: getAdditionalBrakePower, errorMessage: "Couldn't find the 2000f value for the third wheel");
            Tools.FindFloat(ref index, ref codes, findValue: 2000f, addCode: getAdditionalBrakePower, errorMessage: "Couldn't find the 2000f value for the fourth wheel");
            Tools.FindFloat(ref index, ref codes, findValue: 2000f, addCode: getAdditionalBrakePower, errorMessage: "Couldn't find the 2000f value for the remaining wheels");
        }

        [HarmonyTranspiler]
        [HarmonyPatch(nameof(VehicleController.DamagePlayerInVehicle))]
        static IEnumerable<CodeInstruction> DamagePlayerInVehicleTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            MethodInfo getPlayerDamageMitigation = typeof(FluffySeats).GetMethod(nameof(FluffySeats.GetPlayerDamageMitigation));

            List<CodeInstruction> codes = new(instructions);
            int index = 0;

            Tools.FindInteger(ref index, ref codes, findValue: 40, addCode: getPlayerDamageMitigation, errorMessage: "Couldn't find the damage player with value of 40");
            Tools.FindInteger(ref index, ref codes, findValue: 30, addCode: getPlayerDamageMitigation, errorMessage: "Couldn't find the damage player with value of 30");
            Tools.FindInteger(ref index, ref codes, findValue: 10, addCode: getPlayerDamageMitigation, errorMessage: "Couldn't find the damage player with value of 10");

            return codes;
        }

        [HarmonyTranspiler]
        [HarmonyPatch(nameof(VehicleController.TryIgnition), MethodType.Enumerator)]
        static IEnumerable<CodeInstruction> TryIgnitionTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            FieldInfo chanceToStartIgnition = typeof(VehicleController).GetField(nameof(VehicleController.chanceToStartIgnition), BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo getAdditionalIgnitionChance = typeof(IgnitionCoil).GetMethod(nameof(IgnitionCoil.GetAdditionalIgnitionChance));

            List<CodeInstruction> codes = new(instructions);
            int index = 0;

            Tools.FindField(ref index, ref codes, findField: chanceToStartIgnition, addCode: getAdditionalIgnitionChance, errorMessage: "Couldn't find usage of chanceToStartIgnition field");

            return codes;
        }

        [HarmonyTranspiler]
        [HarmonyPatch(nameof(VehicleController.AddTurboBoost))]
        static IEnumerable<CodeInstruction> AddTurboBoostTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> codes = new(instructions);
            int index = 0;

            IncreaseTurboCapacityTranspile(ref index, ref codes, isFloat: false);

            return codes;
        }

        static void IncreaseTurboCapacityTranspile(ref int index, ref List<CodeInstruction> codes, bool isFloat = false)
        {

            if (!isFloat)
            {
                MethodInfo getAdditionalTurboCapacity = typeof(TurboTank).GetMethod(nameof(TurboTank.GetAdditionalTurboCapacity), [typeof(int)]);
                Tools.FindInteger(ref index, ref codes, findValue: 5, addCode: getAdditionalTurboCapacity, errorMessage: "Couldn't find the defined maximum turbo capacity when adding turbo boost");
            }
            else
            {
                MethodInfo getAdditionalTurboCapacity = typeof(TurboTank).GetMethod(nameof(TurboTank.GetAdditionalTurboCapacity), [typeof(float)]);
                Tools.FindFloat(ref index, ref codes, findValue: 5f, addCode: getAdditionalTurboCapacity, errorMessage: "Couldn't find the defined maximum turbo capacity when updating turbo scale");
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(VehicleController.Start))]
        static void StartPostfix(VehicleController __instance)
        {
            __instance.carAcceleration = RapidMotors.GetAdditionalAcceleration(__instance.carAcceleration);
            __instance.EngineTorque = SuperchargedPistons.GetAdditionalEngineTorque(__instance.EngineTorque);
            __instance.steeringWheelTurnSpeed = ImprovedSteering.GetAdditionalTurningSpeed(__instance.steeringWheelTurnSpeed);
        }
    }
}
