using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorMovement : MonoBehaviour
{
    float Speed = 3;
    GameObject Participant;
    GameObject door;
    doorPlacement seter;


    void Start()
    {
        Participant = GameObject.Find("avatar_001");
        door = GameObject.Find("Door");
        seter = door.GetComponent<doorPlacement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if participant can get into the door and react correspond it
        if (seter.DoorWidth >= Participant.transform.localScale[0])
        {
            door.transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }
        // Checks if the door pass the participant and switch door if true

    }
}
