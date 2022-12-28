using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputClick : MonoBehaviour, IPointerDownHandler
{   
    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameData.GameState == GameState.Play)
        {
            Manager.Events.PlayTouchSound?.Invoke();
            AddClickedGameobjectToList();
            CheckClickedListForDestroy();                    
        }
    }

    private void AddClickedGameobjectToList()
    {
        foreach (GameObject item in Manager.LevelData.Clicked)
        {
            if (item.Equals(gameObject)) return;
        }
        Manager.LevelData.Clicked.Add(gameObject);
        gameObject.GetComponent<SpriteRenderer>().color = Manager.LevelData.ClickedColor;
    }

    private void CheckClickedListForDestroy()
    {
        
        for (int i = 0; i < Manager.LevelData.Clicked.Count - 1; i++)
        {
            int index1 = Manager.LevelData.Clicked[i].GetComponent<Item>().SpriteIndex;
            int index2 = Manager.LevelData.Clicked[i + 1].GetComponent<Item>().SpriteIndex;
            if (index1 != index2)
            {
                Manager.Instance.ClearClickedList();
                Manager.LevelData.Clicked.Add(gameObject);
                gameObject.GetComponent<SpriteRenderer>().color = Manager.LevelData.ClickedColor;                
                Manager.LevelData.ComboCount = 0;
                return;
            }
        }

        if (Manager.LevelData.Clicked.Count >= 3)
        {
            for (int i = 0; i < Manager.LevelData.Clicked.Count; i++)
            {
                Manager.LevelData.Clicked[i].SetActive(false);
            }
            Manager.LevelData.ComboCount++;              
            Manager.Events.Destroy3?.Invoke(Manager.LevelData.Clicked);
            Manager.Events.PlayDestroySound?.Invoke();
            if (Manager.LevelData.ComboCount >= 3)
            {
                Manager.Events.AddScore?.Invoke(Manager.LevelData.ScoreForDestroy * Manager.LevelData.ComboCount/2);
                GameObject combo = Instantiate(Manager.LevelData.comboTextPrefab, Manager.LevelData.Canvas.transform);
                combo.transform.position += new Vector3(0, Random.Range(-35f, 35f));
                combo.GetComponent<TextMeshProUGUI>().text = "Combo " + Manager.LevelData.ComboCount;
            }
            else
            {
                Manager.Events.AddScore?.Invoke(Manager.LevelData.ScoreForDestroy);
            }
            Manager.Instance.ClearClickedList();
            Manager.Instance.CheckItemsOnScene();
        }       
    }   
}
