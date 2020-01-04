using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public enum GameState
    {
        INGAME,
        WON,
        LOST,
        DEFAULT
    }

    public static GameState GAMESTATE = GameState.INGAME;

    public static int ADMONITIONS = 0;
    public static int SAVED_BIRDS = 0;

}
