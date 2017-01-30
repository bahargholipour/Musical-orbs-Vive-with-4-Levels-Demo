//github test - ignore!
using UnityEngine;

public class OrbBehavior : MonoBehaviour {

    public GameObject burstPrefab;
    public string orbNote;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter()
    {
        GameManager.gm.UpdateSequence(orbNote);
        Instantiate(burstPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject); // destroy the grenade
    }
}