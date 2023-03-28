using UnityEngine;
using UnityEngine.AI;

namespace CatchTheGiant
{
    public class CGCharacterManager : MonoBehaviour
    {
        private NavMeshAgent navMesh;
        [HideInInspector] public bool canMove;
        [HideInInspector] public Transform target;
        [SerializeField] private Material characterMtl;
        private Renderer BaseMtl;


        private void Awake()
        {
            navMesh = GetComponent<NavMeshAgent>();
            target = FindObjectOfType<CGPlayerMovement>().transform;
            BaseMtl = GetComponentInChildren<Renderer>();

        }

        private void Update()
        {
            if (canMove)
                navMesh.SetDestination(target.position);
        }

        public void changeColor()
        {
            BaseMtl.material = characterMtl;
        }
    }
}





