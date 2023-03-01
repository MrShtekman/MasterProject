using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{

    [SerializeField] private List<Material> materials = new List<Material>();
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {

        ChangeTexture();
    }

    public void ChangeTexture()
    {
        
        foreach(Transform child in transform)
        {
            child.GetComponent<Renderer>().material = materials[index];
        }
        
        index = ((index + 1) < materials.Count) ? ++index : 0;
    }
}
