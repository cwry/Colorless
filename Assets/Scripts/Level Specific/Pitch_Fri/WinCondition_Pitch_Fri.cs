using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinCondition_Pitch_Fri : MonoBehaviour {

    public GameObject player;
    public GameObject wolf;

    public float loseBias = 8;
    public float winBias = 3;
    
    void Update() {
        float distance = wolf.transform.position.x - player.transform.position.x;

        if(distance >= loseBias){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }else if(distance <= winBias) {
            Destroy(wolf);
        }

        
    } 
}
