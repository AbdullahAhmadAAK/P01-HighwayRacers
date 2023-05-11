using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{

    public GameObject[] terrainPrefabs;
    public float zSpawn = 0;
    public float terrainLength = 200;
    public int numberOfTerrains = 3;
    private List<GameObject> activeTerrains = new List<GameObject>();
    public static float terrainsPassed = 0;

    int terrainTurn = 2;

    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        terrainsPassed = 0;

        for(int tileIndex = 0; tileIndex < numberOfTerrains; tileIndex++)
        {
            GameObject go = Instantiate( terrainPrefabs[tileIndex], transform.forward * zSpawn, transform.rotation );
            activeTerrains.Add(go);
            if(tileIndex != 0 && tileIndex != 1)
                activeTerrains[tileIndex].SetActive(false);
            else
            {
                activeTerrains[tileIndex].SetActive(true);
                zSpawn += 200;
            }
                

            
        }

         // this is done 1 time, so that in Update() new terrains are spawned at the correct position

        
    
    /*
        for (int i = 0; i < numberOfTerrains; i++)
        {
            SpawnTerrain(Random.Range(0, terrainPrefabs.Length));

        }
    */

    }

    // Update is called once per frame
    void Update()
    {

        // pooling implementation

        // initially 1 terrain only

        // cross half the terrain (zspawn-100), SPAWNTERRAIN the next terrain (pool of 2 or 3)
        if (playerTransform.position.z - 200 > zSpawn - (1 * terrainLength))
        {
            // random generation still left
            OffTerrain(terrainTurn);

        }

       
        // cross the full terrain (zspawn), OFFTERRAIN the prev terrain
        if (playerTransform.position.z - 100 > zSpawn - (1 * terrainLength))
        {
            if(terrainTurn == numberOfTerrains-1)
                terrainTurn = 0;
            else
                terrainTurn++;

            SpawnTerrain(terrainTurn);
            terrainsPassed += 1;
        }

        // as soon as cross the terrain completely (obj passes through zSpawn), OFFTERRAIN()
        // immediately call SPAWNTERRAIN() on randomly gen tileIndex, that's not the previous one



        // this is simple cyclic implementation

        /*
        if (playerTransform.position.z - 200 > zSpawn - (numberOfTerrains * terrainLength))
        {
            activeTerrains[terrainTurn].transform.position = transform.forward * (zSpawn);
            zSpawn += 200;       

            if(terrainTurn == 2)
                terrainTurn = 0;
            else
                terrainTurn++;
 
        

        /*
            SpawnTerrain(Random.Range(0, terrainPrefabs.Length));
            OffTerrain();
        */
        //}
        
    
    }

    public void SpawnTerrain(int tileIndex)
    {

        activeTerrains[tileIndex].transform.position = transform.forward * (zSpawn);
        zSpawn += 200;
        activeTerrains[tileIndex].SetActive(true);

    /*
        GameObject go = Instantiate(terrainPrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTerrains.Add(go);
        Debug.Log(tileIndex);
        //activeTerrains.SetActive(true);
        zSpawn += terrainLength;
    */
    }

    private void OffTerrain(int tileIndex)
    {

        activeTerrains[tileIndex].SetActive(false);

    /*
        Destroy(activeTerrains[0]);
        activeTerrains.RemoveAt(0);
    */

        //activeTerrains[0].SetActive(false);

        // instead of deleting, set it as inactive
        // activeTiles[0] set inactive, reposition, and set active again. instead of deleting and creating which is resource heavy
    }
}
