using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace HottieLife
{
    public class People : MonoBehaviour
    {
        private enum PeopleDo { Cheering, CheerAndThrowMoney, ThrowMoney }
        private enum PoepleReaction { happy, sad }
        [SerializeField] private PeopleDo peopleMode = PeopleDo.Cheering;
        bool checkThrow;
        [SerializeField] Vector3 triggerCenter;
        [SerializeField] Vector3 triggerSize = Vector3.one;
        [SerializeField] private LayerMask hitLayer;
        [SerializeField] private Transform shootPoint;
        PlayerMovement playerManager;
        bool isTrigger;
        [SerializeField] private float amountOfShoot = 300;
        [SerializeField] Rigidbody Money;

        private void Start()
        {
            Initializer();
        }

        private void Update()
        {

            if (checkThrow)
            {
                CheckPlayerHit();
            }
        }

        private void Initializer()
        {
            switch (peopleMode)
            {
                case PeopleDo.Cheering:
                    cheering();
                    break;

                case PeopleDo.ThrowMoney:
                    checkThrow = true;
                    playerManager = FindObjectOfType<PlayerMovement>();
                    break;
            }
        }

        void cheering()
        {

            transform.DOLocalMoveY(4, 0.5f).SetEase(Ease.InSine).SetLoops(-1, LoopType.Yoyo);
        }

        void CheckPlayerHit()
        {
            Vector3 newCenter = transform.position + triggerCenter;
            if (Physics.CheckBox(newCenter, triggerSize, Quaternion.identity, hitLayer) && !isTrigger)
            {
                isTrigger = true;
                var maxPos = playerManager.MaxHorizontalMove;
                var randomPos = Random.Range(-maxPos, maxPos);
                //StartCoroutine(lookAtThePlayer(new Vector3(randomPos, 0, transform.position.z + amountOfShoot)));
                StartCoroutine(lookAtThePlayer(PlayerManager.Instance.transform.position));


                Vector3 targetThrow = new Vector3(randomPos, PlayerManager.Instance.transform.position.y,
                transform.position.z + amountOfShoot);

                var mon = Instantiate(Money, shootPoint.position, Quaternion.identity);
                Vector3 VO = calculateVelocity(targetThrow, shootPoint.position, 1);


                mon.velocity = VO;
                // isTrigger = true;

            }
        }

        IEnumerator lookAtThePlayer(Vector3 target)

        {
            while (true)
            {
                yield return new WaitForEndOfFrame();
                Vector3 dir = target - transform.position;
                dir.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 1f);
            }
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

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Vector3 newCenter = transform.position + triggerCenter;
            Gizmos.DrawWireCube(newCenter, triggerSize);
        }
    }
}























