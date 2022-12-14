using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace PetsApp.Models
{
    public class Pet : DependencyObject
    {
        private string _name;
        public string name
        {
            get { return _name; }
        }

        private List<PetAction> _likedPetActions = new List<PetAction>();
        public List<PetAction> likedPetActions
        {
            get { return _likedPetActions; }
        }

        private int _startHappiness;
        public int startHappiness
        {
            get { return _startHappiness; }
        }

        private int _startHunger;
        public int startHunger
        {
            get { return _startHunger; }
        }

        private int _maxHunger;
        public int maxHunger
        {
            get { return _maxHunger; }
        }

        private int _maxHappiness;
        public int maxHappiness
        {
            get { return _maxHappiness; }
        }

        public static readonly DependencyProperty _happiness = DependencyProperty.Register(
            "Happiness",
            typeof(int),
            typeof(Pet),
            new PropertyMetadata(null));
        public int happiness
        {
            get { return (int)GetValue(_happiness); }
            set { SetValue(_happiness,  value); }
        }

        // Note: Ideally this would be floating-point, since it'll be divided sometimes
        // but UWP makes it a pain to display floats in text boxes, so for this small
        // project it'll do integer multiplications instead.
        public static readonly DependencyProperty _hunger = DependencyProperty.Register(
            "Hunger",
            typeof(int),
            typeof(Pet),
            new PropertyMetadata(null));
        public int hunger
        {
            get { return (int)GetValue(_hunger); }
            set { SetValue(_hunger, value); }
        }

        private int _minutesPerDecrement;
        public int minutesPerDecrement
        {
            get { return _minutesPerDecrement; }
        }

        private int _minutesElapsed;
        public int minutesElapsed
        {
            get { return _minutesElapsed; }
            set { _minutesElapsed = value; }
        }

        public Pet(
            string name, 
            List<PetAction> likedPetActions, 
            int startHappiness, 
            int startHunger, 
            int maxHunger, 
            int maxHappiness, 
            int minutesPerDecrement)
        {
            this._name = name;
            this._likedPetActions = likedPetActions;
            this._startHappiness = startHappiness;
            this._startHunger = startHunger;
            SetValue(_happiness, startHappiness);
            SetValue(_hunger, startHunger);
            this._maxHunger = maxHunger;
            this._maxHappiness = maxHappiness;
            this._minutesPerDecrement = minutesPerDecrement;
            this.minutesElapsed = 0;
        }
    }
}
