using System.Collections.Generic;
using UnityEngine;

namespace CatchTheGiant
{
    public class CGPlayerList : MonoBehaviour
    {
        public static CGPlayerList Instance;

        public List<CGCharacterManager> playerList;

        public bool CapacityFull;

        public int killedGiant
        {
            get;
            set;
        }



        private void Awake()
        {
            Instance = this;
            playerList = new List<CGCharacterManager>();

        }

        public void AddList(CGCharacterManager p)
        {
            playerList.Add(p);
        }

        public void RemoveList(CGCharacterManager p)
        {
            playerList.Remove(p);
            Destroy(p.gameObject);
            if (playerList.Count <= 0)
            {
                CGGameManager.Instance.LoseState();
            }
        }

        public void SetPlayerParent(CGCharacterManager col)
        {
            col.transform.SetParent(transform);
        }


        public void SetGiant(CGEnenmyController giant)
        {
            giant.transform.SetParent(transform);
        }

        public void RemoveGiant()
        {
            var oldGiant = GetComponentInChildren<CGEnenmyController>();
            oldGiant.getDamage = false;
            oldGiant.transform.SetParent(null);
        }



    }
}
