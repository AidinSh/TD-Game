using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBuildManager : MonoBehaviour {

    public static turretBuildManager instance;

    private GameObject turretToBuild;
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

    public void setTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    } 

    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }
}
