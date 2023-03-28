using UnityEngine;

namespace CatchTheGiant
{
    public class testLocalGlobal : MonoBehaviour
    {

        void Update()
        {
            // transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, 2);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, 2);

        }
    }
}
