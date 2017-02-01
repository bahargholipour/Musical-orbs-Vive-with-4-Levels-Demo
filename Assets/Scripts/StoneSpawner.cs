using UnityEngine;
using System.Collections;
public class StoneSpawner : MonoBehaviour
{
    // public variables
    public float secondsBetweenSpawning = 0.1f;
    public float xMinRange = -50.0f;
    public float xMaxRange = 50.0f;
    public float yMinRange = -40.0f;
    public float yMaxRange = 60.0f;
    public float zMinRange = -50.0f;
    public float zMaxRange = 50.0f;
    public float orbRadius = 0.15f;
    // public GameObject[] spawnObjects; // what prefabs to spawn
    public GameObject[] spawnStones;
    private float nextSpawnTime;


    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input(0); }
    }

    void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {
        // determine when to spawn the next object
        nextSpawnTime = Time.time + secondsBetweenSpawning;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < 2)
        {
            // if time to spawn a new game object
            if (Time.time >= nextSpawnTime)
            {
                // Spawn the game object through function below
                MakeThingToSpawn();

                // determine the next time to spawn the object
                nextSpawnTime = Time.time + secondsBetweenSpawning;
            }
        }
    }

    void MakeThingToSpawn()
    {
        Vector3 spawnPosition = GameObject.FindGameObjectsWithTag("MainCamera")[0].transform.position;

        // get a random position between the specified ranges
        spawnPosition.x += Random.Range(xMinRange, xMaxRange);
        spawnPosition.y += Random.Range(yMinRange, yMaxRange);
        spawnPosition.z += Random.Range(zMinRange, zMaxRange);

        // determine which object to spawn
        int objectToSpawn = Random.Range(0, spawnStones.Length);

      
            // actually spawn the game object
            GameObject spawnedStone = Instantiate(spawnStones[objectToSpawn], spawnPosition, transform.rotation) as GameObject;

            // make the parent the spawner so hierarchy doesn't get super messy
            spawnedStone.transform.parent = gameObject.transform;
        
    }
}
