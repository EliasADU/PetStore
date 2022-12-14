using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsApp.Models
{
    class Plant : Pet
    {
        private static List<PetAction> plantActions = new List<PetAction> {
            new PetAction(PetAction.ActionNames.Water, true, 0, 1, 0.5f),
            new PetAction(PetAction.ActionNames.PlantFood, true, 0, 1, 1, 0),
            new PetAction(PetAction.ActionNames.TalkToThem, false, 1, 1, 1),
            new PetAction(PetAction.ActionNames.PlayMusic, false, 1, 2, 1),
            new PetAction(PetAction.ActionNames.Ignore, false, 3, -3, 1)
        };

        public Plant(string name) : base(name, plantActions, 2, 5, 6, 5, 1) { }
    }
}
