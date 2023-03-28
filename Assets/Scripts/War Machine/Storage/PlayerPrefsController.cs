using UnityEngine;

namespace WarMachine
{
    public static class PlayerPrefsController
    {

        #region SETTER

        public static void SetLevelIndex(int index) => PlayerPrefs.SetInt("level-index", index);
        public static void SetLevelNumber(int number) => PlayerPrefs.SetInt("level-number", number);
        public static void SetCurrency(int currency) => PlayerPrefs.SetInt("currency", currency);
        public static void SetHealth(int health) => PlayerPrefs.SetInt("Health", health);
        public static void SetDamage(int damage) => PlayerPrefs.SetInt("Damage", damage);
        

        #endregion

        #region GETTER

        public static int GetLevelIndex() => PlayerPrefs.GetInt("level-index");
        public static int GetLevelNumber(int defaultNumber) => PlayerPrefs.GetInt("level-number", defaultNumber);
        public static int GetTotalCurrency() => PlayerPrefs.GetInt("currency");
        public static int GetHealth() => PlayerPrefs.GetInt("Health");
        public static int GetDamage() => PlayerPrefs.GetInt("Damage");
        

        #endregion

    }
}
