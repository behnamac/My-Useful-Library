using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Fundamental
{

    public class Shape : MonoBehaviour
    {
        enum AnimMode { Globalmove, LocalMove, rotate, DoMoveX, Scale }
        [SerializeField] private Transform[] Shapes;
        [SerializeField] private float _cycleLength = 2;
        [SerializeField] private Vector3 cordinate;
        [SerializeField] private int loop = 6;
        [SerializeField] private AnimMode animMode = AnimMode.Globalmove;
        [SerializeField] private Ease easeType = Ease.Linear;

        private void Start()
        {
            switch (animMode)
            {
                case AnimMode.Globalmove:
                    GlobalMove();
                    break;
                case AnimMode.rotate:
                    rotate();
                    break;
                case AnimMode.LocalMove:
                    LocalMove();
                    break;
                case AnimMode.DoMoveX:
                    DoMoveX();
                    break;
                case AnimMode.Scale:
                    DoScale();
                    break;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (animMode != AnimMode.Scale) return;
                for (int i = 0; i < Shapes.Length; i++)
                {
                    Shapes[i].localScale = Vector3.zero;
                }
                DoScale();
                print("scale");
            }
        }


        private void GlobalMove()
        {
            transform.DOMove(cordinate, _cycleLength).SetEase(easeType).SetLoops(loop, LoopType.Yoyo).OnComplete(() =>
            { print("done!"); });
        }
        private void rotate()
        {
            transform.DORotate(cordinate, _cycleLength * 0.5f, RotateMode.FastBeyond360).SetLoops(loop, LoopType.Restart).SetEase(easeType);
        }
        private void LocalMove()
        {
            transform.DOLocalMove(cordinate, _cycleLength).SetEase(easeType).SetLoops(loop, LoopType.Yoyo);
        }
        private void DoMoveX()
        {
            for (int i = 0; i < Shapes.Length; i++)
            {
                Shapes[i].DOMoveX(cordinate.x, _cycleLength).onComplete();

            }

        }
        private void DoScale()
        {
            for (int i = 0; i < Shapes.Length; i++)
            {
                Shapes[i].DOScale(cordinate.x, _cycleLength).SetEase(easeType);
            }

        }

    }
}
