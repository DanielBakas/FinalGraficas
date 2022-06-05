/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `TransformBehavior.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

May 18, 2022
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TransformBehavior
{
    void prepareTransformations();
    void updateTransformations(Matrix4x4 matrix);
    void updateOrbit(float x = 0.0f, float y = 0.0f, float z = 0.0f);
    void updatePosition(float x = 0.0f, float y = 0.0f, float z = 0.0f);
    void updateRotation(float x = 0.0f, float y = 0.0f, float z = 0.0f);
    void updateScale(float x = 0.0f, float y = 0.0f, float z = 0.0f);
}