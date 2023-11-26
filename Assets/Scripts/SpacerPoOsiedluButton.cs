using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class SpacerPoOsiedluButton : MonoBehaviour
{
    public Camera MainCamera;
    public Camera PlayerCamera;
    public Button WalkButton;
    public SterowanieGraczem skryptSterowaniaGraczem;
    //public PlayerMovement skryptPlayerMovement;
    //public MoveCamera skryptMoveCamera;
    public GameObject capsulePrefab;
    public BoardManager boardManager;
    public GameObject cameraHolder;

    private void Start()
    {
        PlayerCamera.enabled = false;
        skryptSterowaniaGraczem.enabled = false;
        //skryptPlayerMovement.enabled = false;
        //skryptMoveCamera.enabled = false;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    MainCamera.enabled = true;
        //    PlayerCamera.enabled = false;

        //    skryptSterowaniaGraczem.enabled = false;
        //}
    }

    public void SwitchCamera()
    {

        GameObject capsule = Instantiate(capsulePrefab, boardManager.tile.transform.position, Quaternion.identity);
        cameraHolder.transform.SetParent(capsule.transform);
        cameraHolder.transform.position = capsule.transform.position;

        // Prze³¹czenie miedzy kamerami
        MainCamera.enabled = !MainCamera.enabled;
        PlayerCamera.enabled = !PlayerCamera.enabled;

        // Aktywuj sterowanie graczem po przejsciu na planszê
        skryptSterowaniaGraczem.enabled = true;
        //skryptPlayerMovement.enabled = true;
        //skryptMoveCamera.enabled = true;
    }



}
