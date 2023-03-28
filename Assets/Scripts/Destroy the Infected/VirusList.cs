using System.Collections.Generic;
using UnityEngine;

namespace DestroyTheInfected
{
    public class VirusList : MonoBehaviour
    {
        public static VirusList Innstance;
        private List<NPCController> virusList = new List<NPCController>();

        private void Awake()
        {
            if (Innstance == null)
                Innstance = this;
        }

        public void AddList(NPCController virus)
        {
            virusList.Add(virus);
        }

        public void RemoveList(NPCController virus)
        {
            virusList.Remove(virus);
        }

        public int GetList() => virusList.Count;

    }
}
