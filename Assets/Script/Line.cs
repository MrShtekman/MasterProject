using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class Line : MonoBehaviour
{
    [SerializeField] private bool startConnected;
    [SerializeField] private LineRenderer line;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private Color color1, color2, errorColor;
    private Color displayColor1, displayColor2;
    private Vector3[] positions;


    void Start()
    {
        line.useWorldSpace = true;
        //Line start with black and white
        SwitchColor();
        if (startConnected)
            SwitchColor();
        positions = new Vector3[line.positionCount];
    }

    // Update is called once per frame
    void Update()
    {



        //Creating an array of points on the line
        for (int i = 0; i < positions.Length; i++)
        {
            float percentage = i / (positions.Length - 1f);

            Vector3 v = Vector3.Lerp(startPoint.position, endPoint.position, percentage);
            positions[i] = v;
        }

        line.SetPositions(positions);


        //Switching color using the Sin function
        var gradient = new Gradient();
        gradient.mode = GradientMode.Blend;
        var gradientColorKeys = new GradientColorKey[8];

        for (int i = 0; i < line.positionCount; i++)
        {
            float percentage = i / (positions.Length - 1f);
            var colorPercentage = Mathf.Sin(Time.time * 5 - i) / 2 + 0.5f;

            GradientColorKey colorkey = new GradientColorKey(Color.Lerp(displayColor1, displayColor2, colorPercentage), percentage);
            gradientColorKeys[i] = colorkey;

        }

        var alphaKeys = new GradientAlphaKey[]
        {
                new GradientAlphaKey(1f, 0),
                new GradientAlphaKey(1f, 0)
        };

        gradient.SetKeys(gradientColorKeys, alphaKeys);

        line.colorGradient = gradient;

    }

    //Switching Line color
    public void SwitchColor()
    {
        if (displayColor1 != errorColor)
        {
            displayColor1 = errorColor;
            displayColor2 = errorColor;
        }
        else
        {
            displayColor1 = color1;
            displayColor2 = color2;
        }
    }

}
