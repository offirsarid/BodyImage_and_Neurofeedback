using UnityEngine;

public class Game_manager_script : MonoBehaviour
{   
    // subject properties
    public static float ParticipantHight = 1.7f;
    public static float ParticipantWidth = 0.6f;
    public static float ParticipantCurrWidth = 0.5f;

    // how many trails to run:
    int num_trails = 20;


    // game variables
    public int trail_idx = 0;
    public static int doorNum = 0;
    public static bool changeRoomColor = false;
    bool passedDoor = false;
    public float TrailMaxTime = 10f;
    public float TimePassed = 0f;

    // neurofeedback
    [Range(0.0f, 1.0f)]
    public float neurofeedback;

    // other scripts
    private Room_Manager room_manager;
    private doorPlacement door_placement;
    private Score_update score_update;

    // Start is called before the first frame update
    void Start(){
        room_manager = FindObjectOfType<Room_Manager>();
        door_placement = FindObjectOfType<doorPlacement>();
        score_update = FindObjectOfType<Score_update>();

    }

    // Update is called once per frame
    void Update(){
        TimePassed += Time.deltaTime;
        passedDoor = door_placement.is_door_passed();
        if (passedDoor || TimePassed > TrailMaxTime){
            if (trail_idx < num_trails)
            {
                TriggerNextTrail(passedDoor);
                passedDoor = false;
                TimePassed = 0f;
                trail_idx += 1;
            }
            else { 
                Application.Quit();
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }
    
    void TriggerNextTrail(bool passed){
        if (passed){
            score_update.update_score();
        }
        room_manager.update_walls();
        door_placement.SetDoor();

    }
}
