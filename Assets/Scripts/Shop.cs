using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    turretBuildManager buildManager;
    public turretBluePrint standardTurret;
    public turretBluePrint missileLauncher;

    private void Start()
    {
        buildManager = turretBuildManager.instance;
    }

    public void selectStandardTurret()
    {
        buildManager.selectTurretToBuild(standardTurret);
    }

    public void selectMissileLauncher()
    {
        buildManager.selectTurretToBuild(missileLauncher);
    }
}
