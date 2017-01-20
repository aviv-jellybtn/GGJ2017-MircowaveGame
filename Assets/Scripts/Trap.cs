using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
    [SerializeField]
    Spawner.TrapLevels level;
    Spawner spawner;

    protected void Die()
    {
        GameObject.Find("Spawner").GetComponent<Spawner>().killTrap(gameObject);
    }

    public Spawner.TrapLevels GetTrapLevel()
    {
        return level;
    }
}
