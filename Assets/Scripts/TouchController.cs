using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Transform cursor;

    private bool mouseDown;
    
    void Start()
    {
        cursor.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cursor.gameObject.SetActive(true);
            mouseDown = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            cursor.gameObject.SetActive(false);
            mouseDown = false;
        }

        if (mouseDown)
        {
            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            
            cursor.position = position;
        }
    }
}
