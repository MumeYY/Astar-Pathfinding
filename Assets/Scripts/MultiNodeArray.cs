using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MultiNodeArray
{
    [SerializeField]
    private int width;

    public int Width { get { return width; } }
    [SerializeField]
    private int height;

    public int Height { get { return height; } }
    [SerializeField,HideInInspector]
    public Node[] values;

    public Node this[int x, int y]
    {
        get { return values[y * width + x]; }
        set { values[y * width + x] = value; }
    }

    public MultiNodeArray(int width, int height)
    {
        this.width = width;
        this.height = height;

        values = new Node[width * height];
    }
}


