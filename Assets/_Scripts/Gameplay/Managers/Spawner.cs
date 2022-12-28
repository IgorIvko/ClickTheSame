using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour
{    
    private float _currentTime = 0f;

    private void Start()
    {
        FillThePool();
    }

    private void Update()
    {
        if(_currentTime >= Manager.LevelData.SpawnTime)
        {
            SpawnNewRow(Manager.LevelData.RowPosition, Manager.LevelData.StepBetweenItemsInRow, Manager.LevelData.RowCount);
            _currentTime -= Manager.LevelData.SpawnTime;
        }
        _currentTime += Time.deltaTime;
    }  
    
    private void FillThePool()
    {
        for (int i = 0; i < Manager.LevelData.PoolLength; i++)
        {
            GameObject newItem = Instantiate(Manager.LevelData.ItemPrefab, Manager.LevelData.ItemContainer.transform);
            newItem.SetActive(false);
            Manager.LevelData.PoolList.Add(newItem);
        }
    }

    public void TakeFromPool(Vector3 position)
    {        
        GameObject newItem = Manager.LevelData.PoolList.First(p => p.activeSelf == false);
        newItem.transform.position = position;
        int randomIndex = Random.Range(0, Manager.LevelData.SpritesThisLevel.Count);
        SpriteWithIndex currentSprite = Manager.LevelData.SpritesThisLevel[randomIndex];

        newItem.GetComponent<SpriteRenderer>().sprite = currentSprite.Sprite;
        newItem.GetComponent<Item>().SpriteIndex = currentSprite.SpriteIndex;
        currentSprite.CountForLevel--;
        newItem.SetActive(true);        
        if (currentSprite.CountForLevel <= 0)
        {
            Manager.LevelData.SpritesThisLevel.RemoveAt(randomIndex);
        }
    }

    public void SpawnNewRow(Vector3 position, float step, int rowCount)
    {
        if (Manager.LevelData.SpritesThisLevel.Count > 0)
        {
            for (int i = 0; i < rowCount; i++)
            {
                TakeFromPool(position + new Vector3(step * i, 0));
            }
        }
    }

}
