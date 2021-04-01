using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//DERIVED FROM https://www.youtube.com/watch?v=5Ue0waWtkY4&t=142s

/**
 * Moves the camera to one of the positions in the position index in a linear-interpolative form at a speed
 */
public class MoveCamera : MonoBehaviour
{

    public Vector3[] positions;
    public float speed;

    private int currentIndex = 0;

    // Update is called once per frame
    void Update()
    { 
        //sets the current position of the camera based on what the current index is
        Vector3 currentPos = positions[currentIndex];

        transform.position = Vector3.Lerp(transform.position, currentPos, speed * Time.deltaTime);
    }

    /**
     * Is call on a button pressed.
     * Changes what index the camera should be moved to.
     */
    public void moveToIndex(int index)
    {
    currentIndex = index;
    }
}
