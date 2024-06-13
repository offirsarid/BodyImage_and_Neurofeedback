using System.Collections;
using UnityEngine;
using UnityEngine.ProBuilder;



public class Room_Manager : MonoBehaviour{
    public Material[] wall_colors;
    Renderer rend;
    int index = -1;




    // Start is called before the first frame update
    void Start(){
       rend = GetComponent<Renderer>();
       rend.enabled = true;
        update_walls();
    }

    // Update is called once per frame
    void Update(){}

public void update_walls(){
        index = Random.Range(0,  wall_colors.Length);
        rend.sharedMaterial = wall_colors[index];
    }
}
