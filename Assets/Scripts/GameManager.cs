using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool[] activeTargets;
    [SerializeField] GameObject[] possibleTargets;
    [SerializeField] int howManyActiveAtOnce;
    [SerializeField] int howManyDesiredActive;

    private bool coroutineBool;

    void Update()
    {
        howManyAreActive();
    }

    private int howManyAreActive()
    {
        foreach (bool boolean in activeTargets)
        {
            if (boolean) { howManyActiveAtOnce++; }
        }
        return howManyDesiredActive - howManyActiveAtOnce;
    }

}
