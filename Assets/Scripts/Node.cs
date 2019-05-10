using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Vector3 turretOffset;

    private Renderer rend;
    private Color startColor;
    [Header("Optional")]
    public GameObject turret;

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

        if (!buildManager.canBuild)
            return;

        if ( turret != null)
        {
            Debug.Log("Can't build turret there ! TODO : display to the user ");
        }

        buildManager.buildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.canBuild)
            return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
