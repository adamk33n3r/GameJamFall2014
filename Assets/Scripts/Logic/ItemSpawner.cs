using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

    public GameObject[] itemsToSpawn;
    public int[] priorities;

    private GameSettings settings;

	void Start () {
        this.settings = GameObject.FindObjectOfType<GameSettings>();
        InvokeRepeating("Attempt", 2, 10);
    }
	
	void Update () {
	}

    void Attempt() {
        GameObject itemToSpawn = this.itemsToSpawn[Random.Range(1, this.itemsToSpawn.Length)];
        int ranX, ranY;
        do {
            ranX = Random.Range (0, this.settings.mapSizeX);
            ranY = Random.Range (0, this.settings.mapSizeY);
        } while (this.settings.GetMap()[ranX, ranY]);
        Debug.Log(string.Format("Found location at {0}, {1}", ranX, ranY));
        if (Random.Range (0, 1) <= 25) {
            GameObject item = Instantiate(itemToSpawn) as GameObject;
            item.transform.position = new Vector3(ranX*4+2, 2, 36 - ranY*4);
        }
    }
}
