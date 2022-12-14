using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsApp.Models
{
    public class PetAction
    {
        public enum ActionNames
        {
            BaconSnack,
            DryDogFood,
            Tuna,
            DryCatFood,
            Water,
            PlantFood,
            FishFood,
            Pet,
            RubBelly,
            Play,
            Ignore,
            Scold,
            PlayMusic,
            TalkToThem,
            TapOnGlass,
            None
        }

        private ActionNames _name;
        public ActionNames name
        {
            get { return _name; }
        }

        private bool _isFood;
        public bool isFood { 
            get { return _isFood; } 
        }

        private int _raisesHungerBy;
        public int raisesHungerBy
        {
            get { return _raisesHungerBy; }
        }

        private int _raisesHappinessBy;
        public int raisesHappinessBy
        {
            get { return _raisesHappinessBy; }
        }

        private float _multipliesHungerBy;
        public float multipliesHungerBy
        {
            get { return _multipliesHungerBy; }
        }

        private int _setsHungerTo;
        public int setsHungerTo
        {
            get { return _setsHungerTo; }
        }

        private bool _setsHunger;
        public bool setsHunger
        {
            get { return _setsHunger; }
        }

        private bool _randomlyDisliked;
        public bool randomlyDisliked
        {
            get { return _randomlyDisliked; }
        }

        public PetAction(
            ActionNames name, 
            bool isFood, 
            int raisesHungerBy, 
            int raisesHappinessBy,
            float multipliesHungerBy,
            bool randomlyDisliked = false)
        {
            _name = name;
            _isFood = isFood;
            _raisesHungerBy = raisesHungerBy;
            _raisesHappinessBy = raisesHappinessBy;
            _multipliesHungerBy = multipliesHungerBy;
            _setsHunger = false;
            _setsHungerTo = -1;
            _randomlyDisliked = randomlyDisliked;
        }

        public PetAction(
            ActionNames name,
            bool isFood,
            int raisesHungerBy,
            int raisesHappinessBy,
            float multipliesHungerBy,
            int setsHungerTo,
            bool randomlyDisliked = false)
        {
            _name = name;
            _isFood = isFood;
            _raisesHungerBy = raisesHungerBy;
            _raisesHappinessBy = raisesHappinessBy;
            _multipliesHungerBy = multipliesHungerBy;
            _setsHunger = true;
            _setsHungerTo = setsHungerTo;
            _randomlyDisliked = randomlyDisliked;
        }

    }
}
