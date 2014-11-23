using UnityEngine;
using System.Collections;
using System.IO;

public class Startup : MonoBehaviour {

    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public GameObject lampPrefab;
    public GameObject buttonPrefab;

    public Color ambientColor;

    private GameSettings settings;

	// Use this for initialization
	void Start () {
        this.settings = GameObject.FindObjectOfType<GameSettings>();
//        Random.seed = Time.time;
        RenderSettings.ambientLight = ambientColor;
        if (!this.LoadLevel("Level1")) {
            Debug.Log ("Couldn't load level");
        }
        PlaceButtons();
        SetUpLights();
	}

    private void SetUpLights() {
        for (int i = 0; i < (this.settings.mapSizeX * this.settings.mapSizeY) / 4; i++) {
            Vector3 randPos = new Vector3(Random.Range (0,this.settings.mapSizeX*4), 10, Random.Range (0,this.settings.mapSizeY*4));
            GameObject lamp = Instantiate(this.lampPrefab) as GameObject;
            lamp.transform.position = randPos;
            StartCoroutine(StartSwinging(lamp));
        }
    }

    private IEnumerator StartSwinging(GameObject lamp) {
        yield return new WaitForSeconds(Random.Range (0f,2f));
        lamp.GetComponent<Animator>().SetTrigger("Swing");
    }

    private void PlaceButtons() {
        for (int times = 0; times < this.settings.GetPlayerCount(); times++) {
            GameObject btn = Instantiate(this.buttonPrefab) as GameObject;
            int ranX, ranY;
            do {
                ranX = Random.Range (0, this.settings.mapSizeX);
                ranY = Random.Range (0, this.settings.mapSizeY);
            } while (this.settings.GetMap()[ranX, ranY]);
            btn.transform.position = new Vector3(ranX*4+2, 0, 36 - ranY*4);
        }
    }

    private bool LoadLevel(string fileName) {
        for (int row = 0; row < this.settings.mapSizeY; row++) {
            for (int col = 0; col < this.settings.mapSizeX; col++) {
                GameObject floor = Instantiate(this.floorPrefab) as GameObject;
                floor.transform.position = new Vector3(col * 4 + 2, -2, 36 - row * 4);
                floor.transform.localScale = new Vector3(4,4,4);
            }
        }
//        try {
            string line;
            StreamReader reader = new StreamReader("Assets/Levels/" + fileName + ".txt");
            using (reader) {
                int lineNum = 0;
                do {
                    line = reader.ReadLine();
                    if (line != null) {
                        int pos = 0;

                        foreach (char ch in line) {
                            if (ch == 'x') {
                                GameObject cube = Instantiate(this.wallPrefab) as GameObject;
//                                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                cube.transform.position = new Vector3(pos * 4 + 2, 2, 36 - lineNum * 4);
                                this.settings.addBlock(pos, lineNum);
                                cube.transform.localScale = new Vector3(4, 4, 4);
//                                cube.renderer.material.mainTexture = Resources.LoadAssetAtPath<Texture>("Assets/Textures/Wall.png");
//                                Debug.Log(cube.renderer.material.mainTexture);
//                                Debug.Log(Resources.FindObjectsOfTypeAll(typeof(Texture))[0].name);
                            }
                            pos++;
                        }
                    }
                    lineNum++;
                } while (line != null);
                reader.Close ();
                return true;
            }
//        } catch (System.Exception ex) {
//            Debug.Log(ex.Message);
//            return false;
//        }
    }
}
