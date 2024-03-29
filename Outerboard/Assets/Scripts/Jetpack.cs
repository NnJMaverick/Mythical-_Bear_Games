﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jetpack : MonoBehaviour{
    public Text fuelCounter;
    private float xSpeed = 0f;                                                          //Horizontal speed of player
    private float ySpeed = 0f;                                                          //Vertical speed of player
    private float fuel = 100f;                                                          //Amount of fuel left
    private float maxFuel = 100f;                                                       //Maximum amount of fuel allowed
    private bool hasFuel = true;                                                        //Does the player have fuel
    private float xMax = 200;                                                           //Maximum xPosition of the player
    private float yMax = 200;                                                           //Maximum yPosition of the player

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        Vector3 pos = transform.position;                                               //Position of the player
        
        if (hasFuel){                                                                   //Does the player have fuel, if so move the player
            if (Input.GetKey(KeyCode.W)){
                ySpeed--;
                fuel -= 100f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S)){
                ySpeed++;
                fuel -= 100f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.A)){
                xSpeed++;
                fuel -= 100f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D)){
                xSpeed--;
                fuel -= 100f * Time.deltaTime;
            }
        }

        if (fuel <= 0){                                                                 //If the player runs out of fuel
            fuel = 0;
            hasFuel = false;
            fuelCounter.color = new Color(255, 0, 0);
        }

        pos.x += xSpeed * Time.deltaTime;
        pos.y += ySpeed * Time.deltaTime;
        
        if (pos.x >= xMax) {                                                            //Keeps the player in the game bounds
            pos.x = xMax;
            xSpeed = 0;
        }else if (pos.x <= -xMax) {
            pos.x = -xMax;
            xSpeed = 0;
        }
        if (pos.y >= yMax) {
            pos.y = yMax;
            ySpeed = 0;
        }else if (pos.y <= -yMax) {
            pos.y = -yMax;
            ySpeed = 0;
        }

        transform.position = pos;
        fuel += 50f * Time.deltaTime;

        if (fuel >= maxFuel){                                                           //Caps the fuel quantity
            fuel = maxFuel;
            hasFuel = true;
            fuelCounter.color = new Color(255, 255, 255);
        }

        fuelCounter.text = fuel.ToString();
    }
}
