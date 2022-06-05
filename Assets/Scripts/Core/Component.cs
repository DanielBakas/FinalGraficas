/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `Component.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

March 21, 2022

Copyright © Computational Graphics 2022. All rights reserved.\
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/

using System.Collections.Generic;
using UnityEngine;

public class Component : AbstractComponent
{
    // Constructor
    public Component(GameObject gameObject, int index, string name, float speed, float unit, float frequency = 1.0f)
    {
        // Unity
        if (gameObject != null)
        {
            this.gameObject = gameObject;
            this.gameObject.name = name;
            this.originalVertices = this.gameObject.GetComponent<MeshFilter>().mesh.vertices;
        }
        // Model Attributes
        this.components = new List<Component>();
        this.frequency = frequency;
        this.index = index;
        this.speed = speed;
        this.unit = unit;
        // Transformation Vectors
        this.orbitV = Vector3.zero;
        this.positionV = Vector3.zero;
        this.rotationV = Vector3.zero;
        this.scaleV = Vector3.one * this.unit;
    }
}
