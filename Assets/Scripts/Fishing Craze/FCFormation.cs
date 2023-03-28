using UnityEngine;
using DG.Tweening;

public enum WorldType { Local, Global }

public static class FCFormation
{
    public static void SquareFormation(Transform[] gameObject, Vector3 centerPoint, int maxXline, int maxZline, float space)
    {
        int counterX = 0;
        int counterZ = 0;
        int counterY = 0;

        for (int i = 0; i < gameObject.Length; i++)
        {
            Vector3 offset = new Vector3(counterX * space, counterY * space, counterZ * space);
            gameObject[i].DOMove(centerPoint + offset, 0.2f);
            counterX++;
            if (counterX >= maxXline)
            {
                counterX = 0;
                counterZ++;
                if (counterZ >= maxZline)
                {
                    counterZ = 0;
                    counterY++;
                }
            }
        }
    }

    public static void LineFormation(Transform[] gameobject, Vector3 centerPoint, WorldType world, Vector3 axis, float space)
    {
        for (int i = 0; i < gameobject.Length; i++)
        {
            if (world == WorldType.Global)
            {
                gameobject[i].DOMove(centerPoint + (axis * (i * space)), 0.2f);
            }
            else
            {
                gameobject[i].DOLocalMove(centerPoint + (axis * (i * space)), 0.2f);
            }
        }
    }



}
