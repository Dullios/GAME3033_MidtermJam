using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehaviour : MonoBehaviour
{
    public ColorType colorType;
    public Vector3 startPosition;
    public bool isLaunched;

    private void OnCollisionEnter(Collision collision)
    {
        if(isLaunched && collision.gameObject.CompareTag("Orb"))
        {
            int compositeColor = CompositeIndex(collision.gameObject.GetComponent<OrbBehaviour>().colorType);

            if (compositeColor != -1)
            {
                OrbManager.instance.CreateComposite(gameObject, collision.gameObject, collision.GetContact(0).point, compositeColor);
            }
        }
    }

    private int CompositeIndex(ColorType color)
    {
        // Blue = 0, GREEN = 1, ORANGE = 2, PURPLE = 3, RED = 4, YELLOW = 5

        int composite = -1;

        switch (colorType)
        {
            case ColorType.RED:
                if (color == ColorType.YELLOW)
                    composite = 2;
                else if (color == ColorType.BLUE)
                    composite = 3;
                break;
            case ColorType.YELLOW:
                if (color == ColorType.BLUE)
                    composite = 1;
                else if (color == ColorType.RED)
                    composite = 2;
                    break;
            case ColorType.BLUE:
                if (color == ColorType.RED)
                    composite = 3;
                else if (color == ColorType.YELLOW)
                    composite = 1;
                    break;
        }

        return composite;
    }

    public void LaunchOrb()
    {
        isLaunched = true;
        StartCoroutine(LaunchCoroutine());
    }

    IEnumerator LaunchCoroutine()
    {
        yield return new WaitForSeconds(1);

        isLaunched = false;
    }
}
