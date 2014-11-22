using UnityEngine;
using System.Collections;
using System.IO;

public class Startup : MonoBehaviour {

    public GameObject wallPrefab;
    public GameObject floorPrefab;

	// Use this for initialization
	void Start () {
        this.LoadLevel("Level1");
	}

    private bool LoadLevel(string fileName) {
        for (int row = 0; row < 10; row++) {
            for (int col = 0; col < 10; col++) {
                GameObject floor = Instantiate(this.floorPrefab) as GameObject;
                floor.transform.position = new Vector3(col * 4 + 2, -2, 36 - row * 4);
                floor.transform.localScale = new Vector3(4,4,4);
            }
        }
        try {
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
        } catch (System.Exception ex) {
            System.Console.WriteLine("{0}\n", ex.Message);
            return false;
        }
    }
}
