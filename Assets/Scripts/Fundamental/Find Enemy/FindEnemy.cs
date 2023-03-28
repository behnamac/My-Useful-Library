using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Fundamental
{
    public enum FindEnemyType
    {
        Raycast, SimpleCollider, CheckerBox, Distance
    }
    public class FindEnemy : MonoBehaviour
    {
        [Header("Enum"), Space(5)]
        [SerializeField] private FindEnemyType findEnemyType;

        [SerializeField] private LayerMask layerMask;

        [Header("Raycast"), Space(5)]
        [SerializeField] private bool isRaycast;
        [ConditionalHide(nameof(isRaycast), true)]
        [SerializeField] private Vector3 RaycastOrigin;

        [Header("CheckerBox"), Space(5)]
        [SerializeField] private bool isCheckerBox;
        [ConditionalHide(nameof(isCheckerBox), true)]
        [SerializeField] private Vector3 triggerSize;
        [ConditionalHide(nameof(isCheckerBox), true)]
        [SerializeField] private Vector3 offset;

        [Header("Distance"), Space(5)]
        [SerializeField] private bool isDistance;
        [ConditionalHide(nameof(isDistance), true)]
        [SerializeField] private float distance;

        private Transform enemy;

        private void Awake()
        {
                enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        }
        private void Update()
        {
            if (findEnemyType == FindEnemyType.Raycast)
            {
                FindWithRaycast();
            }
            else if (findEnemyType == FindEnemyType.CheckerBox)
            {
                FindWithCheckerBox();
            }
            else if (findEnemyType == FindEnemyType.Distance)
            {
                FindWithDistance();
            }
        }

        #region Raycast

        private void FindWithRaycast()
        {
            RaycastHit hit;
            var origin = transform.position + RaycastOrigin;

            if (Physics.Raycast(origin, Vector3.forward, out hit, 5, layerMask))
            {
                print("find with Raycast");
                print(hit.collider.name);
                var _hit = hit.collider;
            }
        }

        #endregion

        #region Simple Collider

        private void OnTriggerStay(Collider other)
        {
            if (findEnemyType == FindEnemyType.SimpleCollider)
            {
                if (other.gameObject.layer == 8)
                {
                    print("find with SimpleCollider");

                }
            }
        }

        #endregion

        #region  CheckerBox

        private void FindWithCheckerBox()
        {
            Vector3 newCenter = transform.position + offset;
            if (Physics.CheckBox(newCenter, triggerSize, Quaternion.identity, layerMask))
            {
                print("find with CheckerBox");
            }
        }

        #endregion

        #region Distance

        private void FindWithDistance()
        {
            if (Vector3.Distance(transform.position, enemy.position) <=distance)
            {
                print("find with distance");

            }
        }

        #endregion

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            if (findEnemyType == FindEnemyType.Raycast)
            {
                Gizmos.DrawRay(transform.position + RaycastOrigin, Vector3.forward * 5);
            }
            else if (findEnemyType == FindEnemyType.CheckerBox)
            {
                Gizmos.DrawWireCube(transform.position + offset, triggerSize);

            }
            else if (findEnemyType == FindEnemyType.Distance)
            {
                Gizmos.DrawWireSphere(transform.position, distance);

            }
        }

    }


}
