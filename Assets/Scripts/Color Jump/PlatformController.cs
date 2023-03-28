using UnityEngine;

namespace ColorJump
{
    public class PlatformController : MonoBehaviour
    {
        public ColorsType platformColor = ColorsType.White;
        public bool spring;
        [SerializeField] Transform springObj;
        [ConditionalHide(nameof(spring), true)] public Transform targetJump;
        [ConditionalHide(nameof(spring), true)] public float springForce = 2;


        [SerializeField] bool needGate;
        [SerializeField] Transform gate;

        public bool canChangeColor;
        public Renderer mesh;
        [SerializeField] ColorData colorDatas;


        private void Start()
        {

            Initializer();
            setPatformColor(platformColor);

        }



        void setPatformColor(ColorsType color)
        {
            for (int i = 0; i < colorDatas.colorData.Length; i++)
            {
                if (color == colorDatas.colorData[i].colorsType)
                {
                    GetComponent<Renderer>().material.color = colorDatas.colorData[i].materialColor;
                }
            }
        }

        void Initializer()
        {
            if (spring) springObj.gameObject.SetActive(true);
            if (needGate) gate.gameObject.SetActive(true);
            if (colorDatas == null) Debug.LogError("assign the color controller manager please");
            mesh = GetComponent<Renderer>();
        }


        private void OnDrawGizmos()
        {
            //for (int i = 0; i < colorDatas.colorData.Length; i++)
            //{
            //    if (platformColor == colorDatas.colorData[i].colorsType)
            //    {
            //        this.GetComponent<Renderer>().sharedMaterial.color = colorDatas.colorData[i].materialColor;
            //    }
            //}
            if (spring) springObj.gameObject.SetActive(true);
            else springObj.gameObject.SetActive(false);
            if (needGate) gate.gameObject.SetActive(true);
            else gate.gameObject.SetActive(false);
        }
    }
}
