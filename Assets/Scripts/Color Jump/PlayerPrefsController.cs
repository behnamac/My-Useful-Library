using UnityEngine;

namespace DestroyTheInfected
{
    public static class PlayerPrefsController
    {
        #region Getter
        public static int GetTotalCurrency() => PlayerPrefs.GetInt("Currency");

        #endregion


        #region Setter
        public static void SetTotalCurrency(int value) => PlayerPrefs.SetInt("Currency", value);
        #endregion


    }

}
