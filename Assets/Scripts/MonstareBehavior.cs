//github test - ignore!
using UnityEngine;

public class MonstareBehavior : MonoBehaviour {

    public GameObject burstPrefab;
    public string collectIndex;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter()
    {
        Instantiate(burstPrefab, transform.position, Quaternion.identity);
        GameManager.gm.UpdateCollectPuzzle(collectIndex);
        Destroy(gameObject);
    }
}