using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour {
    public GameObject obstaclePrefab;
    // Start is called before the first frame update
    void Start() {
        Invoke("ObstacleGeneration", 0f);
    }

    // Update is called once per frame
    void Update() {

    }
    void ObstacleGeneration() {
        for (int i = 0; i < 50; i++) {
            GameObject obstacle = Instantiate(obstaclePrefab) as GameObject;
            Vector3 obsPos;
            obsPos.x = Random.Range(-200f, 200f);
            obsPos.y = Random.Range(-200f, 200f);
            obsPos.z = -.1f;
            obstacle.transform.position = obsPos;
        }
    }
}
