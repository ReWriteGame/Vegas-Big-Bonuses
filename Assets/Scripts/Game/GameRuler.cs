using UnityEngine;
using UnityEngine.Events;

public class GameRuler : MonoBehaviour
{
    [SerializeField] private Arrow arrow1;
    [SerializeField] private Roulette roulette;
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private int userNumber = 0;


    public UnityEvent addScoreEvent;
    public UnityEvent takeAwayScoreEvent;
    
    private void OnEnable()
    {
        roulette.endRotateEvent?.AddListener(GetResults);
    }

    private void OnDisable()
    {
        roulette.endRotateEvent.RemoveListener(GetResults);
    }

    public void GetResults()
    {
        if (arrow1.collidedObject.Value > 0)
        {
            scoreCounter.Add(arrow1.collidedObject.Value);
            addScoreEvent?.Invoke();
        }
        else
        {
            scoreCounter.TakeAway(Mathf.Abs(arrow1.collidedObject.Value));
            takeAwayScoreEvent?.Invoke();
        }
        
    }

}
