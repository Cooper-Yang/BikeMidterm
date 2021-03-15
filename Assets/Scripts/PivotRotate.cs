using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotRotate : MonoBehaviour
{
    public static float roDe;
    
    void Start()
    {
        roDe = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        var bicycleScript = GameObject.Find("Player").GetComponent<BicycleControl>();
        float currentSpeed = bicycleScript.speed;
        
        if (Input.GetKey(KeyCode.A)&&roDe<20)
        {
            if(roDe<0){
                roDe +=0.5f;
            }
            else{
                roDe += 0.25f;
            }
        }

        if (Input.GetKey(KeyCode.D)&&roDe>-20)
        {
            if(roDe>0){
                roDe -=0.5f;
            }
            else{
                roDe -= 0.25f;
            }
        }
        //&&currentSpeed!=0
    
    Vector3 to = new Vector3(0, 0, roDe);
    transform.eulerAngles = to;
    }

    
    
    

    
}
