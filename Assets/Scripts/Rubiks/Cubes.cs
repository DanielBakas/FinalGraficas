/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `Cubes.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

May 18, 2022
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/

using System.Collections.Generic;
using UnityEngine;

public static class Cubes
{
    public static List<Vector3> positions = new List<Vector3>()
    {
        new Vector3(-1, -1,  1),    // Cubo 0
        new Vector3( 1, -1,  1),    // Cubo 1
        new Vector3( 1,  1,  1),    // Cubo 2
        new Vector3(-1,  1,  1),    // Cubo 3
        new Vector3( 1, -1, -1),    // Cubo 4
        new Vector3( 1,  1, -1),    // Cubo 5
        new Vector3(-1, -1, -1),    // Cubo 6
        new Vector3(-1,  1, -1),    // Cubo 7
    };
}