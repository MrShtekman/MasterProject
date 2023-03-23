using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : InteractiveObject
{
    private AudioSource aSource;
    [SerializeField] private Transform screen;

    private void Start()
    {
        aSource = screen.GetComponent<AudioSource>();
    }
    public override void DoAction(int value)
    {
        return;
    }

    public void IncreaseVolume()
    {
        aSource.volume += 0.1f;
    }

    public void DecreaseVolume()
    {
        aSource.volume -= 0.1f;
    }


}
