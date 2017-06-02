=========================
Unity Lowpoly Exporter (1.1.1)
-------------------------


首先要确保模型是低模，如果模型精度较高只通过这样改变mesh的顶点三角索引效果就不明显
获取模型的mesh网格，非蒙皮模型通过获取MeshFilter组件得到Mesh，带有蒙皮的模型通过Skinned Mesh Renderer组件获取Mesh。

MeshFilter meshFilter = GetComponent<MeshFilter>();  
Mesh mesh = meshFilter.mesh;  

修改模型mesh顶点以及三角索引：

Vector3[] oldVerts = mesh.vertices;//保存当前Mesh顶点  
        int[] triangles = mesh.triangles;//三角索引数组  
  
        Vector3[] verts = new Vector3[triangles.Length];//用于保存新的顶点信息  
  
        for (int i = 0; i < triangles.Length; i++)  
        {  
            verts[i] = oldVerts[triangles[i]];  
            triangles[i] = i;  
        }  
  
        mesh.vertices = verts;//更新Mesh顶点  
        mesh.triangles = triangles;//更新索引  
        mesh.RecalculateBounds();//重新计算边界  
        mesh.RecalculateNormals();//重新计算法线  

将脚本赋予模型，运行即可得到low poly效果。为了避免每次执行进行顶点的计算以及修改，可以加上下面代码将修改后的Mesh保存成文件：

string fileName = "Assets/FileName.asset";//要保存成的文件路径及文件名 文件格式为.asset  
        AssetDatabase.CreateAsset(meshFilter.sharedMesh, fileName);//创建文件  
        AssetDatabase.SaveAssets();//保存数据  

运行程序后会在Assets下生成Mesh文件，将此文件拖到该模型Mesh Filter组件下的Mesh，此时生成low poly的脚本组件已经无用了，记得移除


完整代码：

using UnityEngine;  
using System.Collections;  
using UnityEditor;  
public class FlatShading : MonoBehaviour  
{  
  
    private Mesh mesh;  
    void Start()  
    {  
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
        string fileName = "Assets/" + System.DateTime.Now.Year.ToString()+ System.DateTime.Now.Month.ToString()+ System.DateTime.Now.Day.ToString()+ System.DateTime.Now.Hour.ToString()+ System.DateTime.Now.Minute.ToString()+ System.DateTime.Now.Second.ToString() + ".asset";  
        AssetDatabase.CreateAsset(meshFilter.sharedMesh, fileName);  
        AssetDatabase.SaveAssets();  
    }  
}  

