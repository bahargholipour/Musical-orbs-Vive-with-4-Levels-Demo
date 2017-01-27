//github test - ignore!
using UnityEngine;

public class BurstScript : MonoBehaviour {

    public GameObject burstPrefab;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter()
    {
        GameObject khar = Instantiate(burstPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject); // destroy the grenade
        
    }
}
