using UnityEngine;

public class RaycasFoundomental : MonoBehaviour
{
    Vector3 vec = new Vector3(0, 0.5f, 0);
    [SerializeField] LayerMask layer;


    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        RaycastHit hit;
        Ray ray = new Ray((transform.position + vec) + Vector3.forward * 0.7f, Vector3.down);
        if (Physics.Raycast(ray, out hit,6f, layer))
        {
            print("raycast");
            print(hit.collider.name);
            print(hit.collider.tag);
            print(hit.distance);
            print(hit.point);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay((transform.position + vec) + Vector3.forward * 0.7f, Vector3.down*6);
    }
}
