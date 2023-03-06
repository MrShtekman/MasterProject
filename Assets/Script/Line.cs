using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private Color color1;
    [SerializeField] private Color color2;

    // Start is called before the first frame update
    void Start()
    {
        line.useWorldSpace = true;

    }

    // Update is called once per frame
    void Update()
    {


        var positions = new Vector3[line.positionCount];

        for (int i = 0; i < positions.Length; i++)
        {
            float percentage = i / (positions.Length - 1f);

            Vector3 v = Vector3.Lerp(startPoint.position, endPoint.position, percentage);
            positions[i] = v;
        }

        line.SetPositions(positions);


        var gradient = new Gradient();
        gradient.mode = GradientMode.Blend;
        var gradientColorKeys = new GradientColorKey[8];

        for (int i = 0; i < line.positionCount; i++)
        {
            float percentage = i / (positions.Length - 1f);
            var test = Mathf.Sin(Time.time * 5 - i) / 2 + 0.5f;

            GradientColorKey colorkey = new GradientColorKey(Color.Lerp(color1, color2, test), percentage);
            gradientColorKeys[i] = colorkey;
            Debug.Log(test);

        }

        var alphaKeys = new GradientAlphaKey[]
        {
                new GradientAlphaKey(1f, 0),
                new GradientAlphaKey(1f, 0)
        };

        gradient.SetKeys(gradientColorKeys, alphaKeys);

        line.colorGradient = gradient;

    }

}
