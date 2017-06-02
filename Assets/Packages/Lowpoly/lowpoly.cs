using UnityEngine;
using System.Collections;
using UnityEditor;
public class cc : MonoBehaviour
{

    private Mesh mesh;
    private SkinnedMeshRenderer mesh1;
    void Start()
    {
        //var meshFilter = GetComponent<SkinnedMeshRenderer>();
        //mesh = meshFilter.sharedMesh;
        var meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        Vector3[] oldVerts = mesh.vertices;
        int[] triangles = mesh.triangles;

        Vector3[] verts = new Vector3[triangles.Length];

        for (int i = 0; i < triangles.Length; i++)
        {
            verts[i] = oldVerts[triangles[i]];
            triangles[i] = i;
        }

        mesh.vertices = verts;
        mesh.triangles = triangles;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        //save file
        string fileName = "Assets/" + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + ".asset";
        AssetDatabase.CreateAsset(meshFilter.sharedMesh, fileName);
        AssetDatabase.SaveAssets();
    }
}