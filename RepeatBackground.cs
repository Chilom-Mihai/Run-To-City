using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;// we use a vector3 for the coordinate and that coordinate will be our start position of the player
    private float repeaatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;//the start position will be equal with the current position of our object
        repeaatWidth = GetComponent<BoxCollider>().size.x / 2; // we will get the specifix size of the box colider on the x axis
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x < startPos.x - repeaatWidth)//we check if our current position is less than start position
        {
            transform.position = startPos;//then we will reset the entire position of our object back to our start pos
        }
    }
}
