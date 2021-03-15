using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CountDownScript : MonoBehaviour
{
    Text countDown;
    float timeLeft;
    // Start is called before the first frame update
    
    void Start()
    {
        countDown = GetComponent<Text>();
        timeLeft = 6f;
    }  
   
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        int realD = (int)timeLeft;
        countDown.text = realD.ToString();
        if(timeLeft<0){
            SceneManager.LoadScene(2);
        }
    }
}
