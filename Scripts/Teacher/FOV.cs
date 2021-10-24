using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FOV : MonoBehaviour
{

    public float viewRange;
    [Range(0, 360)]
    public float viewAngle;
    public bool isSeen;

    public Material FOVmaterial;
    

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform> visibleTargets = new List<Transform>();
    private TeacherScript teacherScript;
    private new MeshRenderer renderer;


    void Start()
    {
        teacherScript = GetComponent<TeacherScript>();
        renderer = GetComponentInChildren<MeshRenderer>();
        StartCoroutine("FindTargetWithDelay", 0.05f);
    }

    void Update()
    {
        
    }
    IEnumerator FindTargetWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            isSeen = false;
            FindVisibleTargets();
        }
    }

    //Finds targets inside field of view not blocked by walls
    void FindVisibleTargets()
    {
        TeacherScript teacherScript = GetComponent<TeacherScript>();
        visibleTargets.Clear();
        //Adds targets in view radius to an array
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRange, targetMask);
        //For every targetsInViewRadius it checks if they are inside the field of view
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            float dstToTarget = Vector3.Distance(transform.position, target.position);
            if ((Vector3.Angle(transform.up, dirToTarget) < viewAngle / 2) || dstToTarget < 1)
            {
                //If line draw from object to target is not interrupted by wall, add target to list of visible 
                //targets
                //check obstacles
                if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                    isSeen = true;
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        float totalFOV = viewAngle;
        float rayRange = viewRange;
        float halfFOV = totalFOV / 2.0f;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV, Vector3.forward);
        Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV, Vector3.forward);
        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;
        Gizmos.DrawRay(transform.position, leftRayDirection * rayRange);
        Gizmos.DrawRay(transform.position, rightRayDirection * rayRange);
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees -= transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
    }
}