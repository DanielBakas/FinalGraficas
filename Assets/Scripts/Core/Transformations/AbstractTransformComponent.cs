/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `AbstractTransformComponent.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

May 18, 2022
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTransformComponent : TransformBehavior
{
    // Literal Attributes
    public float deltaOrbit;
    public float deltaPosition;
    public float deltaRotation;
    public float frequency;
    public float speed;
    public float unit;

    // Matrix Attributes
    public Matrix4x4 matrix;
    public Matrix4x4 orbitM;
    public Matrix4x4 positionM;
    public Matrix4x4 rotationM;
    public Matrix4x4 scaleM;

    // Vector Attributes
    public Vector3 orbitV;
    public Vector3 positionV;
    public Vector3 rotationV;
    public Vector3 scaleV;

    // Unity Attributes
    public GameObject gameObject;
    public Vector3[] originalVertices;

    // Vector Methods
    public void updateOrbit(float x = 0.0f, float y = 0.0f, float z = 0.0f) { this.orbitV += new Vector3(x, y, z) * this.unit / Screen.currentResolution.refreshRate * this.speed * this.frequency; }
    public void updatePosition(float x = 0.0f, float y = 0.0f, float z = 0.0f) { this.positionV += new Vector3(x, y, z) * this.unit / Screen.currentResolution.refreshRate * this.speed * this.frequency; }
    public void updateRotation(float x = 0.0f, float y = 0.0f, float z = 0.0f) { this.rotationV += new Vector3(x, y, z) * this.unit / Screen.currentResolution.refreshRate * this.speed * this.frequency; }
    public void updateScale(float x = 0.0f, float y = 0.0f, float z = 0.0f) { this.scaleV += new Vector3(x, y, z) * this.unit / Screen.currentResolution.refreshRate * this.speed * this.frequency; }

    // Matrix Methods
    public void prepareTransformations()
    {
        // TODO: Implement recursion
        this.orbitM = Transformations.RotateM(this.orbitV.x, Transformations.AXIS.AX_X);
        this.orbitM *= Transformations.RotateM(this.orbitV.y, Transformations.AXIS.AX_Y);
        this.orbitM *= Transformations.RotateM(this.orbitV.z, Transformations.AXIS.AX_Z);
        this.positionM = Transformations.TranslateM(this.positionV.x, this.positionV.y, this.positionV.z);
        this.rotationM = Transformations.RotateM(this.rotationV.x, Transformations.AXIS.AX_X);
        this.rotationM *= Transformations.RotateM(this.rotationV.y, Transformations.AXIS.AX_Y);
        this.rotationM *= Transformations.RotateM(this.rotationV.z, Transformations.AXIS.AX_Z);
        this.scaleM = Transformations.ScaleM(this.scaleV.x, this.scaleV.y, this.scaleV.z);
    }
    public void updateTransformations(Matrix4x4 matrix)
    {
        this.matrix = matrix;
        this.gameObject.GetComponent<MeshFilter>().mesh.vertices = Transformations.ApplyTransform(this.matrix, this.originalVertices);
    }
}