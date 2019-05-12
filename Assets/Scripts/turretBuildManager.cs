using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBuildManager : MonoBehaviour {

    public static turretBuildManager instance;

    private turretBluePrint turretToBuild;
    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    void Awake()
    {
        if ( instance != null)
        {
            Debug.LogError("There is more build manager in the scene !");
            return;
        }
        instance = this;
    }

    public void selectTurretToBuild(turretBluePrint turret)
    {
        turretToBuild = turret;
    } 

    public void buildTurretOn (Node node)
    {
        if ( playerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        playerStats.money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position + node.turretOffset, Quaternion.identity);
        node.turret = turret;
    }

    public bool canBuild { get { return turretToBuild != null; } }
}
