/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `AbstractComponent.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

May 18, 2022
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractComponent : AbstractTransformComponent
{
    // Model Attributes
    public List<Component> components;
    public Component parent;
    public int index;
    public string type;

    // Attributes
    public void prepare()
    {
        this.prepareTransformations();
    }

    public override string ToString()
    {
        string result = this.gameObject.name + ":\n";
        if (this.parent != null)
            result += "- Parent: " + this.parent.gameObject.name + "\n";
        result += "- Orbit: " + this.orbitV + "\n";
        result += "- Position: " + this.positionV + "\n";
        result += "- Rotation: " + this.rotationV + "\n";
        result += "- Scale: " + this.scaleV + "\n";
        return result;
    }

    public void update(Matrix4x4 matrix)
    {
        this.updateTransformations(matrix);
    }
}