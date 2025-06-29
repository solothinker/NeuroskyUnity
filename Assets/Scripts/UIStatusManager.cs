using UnityEngine;
using System.Collections.Generic;
using MindWave;

public class UIStatusManager : MonoBehaviour
{
    public static UIStatusManager Instance;

    [Header("Assign in order: Player 0, 1, 2, 3")]
    public List<UdateStatus> statusBars;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    /// <summary>
    /// Global function to update any player's status by ID
    /// </summary>
    public void UpdatePlayerStatus(int playerId, int value)
    {
        if (playerId >= 0 && playerId < statusBars.Count)
        {
            statusBars[playerId].SetStatus(value);
        }
        else
        {
            Debug.LogWarning("Invalid player ID: " + playerId);
        }
    }
}
