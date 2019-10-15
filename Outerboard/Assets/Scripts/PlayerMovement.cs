using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Camera cam;
    public GameObject jeb;


    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb = this.GetComponent<Rigidbody2D>();

        Vector3 pos = jeb.transform.position;
        pos.x += 3.18f;
        pos.y += -0.65f;
        transform.position = pos;
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
