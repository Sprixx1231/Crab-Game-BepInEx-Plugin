using System;
using System.Collections.Generic;
using System.Diagnostics;
using HarmonyLib;
using CrabGamePlugin.util;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CrabGamePlugin.components;

internal class Esp : MonoBehaviour
{
    public Esp(IntPtr ptr) : base(ptr)
    {
    }
    
    private void OnGUI()
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