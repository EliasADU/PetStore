using PetsApp.Dialogs;
using PetsApp.Models;
using PetsApp.Utils;
using PetsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Threading;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PetsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        PetOwnerViewModel myViewModel;

        public MainPage()
        {
            this.InitializeComponent();
            myViewModel = new PetOwnerViewModel();
            DataContext = myViewModel;

            var timer = new System.Threading.Timer(
            e => Refresh(),
            null,
            TimeSpan.FromMinutes(1),
            TimeSpan.FromMinutes(1));
        }

        private async void BuyPets_Click(object sender, RoutedEventArgs e)
        {
            var diag = new PetStore(myViewModel.ownedPets);
            await diag.ShowAsync();
        }

        private async void Refresh()
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                foreach (Pet pet in myViewModel.ownedPets)
                {
                    ActionUtils.ApplyTime(pet);
                }

                IList<Pet> petList = myViewModel.ownedPets;
                for (int i = 0; i < petList.Count; i++)
                {
                    petList[i] = petList[i];
                }
            });
        }

        private async void Feed_Click(object sender, RoutedEventArgs e)
        {
            ForceSelectItem(sender);
            var diag = new FoodChooser(myViewModel.ownedPets, myViewModel.selectedPet);
            await diag.ShowAsync();
        }

        private async void Interact_Click(object sender, RoutedEventArgs e)
        {
            ForceSelectItem(sender);
            var diag = new InteractionChooser(myViewModel.ownedPets, myViewModel.selectedPet);
            await diag.ShowAsync();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            ForceSelectItem(sender);
            myViewModel.ownedPets.Remove(myViewModel.selectedPet);
        }

        // Ideally, this isn't necessary,
        // but I could not find another way to select an item by just clicking the button
        private void ForceSelectItem(object sender)
        {
            myViewModel.selectedPet = (Pet)((FrameworkElement)sender).DataContext;
        }

        private void AddTestData()
        {
            Dog bowie = new Dog("bowie");
            myViewModel.ownedPets.Add(bowie);
            Cat fresco = new Cat("fresco");
            myViewModel.ownedPets.Add(fresco);
            Plant chompy = new Plant("chompy");
            myViewModel.ownedPets.Add(chompy);
            Fish magikarp = new Fish("magikarp");
            myViewModel.ownedPets.Add(magikarp);
        }
    }
}
