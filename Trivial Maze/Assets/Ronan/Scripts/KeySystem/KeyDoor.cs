using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public bool checkGroupKeys = false;
    public int requiredKeys;
    public KeyType doorTier;

//    public void CheckSingleKeys(Collider collider)
//    {
//        switch (doorTier)
//        {
//            case KeyType.TierOne:
//                if (collider.gameObject.GetComponent<KeyCollecter>().TierOneKeys >= requiredKeys)
//                {
//                    //collider.gameObject.GetComponent<KeyCollecter>().TierOneKeys -= requiredKeys;
//                    Destroy(gameObject);
//                }
//                break;

//            case KeyType.TierTwo:
//                if (collider.gameObject.GetComponent<KeyCollecter>().TierTwoKeys >= requiredKeys)
//                {
//                    //collider.gameObject.GetComponent<KeyCollecter>().TierTwoKeys -= requiredKeys;
//                    Destroy(gameObject);
//                }
//                break;

//            case KeyType.TierThree:
//                if (collider.gameObject.GetComponent<KeyCollecter>().TierThreeKeys >= requiredKeys)
//                {
//                    //collider.gameObject.GetComponent<KeyCollecter>().TierThreeKeys -= requiredKeys;
//                    Destroy(gameObject);
//                }
//                break;
        
//        }
//    }

//    public void CheckGroupKeys()
//    {
//        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");
//        int totalKeys = 0;

//D        for (int i = 0; i < gameObjects.Length; i++)
//        {
//            switch (doorTier)
//            {
//                case KeyType.TierOne:
//                    totalKeys += gameObjects[i].GetComponent<KeyCollecter>().TierOneKeys;
//                    break;

//                case KeyType.TierTwo:
//                    totalKeys += gameObjects[i].GetComponent<KeyCollecter>().TierOneKeys;
//                    break;

//                case KeyType.TierThree:
//                    totalKeys += gameObjects[i].GetComponent<KeyCollecter>().TierOneKeys;
//                    break;
//            }
//        }

//        if (totalKeys >= requiredKeys)
//        {
//            Destroy(gameObject);
//        }
//    }
}
