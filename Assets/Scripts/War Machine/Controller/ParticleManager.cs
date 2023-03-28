using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    public static ParticleManager instance;
    public ParticleData[] particleData;
    Dictionary<string, ParticleData> particleDic;
    private void Awake()
    {
        instance = this;
        particleDic = new Dictionary<string, ParticleData>();
        for (int i = 0; i < particleData.Length; i++)
        {
            particleDic.Add(particleData[i].name, particleData[i]);
        }
    }

    public static Transform PlayParticle(string n)
    {
        return Instantiate(instance.particleDic[n].GetParticle());
    }
    public static Transform PlayParticle(string n, Vector3 pos, Quaternion Rot)
    {
        return Instantiate(instance.particleDic[n].GetParticle(), pos, Rot);
    }
    public static Transform PlayParticle(string n, Vector3 pos, Quaternion Rot, Transform parent)
    {
        return Instantiate(instance.particleDic[n].GetParticle(), pos, Rot, parent);
    }
}

[System.Serializable]
public class ParticleData
{
    public string name;
    public Transform[] particleObj;

    public Transform GetParticle()
    {
        return particleObj[Random.Range(0, particleObj.Length)];
    }
}

