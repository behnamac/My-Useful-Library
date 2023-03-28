using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace switchCotroller
{
    public class RotateObject : MonoBehaviour
    {
        enum rotateMode { x, y, z, }

        [SerializeField] private float speed = 0.4f;
        [SerializeField] rotateMode rotation = rotateMode.x;

        private void OnEnable()
        {
            GameManager.OnLevelStart += Rotate;
        }

        private void Rotate()
        {
            switch (rotation)
            {
                case rotateMode.x:
                    transform.DOLocalRotate(new Vector3(360, 0, 0), speed, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart);
                    break;
                case rotateMode.y:
                    transform.DOLocalRotate(new Vector3(0, 360, 0), speed, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart);
                    break;
                case rotateMode.z:
                    transform.DOLocalRotate(new Vector3(0, 0, 360), speed, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart);
                    break;
            }

        }

        public void Active() => Rotate();
        public void Deactive() => GetComponent<RotateObject>().enabled = false;

    }
}
