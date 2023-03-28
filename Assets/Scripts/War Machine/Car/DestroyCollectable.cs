using UnityEngine;


public class DestroyCollectable : MonoBehaviour
{
    enum Mode {deactive ,destory}
    [SerializeField]private Mode destroyMode = Mode.deactive;
    [SerializeField] private float timer = 7;
    private void OnEnable()
    {
        if (destroyMode == Mode.deactive)
            Invoke(nameof(Deactive), timer);
        else
            Destroy();
    }

    private void Deactive()
    {
        gameObject.SetActive(false);
    }
    private void Destroy()
    {
        Destroy(gameObject,timer);
    }
}


