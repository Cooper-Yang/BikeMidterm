using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BicycleControl : MonoBehaviour
{
    // Start is called before the first frame update
    float lr;
 
    public Slider stamina;

    public Camera backCam;
    public Camera fronCam;
    float maxStami; //s
    float currentStami;

    float roDe;
    Rigidbody car;

    [HideInInspector]
    public float speed;

    float maxSpeed;


    public AudioSource bikeNoise;
    public AudioSource breath;
    
    void Start()
    {
        car = GetComponent<Rigidbody>();
        speed = 0;
        maxSpeed = 28;

        maxStami = 4;
        currentStami =4;

        stamina.value = CalculateStami();

        backCam.enabled = false;
        fronCam.enabled = true;
    }

    // Update is called once per frame

    public void Update()
    {
        if(PlayerRay.crashState){
            bikeNoise.Stop();
            breath.Stop();
        }
        
        if(speed!=0){
            bikeNoise.UnPause();
        }
        else{
            bikeNoise.Pause();
        }

        if (Input.GetKey(KeyCode.W) && speed<maxSpeed)
        {
            speed += 0.2f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if(speed>-5)
                speed -= 0.2f;
        }

        if (Input.GetKey(KeyCode.LeftShift) && currentStami>0)
        {
            maxSpeed = 35f;
            currentStami -= Time.deltaTime;
            stamina.value = CalculateStami();
            breath.volume = 1;
        }
        
        else if (speed > 30) //things happen when you press shift
        {
            maxSpeed -= 0.2f;
            speed -= 0.2f;
        }

        if(currentStami<maxStami && !Input.GetKey(KeyCode.LeftShift))
        {
            currentStami += Time.deltaTime/3;
            stamina.value = CalculateStami();
            breath.volume = 0.7f;
        }
        
        

        if (speed > 0)
        {
            speed -= 0.05f;
        }

        if(speed<0){
            speed += 0.05f;
        }

        

        
        // if (Input.GetKey(KeyCode.A)&&PivotRotate.roDe>0)
        // {
            
        // }

        // if (Input.GetKey(KeyCode.D)&&PivotRotate.roDe<0)
        // {
            
        // }

        CamChange();
        
        pivotC();
        //Debug.Log(speed + "\n" + car.velocity);
    }

    public void FixedUpdate()
    {
        car.velocity = transform.forward * speed;
    }

    float CalculateStami(){
        return currentStami/maxStami;
    }

    void CamChange(){
        if(Input.GetKeyDown(KeyCode.Space)){
            backCam.enabled = true;
            fronCam.enabled = false;
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            backCam.enabled = false;
            fronCam.enabled = true;
        }
    }

    public void pivotC(){
        var bicycleScript = GameObject.Find("Player").GetComponent<BicycleControl>();
        float currentSpeed = bicycleScript.speed;
        if(!Input.anyKeyDown&&roDe!=0){
            roDe = Mathf.Lerp(roDe, 0, Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.A)&&roDe<20)
        {
            if(roDe<0){
                roDe +=0.5f;
            }
            else{
                roDe += 0.25f;
                transform.Rotate(0f, -0.5f, 0f,Space.World);
            }
        }

        if (Input.GetKey(KeyCode.D)&&roDe>-20)
        {
            if(roDe>0){
                roDe -=0.5f;
            }
            else{
                roDe -= 0.25f;
                transform.Rotate(0f, 0.5f, 0f, Space.World);
            }
        }

        //&&currentSpeed!=0
    
        Vector3 to = new Vector3(0, transform.eulerAngles.y, roDe);
        transform.eulerAngles = to;
    }
    
}
