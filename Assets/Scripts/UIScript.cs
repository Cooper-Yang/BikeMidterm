using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    int carSpeed;
    public Text speed;
    public Text watt;
    public Text miles;
    public Text rideTimes;
    public Rigidbody car;
    
    float tm;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    
    
    // Update is called once per frame
    void Update()
    {
        var bicycleScript = GameObject.Find("Player").GetComponent<BicycleControl>();
        float currentSpeed = bicycleScript.speed;
        carSpeed = Mathf.Abs((int)currentSpeed);
        speed.text = carSpeed.ToString();
        
        int watty = (int)carSpeed ;
        watty *= 5;
        watt.text =watty.ToString();

        
        tm += Time.deltaTime;
        int timey = (int) tm;
        rideTimes.text = timey.ToString();
        //Debug.Log( "\n"+ Time.deltaTime);

        if(PlayerRay.crashState){
            speed.text = "0";
            watt.text = "0";
            rideTimes.text = "0";
            
        }
    }
}
