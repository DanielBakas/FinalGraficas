/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `Final.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

March 21, 2022

Copyright © Computational Graphics 2022. All rights reserved.\
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/

using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    // Attributes
    public GameObject carPrefab;
    public GameObject tirePrefab;
    private Model model;

    // Start Method
    void Start()
    {
        // New Model
        this.model = new Model(name: "Cars", speed: 0.0001f, unit: 1);
        // Create Cars
        this.createComponents(amount: 5);
        // Populate Cars
        this.setInitialValues();
        // Trace Path
        this.tracePath();
    }

    // Update Method
    List<Vector3> curve;
    void Update()
    {
        foreach (Car car in this.model.components)
        {
            if (car.index == 0)
            {
                curve = Path.curves[car.curveIndex];
                if (car.deltaPosition < 1)
                {
                    if (Input.GetKey("up") && car.speed < car.speedLimit)
                        car.speed += this.model.speed;
                    else if (Input.GetKey("down") && car.speed > 0)
                        car.speed -= this.model.speed * 5;
                    else if (car.speed > 0)
                        car.speed -= this.model.speed * 3;
                    if (car.speed <= 0) car.speed = 0;
                    car.deltaPosition += car.speed;
                    car.positionV = BezierUtil.calculate(curve, car.deltaPosition);
                }
                else
                {
                    Debug.Log("HOLA");
                    car.deltaPosition = 0;
                    car.curveIndex = (car.curveIndex < Path.curves.Length - 1) ? car.curveIndex + 1 : 0;
                }
                car.positionV.y = 20;
                car.prepare();
                car.update(car.positionM * car.rotationM * car.scaleM);
            }
            else
            {
                car.positionV.y = 20;
                car.prepare();
                car.update(car.positionM * car.rotationM * car.scaleM);
            }
        }
    }

    // Methods
    private void createComponents(int amount)
    {
        // Create Cubes
        for (int i = 0; i < amount; i++)
            this.model.components.Add(
                new Car(
                    gameObject: Instantiate(this.carPrefab),
                    index: i,
                    name: "Car " + i,
                    speed: 0,
                    unit: this.model.unit
                )
            );
    }

    private void setInitialValues()
    {
        // Set Cars Initial Values from Values Arrays
        foreach (Car car in this.model.components)
        {
            car.deltaPosition = 0;
            car.rotationV = new Vector3(x: -90, y: 0);
            car.scaleV *= 500;
            car.speedLimit = this.model.speed * 100;
        }
    }

    private void tracePath()
    {
        foreach (var curve in Path.curves)
        {
            for (int i = 0; i < curve.Count; i++)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                Component component = new Component(
                        gameObject: sphere,
                        index: i,
                        name: "Curve Point",
                        speed: this.model.speed,
                        unit: this.model.unit
                    );
                component.scaleV *= 5;
                component.positionV = curve[i];
                component.prepare();
                component.update(component.positionM * component.scaleM);
            }
            int counter = 0;
            while (true)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                Component component = new Component(
                        gameObject: sphere,
                        index: counter,
                        name: "Path Point",
                        speed: this.model.speed,
                        unit: this.model.unit
                    );
                component.scaleV *= 5;
                component.positionV = BezierUtil.calculate(curve, counter * 0.01f);
                component.prepare();
                component.update(component.positionM * component.scaleM);
                if (component.positionV == curve[curve.Count - 1]) break;
                counter += 1;
            }
        }
    }
}
