using UnityEngine;

namespace CatchTheGiant
{
    [CreateAssetMenu(menuName = "Data/Catch the giant/economy")]
    public class CGEconomyManager : ScriptableObject
    {
        public int Giantscore = 5;
        public float firstMoney = 50;
    }
}
