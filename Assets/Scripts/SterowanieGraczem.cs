using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SterowanieGraczem : MonoBehaviour
{
    public float predkoscPoruszania = 1f;

    private bool kontrolaAktywowana = false;

    void Update()
    {
        if (kontrolaAktywowana)
        {
            float ruchPrzodTyl = Input.GetAxis("Vertical");
            float ruchLewoPrawo = Input.GetAxis("Horizontal");

            Vector3 ruch = new Vector3(ruchLewoPrawo, 0f, ruchPrzodTyl);

            ruch = Camera.main.transform.TransformDirection(ruch);

            ruch.y = 0f;

            ruch.Normalize();

            transform.Translate(ruch * predkoscPoruszania * Time.deltaTime);

            Camera.main.transform.position = transform.position;
            Camera.main.transform.rotation = transform.rotation;
        }
    }

    public void AktywujKontrole()
    {
        kontrolaAktywowana = true;
        transform.rotation = Quaternion.identity;
        Camera.main.transform.rotation = Quaternion.Euler(0f,0f,0f);
    }
}

