using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles all the global temporary data
/// </summary>
public static class GameData
{
    public static bool paused = false;

    public static int timeBeingChased = 0;

    private const int obstacleLayer = 9;
    private const int coinLayer = 10;

    public const int obstacleLayerMask = 1 << obstacleLayer;
    public const int coinLayerMask = 1 << coinLayer;

    public static int coinsCollectedOnRun = 0;
}
