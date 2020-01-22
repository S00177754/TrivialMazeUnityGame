using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollecter : MonoBehaviour
{
    public int TierOneKeys;
    public int TierTwoKeys;
    public int TierThreeKeys;

    public TimerController TimerController;

    // Start is called before the first frame update
    void Start()
    {
        TierOneKeys = 0;
        TierTwoKeys = 0;
        TierThreeKeys = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("On Trigger Enter");
        
        if(collision.gameObject.tag == "key")
        {
            switch (collision.gameObject.GetComponent<KeyScript>().Type)
            {
                case KeyType.TierOne:
                    TierOneKeys++;
                    break;

                case KeyType.TierTwo:
                    TierTwoKeys++;
                    break;

                case KeyType.TierThree:
                    TierThreeKeys++;
                    break;
            }

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "KeyDoor")
        {

            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");
            int totalKeys = 0;

            for (int i = 0; i < gameObjects.Length; i++)
            {
                switch (collision.gameObject.GetComponent<KeyDoor>().doorTier)
                {
                    case KeyType.TierOne:
                        totalKeys += gameObjects[i].GetComponent<KeyCollecter>().TierOneKeys;
                        break;

                    case KeyType.TierTwo:
                        totalKeys += gameObjects[i].GetComponent<KeyCollecter>().TierOneKeys;
                        break;

                    case KeyType.TierThree:
                        totalKeys += gameObjects[i].GetComponent<KeyCollecter>().TierOneKeys;
                        break;
                }
            }

            if (totalKeys >= collision.gameObject.GetComponent<KeyDoor>().requiredKeys)
            {
                TimerController.StopTimer();

                if (!GameObject.FindGameObjectWithTag("GameController").GetComponent<SplitscreenController>().IsMultiplayer)
                {
                    TimerController.PostTimeToAPI();
                }
                
                TimerController.ResetToStart();

                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().ReturnToMenu();
                Time.timeScale = 0;

            }

        }

    }

    public void ResetToStart()
    {
        TierOneKeys = 0;
        TierTwoKeys = 0;
        TierThreeKeys = 0;
    }

}
