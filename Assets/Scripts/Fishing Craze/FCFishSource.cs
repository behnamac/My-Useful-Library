using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = System.Random;

public class FCFishSource : MonoBehaviour
{
    public static FCFishSource Instance;

    private Random _random;
  //  private List<fish>


    private void Awake()
    {
        _random = new Random();

        if(Instance==null)
            Instance = this;

        _random = new Random();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
