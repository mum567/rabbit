using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public string labelText = "Get your Livers!";
    public int maxItems = 4;
         
    
    private int _itemCount = 0;

    public bool showWindow = false;

    public int Item
    {
        get { return _itemCount; }
        set
        {
            _itemCount = value;
            Debug.LogFormat("Items:{0}", _itemCount);

            if(_itemCount >= maxItems)
            {
                labelText = "Rabbit is Free!";
                showWindow = true;
            }

            else
            {
                labelText = "Item found, only" + (maxItems - _itemCount) + "more to go!";
            }

        }
    }

        private int _playerHP = 10;

        public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("HP:{0}", _playerHP);
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Rabbit Health:" + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Get Liver" + _itemCount);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if(showWindow)
        {
            if(GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2 -50, 200, 100), "Rabbit Won!"))
            {
               // SceneManager.LoadScene(0);
            }
        }
    }

    }

    

