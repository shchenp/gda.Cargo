using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
   [SerializeField] private LineRenderer _renderer;

   private Camera _camera;
   private float _depth = 13;

   private void Awake()
   {
      _camera = Camera.main;
   }

   private void Update()
   {
      if (Input.GetMouseButton(0))
      {
         SetNewPoint();
      }

      if (Input.GetMouseButtonUp(0))
      {
         Destroy(this);
      }
   }

   private void SetNewPoint()
   {
      _renderer.positionCount++;
      
      var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _depth);
      var position = _camera.ScreenToWorldPoint(mousePosition);
      
      var index = _renderer.positionCount - 1;
      _renderer.SetPosition(index, position);
   }
}
