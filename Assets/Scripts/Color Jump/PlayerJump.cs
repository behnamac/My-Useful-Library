using System.Collections;
using UnityEngine;

namespace ColorJump
{
    public class PlayerJump : MonoBehaviour
    {
        public static PlayerJump Instance;
        Rigidbody mybody;
//        [SerializeField] float jumpForce = 5;
        bool canJump = true;
        [SerializeField] Transform tagetObject;
        bool canControl;
        float forwardSpeed = 5f;

        private float fillLiqued = 1;

        public Renderer liquidValue;

        [SerializeField] ColorData colorDatas;


        private void Awake()
        {
            Instance = this;
            mybody = GetComponent<Rigidbody>();
            canControl = true;
            liquidValue.material.SetFloat("FillRef", fillLiqued);

        }

        void Update()
        {
            PlayerController();
            SetDamage(-0.01f);
        }

        private void PlayerController()
        {
            if (!canControl) return;
            if (Input.GetMouseButtonDown(0) && canJump)
            {

                StartCoroutine(jumping(tagetObject.position, 1.5f));

            }
        }

        public void chaeckPlatform(PlatformController platform)
        {
            if (platform.canChangeColor)
            {
                mybody.velocity = Vector3.zero;
                canJump = true;
                setPlayerColor(platform.platformColor);
                transform.forward = -platform.transform.forward;
                setParent(transform);
                if (platform.spring)
                {
                    if (platform.targetJump != null)
                    {
                        StartCoroutine(jumping(platform.targetJump.position, platform.springForce));
                    }
                    else
                    {
                        StartCoroutine(jumping(tagetObject.position, 1.5f));

                    }
                }
            }
            else
            {
                UıManager.Instance.death();
            }
        }

        void setPlayerColor(ColorsType color)
        {
            for (int i = 0; i < colorDatas.colorData.Length; i++)
            {
                if (color == colorDatas.colorData[i].colorsType)
                {
                    liquidValue.material.SetColor("SideColorRef", colorDatas.colorData[i].materialColor);
                }
            }

        }

        void setParent(Transform obj)
        {
            obj.transform.SetParent(transform);
        }


        IEnumerator jumping(Vector3 target, float curve)
        {
            yield return new WaitForEndOfFrame();
            var velocity = calculateVelocity(target, transform.position, curve);
            mybody.velocity = velocity;
            canJump = false;
            transform.parent = null;
        }

        private Vector3 calculateVelocity(Vector3 target, Vector3 orgin, float time)
        {
            Vector3 distance = target - orgin;
            Vector3 distanceXZ = distance;
            distanceXZ.y = 0;

            float SY = distance.y;
            float SXY = distanceXZ.magnitude;

            float Vy = SY / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;
            float Vxz = SXY / time;
            Vector3 result = distanceXZ.normalized;
            result *= Vxz;
            result.y = Vy;

            return result;

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<PlatformController>())
            {

                var platform = collision.gameObject.GetComponent<PlatformController>();
                chaeckPlatform(platform);

            }


        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "FinishLine")
            {
                canControl = false;
                StartCoroutine(SetXline());
            }
        }
        IEnumerator SetXline()
        {
            while (true)
            {
                transform.position += transform.forward * forwardSpeed * Time.deltaTime;
                yield return new WaitForEndOfFrame();


            }
        }

        void SetDamage(float value)
        {
            fillLiqued += value * Time.deltaTime;
            liquidValue.material.SetFloat("FillRef", fillLiqued);
            if (fillLiqued <= 0)
            {
                UıManager.Instance.death();
            }

        }
    }
}
