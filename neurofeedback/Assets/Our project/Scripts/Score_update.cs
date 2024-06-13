using UnityEngine;
using UnityEngine.UI;

public class Score_update : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    // Start is called before the first frame update
    void Start(){
    	scoreText.text = score.ToString();
    }

    
    void Update(){} // Update is called once per frame
    
    public void update_score(){
      score = score + 10;
    	scoreText.text = score.ToString();
    }
}
