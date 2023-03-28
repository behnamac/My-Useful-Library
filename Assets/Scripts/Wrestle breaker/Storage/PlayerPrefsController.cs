using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrestleBreaker
{
public  static class PlayerPrefsController
{
        #region Getter
        public static int GetLevelIndex() =>  PlayerPrefs.GetInt("level-index",0);
        public static int GetLevelNumber() => PlayerPrefs.GetInt("level-num", 1);
        public static float GetCurrentcy(float value) => PlayerPrefs.GetFloat("currency",value);
        public static float GetScore() => PlayerPrefs.GetFloat("score");

        public static int GetIncomeLevel() => PlayerPrefs.GetInt("income");
        public static int GetPowerLevel() => PlayerPrefs.GetInt("power");
        public static int GetStaminaLevel() => PlayerPrefs.GetInt("stamina");


        #endregion

        #region Setter
        public static void SetLevelIndex(int value) => PlayerPrefs.SetInt("level-index",value);
        public static void SetLevelNumber(int value) => PlayerPrefs.SetInt("level-num", value);
        public static void SetCurrency(float value) => PlayerPrefs.SetFloat("currency", value);
        public static void SetScore(float value) => PlayerPrefs.SetFloat("score", value);

        public static void SetIncomeLevel(int value) => PlayerPrefs.SetInt("income", value);
        public static void SetPowerLevel(int value) => PlayerPrefs.SetInt("power", value);
        public static void SetStaminaLevel(int value) => PlayerPrefs.SetInt("stamina", value);
        #endregion
    }

}
