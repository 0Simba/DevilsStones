using UnityEngine;
using System.Collections;

public class Tile {

    public enum Type {
        walkable,
        unwalkable,
        obstacle,
        door
    }


    public Tile (Type type, int appearence = 0) {
        this.type       = type;
        this.appearence = appearence;
    }


    public Type type;
    public int  appearence;
}