using GameNetcodeStuff;
using HarmonyLib;
using LategameCompanyCruiserUpgrades.Upgrades.TierUpgrades;
using MoreShipUpgrades.Misc.Upgrades;
using UnityEngine;

namespace LategameCompanyCruiserUpgrades.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal static class PlayerControllerBPatcher
    {

        [HarmonyPrefix]
        [HarmonyPatch(nameof(PlayerControllerB.KillPlayer))]
        static bool KillPlayerPrefix(PlayerControllerB __instance, Vector3 bodyVelocity, bool spawnBody, CauseOfDeath causeOfDeath, int deathAnimation, Vector3 positionOffset)
        {
            return PreventInstantKill(ref __instance, bodyVelocity, spawnBody, causeOfDeath, deathAnimation, positionOffset);
        }

        static bool PreventInstantKill(ref PlayerControllerB __instance, Vector3 bodyVelocity, bool spawnBody, CauseOfDeath causeOfDeath, int deathAnimation, Vector3 positionOffset)
        {
            switch (causeOfDeath)
            {
                case CauseOfDeath.Inertia:
                    {
                        if (!BaseUpgrade.GetActiveUpgrade(FluffySeats.UPGRADE_NAME)) return true;
                        Plugin.mls.LogInfo($"Kill player fired due to car crash with {FluffySeats.UPGRADE_NAME} upgrade on, mitigating 100 damage instead of instant kill...");
                        __instance.DamagePlayer(FluffySeats.GetPlayerDamageMitigation(100), hasDamageSFX: true, callRPC: true, causeOfDeath: causeOfDeath, deathAnimation: deathAnimation, fallDamage: false, force: bodyVelocity);
                        return false;
                    }
                default: return true;
            }
        }
    }
}
