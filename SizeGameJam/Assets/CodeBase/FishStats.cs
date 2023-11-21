using UnityEngine;

namespace Assets.CodeBase
{
    public class FishStats
    {
        private int _scale;
        private Sprite _sprite;
        private bool _isCleaned;

        public FishStats(int scale, Sprite sprite)
        {
            _scale = scale;
            _sprite = sprite;
        }

        public int GetScale() => 
            _scale;

        public Sprite GetSprite() =>
            _sprite;

        public bool IsCleaned() =>
            _isCleaned;

        public void Cleaning() => 
            _isCleaned = true;
    }
}