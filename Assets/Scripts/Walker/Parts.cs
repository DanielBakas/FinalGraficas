/*
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
# Computational Graphics
Module | `Parts.cs`

Daniel Bakas Amuchástegui           A01657103\
Oscar Alfredo Belmont Rodríguez     A01654861\
Karla Paola Ruiz García             A01655768\

May 18, 2022
––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
*/

using System.Collections.Generic;
using UnityEngine;

public static class Parts
{
    public enum parts
    {
        Hips,
        Abdomen, Chest, Neck, Head,
        LShoulder, RShoulder,
        LArm, RArm,
        LForearm, RForearm,
        LHand, RHand,
        LThigh, RThigh,
        LCalve, RCalve,
        LFoot, RFoot
    }

    public static List<int> parents = new List<int>()
    {
        -1,                     // Hips         (0)
        (int)parts.Hips,        // Abdomen      (1)
        (int)parts.Abdomen,     // Chest        (2)
        (int)parts.Chest,       // Neck         (3)
        (int)parts.Neck,        // Head         (4)
        (int)parts.Chest,       // LShoulder    (5)
        (int)parts.Chest,       // RShoulder    (6)
        (int)parts.LShoulder,   // LArm         (7)
        (int)parts.RShoulder,   // RArm         (8)
        (int)parts.LArm,        // LForearm     (9)
        (int)parts.RArm,        // RForearm     (10)
        (int)parts.LForearm,    // LHand        (11)
        (int)parts.RForearm,    // RHand        (12)
        (int)parts.Hips,        // LThigh       (13)
        (int)parts.Hips,        // RThigh       (14)
        (int)parts.LThigh,      // LCalve       (15)
        (int)parts.RThigh,      // RCalve       (16)
        (int)parts.LCalve,      // LFoot        (17)
        (int)parts.RCalve,      // RFoot        (18)
    };

    public static List<float> movement = new List<float>()
    {
        0.5f,                   // Hips         (0)
        0.0f,                   // Abdomen      (1)
        -5.0f,                  // Chest        (2)
        5.0f,                   // Neck         (3)
        0.0f,                   // Head         (4)
        7.0f,                   // LShoulder    (5)
        -7.0f,                  // RShoulder    (6)
        0.0f,                   // LArm         (7)
        0.0f,                   // RArm         (8)
        0.0f,                   // LForearm     (9)
        0.0f,                   // RForearm     (10)
        0.0f,                   // LHand        (11)
        0.0f,                   // RHand        (12)
        20.0f,                  // LThigh       (13)
        -20.0f,                 // RThigh       (14)
        30.0f,                  // LCalve       (15)
        30.0f,                  // RCalve       (16)
        0.0f,                   // LFoot        (17)
        0.0f,                   // RFoot        (18)
    };

    public static List<Vector3> scales = new List<Vector3>()
    {
        new Vector3(x: 8.0f, y: 4.0f, z: 6.0f),     // Hips         (0)
        new Vector3(x: 6.0f, y: 5.0f, z: 4.0f),     // Abdomen      (1)
        new Vector3(x: 10.0f, y: 5.0f, z: 8.0f),    // Chest        (2)
        new Vector3(x: 2.0f, y: 1.0f, z: 2.0f),     // Neck         (3)
        new Vector3(x: 4.0f, y: 4.0f, z: 4.0f),     // Head         (4)
        new Vector3(x: 4.0f, y: 4.0f, z: 4.0f),     // LShoulder    (5)
        new Vector3(x: 4.0f, y: 4.0f, z: 4.0f),     // RShoulder    (6)
        new Vector3(x: 2.0f, y: 3.0f, z: 2.0f),     // LArm         (7)
        new Vector3(x: 2.0f, y: 3.0f, z: 2.0f),     // RArm         (8)
        new Vector3(x: 4.0f, y: 6.0f, z: 4.0f),     // LForearm     (9)
        new Vector3(x: 4.0f, y: 6.0f, z: 4.0f),     // RForearm     (10)
        new Vector3(x: 2.0f, y: 2.0f, z: 2.0f),     // LHand        (11)
        new Vector3(x: 2.0f, y: 2.0f, z: 2.0f),     // RHand        (12)
        new Vector3(x: 3.0f, y: 7.0f, z: 4.0f),     // LThigh       (13)
        new Vector3(x: 3.0f, y: 7.0f, z: 4.0f),     // RThigh       (14)
        new Vector3(x: 4.0f, y: 8.0f, z: 6.0f),     // LCalve       (15)
        new Vector3(x: 4.0f, y: 8.0f, z: 6.0f),     // RCalve       (16)
        new Vector3(x: 4.0f, y: 2.0f, z: 8.0f),     // LFoot        (17)
        new Vector3(x: 4.0f, y: 2.0f, z: 8.0f),     // RFoot        (18)
    };

    public static Vector3 positions(Component part)
    {
        Vector3 result = new Vector3();
        switch (part.index)
        {
            case (int)Parts.parts.Abdomen:
            case (int)Parts.parts.Chest:
            case (int)Parts.parts.Neck:
            case (int)Parts.parts.Head:
                result.y = (part.scaleV.y + part.parent.scaleV.y) / 2; break;
            case (int)Parts.parts.LShoulder:
                result.x = -(part.scaleV.x + part.parent.scaleV.x) / 2; break;
            case (int)Parts.parts.RShoulder:
                result.x = (part.scaleV.x + part.parent.scaleV.x) / 2; break;
            case (int)Parts.parts.LThigh:
                result.x = -(part.unit + part.scaleV.x) / 2;
                result.y = part.unit - (part.scaleV.y + part.parent.scaleV.y) / 2;
                break;
            case (int)Parts.parts.RThigh:
                result.x = (part.unit + part.scaleV.x) / 2;
                result.y = part.unit - (part.scaleV.y + part.parent.scaleV.y) / 2;
                break;
            case (int)Parts.parts.LCalve:
            case (int)Parts.parts.RCalve:
                result.y = part.unit - (part.scaleV.y + part.parent.scaleV.y) / 2; break;
            case (int)Parts.parts.LArm:
            case (int)Parts.parts.RArm:
            case (int)Parts.parts.LForearm:
            case (int)Parts.parts.RForearm:
            case (int)Parts.parts.LHand:
            case (int)Parts.parts.RHand:
            case (int)Parts.parts.LFoot:
            case (int)Parts.parts.RFoot:
                result.y = -(part.scaleV.y + part.parent.scaleV.y) / 2; break;
            default: break;
        }
        return result;
    }
}