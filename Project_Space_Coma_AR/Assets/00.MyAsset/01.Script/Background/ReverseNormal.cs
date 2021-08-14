using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 메쉬 반전 클래스
/// </summary>
[RequireComponent(typeof(MeshFilter))]
public class ReverseNormal : MonoBehaviour
{
    #region 변수

    MeshFilter meshFilter;

    #endregion

    #region 유니티 생명 주기

    void Start() => ReverseMesh();

    #endregion

    #region 구현부

    /// <summary> 메쉬 필터의 노멀 값과 폴리곤 값을 뒤집어서 메쉬를 반전시키는 함수 </summary>
    void ReverseMesh()
    {
        meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null)
        {
            Mesh mesh = meshFilter.mesh;

            //노멀 값 반전
            Vector3[] normals = mesh.normals;
            for (int i = 0; i < normals.Length; i++)
                normals[i] = -normals[i];
            mesh.normals = normals;

            //폴리곤 생성 방향을 시계방향에서 반시계방향으로 변경
            int[] triangles = mesh.triangles;
            for (int i = 0; i < mesh.subMeshCount; i++)
            {
                //int[] triangles = mesh.GetTriangles(i);

                for (int j = 0; j < triangles.Length; j += 3)
                {
                    int temp = triangles[j];
                    triangles[j] = triangles[j + 1];
                    triangles[j + 1] = temp;
                }
                mesh.triangles = triangles;
                //mesh.SetTriangles(triangles, i);
            }
        }
    }

    #endregion
}
