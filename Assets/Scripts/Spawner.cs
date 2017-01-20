using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{   
    // The different trap levels
    public enum TrapLevels
    {
        Easy = 0,
        Medium = 1,
        Hard = 2,
        Boss = 3
    }

    // Trap level to be spawnedTrap
    public TrapLevels curLevel = TrapLevels.Easy;
    
    // Trap Prefabs
    public GameObject[] easyTraps;
    public GameObject[] mediumTraps;
    public GameObject[] hardTraps;
    public GameObject[] bossTraps;

    public List<GameObject[]> traps;
    
    private int trapsAmount = 0;
    [SerializeField] private int[] maxTrapsByLevel;

    private bool shouldSpawn()
    {
        if (trapsAmount < maxTrapsByLevel[(int)curLevel])
        {
            print(Time.deltaTime * Random.Range(0f, 100f));
        }

        return false;
    }

    void Start()
    {
        traps = new List<GameObject[]>();
        traps.Add(easyTraps);
        traps.Add(mediumTraps);
        traps.Add(hardTraps);
        traps.Add(bossTraps);
    }

    void Update()
    {
        if (shouldSpawn())
        {
            spawnTrap();
        }
    }

    // spawns an enemy based on the enemy level that you selected
    private void spawnTrap()
    {
        int spawnLevel = Random.Range(0, (int)curLevel);

        // spawns the enemy
        GameObject trap = (GameObject)Instantiate(traps[spawnLevel][Random.Range(0, traps[spawnLevel].Length)] , gameObject.transform.position, Quaternion.identity);
        // calls a function on the enemy that applies the spawner's ID to the enemy
        trap.SendMessage("setName", "HI");
     
        // Increase the total number of enemies spawned and the number of spawned enemies
        trapsAmount += spawnLevel;
    }
    // Call this function from the enemy when it "dies" to remove an enemy count
    public void killTrap(TrapLevels trapLevel)
    {
        trapsAmount -= (int)trapLevel;
    }
}