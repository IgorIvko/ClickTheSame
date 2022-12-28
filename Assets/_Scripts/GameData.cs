using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameData : MonoBehaviour
{
    public static GameState GameState = GameState.Play;
    public static float BackGroundMusicLevel = 0.5f;
    public static float GameplaySoundsLevel = 1f;
    public static int FirstLevelIndex = 4;
    public static int LevelsCount = 3;
    public static int CurrentLevel;
    public static int Score = 0;
    public int LevelNumber;
    [Header("Sprites")]
    public List<SpriteWithIndex> Sprites = new List<SpriteWithIndex>();
    public int ThisLevelSpritesCount;
    public List<SpriteWithIndex> SpritesThisLevel = new List<SpriteWithIndex>();
    [Header("Pool")]
    public GameObject ItemPrefab;
    public int PoolLength;
    public List<GameObject> PoolList = new List<GameObject>();    
    public GameObject ItemContainer;
    public GameObject Canvas;
    [Header("Spawn")]
    public Vector3 RowPosition;
    public float SpawnTime;
    public float Speed;
    public int RowCount;
    public float StepBetweenItemsInRow;
    public float GameOverLine;
    [Header("Gameplay")]
    public int CountEachItemForLevel;
    public int CurrentScore;
    public int ScoreForDestroy;
    public Color ClickedColor = new Color(0.3921f, 1f, 1f);
    public int ComboCount = 0;
    public GameObject comboTextPrefab;
    public List<GameObject> EffectsList = new List<GameObject>();
    public List<GameObject> Clicked = new List<GameObject>();       

}


