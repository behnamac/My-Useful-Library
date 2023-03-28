using UnityEngine;

namespace FCStorage
{
    public class FCPlayerPrefsController : MonoBehaviour
    {
        public static FCPlayerPrefsController Instance;
        [SerializeField] private FCBalanceParameters balanceParameters;

        private void Awake()
        {
            Instance = this;
        }

        #region Setter

        public void SetPlayerSpeed(float value) => PlayerPrefs.SetFloat("PlayerSpeed", value);
        public void SetFish1Price(float value) => PlayerPrefs.SetFloat("Fish1Price", value);
        public void SetFish2Price(float value) => PlayerPrefs.SetFloat("Fish2Price", value);
        public void SetFish3Price(float value) => PlayerPrefs.SetFloat("Fish3Price", value);



        #endregion


        #region Getter

        public float GetPlayerSpeed() => PlayerPrefs.GetFloat("PlayerSpeed",balanceParameters.PlayerSpeed);
        public float GetFish1Price() => PlayerPrefs.GetFloat("Fish1Price", balanceParameters.fish1Price);
        public float GetFish2Price() => PlayerPrefs.GetFloat("Fish1Price", balanceParameters.fish2Price);
        public float GetFish3Price() => PlayerPrefs.GetFloat("Fish1Price", balanceParameters.fish3Price);


        #endregion

    }
}

