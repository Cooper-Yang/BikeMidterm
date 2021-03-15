using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject crashText;
    public static bool crashState;
    
    float couldP;
    public AudioSource crash;
    void Start()
    {
        crashState = false;
        couldP = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var class1 = GetComponent<BicycleControl>();

        Ray frontDetect = new Ray(transform.position, transform.forward);
        float frontRayDist = 1.8f;
        Debug.DrawRay(frontDetect.origin, frontDetect.direction * frontRayDist, Color.yellow);
        if (Physics.SphereCast(frontDetect, 0.25f ,frontRayDist))
        {
            crashText.SetActive(true);
            crashState = true;
            couldP -=0.00001f;
            
        }
        if(couldP<0)
        {
            crash.Play();
            couldP = 10000000000000000f;
        }
        

        if(crashState&&Input.GetKeyDown(KeyCode.R)){
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    
    
    
    
    


}
