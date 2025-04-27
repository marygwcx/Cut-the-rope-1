using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Transform cursor;

    private bool mouseDown;
    
    void Start()
    {
        cursor.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
            cursor.gameObject.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            cursor.gameObject.SetActive(false);
        }


        if (mouseDown)
        {
            cursor.position = ScreenToWorldPoint(Input.mousePosition) ;
        }
    }

    Vector3 ScreenToWorldPoint(Vector3 screenPoint)
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
        worldPoint.z = 0;
        
        return worldPoint;
    }
}
