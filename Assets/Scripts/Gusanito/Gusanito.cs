/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `SolarSystem.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

May 18, 2022
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gusanito : MonoBehaviour
{
    // Attributes
    private Model model;

    // Start Method
    void Start()
    {
        // New Model
        this.model = new Model(name: "Gusanito", speed: 0.5f, unit: 1.0f);
        // Create Planets
        this.createComponents(amount: 3);
        // Populate Planets
        this.setInitialValues();
    }

    // Update Method
    void Update()
    {
        foreach (var cube in this.model.components)
        {
            if (Mathf.Abs(cube.rotationV.x) > 45)
                cube.deltaRotation *= -1;
            cube.updateRotation(x: cube.deltaRotation);
            cube.prepareTransformations();
            if (cube.index == 0)
                cube.update(cube.rotationM * cube.positionM * cube.scaleM);
            else
                cube.update(cube.parent.matrix * cube.parent.scaleM.inverse * cube.positionM * cube.rotationM * cube.positionM * cube.scaleM);
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
                    name: "Cube " + i,
                    speed: this.model.speed,
                    unit: this.model.unit
                )
            );
    }

    private void setInitialValues()
    {
        List<Component> cubes = this.model.components;
        // Set Planets Initial Values from Values Arrays
        foreach (var cube in this.model.components)
        {
            cube.scaleV.z *= 2;
            cube.positionV.z = cube.scaleV.z / 2;
            cube.deltaRotation = 1;
            if (cube.index > 0)
                cube.parent = cubes[Sections.parents[cube.index]];
        }
    }
}
