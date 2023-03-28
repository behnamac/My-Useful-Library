using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace WarMachine
{
    public class WheelRotate : MonoBehaviour
    {
        private void OnEnable()
        {
            GameManager.OnLevelStart += OnLevelStart;
            GameManager.OnLevelFaild += OnLevelFaild;

        }
        private void OnDisable()
        {
            GameManager.OnLevelStart -= OnLevelStart;
            GameManager.OnLevelFaild -= OnLevelFaild;
        }

       

        private void OnLevelStart()
        {
            transform.DOLocalRotate(new Vector3(360, 0, 0), 0.4f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart);

        }
        private void OnLevelFaild()
        {
            GetComponent<WheelRotate>().enabled = false;
        }
    }
}
