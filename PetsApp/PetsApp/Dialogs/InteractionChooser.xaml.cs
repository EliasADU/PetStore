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
    public sealed partial class InteractionChooser : ContentDialog
    {
        private Pet pet;
        private IList<Pet> petList;

        public InteractionChooser(IList<Pet> petList, Pet pet)
        {
            this.InitializeComponent();
            this.pet = pet;
            this.petList = petList;
        }

        private void Interaction_Click(object sender, RoutedEventArgs e)
        {
            string type = (string)((Button)sender).Tag;
            PetAction.ActionNames name = PetAction.ActionNames.None;
            switch (type)
            {
                case "Pet":
                    name = PetAction.ActionNames.Pet;
                    break;
                case "RubBelly":
                    name = PetAction.ActionNames.RubBelly;
                    break;
                case "Play":
                    name = PetAction.ActionNames.Play;
                    break;
                case "Ignore":
                    name = PetAction.ActionNames.Ignore;
                    break;
                case "Scold":
                    name = PetAction.ActionNames.Scold;
                    break;
                case "PlayMusic":
                    name = PetAction.ActionNames.PlayMusic;
                    break;
                case "TalkToThem":
                    name = PetAction.ActionNames.TalkToThem;
                    break;
                case "TapOnGlass":
                    name = PetAction.ActionNames.TapOnGlass;
                    break;
            }

            if (name != PetAction.ActionNames.None)
            {
                ActionUtils.ApplyAction(pet, name);
            }

            // Forces an update
            petList[petList.IndexOf(pet)] = pet;

            Hide();
        }
    }
}
