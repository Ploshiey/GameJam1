using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceScript : MonoBehaviour
{
    public float xBounds = 11;
    public float yBounds = 6;
    float mouseX;
    float mouseY;

    [SerializeField] Rigidbody tablerb;
    public GameObject straightPiece;
    public GameObject leftPiece;
    public GameObject rightPiece;
    public GameObject intersectionPiece;
    public GameObject stopPiece;
    void Start()
    {
        
    }

    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 4.7f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mouseX = mousePos.x;
        mouseY = mousePos.y;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.rigidbody == tablerb)
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        if((mouseX <= xBounds + 0.5f || -mouseX >= -xBounds - 0.5f) && (mouseY <= yBounds + 0.5f || -mouseY >= -yBounds - 0.5f))
                        {
                            Instantiate(straightPiece, new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), mousePos.z), Quaternion.Euler(270f,0,0));
                        }
                    }
                }
            }
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit1;
            if (Physics.Raycast(ray1, out hit1))
            {
                if (hit1.rigidbody != tablerb)
                {
                    if (Input.GetKey(KeyCode.Mouse1))
                    {
                        Destroy(hit1.transform.gameObject);
                    }
                }
            }
        }
    }
}
