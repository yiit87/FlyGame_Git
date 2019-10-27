using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private float DefaultSpeed;


    private void Awake()
    {
        Instance = this;
    }
}
