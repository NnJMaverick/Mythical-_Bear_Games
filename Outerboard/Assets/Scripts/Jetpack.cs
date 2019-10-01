﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour{
    private float xSpeed = 0f;                                                          //Horizontal speed of player
    private float ySpeed = 0f;                                                          //Vertical speed of player
    private float fuel = 1f;                                                            //Amount of fuel left
    private float maxFuel = 1f;                                                         //Maximum amount of fuel allowed
    private bool hasFuel = true;                                                        //Does the player have fuel

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        Vector3 pos = transform.position;                                               //Position of the player
        
        if (hasFuel){                                                                   //Does the player have fuel, if so move the player
            if (Input.GetKey(KeyCode.W)){
                ySpeed--;
                fuel -= .5f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S)){
                ySpeed++;
                fuel -= .5f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.A)){
                xSpeed++;
                fuel -= .5f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D)){
                xSpeed--;
                fuel -= .5f * Time.deltaTime;
            }
        }
        if (fuel <= 0){                                                                 //If the player runs out of fuel
            fuel = 0;
            hasFuel = false;
        }

        pos.x += xSpeed * Time.deltaTime;
        pos.y += ySpeed * Time.deltaTime;
        transform.position = pos;
        fuel += .2f * Time.deltaTime;

        if (fuel >= maxFuel){                                                           //Caps the fuel quantity
            fuel = maxFuel;
            hasFuel = true;
        }
    }
}