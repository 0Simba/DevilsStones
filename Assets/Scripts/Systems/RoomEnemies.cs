using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomEnemies : MonoBehaviour {


    /*===================================
    =            Static Part            =
    ===================================*/

    static public RoomEnemies       instance;
    static public RoomCreatorConfig config;

    static public void CreateOnce () {
        instance.CreateEnemies();
    }



    /*=====================================
    =            Instance Part            =
    =====================================*/
    
    public List<EnemiesGroupConfig> possibleGroups;


    void Awake () {
        instance = this;
    }


    void Start () {
        config = GeneralConfig.instance.roomCreatorConfig;
        InitPossibleGroups();
        EventBus.difficultyChanged += UpdatePossibleGroups;
    }


    void OnDestroy () {
        EventBus.difficultyChanged -= UpdatePossibleGroups;
    }


    void InitPossibleGroups () {
        possibleGroups = new List<EnemiesGroupConfig>();

        for (int i = 0; i < config.enemiesGroup.Length; ++i) {
            EnemiesGroupConfig item = config.enemiesGroup[i];

            if (item.difficulty.IsBetween(GameData.instance.difficulty)) {
                possibleGroups.Add(item);
            }
        }


        if (possibleGroups.Count == 0) {
            Debug.LogError("[Devil's Stones] RoomEnemies.InitPossibleGroups -> possibleGroups is empty");
        }
    }


    void UpdatePossibleGroups (int difficulty) {
        InitPossibleGroups();
    }


    public void CreateEnemies () {
        List<EnemiesGroupConfig> groupsToSpawn = EstablishGroupsToSpawn();
        SpawnGroups(groupsToSpawn);
    }


    public void SpawnGroups (List<EnemiesGroupConfig> groups) {
        for (int i = 0; i < groups.Count; ++i) {
            SpawnGroup(groups[i]);
        }
    }


    public void SpawnGroup (EnemiesGroupConfig group) {
        Vector3 spawnCenter = Vector3.zero;

        for (int i = 0; i < group.enemies.Length; ++i) {
            SpawnEnemy(group.enemies[i], spawnCenter);
        }
    }


    public void SpawnEnemy (GameObject enemy, Vector3 spawnCenter) {
        Vector2 offset        = Random.insideUnitCircle * 5;
        Vector3 spawnPosition = new Vector3(spawnCenter.x + offset.x, 0, spawnCenter.z + offset.y);

        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }


    public List<EnemiesGroupConfig> EstablishGroupsToSpawn () {
        List<EnemiesGroupConfig> groups                = new List<EnemiesGroupConfig>();
        int                      totalPatternChallenge = 0;

        while (totalPatternChallenge < config.challengeMinimumPerRoom) {
            int                groupIndex = Random.Range(0, possibleGroups.Count);
            EnemiesGroupConfig group      = possibleGroups[groupIndex];

            totalPatternChallenge += group.patternChallenge;
            groups.Add(group);
        }

        return groups;
    }

}