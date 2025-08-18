using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillAction : BaseAction
{
    [SerializeField] private int manaCost;
    [SerializeField] private Sprite skillImage;

    private void Start()
    {
        skillCost = manaCost;
    }

    public Sprite GetSkillImage()
    {
        return skillImage;
    }

}
