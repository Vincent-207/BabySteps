using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFlatCone : MonoBehaviour
{
    [SerializeField]
    Mesh mesh;
    [SerializeField]
    float angle, height, radius;
    [SerializeField]
    [Min(2)]
    int resolution;
    Vector3[] vertices;
    int[] triangles;
    float[] vertAngles;
    // Start is called before the first frame update
    void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        tryGenerate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Mesh getCone()
    {
        return mesh;
    }

    public bool tryGenerate()
    {
        if(!Application.isPlaying)
        {
            //Debug.LogWarning("Can't generate cone outside of playmode");
            return false;
        }
        else
        {
            generateVertices();
            generateTriangles();  
            updateShape();
        }
        return true;
    }

    void generateVertices()
    {
        int baseVertCount = 2;
        vertices = new Vector3[baseVertCount + (resolution * 2)];
        vertAngles = new float[vertices.Length];
        vertices[0] = new Vector3(0,0,0);
        vertices[1] = new Vector3(0,height,0);

        for(int vertIndex = baseVertCount; vertIndex < vertices.Length; vertIndex += 2)
        {
            float vertAngle = (-angle/2.0f) + (((vertIndex - baseVertCount)/2) * (angle/(resolution-1)));
            
            // Debug.Log("Angle: " + vertAngle);
            // Debug.Log("Angle / res " + (angle/(resolution - 1)));
            // Debug.Log("Count : " + ((vertIndex - baseVertCount)/2));
            // Debug.Log("Multiplied: " + (((vertIndex - baseVertCount)/2) * (angle/(resolution-1))));
            
            vertAngles[vertIndex] = vertAngle;
            vertAngles[vertIndex + 1] = vertAngle;
            vertices[vertIndex] = new Vector3(Mathf.Cos(vertAngle * Mathf.Deg2Rad) * radius , 0, Mathf.Sin(vertAngle * Mathf.Deg2Rad) * radius);
            if(vertIndex + 1 >= vertices.Length)
            {
                break;
            }
            vertices[vertIndex + 1] = new Vector3(Mathf.Cos(vertAngle  * Mathf.Deg2Rad) * radius  , getHeight(), Mathf.Sin(vertAngle* Mathf.Deg2Rad) * radius);
            
        }

    }

    void generateTriangles()
    {
        int wallTriCount = 4;
        int triangleCount = (wallTriCount + (resolution *2)) + ((resolution - 1) * 2);
        int lastTopTriangle = wallTriCount + (resolution *2);
        // int manualCount = 12;
        triangles = new int[triangleCount * 3];
        
        generateWallTriangles();
        generateTopBottomTriangles(wallTriCount * 3, lastTopTriangle * 3);
        generateFrontTriangles((lastTopTriangle * 3));
    }

    void generateFrontTriangles(int startIndex)
    {
        //Debug.Log("Start Index: " + startIndex);
        //Debug.Log("Front Triangles: " + (triangles.Length - startIndex)/ 3);
        //Debug.Log("Max sections: " + ((triangles.Length - startIndex)/ 6));
        for(int index = startIndex; index < triangles.Length; index += 6)
        {
            int sectionNumber = 0 + (index - startIndex)/6;
            //Debug.Log("Section Number: " + sectionNumber);
            // Bottom Left Corner Tris
            triangles[index] = 2 + (sectionNumber *2);
            triangles[index + 1] = 3 + (sectionNumber * 2);
            triangles[index + 2] = 4 + (sectionNumber * 2);
            // Top Right Corner Tris
            triangles[index + 3] = 3 + (sectionNumber * 2);
            triangles[index + 4] = 5 + (sectionNumber * 2);
            triangles[index + 5] = 4 + (sectionNumber * 2);
        }
    }

    void generateTopBottomTriangles(int startIndex, int endIndex)
    {
        int wallTriangleCount = 12;
        for(int index = wallTriangleCount; index < endIndex; index += 6)
        {
            int triangleNumber = (index - wallTriangleCount)/6;
            //Debug.Log("Tri number: " + triangleNumber);
            // Top Tri

            
            triangles[index + 1] = 1 + triangleNumber * 2;
            triangles[index + 0] = 3 + (triangleNumber * 2);
            triangles[index + 2] = 1;
            triangles[index + 3] = 0 + triangleNumber * 2;
            triangles[index + 4] = 2 + (triangleNumber * 2);
            triangles[index + 5] = 0;

            
        }
    }

    void generateWallTriangles()
    {
        int triangleCount = triangles.Length;
        // Right Wall
        triangles[0] = 0; triangles[1] = 1; triangles [2] = 3;
        triangles[3] = 0; triangles[4] = 3; triangles[5] = 2;

        // Left Wall
        triangles[7] = 1; triangles[6] = vertices.Length - 1; triangles[8] = vertices.Length - 2;
        triangles[10] = vertices.Length - 2; triangles[11] = 1; triangles[9] = 0;

    }

    void updateShape()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

    protected virtual float getHeight(float x)
    {
        return height;
    }

    protected virtual float getHeight()
    {
        return getHeight(0);
    }

/*    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for(int vertIndex = 0; vertIndex < vertices.Length; vertIndex++)
        {
            Gizmos.DrawSphere(vertices[vertIndex] + transform.position, .2f);
        }
        
    }

*/
}
