/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `Walker.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

May 18, 2022
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    // Attributes
    private Model model;

    // Start Method 
    void Start()
    {
        // New Model
        this.model = new Model(name: "Walker", speed: 0.5f, unit: 1.0f);
        // Create Components
        this.createComponents(amount: System.Enum.GetNames(typeof(Parts.parts)).Length);
        // Populate Components
        this.setInitialValues();
    }

    // Update Method
    void Update()
    {
        foreach (var part in this.model.components)
        {
            switch (part.index)
            {
                case (int)Parts.parts.Hips:
                    if (Mathf.Abs(part.positionV.y) > Mathf.Abs(part.deltaPosition))
                        part.deltaPosition *= -1;
                    part.updatePosition(y: part.deltaPosition);
                    part.prepareTransformations();
                    part.update(part.positionM * part.rotationM * part.scaleM);
                    break;
                case (int)Parts.parts.Chest:
                case (int)Parts.parts.Neck:
                    if (Mathf.Abs(part.rotationV.y) > Mathf.Abs(part.deltaPosition))
                        part.deltaRotation *= -1;
                    part.updateRotation(y: part.deltaRotation);
                    break;
                case (int)Parts.parts.LShoulder:
                case (int)Parts.parts.RShoulder:
                case (int)Parts.parts.LThigh:
                case (int)Parts.parts.RThigh:
                    if (Mathf.Abs(part.rotationV.x) > Mathf.Abs(part.deltaPosition))
                        part.deltaRotation *= -1;
                    part.updateRotation(x: part.deltaRotation);
                    break;
                case (int)Parts.parts.LCalve:
                case (int)Parts.parts.RCalve:
                    if (part.parent.deltaRotation > 0)
                    {
                        if (part.rotationV.x < -part.deltaPosition || part.rotationV.x > 0)
                            part.deltaRotation *= -1;
                        part.updateRotation(x: part.deltaRotation);
                    }
                    else part.rotationV.x = 0.0f;
                    break;
                default: break;
            }
            if (part.index > (int)Parts.parts.Hips)
            {
                part.prepareTransformations();
                part.update(part.parent.matrix * part.parent.scaleM.inverse * part.positionM * part.rotationM * part.positionM * part.scaleM);
            }
        }
    }

    // Methods
    private void createComponents(int amount)
    {
        // Create Cubes
        for (int i = 0; i < amount; i++)
            this.model.components.Add(
                new Component(
                    gameObject: GameObject.CreatePrimitive(PrimitiveType.Cube),
                    index: i,
                    name: System.Enum.GetName(typeof(Parts.parts), i),
                    speed: this.model.speed,
                    unit: this.model.unit
                )
            );
    }

    private void setInitialValues()
    {
        List<Component> parts = this.model.components;
        // Set Planets Initial Values from Values Arrays
        foreach (var part in this.model.components)
        {
            part.deltaRotation = Parts.movement[part.index];
            part.deltaPosition = Parts.movement[part.index];
            if (part.index > 0)
                part.parent = parts[Parts.parents[part.index]];
            else part.frequency *= 2;
            part.scaleV = Parts.scales[part.index];
            part.positionV = Parts.positions(part) / 2;
        }
    }
}
