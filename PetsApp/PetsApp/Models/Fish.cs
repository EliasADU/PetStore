using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsApp.Models
{
    class Fish : Pet
    {
        private static List<PetAction> fishActions = new List<PetAction> {
            new PetAction(PetAction.ActionNames.FishFood, true, 0, 1, 1, 0),
            new PetAction(PetAction.ActionNames.PlayMusic, false, 1, 1, 1),
            new PetAction(PetAction.ActionNames.TalkToThem, false, 1, 1, 1),
            new PetAction(PetAction.ActionNames.TapOnGlass, false, 3, -2, 1),
        };

        public Fish(string name) : base(name, fishActions, 2, 2, 5, 5, 3) { }
    }
}
