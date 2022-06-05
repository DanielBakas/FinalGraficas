/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `Model.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

May 18, 2022
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : Component
{
    public void prepareAll()
    {
        this.prepareTransformations();
        foreach (var component in this.components) { component.prepareTransformations(); }
    }

    // Constructor
    public Model(string name, float speed, float unit, GameObject gameObject = null) : base(gameObject, 0, name, speed, unit) { }
}