using UnityEngine;
using System;
[System.Serializable]
public class Block {
    [SerializeField]
    private GameObject first, second;
    public void Deactive()
    {
        first.SetActive(false);
        second.SetActive(false);
    }
    public void Active()
    {
        first.SetActive(true);
        second.SetActive(true);
    }
}
