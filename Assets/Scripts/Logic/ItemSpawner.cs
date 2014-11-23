using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

    public GameObject[] itemsToSpawn;
    public float[] priorities;

    private GameSettings settings;

	void Start () {
        this.settings = GameObject.FindObjectOfType<GameSettings>();
        InvokeRepeating("Attempt", 2, 10);
    }

    void Attempt() {
        int randIdx = Random.Range(0, this.itemsToSpawn.Length);
        GameObject itemToSpawn = this.itemsToSpawn[randIdx];
        int ranX, ranY;
        do {
            ranX = Random.Range (0, this.settings.mapSizeX);
            ranY = Random.Range (0, this.settings.mapSizeY);
        } while (this.settings.GetMap()[ranX, ranY]);
        if (Random.Range (0, 1) <= this.priorities[randIdx] * 100) {
            Debug.Log(string.Format("Found location for {2} at {0}, {1}", ranX, ranY, itemToSpawn.name));
            GameObject item = Instantiate(itemToSpawn) as GameObject;
            item.transform.position = new Vector3(ranX*4+2, 2, 36 - ranY*4);
        }
    }
}
