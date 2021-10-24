using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    public SpriteRenderer aura;

    Mesh mesh;
    public Material FOVcolor;
    private int acc = 50;
    Vector3[] vertices;
    int[] triangles;
    public Transform playerTransform;
    public LayerMask obstacleMask;

    private Color _colorNear;
    private Color _colorFar;

    private Vector3 origin;

    float angleStart;
    float angleCurrent;
    float angleIncrease;

    FOV FOVscript = new FOV();
    private void Awake()
    {
        FOVscript = GetComponentInParent<FOV>();
    }
    void Start()
    {
        vertices = new Vector3[acc];
        triangles = new int[3 * (acc - 2)];

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        createShape();
        updateMesh();
        aura.gameObject.SetActive(true);
        origin = Vector3.zero;

        angleIncrease = FOVscript.viewAngle / acc;
    }
    private void FixedUpdate()
    {
        createShape();
        updateMesh();
    }
    void createShape()
    {
        float playerRotation = transform.rotation.eulerAngles.z;
        playerRotation += 90;
        angleStart = playerRotation + FOVscript.viewAngle/2;
        angleCurrent = angleStart;
        
        for (int i = 0; i < acc; i++)
        {
            if(i == 0)
            {
                vertices[0] = origin;
            }
            else
            {
                RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, GetVectorFromAngle(angleCurrent), FOVscript.viewRange, obstacleMask);
                if (raycastHit2D.collider == null)
                {
                    // No hit
                    vertices[i] = origin + GetVectorFromAngle(angleCurrent - playerRotation + 90) * FOVscript.viewRange;
                }
                else
                {
                    // Hit object
                    vertices[i] = origin + GetVectorFromAngle(angleCurrent - playerRotation + 90) * raycastHit2D.distance;
                    
                }
                angleCurrent -= angleIncrease;
            }
        }
            
            for(int i = 0; i < acc-2; i++)
        {
            triangles[i * 3] = 0;
            triangles[(i * 3) + 1] = i+1;
            triangles[(i * 3) + 2] = i+2;
        }
        
    }
    void updateMesh()
    {
        TeacherScript teacherScript = GetComponentInParent<TeacherScript>();

        float currentAwarness = teacherScript.Awarness / teacherScript.AwarnessMax;

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        _colorNear = Color.Lerp(Color.red, Color.green, currentAwarness);
        _colorFar = Color.Lerp(Color.red, Color.green, currentAwarness);
        _colorNear.a = Mathf.Clamp(0.4f * (1 / currentAwarness), 0.1f, 0.7f) ;
        _colorFar.a = Mathf.Clamp(0.1f * (1 / currentAwarness), 0.05f, 0.1f);

        // create new colors array where the colors will be created.
        //Color[] colors = new Color[vertices.Length];
        Color[] colors = new Color[vertices.Length];
        float maxLength = 0;
        foreach (Vector3 point in vertices)
        {
            if (point.y > maxLength)
            {
                maxLength = point.y;
            }
        }

        for (int i = 0; i < vertices.Length; i++)
            //colors[i] = Color.Lerp(_colorNear, _colorFar, vertices[i].y);
            colors[i] = Color.Lerp(_colorNear, _colorFar, vertices[i].y);

        // assign the array of colors to the Mesh.
        mesh.colors = colors;


        //aura
        aura.color = Color.Lerp(Color.red, Color.green, currentAwarness);
        aura.color = _colorNear;

    }
    public Vector3 GetVectorFromAngle(float angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
    public float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
    public void SetAimDirection(Vector3 AimDirection)
    {
        angleStart = GetAngleFromVectorFloat(AimDirection) - FOVscript.viewAngle / 2f;
    }
}
