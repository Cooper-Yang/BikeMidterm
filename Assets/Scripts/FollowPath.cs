using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour
{
    #region Enums
    public enum MovementType  
    {
        MoveTowards,
        LerpTowards
    }
    #endregion 

    #region Public Variables
    public MovementType Type = MovementType.MoveTowards; 
    public MovementPath MyPath; 
    public float Speed = 0; 
    public float MaxDistanceToGoal = .1f; 
    #endregion 

    #region Private Variables
    private IEnumerator<Transform> pointInPath; 
    #endregion 

    
    #region Main Methods
    public void Start()
    {
        // if (MyPath == null)
        // {
        //     Debug.LogError("Movement Path cannot be null, I must have a path to follow.", gameObject);
        //     return;
        // }

        
        pointInPath = MyPath.GetNextPathPoint();
        Debug.Log(pointInPath.Current);
        
        pointInPath.MoveNext();
        Debug.Log(pointInPath.Current);

        
        if (pointInPath.Current == null)
        {
            Debug.LogError("A path must have points in it to follow", gameObject);
            return; 
        }

        
        transform.position = pointInPath.Current.position;
    }
     
    
    public void Update()
    {
        
        if (pointInPath == null || pointInPath.Current == null)
        {
            return; 
        }

        if (Type == MovementType.MoveTowards) 
        {
            
            transform.position =
                Vector3.MoveTowards(transform.position,
                                    pointInPath.Current.position,
                                    Time.deltaTime * Speed);
            transform.LookAt(pointInPath.Current.position);
        }
        else if (Type == MovementType.LerpTowards) 
        {
            transform.position = Vector3.Lerp(transform.position,
                                                pointInPath.Current.position,
                                                Time.deltaTime * Speed);
        }
 
        var distanceSquared = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal) 
        {
            pointInPath.MoveNext(); 
        }
    }
    #endregion /

    
    #region Utility Methods 

    #endregion 

    #region Coroutines

    #endregion 
    
}
