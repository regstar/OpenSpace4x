﻿/*****************************************************************************************************************************************
Author: Michael Shoots
Email: michael.shoots@live.com
Project: Open Space 4x
License: MIT License
Notes:
******************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuleSetButton : baseToggleButton
{
    [SerializeField]
    Image ModuleTexture;
    [SerializeField]
    Text ModuleName;
    [SerializeField]
    Text ModuleDescription;
    [SerializeField]
    Text ModuleMod;

    ModuleSet moduleSet;

    public delegate void ButtonPress(ModuleSet modSet);
    protected ButtonPress buttonCallBack;

    public delegate void Select(ModuleSetButton button);
    protected Select selectCallBack;

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetModuleSet(ModuleSet modSet, ButtonPress callBack, Select select)
    {
        moduleSet = modSet;
        buttonCallBack = callBack;
        selectCallBack = select;

        ModuleName.text = moduleSet.GetName();
        ModuleDescription.text = moduleSet.GetDescription();
        ModuleMod.text = "Mod: " + moduleSet.GetParentModName();

        Texture2D texture = moduleSet.GetTexture();
        ModuleTexture.sprite =  Sprite.Create(texture, new Rect(0,0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        ModuleTexture.preserveAspect = true;
    }

    public void ClickModuleSetButton()
    {
        selectCallBack(this);
        buttonCallBack(moduleSet);
    }
}
