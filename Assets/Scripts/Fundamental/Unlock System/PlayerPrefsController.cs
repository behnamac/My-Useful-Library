using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnlockSystem
{
    public class PlayerPrefsController : MonoBehaviour
    {

        #region SETTER

        public static void SetModel(string carName) => PlayerPrefs.SetString("Model", carName);
        public static void SetCurrentModel(int thisCar) => PlayerPrefs.SetInt("CurrentModel", thisCar);
        public static void SetModelFill(float carFill) => PlayerPrefs.SetFloat("ModelFill", carFill);

        #endregion

        #region GETTER

        public static string GetModel(string defaultCar) => PlayerPrefs.GetString("Model", defaultCar);
        public static int GetCurrentModel(int defaultThisCar) => PlayerPrefs.GetInt("CurrentModel", defaultThisCar);
        public static float GetModelFill(float defaultCarFill) => PlayerPrefs.GetFloat("ModelFill", defaultCarFill);

        #endregion

    }
}
