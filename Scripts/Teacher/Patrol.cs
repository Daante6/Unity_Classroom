using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public float movementSpeed;
    private Vector3 targetPosition;
    private Quaternion rotation;
    private int currentPoint = 0;
    private int nextPoint = 1;
    private float currentWait = 0;
    FOV FOVscript = new FOV();

    public PatrolTable[] patrolTable;

    void Start()
    {
        FOVscript = GetComponent<FOV>();
    }

    void Update()
    {
        if(currentWait <= 0)
        {
            
            currentPoint++;
            nextPoint++;
            if (currentPoint >= patrolTable.Length)
            {
                currentPoint = 0;
            }
            if(nextPoint >= patrolTable.Length)
            {
                nextPoint = 0;
            }
            currentWait = patrolTable[currentPoint].timeMax;
        }
        else
        {
            currentWait -= Time.deltaTime;
            GoToPoint();
            changeFOV();
        }
        transform.position = new Vector3(transform.position.x,transform.position.y,-1);
    }
    void GoToPoint()
    {
        //moving
        targetPosition = patrolTable[currentPoint].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        //rotating
        rotation = patrolTable[currentPoint].transform.rotation;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, patrolTable[currentPoint].rotationSpeed * Time.deltaTime);
    }
    void changeFOV()
    {
        if(currentPoint == 0)
        {
            FOVscript.viewAngle = Mathf.Lerp(patrolTable[currentPoint].ViewAngle, patrolTable[patrolTable.Length-1].ViewAngle, currentWait / patrolTable[currentPoint].timeMax);
            FOVscript.viewRange = Mathf.Lerp(patrolTable[currentPoint].ViewRange, patrolTable[patrolTable.Length-1].ViewRange, currentWait / patrolTable[currentPoint].timeMax);
        }
        else
        {
            FOVscript.viewAngle = Mathf.Lerp(patrolTable[currentPoint].ViewAngle, patrolTable[currentPoint-1].ViewAngle, currentWait / patrolTable[currentPoint].timeMax);
            FOVscript.viewRange = Mathf.Lerp(patrolTable[currentPoint].ViewRange, patrolTable[currentPoint-1].ViewRange, currentWait / patrolTable[currentPoint].timeMax);
        }
        
    }
}

[System.Serializable]
public class PatrolTable
{
    public Transform transform;
    public int timeMax;
    public float ViewRange;
    public float ViewAngle;
    public float rotationSpeed;
}