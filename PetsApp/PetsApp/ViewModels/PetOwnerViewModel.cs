using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PetsApp.Models;

namespace PetsApp.ViewModels
{
    class PetOwnerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Pet> _ownedPets;
        public ObservableCollection<Pet> ownedPets
        {
            get { return _ownedPets; }
            set
            {
                _ownedPets = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ownedPets"));
                }
            }
        }

        public Pet selectedPet { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public PetOwnerViewModel()
        {
            ownedPets = new ObservableCollection<Pet>();
        }

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
