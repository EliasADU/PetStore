using PetsApp.Models;
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
    public sealed partial class PetStore : ContentDialog
    {
        IList<Pet> petList;
        public static readonly DependencyProperty nameProperty = DependencyProperty.Register(
            "Name",
            typeof(string),
            typeof(PetStore),
            new PropertyMetadata(null));
        public string name
        {
            get
            {
                return (string)GetValue(nameProperty);
            }
            set
            {
                SetValue(nameProperty, value);
            }
        }
        public string type;

        public PetStore(IList<Pet> petList)
        {
            this.InitializeComponent();
            this.petList = petList;
            DataContext = this;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if(name != null && type != null)
            {
                Pet newPet = null;

                Pet matchingNamePet = petList.SingleOrDefault(s => s.name == name);
                while (matchingNamePet != null)
                {
                    // I forgot to implement GUIDs
                    // so this is the dirty "fix"
                    name = name + " Junior";
                    matchingNamePet = petList.SingleOrDefault(s => s.name == name);
                }

                switch (type)
                {
                    case "Dog":
                        newPet = new Dog(name);
                        break;
                    case "Cat":
                        newPet = new Cat(name);
                        break;
                    case "Plant":
                        newPet = new Plant(name);
                        break;
                    case "Fish":
                        newPet = new Fish(name);
                        break;
                }

                if(newPet != null)
                {
                    petList.Add(newPet);
                }
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PetTypeChooser.SelectedItem != null)
            {
                type = (string)PetTypeChooser.SelectedItem;
            }
        }
    }
}
