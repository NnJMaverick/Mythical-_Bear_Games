using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int health;
    float currentTime = 0f;
    private float startingTime = 180f;

    public Text OxText;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        OxText.text = currentTime.ToString();

        if (currentTime <= 0)
        {
            currentTime = 0;
            animator.SetBool("die", true);
        }
        
    }
    
    void OnCollision(Collider collider) {
        if (collider.tag.Equals("Obstacle")) {
            animator.SetBool("hurt", true);
            health--;
        }
    }
    
}
