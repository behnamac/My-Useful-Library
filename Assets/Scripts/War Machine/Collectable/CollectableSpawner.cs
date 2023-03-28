using System.Collections;
using UnityEngine;
using Dreamteck.Splines;
using System.Collections.Generic;

namespace WarMachine
{
    public class CollectableSpawner : MonoBehaviour
    {
        [Header("Spline")]
        [Space(5)]
        [SerializeField] private SplineFollower spawnPointFollower;
        [SerializeField] private SplineComputer splineComputer;

        [Header("CollectableSpawn")]
        [Space(5)]
        [SerializeField] Collectables[] collectables;
        private GameObject _parentCollectable;
        private bool _spawnObject;
        private bool _onStart;

        private PlayerMove _playerMove;

        //---------------just for practicing-----------------
        //private Dictionary<string, Collectables> _collectableDic;

        #region Unity Methodes

        private void Awake()
        {
            //            DictionrayInitialize();
            _playerMove = FindObjectOfType<PlayerMove>();
        }

        private void Start()
        {
            spawnPointFollower.followSpeed = 0;
            _parentCollectable = new GameObject();
            _parentCollectable.name = "Collecable Parent";
        }

        private void Update()
        {
            if (_onStart)
            {
                spawnPointFollower.followSpeed = _playerMove.SpeedFowrard;
                if (_spawnObject) return;
                setCollectable();

            }


        }


        private void OnEnable()
        {
            GameManager.OnLevelComplete += OnLevelComplete;
            GameManager.OnLevelFaild += OnLevelFaild;
            GameManager.OnLevelStart += OnLevelStart;
        }

        private void OnDisable()
        {
            GameManager.OnLevelComplete -= OnLevelComplete;
            GameManager.OnLevelFaild -= OnLevelFaild;
            GameManager.OnLevelStart -= OnLevelStart;
        }

        #endregion

        #region Custom Methodes

        private void setCollectable()
        {
            for (int j = 0; j < collectables.Length; j++)
            {


                if (!_spawnObject)
                {

                    _spawnObject = true;
                    StartCoroutine(spawnObject(j));

                }

            }
        }

        private IEnumerator spawnObject(int index)
        {
            for (int i = 0; i < collectables[index].SpawnObjects.Length; i++)
            {
                var _object = Instantiate(collectables[index].SpawnObjects[i].GetRandomObject());
                var newPos = collectables[index].GetPos();
                _object.transform.SetParent(spawnPointFollower.transform);
                _object.transform.rotation = spawnPointFollower.transform.rotation;
                _object.transform.localPosition = newPos;
                _object.transform.SetParent(_parentCollectable.transform);

                yield return new WaitForSeconds(collectables[index].setCollectableDistsnce);

            }
                _spawnObject = false;
        }

        #region Spawn With dictionary

        //private void DictionrayInitialize()
        //{
        //    _collectableDic = new Dictionary<string, Collectables>();

        //    for (int i = 0; i < collectables.Length; i++)
        //    {
        //        _collectableDic.Add(collectables[i].Name, collectables[i]);
        //    }
        //}
        //private IEnumerator spawnObject(string name)
        //{
        //    for (int i = 0; i < _collectableDic[name].SpawnObjects.Length; i++)
        //    {
        //        print("instance");
        //        var _object = Instantiate(_collectableDic[name].SpawnObjects[i].GetRandomObject());
        //        var newPos = _collectableDic[name].GetPos();
        //        _object.transform.SetParent(spawnPointFollower.transform);
        //        _object.transform.rotation = spawnPointFollower.transform.rotation;
        //        _object.transform.localPosition = newPos;
        //        _object.transform.SetParent(_parentCollectable.transform);

        //        yield return new WaitForSeconds(_collectableDic[name].setCollectableDistsnce);
        //    }
        //        _spawnObject = false;
        //}

        #endregion




        #endregion

        #region Delegate Methodes

        private void OnLevelComplete()
        {
            _onStart = false;

        }

        private void OnLevelFaild()
        {
            _onStart = false;
        }

        private void OnLevelStart()
        {
            _onStart = true;
        }

        #endregion



    }


    [System.Serializable]

    public class Collectables
    {
        public string Name;
        public ObjectsForSpawn[] SpawnObjects;
        public float[] XPos;
        public float YPos;
        public float setCollectableDistsnce;

        public Vector3 GetPos()
        {
            return new Vector3(XPos[Random.Range(0, XPos.Length)], YPos, 0);
        }

    }


    [System.Serializable]

    public class ObjectsForSpawn
    {
        [SerializeField] private GameObject[] objects;

        public GameObject GetRandomObject()
        {
            return objects[Random.Range(0, objects.Length)];
        }
    }
}
