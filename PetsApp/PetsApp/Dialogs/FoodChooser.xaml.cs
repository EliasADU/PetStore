using PetsApp.Models;
using PetsApp.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PetsApp.Dialogs
{
    public sealed partial class FoodChooser : ContentDialog
    {
        private Pet pet;
        private IList<Pet> petList;

        public FoodChooser(IList<Pet> petList, Pet pet)
        {
            this.InitializeComponent();
            this.pet = pet;
            this.petList = petList;
        }

        private void Food_Click(object sender, RoutedEventArgs e)
        {
            string type = (string)((Button)sender).Tag;
            PetAction.ActionNames name = PetAction.ActionNames.None;
            switch (type)
            {
                case "BaconSnack":
                    name = PetAction.ActionNames.BaconSnack;
                    break;
                case "DryDogFood":
                    name = PetAction.ActionNames.DryDogFood;
                    break;
                case "DryCatFood":
                    name = PetAction.ActionNames.DryCatFood;
                    break;
                case "Tuna":
                    name = PetAction.ActionNames.Tuna;
                    break;
                case "Water":
                    name = PetAction.ActionNames.Water;
                    break;
                case "PlantFood":
                    name = PetAction.ActionNames.PlantFood;
                    break;
                case "FishFood":
                    name = PetAction.ActionNames.FishFood;
                    break;
            }

            if(name != PetAction.ActionNames.None)
            {
                ActionUtils.ApplyAction(pet, name);
            }

            // Forces an update
            petList[petList.IndexOf(pet)] = pet;

            Hide();
        }
    }
}
