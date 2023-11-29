using UnityEngine;

namespace Assets.CodeBase
{
    public class FishStats
    {
        private int _scale;
        private string _name;
        private int _price;
        private Sprite _sprite;
        private bool _isCleaned;

        public FishStats(int scale, Sprite sprite, string name, int price)
        {
            _scale = scale;
            _sprite = sprite;
            _name = name;
            _price = price;
        }

        public int GetPrice() =>
            _price;

        public int GetScale() => 
            _scale;

        public Sprite GetSprite() =>
            _sprite;

        public string GetName() =>
            _name;

        public bool IsCleaned() =>
            _isCleaned;

        public void Cleaning() => 
            _isCleaned = true;

        public void SetNewPrice() => 
            _price *= 2;
    }
}