using UnityEngine;

namespace ColorJump
{
    public class UıManager : MonoBehaviour
    {

        public GameObject WinPanel;
        public GameObject losePanel;
        public static UıManager Instance;
        private void Awake()
        {
            Instance = this;
        }
        public void death()
        {
            losePanel.gameObject.SetActive(true);
        }
    }
}
