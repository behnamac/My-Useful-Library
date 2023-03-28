using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace WrestleBreaker
{
    public class PlayerMove : MonoBehaviour
    {
        private Wreslers _wreslers;
        private Transform _point;

        #region Unity Methodes

        private void Awake()
        {
            TryGetComponent(out _wreslers);
        }

        private void Start()
        {
            
        }
        private void OnEnable()
        {
            _wreslers.OnDead += GotoNextPoint;
            LevelManager.OnLevelStart += SetPlayerPosition;
        }
        private void OnDisable()
        {
            _wreslers.OnDead -= GotoNextPoint;
            LevelManager.OnLevelStart -= SetPlayerPosition;


        }

        private void SetPlayerPosition(Level level)
        {
            transform.position = WaveHolder.Instance.enemieList[0].GetComponent<Enemy>().Point.position;
        }

        public void GotoNextPoint()
        {
            StartCoroutine(GoToNextPointCo());

        }

        #endregion

        #region Custom Methodes
        private IEnumerator GoToNextPointCo()
        {
            _wreslers.SetState();
            if (WaveHolder.Instance.GameMode == WrestelMode.dead|| WaveHolder.Instance.GameMode == WrestelMode.Idle) yield break;
            _point = WaveHolder.Instance.enemieList[0].GetComponent<Enemy>().Point;
            transform.DOMove(_point.position, 1).OnComplete(() =>
            {

                _wreslers.CanWrestle = true;
                WaveHolder.Instance.SetWrestelMode(WrestelMode.Wrestle);
                _wreslers.SetState();
            });
            yield return null;

            
        }

        #endregion 
    }
}
