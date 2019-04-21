using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Vector3 turretOffset;

    private Renderer rend;
    private Color startColor;
    private GameObject turret;

    turretBuildManager buildManager;
    
	
	void Start ()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = turretBuildManager.instance;
	}

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.getTurretToBuild() == null)
            return;

        if ( turret != null)
        {
            Debug.Log("Can't build turret there ! TODO : display to the user ");
        }

        GameObject turretToBuild = turretBuildManager.instance.getTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild,transform.position + turretOffset , transform.rotation);
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.getTurretToBuild() == null)
            return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
