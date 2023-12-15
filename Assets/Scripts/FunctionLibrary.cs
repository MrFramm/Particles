using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{
    public delegate float Function(float x, float t);
    public static Function GetFunction (int index)
    {
        switch (index)
        {
            case 0:
                return Wave;
            case 1:
                return MultiWave;
            case 2:
                return Ripple;

        }
        return Wave;
    }
    public static float Wave(float x, float t)
    {
        return Sin(PI * (x + t));
    }
    public static float MultiWave(float x, float t)
    {
        float y = Sin(PI * (x + 0.5f * t));
        y += Sin(2f * PI * (x + t)) * (1f / 2f);
        return y * (2f / 3f);
    }
    public static float Ripple(float x, float t)
    {
        float d = Abs(x);
        return d;
    }
}
