/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `Path.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

March 21, 2022

Copyright © Computational Graphics 2022. All rights reserved.\
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/

using System.Collections.Generic;
using UnityEngine;

public static class Path
{
    public static List<Vector3>[] curves = new List<Vector3>[]
    {
        new List<Vector3> {
            new Vector3(-206, 0, 15),
            new Vector3(-140, 0, 170),
            new Vector3(-86, 0,-15),
            new Vector3(12, 0, 50),
        },
        new List<Vector3> {
            new Vector3(12, 0, 50),
            new Vector3(273, 0, 182),
            new Vector3(260, 0, -106),
            new Vector3(110, 0,-85),
        },
        new List<Vector3> {
            new Vector3(110, 0,-85),
            new Vector3(-27, 0, -58),
            new Vector3(-47, 0, 8),
            new Vector3(-138, 0, -68),
        },
        new List<Vector3> {
            new Vector3(-138, 0, -68),
            new Vector3(-168, 0,-100),
            new Vector3(-227, 0, -81),
            new Vector3(-206, 0, 15),
        }
    };
}