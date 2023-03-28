using UnityEngine;

namespace CatchTheGiant
{
    public class CGPlayerCollision : MonoBehaviour
    {
        private int xLine = 1;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.CompareTag("AI") && !collision.gameObject.GetComponent<CGCharacterManager>().canMove)
            {
                var ai = collision.gameObject.GetComponent<CGCharacterManager>();
                var aiProp = collision.gameObject.GetComponent<CGCharacterManager>();
                ai.canMove = true;
                aiProp.canMove = true;
                aiProp.changeColor();
                CGPlayerList.Instance.AddList(ai);
                CGPlayerList.Instance.SetPlayerParent(aiProp);
            }

            else if (collision.CompareTag("Obstcle"))
            {
                var ai = GetComponent<CGCharacterManager>();
                CGPlayerList.Instance.RemoveList(ai);
                //Destroy(gameObject);
            }

            else if (collision.gameObject.GetComponent<CGEnenmyController>())
            {
                var playerManager = CGPlayerList.Instance;
                var enemy = collision.GetComponent<CGEnenmyController>();

                if (playerManager.CapacityFull)
                {
                    if (enemy.activeEnemy) return;
                    playerManager.RemoveGiant();
                    playerManager.CapacityFull = false;

                }

                if (!enemy.activeEnemy)
                {
                    enemy.activeEnemy = true;
                    CGPlayerList.Instance.SetGiant(enemy);
                    enemy.MoveToCenter(Vector3.zero);
                    enemy.getDamage = true;
                    playerManager.CapacityFull = true;
                }

            }

            else if (collision.tag == "FinishLine")
            {

                CGPlayerMovement.Instance.GoToXline();
                for (int i = 1; i < CGPlayerList.Instance.playerList.Count; i++)
                {
                    CGPlayerList.Instance.playerList[i].GetComponent<Collider>().enabled = false;
                }
            }
            else if (collision.tag == "X")
            {

                xLine++;
                if (xLine >= CGPlayerMovement.Instance.CalculateXline())
                    CGGameManager.Instance.WinState();
                print("pass");
                collision.enabled = false;
            }
        }


    }
}
