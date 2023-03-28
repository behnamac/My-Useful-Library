using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WarMachine;

namespace Fundamental
{
public class AddExplode : MonoBehaviour
{
        [SerializeField] private ExplosionForce[] points;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                var random = Random.Range(0, points.Length);
                points[random].GetComponent<ExplosionForce>().Expload();
                print(random);
            }
        }


    }

}
