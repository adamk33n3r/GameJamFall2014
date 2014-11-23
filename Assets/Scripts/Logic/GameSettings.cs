using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameSettings : MonoBehaviour {
    public int mapSizeX = 20, mapSizeY = 10;
    public bool nodie = false;
    private bool[,] map;
    private int playerCount;

    void Awake() {
        this.playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
        this.map = new bool[this.mapSizeX, this.mapSizeY];
    }

    public void addBlock (int x, int y) {
        this.map[x, y] = true;
    }

    public bool[,] GetMap() {
        return this.map;
    }

    public int GetPlayerCount() {
        return this.playerCount;
    }

    public void setAmbient(Color color) {
        RenderSettings.ambientLight = color;
    }

    public Color getAmbient() {
        return RenderSettings.ambientLight;
    }
}
