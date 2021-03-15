using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRay : MonoBehaviour
{
    public Transform playerPosition;

    float theSpeed;

    float theMaxSpeed;

    float theRealMaxSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        theSpeed = 0;
        theMaxSpeed = 25;
        theRealMaxSpeed = 25;
    }

    // Update is called once per frame
    void Update()
    {
        var class1 = GetComponent<FollowPath>();

        acceletrate();

        Ray frontDetect = new Ray(transform.position, transform.forward);
        float frontRayDist = 1.8f;
        Debug.DrawRay(frontDetect.origin, frontDetect.direction * frontRayDist, Color.yellow);
        if (Physics.SphereCast(frontDetect, 0.5f ,frontRayDist))
        {
            theMaxSpeed = 0;
        }

        if(detetcBoost()){
            theMaxSpeed = 30;
        }
        else{
            theMaxSpeed = theRealMaxSpeed;
        }
        class1.Speed = theSpeed;
    }

    void acceletrate(){
        if(theSpeed<theMaxSpeed){
            theSpeed += 0.25f;
        }
        if(theSpeed>theMaxSpeed){
            theSpeed = theMaxSpeed;
        }
        
        theRealMaxSpeed += 0.002f;
        //Debug.Log(theRealMaxSpeed);
    }

    bool detetcBoost(){
        Vector3 targetDir = playerPosition.position - transform.position;
        float angle = Vector3.Angle(targetDir, -transform.forward);

        if(angle<30&&Vector3.Distance(playerPosition.position,transform.position)<15){
            //Debug.Log("In the view");
            return true;
        }
        return false;
    }
}
