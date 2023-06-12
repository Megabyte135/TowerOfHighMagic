using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NodeRenderer
{
    Canvas _canvas;

    public NodeRenderer(Canvas canvas)
    {
        _canvas = canvas;
    }

    public abstract void Render();
}
