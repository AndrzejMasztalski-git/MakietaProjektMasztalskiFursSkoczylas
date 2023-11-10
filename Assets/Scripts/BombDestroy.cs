using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    private bool shouldDestroy = false;

    public void DestroyObject()
    {
        shouldDestroy = true;
    }

    void Update()
    {
        if (shouldDestroy)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                    Destroy(hit.transform.gameObject);
            }

            shouldDestroy = false;
        }
    }
}
