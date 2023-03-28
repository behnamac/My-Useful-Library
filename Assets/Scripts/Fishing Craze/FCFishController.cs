using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FCFishController : MonoBehaviour
{
    public int Size = 1;
    public FCAutoCollectable fishCollect;
    public bool changeScale;
    public float ScaleLow = 1;
    [HideInInspector] public bool activeLookAt;
    [SerializeField] private string WaterSplash = "WaterSplash";
    Rigidbody rigid;


    public void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (activeLookAt)
            transform.DOLookAt(rigid.velocity, 0.2f);
    }

    public void playWaterSplash()
    {
        var d = ParticleManager.PlayParticle(WaterSplash, transform.position, Quaternion.identity);
        Destroy(d.gameObject, 2f);
    }

    public void ActiveCollider()
    {
        GetComponent<Collider>().enabled = true;
    }
}
