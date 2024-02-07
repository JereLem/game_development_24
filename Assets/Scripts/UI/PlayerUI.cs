using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EventSystem;
public class PlayerUI : MonoBehaviour
{
    // Reference to scripts
    public LevelParameters levelParameters;
    public PlayerStats playerStats;
    public TickSystem tickSystem;
    private int remainingTicks;

    void Start()
    {
        // Get data from EventSystem, PlayerStats and TickSystem
        levelParameters = GameObject.FindGameObjectWithTag("EventSystem")?.GetComponent<LevelParameters>();
        tickSystem = GameObject.FindGameObjectWithTag("EventSystem")?.GetComponent<TickSystem>();
        playerStats = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerStats>();
        remainingTicks = levelParameters.timerDuration;

        UpdateUI();
    }

    void Update()
    {
        // Update the remaining ticks
        remainingTicks = Mathf.Max(levelParameters.timerDuration - tickSystem.GetCurrentTick(), 0);
        UpdateUI();
    }

    void UpdateUI()
    {
        Transform panel = GameObject.Find("TopPanel").transform;

        // Find every text element
        TMP_Text number = panel.Find("levelNumber").GetComponent<TMP_Text>();
        TMP_Text name = panel.Find("levelName").GetComponent<TMP_Text>();
        TMP_Text targetValue = panel.Find("targetValue").GetComponent<TMP_Text>();
        TMP_Text timeLimit = panel.Find("timeLimit").GetComponent<TMP_Text>();

        // Set every text to the UI
        number.text = levelParameters.levelNumber.ToString();
        name.text = levelParameters.levelName;
        targetValue.text = playerStats.pickpocketedValue.ToString() + "/" + levelParameters.targetValue.ToString();


        // Time calculations
        int ticksPerMinute = 3600;
        int remainingMinutes = remainingTicks / ticksPerMinute;
        int remainingSeconds = (remainingTicks % ticksPerMinute) / 100;
        int remainingMilliseconds = (remainingTicks % ticksPerMinute) % 100;

        // Format the as mm:ss:ms
        string formattedTicks = string.Format("{0:D2}:{1:D2}:{2:D2}", remainingMinutes, remainingSeconds, remainingMilliseconds);
        timeLimit.text = formattedTicks;
    }
}
