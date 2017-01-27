using UnityEngine;
using System.Collections;
public class SpawnGameObjects : MonoBehaviour
{
	// public variables
	public float secondsBetweenSpawning = 0.1f;
	public float xMinRange = -5.0f;
	public float xMaxRange = 5.0f;
	public float yMinRange = -4.0f;
	public float yMaxRange = 6.0f;
	public float zMinRange = -5.0f;
	public float zMaxRange = 5.0f;
	public GameObject[] spawnObjects; // what prefabs to spawn
	private float nextSpawnTime;

    private SteamVR_Controller.Device Controller
    {
		get { return SteamVR_Controller.Input(0); }
    }

    void Awake()
    {
	    }

	// Use this for initialization
	void Start ()
	{
		// determine when to spawn the next object
		nextSpawnTime = Time.time+secondsBetweenSpawning;
        Debug.Log("lalala");
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        Debug.Log("lalala update");

        // if time to spawn a new game object
        if (Time.time  >= nextSpawnTime) {
            Debug.Log("lalala next spawn");

            // Spawn the game object through function below
            MakeThingToSpawn();

			// determine the next time to spawn the object
			nextSpawnTime = Time.time+secondsBetweenSpawning;
		}	

	}

	void MakeThingToSpawn ()
	{
		Vector3 spawnPosition = GameObject.FindGameObjectsWithTag("MainCamera")[0].transform.position;
        Debug.Log(spawnPosition.ToString("G4"));

		// get a random position between the specified ranges
		spawnPosition.x +=  Random.Range (xMinRange, xMaxRange);
		spawnPosition.y +=  Random.Range (yMinRange, yMaxRange);
		spawnPosition.z +=  Random.Range (zMinRange, zMaxRange);

		// determine which object to spawn
		int objectToSpawn = Random.Range (0, spawnObjects.Length);

		// actually spawn the game object
		GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition, transform.rotation) as GameObject;

		// make the parent the spawner so hierarchy doesn't get super messy
		spawnedObject.transform.parent = gameObject.transform;
	}
}
