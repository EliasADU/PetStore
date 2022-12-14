using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsApp.Models
{
    class Dog : Pet
    {
        private static List<PetAction> dogActions = new List<PetAction> { 
            new PetAction(PetAction.ActionNames.BaconSnack, true, 0, 1, 0.5f),
            new PetAction(PetAction.ActionNames.DryDogFood, true, 0, 1, 1, 0),
            new PetAction(PetAction.ActionNames.RubBelly, false, 1, 1, 1),
            new PetAction(PetAction.ActionNames.Play, false, 3, 2, 1),
            new PetAction(PetAction.ActionNames.Scold, false, 2, -2, 1)
        };

        public Dog(string name) : base(name, dogActions, 5, 2, 10, 10, 2) { }

        public override string ToString()
        {
            return name;
        }
    }
}
