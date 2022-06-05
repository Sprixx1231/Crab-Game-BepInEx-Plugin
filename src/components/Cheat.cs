using System;
using UnityEngine;
using System.Threading;
using CrabGamePlugin.util;
using static CodeStage.AntiCheat.Common.ACTk;

namespace CrabGamePlugin.components;

internal class Cheat : MonoBehaviour
{
    private bool _hack;
    private bool _esp;
    private float _scrHeight = Screen.height;
    private int _selection = 1;
    private const int MaxSelect = 4;
    private float _scrWidth = Screen.width;

    private void Update()
    {
        //Keycode hack activation
        if (Input.GetKeyDown(KeyCode.F1))
        {
            _hack = !_hack;
        }
        if (_hack)
        {
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (_selection != MaxSelect)
                {
                    _selection += 1;
                }
                else
                {
                    if (_selection == MaxSelect)
                    {
                        _selection = 1;
                    }
                }
            }
            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (_selection != 1)
                {
                    _selection -= 1;
                }
                else
                {
                    if (_selection == 1)
                    {
                        _selection = MaxSelect;
                    }
                }
            }
            
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                if (_selection == 1)
                {
                    ToggleEsp();
                }
                else
                {
                    if (_selection == 2)
                    {
                        UnlimitedJumps();
                    }
                    else
                    {
                        if (_selection == 3)
                        {
                            Selection3();
                        }
                        else
                        {
                            if (_selection == 4)
                            {
                                Selection4();
                            }
                            else
                            {
 
                            }
                        }
                    }
                }
            }
        }
 
    }
    private void ToggleEsp()
    {
        _esp = !_esp;
    }
 
    private void UnlimitedJumps()
    {
        var comp = FindObjectOfType<PlayerInput>();
       

        
        //comp.playerMovement.
    }

    private static void Selection3()
    {
        //bhop 
        var playermov = FindObjectOfType<MonoBehaviourPublicGaplfoGaTrorplTrRiBoUnique>();
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            Thread.Sleep(1);

            if (!playermov)
                return;

            if (playermov.grounded)
            {
                Plugin.Log.LogMessage("Jump");
                return;
                //playermov.Jump();
            }


        }
    }

    private void Selection4()
        {
            // var player = GameObject.Find("Player");
        }

        private void OnGUI()
        {
            var guistyle = new GUIStyle();
            guistyle.normal.textColor = Color.green;
            GUI.Label(new Rect(10f, 40f, 260f, 20f), "Crab Game Menu v1.0 [Made by SpreadMouse#1121]", guistyle);
            //Nice GUI

            GUI.color = Color.white;
            if (_hack)
            {
                GUI.Box(new Rect(0, 290, 150, 300), "- Functions -");
                if (_selection == 1)
                {
                    GUI.color = Color.red;
                }
                else
                {
                    GUI.color = Color.white;
                }
                GUI.Label(new Rect(10, 320, 120, 30), "Player ESP");
                if (_selection == 2)
                {
                    GUI.color = Color.red;
                }
                else
                {
                    GUI.color = Color.white;
                }
                GUI.Label(new Rect(10, 350, 120, 30), "Unlimited Jumps");
                if (_selection == 3)
                {
                    GUI.color = Color.red;
                }
                else
                {
                    GUI.color = Color.white;
                }
                GUI.Label(new Rect(10, 380, 120, 30), "Selection3");
 
                if (_selection == 4)
                {
                    GUI.color = Color.red;
                }
                else
                {
                    GUI.color = Color.white;
                }
                GUI.Label(new Rect(10, 410, 120, 30), "Selection4");
 
            }

            if (_esp)
            {
                foreach (var player in FindObjectsOfType<MonoBehaviourPublicCSstReshTrheObplBojuUnique>())
                {
                    //player positions
                    Vector3 pivPos = player.transform.position;
                    Vector3 playerFootPos;
                    playerFootPos.x = pivPos.x;
                    playerFootPos.y = pivPos.y - 2f;
                    playerFootPos.z = pivPos.z;

                    Vector3 playerHeadPos;
                    playerHeadPos.x = pivPos.x;
                    playerHeadPos.y = pivPos.y + 2f;
                    playerHeadPos.z = pivPos.z;
               
                    //Screen Position
                    var cam = Camera.main;
                    Vector3 wtsFoot = cam!.WorldToScreenPoint(playerFootPos);
                    Vector3 wtsHead = cam!.WorldToScreenPoint(playerHeadPos);


                    if (wtsFoot.z > 0f)
                    {
                        DrawEsp(wtsFoot, wtsHead,Color.red, 2f );
                    }
                }
            }
        }
    
        public void DrawEsp(Vector3 footPos, Vector3 headPos, Color color,  float thiccness = 2f)
        {
            float height = headPos.y - footPos.y;
            float widthOffset = 2;
            float width = height / widthOffset;
            
            //Rendering
            Render.DrawBox(footPos.x - (width / 2), (float)Screen.height - footPos.y - height, width, height, color,thiccness);
            
            //Snap line 
            Render.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)),new Vector2(footPos.x, (float)Screen.height - footPos.y), color, thiccness);
            
        }
}