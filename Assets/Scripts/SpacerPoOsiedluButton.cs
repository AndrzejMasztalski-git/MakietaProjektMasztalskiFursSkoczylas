using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class SpacerPoOsiedluButton : MonoBehaviour
{
    public float destinationX = 2f;
    public float destinationY = 0.3f;
    public float destinationZ = 1f;
    public float speed = 1f;

    public GameObject capsulePrefab;

    private GameObject capsule;


    private void Start()
    {
        Camera.main.transform.position = new Vector3(2.28f, 10.09f, -16.17f);
        Camera.main.transform.rotation = Quaternion.Euler(30f, 0f, 0f);


        if (capsulePrefab != null)
        {
            capsule = Instantiate(capsulePrefab, new Vector3(0f,0f,0f), Quaternion.identity);
            capsule.SetActive(false);
        }
        else
        {
            Debug.Log("Prefab kapsu³y nie jest przypisany!");
        }
    }


    public void MoveToCordinates()
    {
        Camera.main.transform.position = new Vector3(destinationX, destinationY, destinationZ);

        if (capsule != null)
        {
            capsule.SetActive(true);

            capsule.transform.position = Camera.main.transform.position;

            SterowanieGraczem sterowanieGraczem = capsule.AddComponent<SterowanieGraczem>();
            sterowanieGraczem.AktywujKontrole();
        }

    }
}
