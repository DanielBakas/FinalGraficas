/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `LightComponent.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

May 18, 2022
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/

public class LightComponent
{
    public float k;
    public float I;

    public LightComponent() { }
    public LightComponent(float k, float I)
    {
        this.k = k;
        this.I = I;
    }

    public float product() { return this.k * this.I; }
}