using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dungeon {

    public List<Room>    rooms;
    public DungeonConfig config;
    public Vector3       start;
    public int           floors;

    private int       restToPlace = 0;
    private List<int> placeLadderAtRestToPlace;


    public void Generate () {
        rooms  = new List<Room>();
        config = GeneralConfig.instance.dungeonConfig;
        floors = config.floorsNumber.Throw();

        for (int i = 0; i < floors; ++i) {
            GenerateFloor(i);
        }
    }


    public void GenerateFloor (int floorIndex) {

        int roomsNumber   = config.roomsNumber.Throw();
        int laddersNumber = (floorIndex < floors - 1) ? config.laddersNumber.Throw() : 0;
        SetPlaceLadderAtRestToPlace(laddersNumber, roomsNumber);

        Vector3 floorFirstPosition = new Vector3(0, floorIndex, 0);

        if (floorIndex == 0) {
            start = floorFirstPosition;
        }


        restToPlace = roomsNumber;
        GenerateRoom(floorFirstPosition);
    }


    public void GenerateRoom (Vector3 position) {
        restToPlace--;

        int neighbors = Mathf.Min(Random.Range(1, 5), restToPlace);

        List<Vector3> neightborsOffsets = NeighborsOffsets(neighbors, position);

        if (placeLadderAtRestToPlace.IndexOf(restToPlace) != -1) {
            neightborsOffsets.Add(Vector3.down);
        }


        for (int i = 0; i < neightborsOffsets.Count; ++i) {
            GenerateRoom(neightborsOffsets[i]);
        }

        Room room = new Room(position);
        rooms.Add(room);
    }


    public List<Vector3> NeighborsOffsets (int number, Vector3 from) {
        List<Vector3> possibleNeighbors = PossibleNeighbors(from);
        List<Vector3> neighborsOffsets  = new List<Vector3>();


        for (int i = 0; i < number && possibleNeighbors.Count > 0; ++i) {
            int index = Random.Range(0, possibleNeighbors.Count);
            neighborsOffsets.Add(possibleNeighbors[index]);
            possibleNeighbors.RemoveAt(index);
        }

        return neighborsOffsets;
    }


    public List<Vector3> PossibleNeighbors (Vector3 from) {
        List<Vector3> possibleNeighbors = new List<Vector3>();
        possibleNeighbors.Add(Vector3.forward);
        possibleNeighbors.Add(Vector3.back);
        possibleNeighbors.Add(Vector3.left);
        possibleNeighbors.Add(Vector3.right);

        for (int i = possibleNeighbors.Count - 1; i >= 0; --i) {
            if (RoomExist(from + possibleNeighbors[i])) {
                possibleNeighbors.RemoveAt(i);
            }
        }

        return possibleNeighbors;
    }


    public bool RoomExist (Vector3 position) {
        for (int i = 0; i < rooms.Count; ++i) {
            if (rooms[i].position == position) {
                return true;
            }
        }

        return false;
    }


    public void SetPlaceLadderAtRestToPlace (int laddersNumber, int roomsNumber) {
        placeLadderAtRestToPlace = new List<int>();


        int min = (int) (roomsNumber / 2);

        for (int i = 0; i < laddersNumber; ++i) {
            int at = Random.Range(min, roomsNumber);

            if (placeLadderAtRestToPlace.IndexOf(at) != -1) {
                i--;
            }
            else {
                placeLadderAtRestToPlace.Add(i);
            }
        }
    }


    public Room GetRoom (Vector3 position) {
        for (int i = 0; i < rooms.Count; ++i) {
            if (rooms[i].position == position) {
                return rooms[i];
            }
        }

        return rooms[0];
    }
}