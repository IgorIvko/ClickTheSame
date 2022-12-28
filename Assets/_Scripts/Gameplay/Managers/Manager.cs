using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Events Events; 
    public static GameData LevelData;
    public static Manager Instance;

    private void Awake()
    {
        Events = GameObject.FindWithTag("Events").GetComponent<Events>();
        LevelData = GameObject.FindWithTag("GameData").GetComponent<GameData>();
        Instance = this;

        CreateSpritesForLevel();     
        GameData.CurrentLevel = LevelData.LevelNumber;         
        SetSettingsOnLevel();
        SetScreenSettings();        
    }

    private void CreateSpritesForLevel()
    {
        while (LevelData.SpritesThisLevel.Count < LevelData.ThisLevelSpritesCount)
        {
            int randomIndex = Random.Range(0, LevelData.Sprites.Count);
            if (SpriteIsUnique(randomIndex))
            {
                LevelData.Sprites[randomIndex].CountForLevel = LevelData.CountEachItemForLevel;
                LevelData.SpritesThisLevel.Add(LevelData.Sprites[randomIndex]);
            }
        }
    }

    private bool SpriteIsUnique(int spriteIndex)
    {
        foreach (SpriteWithIndex item in LevelData.SpritesThisLevel)
        {
            if (item.SpriteIndex == spriteIndex) return false;
        }
        return true;
    }

    public void ClearClickedList()
    {
        foreach (GameObject item in LevelData.Clicked)
        {
            item.GetComponent<SpriteRenderer>().color = Color.white;
        }
        LevelData.Clicked.Clear();
    }

    public static void LoseLevel()
    {        
        Manager.Instance.SaveSettings();
        SceneManager.LoadScene(2); //YouLose
    }

    public static void WinLevel()
    {                
        SceneManager.LoadScene(3); //YouWin
    }

    public void CheckItemsOnScene()
    {
        if (LevelData.SpritesThisLevel.Count == 0 && LevelData.PoolList.Find(p => p.activeSelf) == null)
        {           
            SaveSettings();
            WinLevel();
        }
    }  
    
    private void SetSettingsOnLevel()
    {
        gameObject.GetComponent<BackgroundMusic>().Music.volume = GameData.BackGroundMusicLevel;
        gameObject.GetComponent<PlayDestroySound>().Sound.volume = GameData.GameplaySoundsLevel;
        gameObject.GetComponent<PlayTouchSound>().Sound.volume = GameData.GameplaySoundsLevel;
    }

    public void SaveSettings()
    {
        GameData.Score = LevelData.CurrentScore;
        GameData.BackGroundMusicLevel = gameObject.GetComponent<BackgroundMusic>().Music.volume;
        GameData.GameplaySoundsLevel = gameObject.GetComponent<PlayDestroySound>().Sound.volume;        
    }   
    
    private void SetScreenSettings()
    {
        if(Screen.height != 2160)
        {
            // эталон экрана имеет соотношение 2:1, стартовый х = -20
            // смещение соотношения на 0.1f даст смещение по иксу на 1
            // размер item в инспекторе 1.88f
            float itemSize = 1.88f;
            float x = (float)Screen.height / (float)Screen.width;
            float step = (x - 2f) * 10;
            LevelData.RowPosition.x += step;
            float width = -LevelData.RowPosition.x * 2; 
            float spaceWidth = (width - itemSize * (LevelData.RowCount-1)) / (LevelData.RowCount-1);
            // расстояние между ЦЕНТРАМИ ДВУХ ITEM = ширина пробела + размер item
            LevelData.StepBetweenItemsInRow = spaceWidth + itemSize;
        }        
    }
}


