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

public class Rubiks : MonoBehaviour
{
    // Attributes
    private Model model;

    // Start Method
    void Start()
    {
        // New Model
        this.model = new Model(name: "Rubiks", speed: 15.0f, unit: 1.0f);
        // Create Planets
        this.createComponents(amount: 8);
        // Populate Planets
        this.setInitialValues();
    }

    // Update Method
    void Update()
    {
        foreach (var cube in this.model.components)
        {
            if (cube.orbitV.z < 360)
            {
                cube.updateOrbit(z: cube.deltaOrbit);
                if (cube.positionV.z > 0)
                    cube.prepare();
            }
            else if (cube.orbitV.y < 360)
            {
                cube.updateOrbit(y: cube.deltaOrbit);
                if (cube.positionV.y > 0)
                {
                    Debug.Log(cube.gameObject.name);
                    cube.prepare();
                }
            }
            else
                cube.orbitV *= 0;
            cube.update(cube.orbitM * cube.positionM * cube.scaleM);
        };
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
        // Set Planets Initial Values from Values Arrays
        foreach (var cube in this.model.components)
        {
            cube.deltaOrbit = 1.0f;
            cube.parent = this.model;
            cube.positionV = Cubes.positions[cube.index] / 2;
            cube.prepare();
        }
    }
}
