using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    public GameManager gameManager;
    public bool shouldDestroy = false;
    public bool wasDestroyed = false;
    public void DestroyObject()
    {
        shouldDestroy = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (shouldDestroy)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.CompareTag("Building") && gameManager.bombCounter>0)
                    {
                        Destroy(hit.transform.gameObject);
                        gameManager.bombCounter--;
                        gameManager.bombsLeft.text = $"{gameManager.bombCounter}";
                    }
                    else if(gameManager.bombCounter<=0)
                    {
                        gameManager.bombsLeft.text = "No bombs left!";
                    }
                   
                }

                shouldDestroy = false;
            }
        }
        
    }
}
