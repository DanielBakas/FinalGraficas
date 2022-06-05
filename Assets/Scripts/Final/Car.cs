/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `Car.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

May 18, 2022
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Component
{
    // Attribute
    public int curveIndex;
    public int pathIndex;
    public float speedLimit;

    // Constructor
    public Car(GameObject gameObject, int index, string name, float speed, float unit) : base(gameObject, index, name, speed, unit)
    {
        this.curveIndex = 0;
        this.pathIndex = 0;
    }
}