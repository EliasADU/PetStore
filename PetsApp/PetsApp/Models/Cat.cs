using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsApp.Models
{
    class Cat : Pet
    {
        private static List<PetAction> catActions = new List<PetAction> {
            new PetAction(PetAction.ActionNames.Tuna, true, 0, 3, 1, 0),
            new PetAction(PetAction.ActionNames.DryCatFood, true, 0, 1, 0.5f),
            new PetAction(PetAction.ActionNames.Pet, false, 1, 1, 1, true),
            new PetAction(PetAction.ActionNames.Ignore, false, 1, 2, 1),
            new PetAction(PetAction.ActionNames.Scold, false, 2, -2, 1),
        };

        public Cat(string name) : base(name, catActions, 4, 2, 8, 5, 2) { }
    }
}
