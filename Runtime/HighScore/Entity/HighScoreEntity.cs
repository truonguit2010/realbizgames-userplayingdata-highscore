using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreEntity
{
    public static HighScoreEntity defaultValue {
        get {
            HighScoreEntity entity = new HighScoreEntity();

            entity.highScore = 0;
            entity.name = string.Empty;
            entity.time = string.Empty;

            return entity;
        }
    }

    public int highScore;
    public string name;

    public string time;
}
