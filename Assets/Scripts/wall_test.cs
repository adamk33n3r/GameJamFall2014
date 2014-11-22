using UnityEngine;
using System.Collections;

public class wall_test : MonoBehaviour {
    public Texture tex2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void HitByRaycast(GameObject source) {
        this.renderer.material.mainTexture = this.tex2;
    }
}
