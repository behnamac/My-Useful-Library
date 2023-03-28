using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class RotateObject : MonoBehaviour
{
    [SerializeField] private float speed=0.4f;
    

    private void Rotate()
    {
        transform.DOLocalRotate(new Vector3(360, 0, 0),speed, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart);

    }

    public void Active() => Rotate();
    public void Deactive() => GetComponent<RotateObject>().enabled = false;

}
