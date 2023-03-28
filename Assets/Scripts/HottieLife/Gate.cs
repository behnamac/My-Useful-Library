using UnityEngine;
using UnityEngine.UI;

namespace HottieLife
{
    public class HGate : MonoBehaviour
    {
        private enum GateState { good, bad }
        [SerializeField] private GateState gateState = GateState.good;
        [SerializeField] private MeshRenderer[] GateModel;
        [SerializeField] ClothState clothState = ClothState.Natural;
        private string gateName;
        [SerializeField] private Text gateNameTxt;
        private int price;
        [SerializeField] Text priceTxt;
        private float GateValue = 0.3f;


        private void Awake()
        {
            if (gateState == GateState.good)
            {
                foreach (var item in GateModel)
                {
                    item.material.color = Color.green;
                }
            }
            else
            {
                foreach (var item in GateModel)
                {
                    item.material.color = Color.red;
                }
            }
            SetGate();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerMovement>())
            {
                if (gateState == GateState.good)
                {
                    other.GetComponent<PlayerManager>().CalculateClothStateBar(GateValue);
                }
                else
                {
                    other.GetComponent<PlayerManager>().CalculateClothStateBar(-GateValue);

                }
            }
        }


        private void SetGate()
        {
            switch (clothState)
            {

                case (ClothState.Natural):
                    price = 20;
                    break;
                case (ClothState.Wild):
                    price = 40;
                    break;
                case (ClothState.Dancer):
                    price = 60;
                    break;
                case (ClothState.Stripper):
                    price = 80;
                    break;


            }
            gateName = clothState.ToString();
            gateNameTxt.text = gateName;
            priceTxt.text = price.ToString();


        }
    }
}
