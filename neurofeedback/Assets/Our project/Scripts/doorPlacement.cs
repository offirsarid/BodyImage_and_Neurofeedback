using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class doorPlacement : MonoBehaviour
{
    GameObject door;
    float Speed = 1;
    List<Transform> doorParts;
    List<float> doorsArr;
    public float DoorWidth;
    public List<float> ratios = new List<float> { 1.3f, 1.5f, 1.2f, 1.1f, 2f, 1.15f, 1.05f, 1.7f, 1.4f, 1.2f};
    // for each ratio there is a threshold in the range of [0,1]
    public List<float> thresholds = new List<float> { 0.3f, 0.5f, 0.2f, 0.1f, 1f, 0.15f, 0.05f, 0.7f, 0.4f, 0.2f };
    public int door_num = -1;

    private Game_manager_script GMS;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize doors for session correspond the participant width
        doorsArr = ratios.Select(x => globalVariables.ParticipantWidth * x).ToList();
        // Gets all parts of the door in list
        doorParts = GetChildren(transform);
        door = GameObject.Find("Door");
        GMS = FindObjectOfType<Game_manager_script>();
        SetDoor();
    }


    // Update is called once per frame
    void Update()
    {
        // Checks if participant can get into the door and react correspond it
        if (thresholds[door_num] >= GMS.neurofeedback)
        {
            door.transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }
        // Checks if the door pass the participant and switch door if true

    }

    // The function return list of all Door's children - each component of Door.
    List<Transform> GetChildren(Transform Door)
    {
        List<Transform> doorParts = new List<Transform>();
        foreach (Transform doorPart in Door)
        {
            doorParts.Add(doorPart);
        }
        return doorParts;
    }

    // The function sets the door size and position
    public void SetDoor()
    {
        // Sets door size based on the participant size and random num for changing the door width
        // each trail
        door_num = Random.Range(0, doorsArr.Count);
        DoorWidth = doorsArr[door_num];
        float ParticipantHight = globalVariables.ParticipantHight;
        doorParts[1].localScale = new Vector3(DoorWidth, 0.1f, 0.1f);
        doorParts[0].localScale = new Vector3(0.1f, ParticipantHight + 0.2f, 0.1f);
        doorParts[2].localScale = new Vector3(0.1f, ParticipantHight + 0.2f, 0.1f);
        // Sets door position at the start of the trail
        doorParts[1].position = new Vector3(0, ParticipantHight + 0.225f, 4);
        doorParts[0].position = new Vector3(-1 * (DoorWidth / 2) - 0.05f, (ParticipantHight + 0.15f) / 2 + 0.1f, 4);
        doorParts[2].position = new Vector3((DoorWidth / 2) + 0.05f, (ParticipantHight + 0.15f) / 2 + 0.1f, 4);
    }

    public bool is_door_passed(){
        if (doorParts[0].position.z < 0 && doorParts[1].position.z < 0 && doorParts[2].position.z < 0){
            return true;
        }
        return false;
    }
}
