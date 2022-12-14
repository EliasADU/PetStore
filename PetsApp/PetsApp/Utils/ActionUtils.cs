using PetsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsApp.Utils
{
    static class ActionUtils
    {
        public static void ApplyAction(Pet pet, PetAction.ActionNames actionName)
        {
            // Rule: if pet is above max hungry or below or at zero happy, no interactions allowed
            if ((pet.hunger > pet.maxHunger || pet.happiness <= 0) && !ActionIsFood(actionName))
            {
                return;
            }

            PetAction likedAction = null;
            foreach (PetAction action in pet.likedPetActions)
            {
                if (action.name == actionName)
                {
                    likedAction = action;
                    break;
                }
            }

            Random r = new Random();
            // Only apply if not null and (if randomly disliked then 50% chance to not apply)
            bool applyAction = likedAction != null && (!likedAction.randomlyDisliked || r.Next(0, 2) == 0);

            if (applyAction)
            {
                pet.happiness += likedAction.raisesHappinessBy;
                pet.hunger = (int)((pet.hunger + likedAction.raisesHungerBy) * likedAction.multipliesHungerBy);
                if (likedAction.setsHunger)
                {
                    pet.hunger = likedAction.setsHungerTo;
                }
            }
            else
            {
                pet.happiness -= 2;
                pet.hunger += 2;
            }
        }

        public static void ApplyTime(Pet pet)
        {
            pet.minutesElapsed += 1;
            if(pet.minutesElapsed >= pet.minutesPerDecrement)
            {
                pet.happiness -= 1;
                pet.hunger += 1;
                pet.minutesElapsed = 0;
            }
        }

        public static bool ActionIsFood(PetAction.ActionNames actionName)
        {
            switch (actionName)
            {
                case PetAction.ActionNames.BaconSnack:
                    return true;
                case PetAction.ActionNames.DryCatFood:
                    return true;
                case PetAction.ActionNames.DryDogFood:
                    return true;
                case PetAction.ActionNames.FishFood:
                    return true;
                case PetAction.ActionNames.PlantFood:
                    return true;
                case PetAction.ActionNames.Tuna:
                    return true;
                case PetAction.ActionNames.Water:
                    return true;
                case PetAction.ActionNames.Play:
                    return false;
                case PetAction.ActionNames.Pet:
                    return false;
                case PetAction.ActionNames.Ignore:
                    return false;
                case PetAction.ActionNames.PlayMusic:
                    return false;
                case PetAction.ActionNames.RubBelly:
                    return false;
                case PetAction.ActionNames.Scold:
                    return false;
                case PetAction.ActionNames.TapOnGlass:
                    return false;
                case PetAction.ActionNames.TalkToThem:
                    return false;
            }
            return false;
        }
    }
}
