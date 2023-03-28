using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrestleBreaker
{
    public class Level : MonoBehaviour
    {
        public int LevelIndex;
        public int LevelNumber;
        public WaveInfo WaveInfo;

        [SerializeField] private Material SkyBox;
        [SerializeField] private bool hasFog;
        [ConditionalHide(nameof(hasFog), true)]
        [SerializeField] private Color fogColor;


        private void Awake()
        {
            RenderSettings.skybox = SkyBox;
            RenderSettings.fog = hasFog;
            if (hasFog)
                RenderSettings.fogColor = fogColor;

            PlayerPrefsController.SetLevelIndex(LevelIndex);
            PlayerPrefsController.SetLevelNumber(LevelNumber);
            var score = LevelNumber + WaveInfo.score;
            PlayerPrefsController.SetScore(score);
        }
    }
}

