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

    void Start()
    {
        traps = new List<GameObject[]>();
        traps.Add(easyTraps);
        traps.Add(mediumTraps);
        traps.Add(hardTraps);
        traps.Add(bossTraps);
        Invoke("trySpawn", 0.5f);
    }

    private void trySpawn()
    {
        if (trapsAmount < maxTrapsByLevel[(int)curLevel] && Random.Range(0, 100) > 75)
        {
            spawnTrap();
        }

        Invoke("trySpawn", 0.5f);
    }

    void Update()
    {

    }

    // spawns an enemy based on the enemy level that you selected
    private void spawnTrap()
    {
        int spawnLevel = Random.Range(0, (int)curLevel);

        // spawns the enemy
        GameObject trap = (GameObject)Instantiate(traps[spawnLevel][Random.Range(0, traps[spawnLevel].Length)] , 
                                                    new Vector3(gameObject.transform.position.x + Random.Range(-5f, 5f),
                                                                gameObject.transform.position.y,
                                                                gameObject.transform.position.z + Random.Range(-5f, 5f)), Quaternion.identity);
        trap.transform.SetParent(transform);
     
        // Increase the total number of enemies spawned and the number of spawned enemies
        trapsAmount += spawnLevel + 1;
    }
    // Call this function from the enemy when it "dies" to remove an enemy count
    public void killTrap(GameObject trap)
    {
        trapsAmount -= ((int)trap.GetComponent<Trap>().GetTrapLevel()) + 1;
        Destroy(trap);
    }
}