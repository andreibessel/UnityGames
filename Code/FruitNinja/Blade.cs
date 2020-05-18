using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVelo = .1f;
    private Vector3 lastMousePos;
    private Vector3 mouseVelo;

    private Collider2D col;


    Rigidbody2D rb;
    // Start is called before the first frame update
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col=GetComponent<Collider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        SetBladeToMouse();
        col.enabled=IsMouseMoving();
    }
    private void SetBladeToMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10; //distance 10 unit from camera

        rb.position=Camera.main.ScreenToWorldPoint(mousePos);
    }
    private bool IsMouseMoving()
    {
        Vector3 curPossition = transform.position;
        float mouseTravel = (curPossition - lastMousePos).magnitude;
        lastMousePos = curPossition;
        if (mouseTravel > minVelo)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
      
}
