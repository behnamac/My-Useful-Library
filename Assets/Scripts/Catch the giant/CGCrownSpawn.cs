using System.Collections;
using UnityEngine;

namespace CatchTheGiant
{
    public class CGCrownSpawn : MonoBehaviour
    {
        // private Transform gameplayPanel;
        [SerializeField] private float jumpForce;
        private bool active;
        private CGEnenmyController giant;
        private RotateObject rotateObject;
        private Rigidbody myBody;
        private float timeToScale = 8f;



        private void Start()
        {
            rotateObject = GetComponent<RotateObject>();
            myBody = GetComponent<Rigidbody>();
            myBody.isKinematic = true;
            myBody.useGravity = false;
            rotateObject.enabled = false;
            giant = GetComponentInParent<CGEnenmyController>();

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CGPlayerCollision>() && !active)
            {
                jumpUp();
                StartCoroutine(downScaleCo());
                CGPlayerList.Instance.CapacityFull = false;
            }
        }

        private void jumpUp()
        {
            active = true;
            transform.SetParent(CGPlayerList.Instance.transform);
            transform.localPosition = Vector3.zero;
            rotateObject.enabled = true;
            myBody.isKinematic = false;
            myBody.useGravity = true;
            myBody.AddForce(Vector3.up * jumpForce);
        }

        private IEnumerator downScaleCo()
        {
            yield return new WaitForSeconds(1f);
            myBody.isKinematic = true;
            myBody.useGravity = false;
            while (transform.localScale != Vector3.zero)
            {
                yield return new WaitForEndOfFrame();
                transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, timeToScale * Time.deltaTime);
                if (transform.localScale == Vector3.zero)
                {
                    setScore();
                    giant.death(2f);
                    CGPlayerList.Instance.killedGiant++;

                }
            }
        }

        private void setScore()
        {
            CGUIManager.Instance.SetCurrencyNumber(CGUIManager.Instance.GiantScore);
        }
    }
}
