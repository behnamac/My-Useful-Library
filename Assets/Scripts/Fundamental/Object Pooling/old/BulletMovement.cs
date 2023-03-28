using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Fundamental
{
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField] private float timer = 2f;

        private void Update()
        {
            transform.Translate(0, 0, timer);
        }
        private void OnEnable()
        {
            Invoke(nameof(Deactive), 3f);
        }
        private void Deactive()
        {
            CancelInvoke();
            gameObject.SetActive(false);
        }
        

    }
}
