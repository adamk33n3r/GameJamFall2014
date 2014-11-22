using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameSettings : MonoBehaviour {
    public int mapSizeX = 20, mapSizeY = 10;
    private bool[,] map;

    void Start() {
        this.map = new bool[this.mapSizeX, this.mapSizeY];
    }

    public void addBlock (int x, int y) {
        this.map[x, y] = true;
    }

    public bool[,] GetMap() {
        return this.map;
    }
}
