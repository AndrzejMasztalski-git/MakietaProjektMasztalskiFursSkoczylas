using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Build : MonoBehaviour
{
    public struct BuildingStruct
    {
        public Button buildButton; // this button places the building on the map
        public Transform placeSpot; // the spot where the building will go
        public GameObject buildingGraphic; // building graphics
        public bool isOccupied; // check if spot is free to build
    }
    public BuildingStruct Cube;
    public BuildingStruct Sphere;
   
    void Start()
    {
        Cube.buildButton.onClick.AddListener(BuildCube);
        Sphere.buildButton.onClick.AddListener(BuildSphere);
    }

    void Update()
    {
        
    }

    public void BuildCube()
    {

    }

    public void BuildSphere()
    {
        
    }
}
