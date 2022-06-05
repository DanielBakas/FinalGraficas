/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `Planets.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

May 18, 2022
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/

using System.Collections.Generic;

public static class Planets
{
    public static List<string> names = new List<string>() {
        // Suns
        "The Sun",
        // Planets
        "Mercury",
        "Venus",
        "Earth",
        "Mars",
        "Jupiter",
        "Saturn",
        "Uranus",
        "Neptune",
        // Moons
        "The Moon"
    };
    public static List<float> orbit = new List<float>() {
        // Suns
        0.0f,       // The Sun
        // Planets
        0.3f,       // Mercury
        0.8f,       // Venus
        0.9f,       // Earth
        0.5f,       // Mars
        10.2f,      // Jupiter
        8.6f,       // Saturn
        3.6f,       // Uranus
        3.5f,       // Neptune
        // Moons
        10.0f        // The Moon
    };

    public static List<int> parents = new List<int>() {
        // Suns
        -1,         // The Sun
        // Planets
        0,          // Mercury
        0,          // Venus
        0,          // Earth
        0,          // Mars
        0,          // Jupiter
        0,          // Saturn
        0,          // Uranus
        0,          // Neptune
        // Moons
        3           // The Moon
    };

    public static List<float> rotations = new List<float>() {
        // Suns
        0.04f,      // The Sun
        // Planets
        0.02f,      // Mercury
        0.005f,     // Venus
        1.0f,       // Earth
        1.02f,      // Mars
        2.4f,       // Jupiter
        2.24f,      // Saturn
        1.4f,       // Uranus
        1.6f,       // Neptune
        // Moons
        0.04f       // The Moon
    };

    public static List<float> scales = new List<float>() {
        // Suns
        100.0f,     // The Sun
        // Planets
        0.3f,       // Mercury
        0.8f,       // Venus
        0.9f,       // Earth
        0.5f,       // Mars
        10.2f,      // Jupiter
        8.6f,       // Saturn
        3.6f,       // Uranus
        3.5f,       // Neptune
        // Moons
        0.1f,       // Moon
    };

    public static List<float> separations = new List<float>() {
        // Suns
        0.0f,       // The Sun
        // Planets
        3.9f,       // Mercury
        7.2f,       // Venus
        10.0f,      // Earth
        15.2f,      // Mars
        50.2f,      // Jupiter
        95.4f,      // Saturn
        192.0f,     // Uranus
        300.6f,     // Neptune
        // Moons
        0.1f        // Moon
    };
    public static List<string> types = new List<string>() {
        // Suns
        "sun",      // The Sun
        // Planets
        "planet",   // Mercury
        "planet",   // Venus
        "planet",   // Earth
        "planet",   // Mars
        "planet",   // Jupiter
        "planet",   // Saturn
        "planet",   // Uranus
        "planet",   // Neptune
        // Moons
        "moon"      // Moon
    };
}