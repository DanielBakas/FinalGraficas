/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `Illumination.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

May 18, 2022
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Illumination : MonoBehaviour
{
    Pixel pixel;
    // Start is called before the first frame update
    void Start()
    {
        pixel = new Pixel();
        // Ambient Light
        pixel.red.ambientC.k = 0.05f;
        pixel.red.ambientC.I = 1;
        pixel.green.ambientC.k = 0.05f;
        pixel.green.ambientC.I = 1;
        pixel.blue.ambientC.k = 0.05f;
        pixel.blue.ambientC.I = 1;
        // Diffuse Light
        pixel.red.diffuseC.k = 0.05f;
        pixel.red.diffuseC.I = 1;
        pixel.green.diffuseC.k = 0.05f;
        pixel.green.diffuseC.I = 1;
        pixel.blue.diffuseC.k = 0.05f;
        pixel.blue.diffuseC.I = 1;
        // Specular Light
        pixel.red.specularC.k = 0.4f;
        pixel.red.specularC.I = 1;
        pixel.green.specularC.k = 0.4f;
        pixel.green.specularC.I = 1;
        pixel.blue.specularC.k = 0.4f;
        pixel.blue.specularC.I = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
