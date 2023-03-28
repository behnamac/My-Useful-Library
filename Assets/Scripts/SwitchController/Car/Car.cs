using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace switchCotroller
{
public class Car : MonoBehaviour
{
        [SerializeField] protected Color Colors;
        [SerializeField] protected float Speed=20;
        [SerializeField] protected float Health=100;
        [SerializeField] protected float Damage =30;

        protected bool CanMove;

        #region Unity Methodes

        protected virtual void Awake()
        {

        }
        protected virtual void Start()
        {

        }
        protected virtual void Update()
        {
            if (!CanMove) return;
            Moveing();

        }
        protected virtual void OnEnable()
        {
            GameManager.OnLevelStart += OnLevelStart;
            GameManager.OnLevelComplete += OnLevelComplete;
            GameManager.OnLevelFailed += OnLevelFailed;
        }
        protected virtual void OnDisable()
        {
            GameManager.OnLevelStart -= OnLevelStart;
            GameManager.OnLevelComplete -= OnLevelComplete;
            GameManager.OnLevelFailed -= OnLevelFailed;
        }

        #endregion

        #region Action Methods

        protected virtual void OnLevelStart()
        {
        }
        protected virtual void OnLevelComplete()
        {

        }
        protected virtual void OnLevelFailed()
        {

        }
        #endregion

        #region Custom Methods

        protected void Moveing()
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        

        #endregion

    }
}
