using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct ColorCount
{
    public ColorType colorType;
    public int count;
}

public class LightPostBehaviour : MonoBehaviour
{
    public UnityEvent<GameObject> lightActivatedEvent;

    [Header("Post Parts")]
    public GameObject[] pieces;
    public Light pointLight;
    public ParticleSystem particles;

    [Header("ColorType Values")]
    public ColorType colorType;
    public ColorCount[] bugCounts;

    private void Start()
    {
        bugCounts = new ColorCount[(int)ColorType.COUNT];

        for(int i = 0; i < (int)ColorType.COUNT; i++)
        {
            ColorCount count;
            count.colorType = (ColorType)i;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Orb"))
        {
            OrbBehaviour behaviour = other.GetComponent<OrbBehaviour>();
            MeshRenderer renderer = other.GetComponent<MeshRenderer>();

            if(colorType != ColorType.COUNT)
            {
                BugManager.instance.SetBugCount(colorType, 0);
                
                foreach (ColorCount cc in bugCounts)
                {
                    if(cc.colorType == behaviour.colorType)
                    {
                        for (int i = 0; i < cc.count; i++)
                            BugManager.instance.IncrementBugCount(colorType, 1);
                    }
                }
            }

            colorType = behaviour.colorType;

            foreach (GameObject p in pieces)
            {
                p.GetComponent<MeshRenderer>().material = renderer.material;
                if (p.name == "Sphere")
                    p.SetActive(true);
            }

            pointLight.color = renderer.material.color;

            var main = particles.GetComponent<ParticleSystem>().main;
            main.startColor = renderer.material.color;
            particles.GetComponent<ParticleSystem>().Play();

            if (behaviour.startPosition == Vector3.zero)
                Destroy(other.gameObject);
            else
                OrbManager.instance.ResetOrb(other.gameObject);

            lightActivatedEvent.Invoke(gameObject);
        }
        else if (other.gameObject.CompareTag("Bug"))
        {
            if (other.GetComponent<BugBehaviour>().colorType == colorType)
                BugManager.instance.IncrementBugCount(colorType, 1);
            else
                BugManager.instance.IncrementBugCount(colorType, -1);

            for (int i = 0; i < bugCounts.Length; i++)
            {
                if (bugCounts[i].colorType != other.GetComponent<BugBehaviour>().colorType)
                    continue;

                bugCounts[i].count++;
                break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bug"))
        {
            if (other.GetComponent<BugBehaviour>().colorType == colorType)
                BugManager.instance.IncrementBugCount(colorType, -1);
            else
                BugManager.instance.IncrementBugCount(colorType, 1);

            for (int i = 0; i < bugCounts.Length; i++)
            {
                if (bugCounts[i].colorType != other.GetComponent<BugBehaviour>().colorType)
                    continue;

                bugCounts[i].count--;
                break;
            }
        }
    }

    private void InformUI()
    {
        for (int i = 0; i < bugCounts.Length; i++)
        {
            if(bugCounts[i].colorType == colorType)
                BugManager.instance.IncrementBugCount(colorType, bugCounts[i].count);
            else
                BugManager.instance.IncrementBugCount(colorType, -bugCounts[i].count);
        }
    }
}
