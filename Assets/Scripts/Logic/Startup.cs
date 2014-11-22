using UnityEngine;
using System.Collections;
using System.IO;

public class Startup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.LoadLevel("Level1");
	}

    private bool LoadLevel(string fileName) {
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
                                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                cube.transform.position = new Vector3(pos * 4 + 2, 2, lineNum * 4 + 2);
                                cube.transform.localScale = new Vector3(4, 4, 4);
                                cube.renderer.material.mainTexture = Resources.LoadAssetAtPath<Texture>("Assets/Textures/Wall.png");
                                Debug.Log(cube.renderer.material.mainTexture);
                                Debug.Log(Resources.FindObjectsOfTypeAll(typeof(Texture))[0].name);
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
