using UnityEngine;
using UnityEngine.UI;

namespace HottieLife
{
    public class HUiManager : MonoBehaviour
    {
        public static HUiManager Instance;
        public Image ClothStateBar;

        void Awake()
        {
            Instance = this;
        }


    }
}
