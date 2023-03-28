using System.Collections;
using UnityEngine;

namespace CatchTheGiant
{
    public class CGEnenmyController : MonoBehaviour
    {
        public bool activeEnemy;
        [SerializeField] private float downSpeed = 0.3f;
        [HideInInspector] public bool getDamage;
        private int numberOfPlayer = 1;
        [SerializeField] private Transform particleTarget;
        bool attack = true;
        private float maxAttack = 8f;
        private float timer = 1f;
        private int maxKill = 3;



        private void OnEnable()
        {
            CGGameManager.LevelLose += levelLose;
        }
        private void OnDisable()
        {
            CGGameManager.LevelLose -= levelLose;

        }

        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 1;
                numberOfPlayer = CGPlayerList.Instance.playerList.Count;
            }
            if (getDamage)
            {
                GoDown();
            }
        }



        public void GoDown()
        {
            transform.Translate(0, -downSpeed * numberOfPlayer * Time.deltaTime, 0);
        }

        public void MoveToCenter(Vector3 target)
        {
            StartCoroutine(MoveToCenterCo(target));
        }

        IEnumerator MoveToCenterCo(Vector3 target)
        {

            while (transform.localPosition != target)
            {
                yield return new WaitForEndOfFrame();
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, 10 * Time.deltaTime);
            }
        }

        public void death(float value)
        {
            Destroy(gameObject, value);
            CancelInvoke();
        }

        public void Attack()
        {
            ParticleManager.PlayParticle("damage", CGPlayerList.Instance.transform.position, Quaternion.Euler(0, 0, 0), transform);

            //CGPlayerList.Instance.playerList.RemoveRange(0, maxKill);

            for (int i = 0; i < maxKill; i++)
            {
                CGPlayerList.Instance.RemoveList(CGPlayerList.Instance.playerList[i]);
                if (CGPlayerList.Instance.playerList.Count <= 0)
                {
                    CGGameManager.Instance.LoseState();
                }
            }



        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CGPlayerCollision>())
            {
                if (attack)
                {
                    float time = (maxAttack / numberOfPlayer) + 3;
                    var timeToAttack = Mathf.Clamp(time, 2, maxAttack);
                    InvokeRepeating(nameof(Attack), timeToAttack, timeToAttack);
                    attack = false;
                }
            }
        }

        private void levelLose()
        {
            getDamage = false;
            CancelInvoke();
        }



    }
}
