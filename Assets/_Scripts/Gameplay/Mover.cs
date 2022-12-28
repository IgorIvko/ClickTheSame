using UnityEngine;

public class Mover : MonoBehaviour
{
    private void Update()
    {            
        transform.position -= new Vector3(0, Time.deltaTime * Manager.LevelData.Speed);
        if (transform.position.y < Manager.LevelData.GameOverLine) Manager.LoseLevel();
    }        
    
}

