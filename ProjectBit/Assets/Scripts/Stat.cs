using UnityEngine;
using System.Collections;
using System;

[Serializable]
public struct Stats
{
    /// <summary>
    /// name of statistic
    /// </summary>
    public string name;

    /// <summary>
    /// level of the particular stat
    /// </summary>
    public int level;

    /// <summary>
    /// the constant increase for each stat for every upgrade
    /// </summary>
    public int upGradeAmount;

    /// <summary>
    /// the character level requiered to be able to upgrade the stat to the next level
    /// </summary>
    public int baseLevel;

    /// <summary>
    /// the starting amount for the statistic
    /// </summary>
    public int baseValue;

    /// <summary>
    /// the max amount value for the statistic
    /// </summary>
    public int maxValue;

    /// <summary>
    /// the maximum upgrade amount
    /// </summary>
    public int maxUpgradeValue;

    /// <summary>
    /// the starting amount for stats dealing with percentages like energy or armor
    /// </summary>
    public float percentageValue;

    /// <summary>
    /// the max percentage amount for stats dealing with percentages like energy or armor
    /// </summary>
    public float maxPercentageValue;

    /// <summary>
    /// The current value for each stat
    /// </summary>
    private int _currentValue;
    public int currentValue
    {
        get { return _currentValue; }
        set { _currentValue = (Mathf.Clamp(value, 0, maxValue)); }
    }

    /// <summary>
    /// the current float value for stats that use percentages like energy or armor
    /// </summary>
    private float _currentFValue;
    public float currentFValue
    {
        get { return _currentFValue; }
        set { _currentFValue = (Mathf.Clamp(value, 0, maxValue)); }
    }
}
