using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    turretBuildManager buildManager;

    private void Start()
    {
        buildManager = turretBuildManager.instance;
    }

    public void purchaseStandardTurret()
    {
        buildManager.setTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void purchaseMissileLauncher()
    {
        buildManager.setTurretToBuild(buildManager.missileLauncherPrefab);
    }
}
