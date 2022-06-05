/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `Solar.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

May 18, 2022
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solar : MonoBehaviour
{
    // Attributes
    private Model model;

    // Start Method
    void Start()
    {
        // New Model
        this.model = new Model(name: "Planets", speed: 0.1f, unit: 1.0f);
        // Create Components
        this.createComponents(amount: Planets.names.Count);
        // Populate Components
        this.setInitialValues();
    }

    // Update Method
    void Update()
    {
        foreach (var planet in this.model.components)
        {
            // Translate Planet relative to parent
            planet.updateOrbit(y: planet.deltaOrbit);
            // Rotate Planet along its own Y Axis
            planet.updateRotation(y: planet.deltaRotation);
            // Prepare Planet Transformations
            planet.prepareTransformations();
            // Apply Planet Transformations
            switch (planet.type)
            {
                case "sun":
                    planet.update(planet.positionM * planet.rotationM * planet.scaleM);
                    break;
                case "planet":
                    planet.update((planet.parent.positionM) * (planet.orbitM * planet.positionM * planet.rotationM * planet.scaleM));
                    break;
                case "moon":
                    planet.update((planet.parent.matrix * planet.parent.scaleM.inverse) * (planet.orbitM * planet.positionM * planet.rotationM * planet.scaleM));
                    break;
            }
        }
    }

    // Methods
    private void createComponents(int amount)
    {
        // Create Planets from Names Array
        for (int i = 0; i < amount; i++)
            this.model.components.Add(
                new Component(
                    gameObject: GameObject.CreatePrimitive(PrimitiveType.Sphere),
                    index: i,
                    name: Planets.names[i],
                    speed: this.model.speed,
                    unit: this.model.unit
                )
            );
    }

    private void setInitialValues()
    {
        List<Component> planets = this.model.components;
        // Set Planets Initial Values from Values Arrays
        foreach (var planet in this.model.components)
        {
            planet.deltaOrbit = Planets.orbit[planet.index];
            planet.deltaRotation = Planets.rotations[planet.index];
            planet.scaleV *= Planets.scales[planet.index];
            planet.type = Planets.types[planet.index];
            if (Planets.types[planet.index] != "sun")
            {
                planet.parent = planets[Planets.parents[planet.index]];
                planet.positionV.x = (planet.parent.scaleV.x / 2) + (planet.scaleV.x / 2) + Planets.separations[planet.index];
            }
        }
    }
}
