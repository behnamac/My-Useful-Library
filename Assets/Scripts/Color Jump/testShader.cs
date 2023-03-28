using UnityEngine;

namespace ColorJump
{
    public class testShader : MonoBehaviour
    {
        private Renderer renderr;
        void Start()
        {
            renderr = GetComponent<Renderer>();
            //  renderr.sharedMaterial.color = Color.blue;
            renderr.material.color = Color.blue;

        }
    }
}
