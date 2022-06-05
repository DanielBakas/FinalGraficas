/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `AbstractPixelComponent.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

May 18, 2022
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/

using UnityEngine;

public class PixelComponent
{
    // Attributes
    float alpha;
    float ambient;
    float diffuse;
    float illumination;
    float specular;

    // LightComponent Attributes
    public LightComponent ambientC;
    public LightComponent diffuseC;
    public LightComponent specularC;

    // Vector Attributes
    public Vector3 A;
    public Vector3 B;
    public Vector3 n;
    public Vector3 l;
    public Vector3 r;
    public Vector3 v;

    public PixelComponent()
    {
        this.ambientC = new LightComponent();
        this.diffuseC = new LightComponent();
        this.specularC = new LightComponent();
    }

    public PixelComponent(LightComponent ambientC, LightComponent diffuseC, LightComponent specularC)
    {
        this.ambientC = ambientC;
        this.diffuseC = diffuseC;
        this.specularC = specularC;
    }

    public void prepare()
    {
        this.v = this.B - this.A;
        this.ambient = this.ambientC.product();
        this.diffuse = this.diffuseC.product() * Vector3.Dot(this.n, this.l);
        this.specular = this.specularC.product() * (Mathf.Pow(Vector3.Dot(this.v, this.r), alpha));
        this.illumination = this.ambient + this.diffuse + this.specular;
    }

    public void update() { }
}