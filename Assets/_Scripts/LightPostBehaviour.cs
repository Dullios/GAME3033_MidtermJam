using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPostBehaviour : MonoBehaviour
{
    [Header("Light Post Parts")]
    public GameObject[] pieces;
    public Light pointLight;
    public ParticleSystem particles;

    public ColorType colorType;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Orb"))
        {
            OrbBehaviour behaviour = other.GetComponent<OrbBehaviour>();
            MeshRenderer renderer = other.GetComponent<MeshRenderer>();
            
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
        }
    }
}
