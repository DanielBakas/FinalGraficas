/*
* Santiago Hernández Guerrero A01027543
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier : MonoBehaviour
{
    List<Vector3> ctrl;
    GameObject greenBall;
    float pason = 0.0f;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        ctrl = new List<Vector3>();
        ctrl.Add(new Vector3(0, 0, 0));
        ctrl.Add(new Vector3(2.5f, 5, 0));
        ctrl.Add(new Vector3(5, 10, 0));
        ctrl.Add(new Vector3(7.5f, 5, 0));
        ctrl.Add(new Vector3(10, 0, 0));
        ctrl.Add(new Vector3(7.5f, -5, 0));
        ctrl.Add(new Vector3(5, -10, 0));
        ctrl.Add(new Vector3(2.5f, -5, 0));
        ctrl.Add(new Vector3(0, 0, 0));

        Vector3 test1 = BezierUtil.calculate(ctrl, 0); // == ctrl[0]
        Debug.Log(test1);

        Vector3 test2 = BezierUtil.calculate(ctrl, 1.0f); // == ctrl[4]
        Debug.Log(test2);

        foreach (Vector3 v in ctrl)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            sphere.transform.position = v;
        }

        for (float i = 0; i <= 1.0f; i += 0.01f)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            sphere.transform.position = BezierUtil.calculate(ctrl, i);
            sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        greenBall = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        greenBall.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        greenBall.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        greenBall.transform.position = BezierUtil.calculate(ctrl, pason * 0.01f);
        pason += direction / 20.0f;
        if (pason > 100 || pason < 0) direction *= -1;
    }
}
