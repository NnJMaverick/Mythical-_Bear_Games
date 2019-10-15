using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    private float xSpeed;                                                       //X speed
    private float ySpeed;                                                       //Y speed
    private float xMax = 200f;                                                  //X boundary
    private float yMax = 200f;                                                  //Y boundary
    private Vector3 deg;                                                        //Direction of motion

    // Start is called before the first frame update
    void Start() {
        xSpeed = Random.Range(-1f, 1f);
        ySpeed = Random.Range(-1f, 1f);
        deg = new Vector3(xSpeed, ySpeed, 0f);

        this.GetComponent<Rigidbody2D>().AddForce(deg * 1000);
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;

        if (pos.x >= xMax) {                                                            //Keeps the player in the game bounds
            pos.x = xMax;
            transform.position = pos;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-this.GetComponent<Rigidbody2D>().velocity.x, this.GetComponent<Rigidbody2D>().velocity.y);
        } else if (pos.x <= -xMax) {
            pos.x = -xMax;
            transform.position = pos;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-this.GetComponent<Rigidbody2D>().velocity.x, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (pos.y >= yMax) {
            pos.y = yMax;
            transform.position = pos;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, -this.GetComponent<Rigidbody2D>().velocity.y);
        } else if (pos.y <= -yMax) {
            pos.y = -yMax;
            transform.position = pos;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, -this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
