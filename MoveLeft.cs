using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30.0f;
    private PlayerController playerControllerScript;
    private float leftBound = -15;//left boundary(limita din stanga)
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //in gameobject we will find the name of our object 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)//if our gameOver is false or the game is not over we will move things to the left
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            //we compare our gameobject current position to see if goes past the left boundary on the left size and make sure that is an obstacle 
            //because it can delete our backgound
        {
            Destroy(gameObject);
        }

    }
}
