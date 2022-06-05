using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEinar : MonoBehaviour
{
    public GameObject car;
    Vector3[] originalCoordinates;
    Vector3[] testCoor;
    public Vector3 start;
    public Vector3 end;
    public Vector3 pos;
    Vector3 prev;
    float param;
    List<Vector3> ctrl;
    List<Vector3> ctrl2;
    float t;
    int n;
    int n2;
    float rate = 0.005f;
    GameObject sphere;
    Matrix4x4 trans;
    float count;


    float Combination(int n, int i)
    {
        return (float)Factorial(n) / (Factorial(i) * Factorial(n - i));
    }

    int Factorial(int n)
    {
        if (n == 0) return 1;
        else return n * Factorial(n - 1);
    }

    Vector3 EvalBezier(float t)
    {
        Vector3 bez = Vector3.zero;
        for (int i = 0; i < n; i++)
        {
            float u = Combination(n - 1, i) * Mathf.Pow(1.0f - t, n - 1 - i) * Mathf.Pow(t, i);
            bez += u * ctrl[i];
        }


        return bez;
    }


    Vector3 EvalBezier2(float t)
    {
        Vector3 bez = Vector3.zero;
        for (int i = 0; i < n2; i++)
        {
            float u = Combination(n - 1, i) * Mathf.Pow(1.0f - t, n - 1 - i) * Mathf.Pow(t, i);
            bez += u * ctrl2[i];
        }


        return bez;
    }
    //   bez = Vector3.zero;


    Vector3 Interpolate(Vector3 A, Vector3 B, float t)
    { //EvaluateBezier
        return A + t * (B - A);
    }

    Vector3[] ApplyTransform(Matrix4x4 m, Vector3[] verts)
    {
        int num = verts.Length;
        Vector3[] result = new Vector3[num];
        for (int i = 0; i < num; i++)
        {
            Vector3 v = verts[i];
            Vector4 temp = new Vector4(v.x, v.y, v.z, 1);
            result[i] = m * temp;
        }

        return result;
    }

    // Start is called before the first frame update
    void Start()
    {

        ctrl = new List<Vector3>() {
            new Vector3(-80.5f,0.247539282f,83f),
            new Vector3(198f,0.247539282f,-89f),
            new Vector3(142f,0.247539282f,299f),
            new Vector3(268f,0.247539282f,-118f),
        };

        ctrl2 = new List<Vector3>() {
            new Vector3(196f,0.247539282f,69f),
            new Vector3(251f,0.247539282f,-85.7f),
            new Vector3(74f,0.247539282f,-180.5f),
            new Vector3(41.6f,0.247539282f,95.6f),
        };

        n = ctrl.Count;
        n2 = ctrl2.Count;

        for (int i = 0; i < n; i++)
        {
            sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = ctrl2[i];
            sphere.transform.localScale = new Vector3(25, 25, 25);
            sphere.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0, 0, 1));
        }
        param = 0;
        count = 0;
        originalCoordinates = car.GetComponent<MeshFilter>().mesh.vertices;
        testCoor = originalCoordinates;

    }

    // Update is called once per frame
    void Update()
    {   //Para controlar velocidad aumentar o reducir param
        // (Pos - prev)/ parm = velocicdad
        // Formula colision 36:11
        param += rate;

        Debug.Log(param);
        if (param > 8)
        {
            count += rate;
            Debug.Log("hey");
            pos = EvalBezier2((float)count / 10);
            trans = Transformations.TranslateM(pos.x, pos.y + 1.15f, pos.z);

            prev = EvalBezier2((float)(count - rate) / 10);
            Vector3 du = (pos - prev).normalized;
            float alpha = Mathf.Atan2(-du.z, du.x) * Mathf.Rad2Deg;
            Matrix4x4 r = Transformations.RotateM(alpha, Transformations.AXIS.AX_Y);
            // r * t sistema solar 
            car.GetComponent<MeshFilter>().mesh.vertices = ApplyTransform(trans * r, testCoor);
            car.GetComponent<MeshFilter>().mesh.RecalculateBounds();

        }
        else
        {
            pos = EvalBezier((float)param / 10);
            trans = Transformations.TranslateM(pos.x, pos.y + 1.15f, pos.z);
            //Vector3 prev = Interpolate(start, end, param - 0.0001f);
            prev = EvalBezier((float)(param - rate) / 10);

            Vector3 du = (pos - prev).normalized;
            float alpha = Mathf.Atan2(-du.z, du.x) * Mathf.Rad2Deg;
            Matrix4x4 r = Transformations.RotateM(alpha, Transformations.AXIS.AX_Y);
            // r * t sistema solar 
            car.GetComponent<MeshFilter>().mesh.vertices = ApplyTransform(trans * r, originalCoordinates);
            car.GetComponent<MeshFilter>().mesh.RecalculateBounds();
        }
    }
}
