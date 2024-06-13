using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class welcome_script : MonoBehaviour{

    public GameObject input_id;
    public GameObject input_height;
    public GameObject input_shoulders;
    public string sub_id = "";
    public float sub_height = 0f;
    public float sub_shoulders = 0f;

    public void take_inputs(){
        sub_id = input_id.GetComponent<Text>().text;
        sub_height = float.Parse(input_height.GetComponent<Text>().text);
        sub_shoulders = float.Parse(input_shoulders.GetComponent<Text>().text);
    }

    public bool validateInputs(){
            return sub_id != "" && sub_height > 0 && sub_shoulders > 0;
    }

    public void startGame(){
            take_inputs();
            Debug.Log(sub_id);
            Debug.Log(sub_height.ToString());
            Debug.Log(sub_shoulders.ToString());
            if (validateInputs()){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else{
                Debug.Log("invalid input!");
            }
    }
}
