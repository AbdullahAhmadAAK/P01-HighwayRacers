using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 20;
    public int numberOfTiles = 5;
    private List<GameObject> activeTiles = new List<GameObject>();

    // create a reference list of all the files u need in this script. tile manager refs

    // see hierachy from here, find on net
    // alag script for attaching objects to tile manager script

    // dont copy long lines from tutorials, try to reduce as tutroials may noy be effective
    // can copy snippets word to word,if small
    // linq, methods built in can be found with this. 1 liner codes easy, to avoid plag

    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - 20 > zSpawn - (numberOfTiles * tileLength)) 
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
       // activeTiles[0].set

        // instead of deleting, set it as inactive
        // activeTiles[0] set inactive, reposition, and set active again. instead of deleting and creating which is resource heavy
    }



}
