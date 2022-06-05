/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `Pixel.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

May 18, 2022
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/

using UnityEngine;

public class Pixel
{
    // Pixel Component Attributes
    public PixelComponent red;
    public PixelComponent green;
    public PixelComponent blue;

    // Vector Attributes
    public Vector3 n;
    public Vector3 l;
    public Vector3 r;
    public Vector3 v;

    public Pixel()
    {
        this.red = new PixelComponent();
        this.green = new PixelComponent();
        this.blue = new PixelComponent();
    }

    public Pixel(PixelComponent red, PixelComponent green, PixelComponent blue)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
    }
}