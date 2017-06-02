=========================
Unity Lowpoly Exporter (1.1.1)
-------------------------


����Ҫȷ��ģ���ǵ�ģ�����ģ�;��Ƚϸ�ֻͨ�������ı�mesh�Ķ�����������Ч���Ͳ�����
��ȡģ�͵�mesh���񣬷���Ƥģ��ͨ����ȡMeshFilter����õ�Mesh��������Ƥ��ģ��ͨ��Skinned Mesh Renderer�����ȡMesh��

MeshFilter meshFilter = GetComponent<MeshFilter>();  
Mesh mesh = meshFilter.mesh;  

�޸�ģ��mesh�����Լ�����������

Vector3[] oldVerts = mesh.vertices;//���浱ǰMesh����  
        int[] triangles = mesh.triangles;//������������  
  
        Vector3[] verts = new Vector3[triangles.Length];//���ڱ����µĶ�����Ϣ  
  
        for (int i = 0; i < triangles.Length; i++)  
        {  
            verts[i] = oldVerts[triangles[i]];  
            triangles[i] = i;  
        }  
  
        mesh.vertices = verts;//����Mesh����  
        mesh.triangles = triangles;//��������  
        mesh.RecalculateBounds();//���¼���߽�  
        mesh.RecalculateNormals();//���¼��㷨��  

���ű�����ģ�ͣ����м��ɵõ�low polyЧ����Ϊ�˱���ÿ��ִ�н��ж���ļ����Լ��޸ģ����Լ���������뽫�޸ĺ��Mesh������ļ���

string fileName = "Assets/FileName.asset";//Ҫ����ɵ��ļ�·�����ļ��� �ļ���ʽΪ.asset  
        AssetDatabase.CreateAsset(meshFilter.sharedMesh, fileName);//�����ļ�  
        AssetDatabase.SaveAssets();//��������  

���г�������Assets������Mesh�ļ��������ļ��ϵ���ģ��Mesh Filter����µ�Mesh����ʱ����low poly�Ľű�����Ѿ������ˣ��ǵ��Ƴ�


�������룺

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

