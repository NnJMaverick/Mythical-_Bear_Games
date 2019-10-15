using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jetpack : MonoBehaviour {
    public Text fuelCounter;
    public Rigidbody2D arm;
    private float xSpeed = 0f;                                                          //Horizontal speed of player
    private float ySpeed = 0f;                                                          //Vertical speed of player
    private float fuel = 100f;                                                          //Amount of fuel left
    private float maxFuel = 100f;                                                       //Maximum amount of fuel allowed
    private bool hasFuel = true;                                                        //Does the player have fuel
    private float xMax = 200;                                                           //Maximum xPosition of the player
    private float yMax = 200;                                                           //Maximum yPosition of the player

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;                                               //Position of the player
        Vector3 up = new Vector3(0, 1, 0);
        Vector3 down = new Vector3(0, -1, 0);
        Vector3 left = new Vector3(-1, 0, 0);
        Vector3 right = new Vector3(1, 0, 0);

        if (hasFuel) {                                                                   //Does the player have fuel, if so move the player
            if (Input.GetKey(KeyCode.W)) {
                this.GetComponent<Rigidbody2D>().AddForce(down * 20);
                arm.AddForce(down * 20);
                fuel -= 100f * Time.deltaTime;
            } else if (Input.GetKey(KeyCode.S)) {
                this.GetComponent<Rigidbody2D>().AddForce(up * 20);
                arm.AddForce(up * 20);
                fuel -= 100f * Time.deltaTime;
            } else if (Input.GetKey(KeyCode.A)) {
                this.GetComponent<Rigidbody2D>().AddForce(right * 20);
                arm.AddForce(right * 20);
                fuel -= 100f * Time.deltaTime;
            } else if (Input.GetKey(KeyCode.D)) {
                this.GetComponent<Rigidbody2D>().AddForce(left * 20);
                arm.AddForce(left * 20);
                fuel -= 100f * Time.deltaTime;
            }

            if (pos.x >= xMax) {                                                            //Keeps the player in the game bounds
                pos.x = xMax;
                transform.position = pos;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, this.GetComponent<Rigidbody2D>().velocity.y);
            } else if (pos.x <= -xMax) {
                pos.x = -xMax;
                transform.position = pos;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, this.GetComponent<Rigidbody2D>().velocity.y);
            }
            if (pos.y >= yMax) {
                pos.y = yMax;
                transform.position = pos;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 0f);
            } else if (pos.y <= -yMax) {
                pos.y = -yMax;
                transform.position = pos;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 0f);
            }

            if (fuel <= 0) {                                                                 //If the player runs out of fuel
                fuel = 0;
                hasFuel = false;
                fuelCounter.color = new Color(255, 0, 0);
            }
        }
        
        fuel += 50f * Time.deltaTime;

        if (fuel >= maxFuel) {                                                           //Caps the fuel quantity
            fuel = maxFuel;
            hasFuel = true;
            fuelCounter.color = new Color(255, 255, 255);
        }

        fuelCounter.text = fuel.ToString();
    }
}
