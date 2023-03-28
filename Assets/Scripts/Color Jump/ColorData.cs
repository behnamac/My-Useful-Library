using UnityEngine;

namespace ColorJump
{
    public enum ColorsType
    {
        White, Yellow, Green, Blue, Red, Purple
    }
    [CreateAssetMenu(menuName = "Data/Color Jump/colorData")]
    public class ColorData : ScriptableObject
    {


        public data[] colorData;

    }
    [System.Serializable]
    public class data
    {
        public Color materialColor;
        public ColorsType colorsType;
    }
}

