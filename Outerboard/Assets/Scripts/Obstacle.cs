using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    private float xSpeed;
    private float ySpeed;
    private float xMax = 200f;
    private float yMax = 200f;
    // Start is called before the first frame update
    void Start() {
        xSpeed = Random.Range(-1f, 1f);
        ySpeed = Random.Range(-1f, 1f);
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;
        pos.x += xSpeed;
        pos.y += ySpeed;

        if (pos.x >= xMax) {                                                            //Keeps the player in the game bounds
            pos.x = xMax;
            xSpeed = -xSpeed;
        } else if (pos.x <= -xMax) {
            pos.x = -xMax;
            xSpeed = -xSpeed;
        }
        if (pos.y >= yMax) {
            pos.y = yMax;
            ySpeed = -ySpeed;
        } else if (pos.y <= -yMax) {
            pos.y = -yMax;
            ySpeed = -ySpeed;
        }

        transform.position = pos;
    }
}
