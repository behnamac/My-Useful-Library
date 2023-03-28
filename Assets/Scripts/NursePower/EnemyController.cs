using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace NursePower
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer[] blendShaps;
        [SerializeField] private float firstSize;
        private float _minSize;

        [SerializeField] private float health = 5;
        [SerializeField] private Text healthText;
        private float _currnetHelath;

        [SerializeField] private skinHolder[] skinHolders;


        private void Awake()
        {
            firstSize = 100;
        }

        private void Start()
        {
            foreach (var item in blendShaps)
            {
                item.SetBlendShapeWeight(0, firstSize);
            }

            _currnetHelath = health;
            healthText.text = _currnetHelath.ToString();

            setSkin();

        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BulletController>())
            {
                damage();
                other.gameObject.SetActive(false);
            }
        }

        private void damage()
        {
            if (_currnetHelath <= 0) return;

            foreach (var item in blendShaps)
            {
                item.SetBlendShapeWeight(0, item.GetBlendShapeWeight(0) - calculateTakeDamage());
                item.SetBlendShapeWeight(0, Mathf.Clamp(item.GetBlendShapeWeight(0), _minSize, Mathf.Infinity));
            }

            _currnetHelath--;
            healthText.text = _currnetHelath.ToString();

            if (_currnetHelath <= 0)
            {
                StartCoroutine(GoForwardCO());
                Destroy(gameObject, 3f);
                healthText.gameObject.SetActive(false);
            }
        }


        private void setSkin()
        {
            foreach (var skin in skinHolders)
            {
                skin.SetRandomSkin();
            }
        }

        IEnumerator GoForwardCO()
        {
            float speed = 4f;
            while (true)
            {
                yield return new WaitForEndOfFrame();
                transform.position += Vector3.forward * speed * Time.deltaTime;

            }
        }

        private float calculateTakeDamage()
        {
            return firstSize / health;
        }

        [System.Serializable]

        class skinHolder
        {
            public string name;
            public GameObject[] skins;

            public void SetRandomSkin()
            {
                foreach (var item in skins)
                {
                    item.SetActive(false);
                }
                int random = Random.Range(0, skins.Length);
                skins[random].SetActive(true);
            }

        }
    }
}
