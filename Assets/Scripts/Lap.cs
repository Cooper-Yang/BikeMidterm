using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lap : MonoBehaviour
{
    int pLap;
    int eLap;

    public TextMesh lapsLeft;

    public Text winText;

    public int laps = 5;

    
    bool finished;
    // Start is called before the first frame update
    void Start()
    {
        pLap = -1;
        eLap = -1;

    }

    // Update is called once per frame
    void Update()
    {
        if( pLap==laps || eLap == laps){
            if(pLap>eLap && !finished){
                winText.text = "You win\nPress R to restart";
                finished = true;
            }
            if(pLap<eLap && !finished){
                winText.text = "You lose\nPress R to restart";
                finished = true;
            }
        }

        if(finished && Input.GetKeyDown(KeyCode.Space)){
            Application.LoadLevel(Application.loadedLevel);
        }

        int realPlayerLap = pLap +1;

        lapsLeft.text = "LAPS: "+realPlayerLap+"/5";

        Debug.Log(pLap);

    }

    void OnTriggerEnter(Collider target){
        if(target.tag == "Player"){
            pLap += 1;
            Debug.Log("p is" + pLap);
        }
        
        if(target.tag == "enemy"){
            eLap += 1;
            Debug.Log("e is" + eLap);
        }
    }
}
