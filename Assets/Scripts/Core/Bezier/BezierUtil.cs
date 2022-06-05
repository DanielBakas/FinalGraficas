/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `BezierUtil.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

March 21, 2022

Copyright © Computational Graphics 2022. All rights reserved.\
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/

using System.Collections.Generic;
using UnityEngine;

public static class BezierUtil
{
    public static Vector3 calculate(List<Vector3> P, float t)
    {
        int n = P.Count;
        Vector3 p = Vector3.zero;
        for (int i = 0; i < n; i++)
            p += Combination(n - 1, i) * Mathf.Pow(1.0f - t, n - 1 - i) * Mathf.Pow(t, i) * P[i];
        return p;
    }

    public static float Combination(int n, int i)
    {
        return (float)factorial(n) / (factorial(i) * factorial(n - i));
    }

    public static int factorial(int n)
    {
        if (n == 0) return 1;
        else return n * factorial(n - 1);
    }
}