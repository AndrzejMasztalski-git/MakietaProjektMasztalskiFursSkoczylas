using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTreesFountains : MonoBehaviour
{

    public GameObject treePrefab;
    public GameObject fountainPrefab;
    public BoardManager boardManager;
    public void SpawnTrees(Vector3 positionObject)
    {
        System.Random rand = new();

        int numberofTrees = rand.Next(1, 3);
        

        for(int i = 0; i<numberofTrees; i++)
        {
            double randomZ = 0.0;
            float randomZZ = 0.0f;
            double randomX = 0.0;
            float randomXX = 0.0f;
            int temp = rand.Next(0, 1);
            if(temp == 0)
            {
                randomZ = rand.NextDouble() * (-1.25 - (-2.5)) + (-2.5);
                randomZZ = (float)randomZ;
            }
            else
            {
                randomZ = rand.NextDouble() * (2.5 - (1.25)) + (2.5);
                randomZZ = (float)randomZ;
            }

            int temp1 = rand.Next(0, 1);
            if (temp1 == 0)
            {
                randomX = rand.NextDouble() * (-1.25 - (-2.5)) + (-2.5);
                randomXX = (float)randomX;
            }
            else
            {
                randomX = rand.NextDouble() * (2.5 - (1.25)) + (2.5);
                randomXX = (float)randomX;
            }
            Debug.Log($"{randomX}, {randomZ}");

            
            var px = positionObject.x;
            var py = positionObject.y;
            var pz = positionObject.z;
            Vector3 pos = new Vector3(px + randomXX, py, pz + randomZZ);
            Instantiate(treePrefab, pos, Quaternion.identity);
            Debug.Log(positionObject);
        }

        
    }

    public void SpawnFountains(Vector3 positionObject)
    {
        System.Random rand = new();

        int numberofTrees = rand.Next(1, 2);


        for (int i = 0; i < numberofTrees; i++)
        {
            double randomZ = 0.0;
            float randomZZ = 0.0f;
            double randomX = 0.0;
            float randomXX = 0.0f;
            int temp = rand.Next(0, 1);
            if (temp == 0)
            {
                randomZ = rand.NextDouble() * (-1.25 - (-2.5)) + (-2.5);
                randomZZ = (float)randomZ;
            }
            else
            {
                randomZ = rand.NextDouble() * (2.5 - (1.25)) + (2.5);
                randomZZ = (float)randomZ;
            }

            int temp1 = rand.Next(0, 1);
            if (temp1 == 0)
            {
                randomX = rand.NextDouble() * (-1.25 - (-2.5)) + (-2.5);
                randomXX = (float)randomX;
            }
            else
            {
                randomX = rand.NextDouble() * (2.5 - (1.25)) + (2.5);
                randomXX = (float)randomX;
            }
            Debug.Log($"{randomX}, {randomZ}");

            var bounds = positionObject;
            var px = bounds.x;
            var py = bounds.y;
            var pz = bounds.z;
            Vector2 pos = new Vector3(px + randomXX, py, pz + randomZZ);
            Instantiate(treePrefab, pos, Quaternion.identity);
            Debug.Log(positionObject);
        }
    }
}
