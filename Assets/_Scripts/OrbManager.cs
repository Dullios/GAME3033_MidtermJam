using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    public GameObject orbPrefab;
    public Material[] orbMaterials;

    public static OrbManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void CreateComposite(GameObject orb1, GameObject orb2, Vector3 location, int index)
    {
        GameObject orbTemp = Instantiate(orbPrefab, location, Quaternion.identity);

        Material[] mats = orbTemp.GetComponent<MeshRenderer>().materials;
        mats[0] = orbMaterials[index];
        orbTemp.GetComponent<MeshRenderer>().materials = mats;
        orbTemp.GetComponent<OrbBehaviour>().colorType = (ColorType)index;
        // TODO: give orbTemp the max velocity of the two other orbs

        ResetOrb(orb1);
        ResetOrb(orb2);
    }

    private void ResetOrb(GameObject orb)
    {
        OrbBehaviour orbBehaviour = orb.GetComponent<OrbBehaviour>();
        orb.transform.position = orbBehaviour.startPosition;
        orbBehaviour.isLaunched = false;
        orb.GetComponent<Rigidbody>().velocity = Vector3.zero;
        orb.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
