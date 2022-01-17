using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToMove : MonoBehaviour {

    private Touch touch;
    //Controls how fast model will move
    private float SpeedModifier; 

    // Start is called before the first frame update
    void Start()
    {
        //increase this value to make object move faster
        SpeedModifier = 0.001f;
    }

    // Update is called once per frame
    void Update()
    {
        //when a finger is touching the screen
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            //when move gesture is performed
            if (touch.phase == TouchPhase.Moved)
            {
                //changes position of object in each frame, assigns new vector 3 values
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * SpeedModifier, transform.position.y, transform.position.z + touch.deltaPosition.y * SpeedModifier);
                //Original x value of car + how much our finger has moved for that frame inx * spped, keep y original, for z same logic as for x 
            }
        }
    }
}
