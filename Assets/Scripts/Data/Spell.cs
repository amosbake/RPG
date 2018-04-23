using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Spell {
    [SerializeField]
    private string name;
    [SerializeField]
    private int damage;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float castTime;
    [SerializeField]
    private GameObject spellPrefab;
    [SerializeField]
    private Color barColor;

    public GameObject SpellPrefab
    {
        get
        {
            return spellPrefab;
        }

        set
        {
            spellPrefab = value;
        }
    }

    public Color BarColor
    {
        get
        {
            return barColor;
        }

        set
        {
            barColor = value;
        }
    }

    public float CastTime
    {
        get
        {
            return castTime;
        }

        set
        {
            castTime = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public Sprite Icon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }
}
