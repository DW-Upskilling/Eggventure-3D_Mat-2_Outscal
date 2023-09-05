using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Outscal.UnityAdvanced.Mat2.Events;
using Outscal.UnityAdvanced.Mat2.Components.Character;
using Outscal.UnityAdvanced.Mat2.Utils;

namespace Outscal.UnityAdvanced.Mat2.Components.Achievement
{
    public class AchievementController : MonoBehaviour
    {
        DeathEventHandler deathEventHandler;
        KillEventHandler killEventHandler;
        EnergyUsageEventHandler energyUsageEventHandler;
        
        private void Start()
        {
            deathEventHandler = DeathEventHandler.Instance;
            deathEventHandler.AddListener(HandleDeath);

            killEventHandler = KillEventHandler.Instance;
            killEventHandler.AddListener(HandleKill);

            energyUsageEventHandler = EnergyUsageEventHandler.Instance;
            energyUsageEventHandler.AddListener(HandleEnergyUsage);
        }

        private void OnDestroy()
        {
            deathEventHandler.RemoveListener(HandleDeath);
            killEventHandler.RemoveListener(HandleKill);
            energyUsageEventHandler.RemoveListener(HandleEnergyUsage);
        }

        private void HandleDeath(CharacterView view)
        {
            if (deathEventHandler.TotalDeaths % Constants.DefaultDeathAchievementMultiple == 0)
            {
                Debug.Log("Achievement Unlocked: " + deathEventHandler.TotalDeaths + " deaths");
            }
        }

        private void HandleKill(CharacterView view)
        {
            if (killEventHandler.TotalKills % Constants.DefaultKillAchievementMultiple == 0)
            {
                Debug.Log("Achievement Unlocked: " + killEventHandler.TotalKills + " kills");
            }
        }

        private void HandleEnergyUsage(CharacterView view)
        {
            if(energyUsageEventHandler.TotalEnergyUses % Constants.DefaultEnergyUsageAchievementMultiple == 0)
            {
                Debug.Log("Achievement Unlocked: " + energyUsageEventHandler.TotalEnergyUses + " energy uses");
            }
        }
    }
}
