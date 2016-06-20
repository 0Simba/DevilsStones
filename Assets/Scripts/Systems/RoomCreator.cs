using UnityEngine;
using System.Collections;

public static class RoomCreator {
    

    static public RoomCreatorConfig config;

    static public RoomData CreateOnce () {
        config = GeneralConfig.instance.roomCreatorConfig;


        int x = config.size.RandomPick();
        int y = config.size.RandomPick();

        RoomData roomData = new RoomData(x, y);

        SetRoomUnwalkable(roomData);
        SetRoomObstacles(roomData);

        return roomData;
    }


    static public void SetRoomUnwalkable (RoomData roomData) {
        int unwalkableNumber = config.unwalkable.RandomPick();

        for (int i = 0; i < 500 && unwalkableNumber > 0; ++i) {
            Tile tile = roomData.RandomTile();

            if (ApplyTypeIfItsWalkable(tile, Tile.Type.unwalkable)) {
                unwalkableNumber--;
            }
        }
    }


    static public void SetRoomObstacles (RoomData roomData) {
        int obstacleNumber = config.obstacle.RandomPick();

        for (int i = 0; i < 500 && obstacleNumber > 0; ++i) {
            Tile tile = roomData.RandomTile();

            if (ApplyTypeIfItsWalkable(tile, Tile.Type.obstacle)) {
                obstacleNumber--;
            }
        }
    }
    

    static private bool ApplyTypeIfItsWalkable (Tile tile, Tile.Type targetType) {
        if (tile.type == Tile.Type.walkable) {
            tile.type = targetType;
            return true;
        }

        return false;
    }
}