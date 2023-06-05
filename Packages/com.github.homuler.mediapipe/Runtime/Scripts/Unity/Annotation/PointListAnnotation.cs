// Copyright (c) 2021 homuler
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System.Collections.Generic;
using UnityEngine;

using mplt = Mediapipe.LocationData.Types;

namespace Mediapipe.Unity
{
#pragma warning disable IDE0065
  using Color = UnityEngine.Color;
#pragma warning restore IDE0065

  public class PointListAnnotation : ListAnnotation<PointAnnotation>
  {
    [SerializeField] private Color _color = Color.green;
    [SerializeField] private float _radius = 15.0f;
    
    //personalizado para o ponto médio
    [SerializeField] private Color _color2 = new Color(0.9f, 0.4f, 0.6f, 0.3f);

    private GameObject _bracelet;
    private GameObject _handGear;

// #if UNITY_EDITOR
//     private void OnValidate()
//     {
//       if (!UnityEditor.PrefabUtility.IsPartOfAnyPrefab(this))
//       {
//         ApplyColor(_color);
//         ApplyRadius(_radius);
//       }
//     }
// #endif

    void Update()
    {
        // ApplyColor(_color);
        // ApplyRadius(_radius);
        ShowCircle();
    }

    public void SetColor(Color color)
    {
      _color = color;
      ApplyColor(_color);
    }

    public void SetRadius(float radius)
    {
      _radius = radius;
      ApplyRadius(_radius);
    }

    public void Draw(IList<Vector3> targets)
    {
      if (ActivateFor(targets))
      {
        CallActionForAll(targets, (annotation, target) =>
        {
          if (annotation != null) { annotation.Draw(target); }
        });
      }
    }

    public void Draw(IList<Landmark> targets, Vector3 scale, bool visualizeZ = true)
    {
      if (ActivateFor(targets))
      {
        CallActionForAll(targets, (annotation, target) =>
        {
          if (annotation != null) { annotation.Draw(target, scale, visualizeZ); }
        });
      }
    }

    public void Draw(LandmarkList targets, Vector3 scale, bool visualizeZ = true)
    {
      Draw(targets.Landmark, scale, visualizeZ);
    }

    public void Draw(IList<NormalizedLandmark> targets, bool visualizeZ = true)
    {
      if (ActivateFor(targets))
      {
        CallActionForAll(targets, (annotation, target) =>
        {
          if (annotation != null) { annotation.Draw(target, visualizeZ); }
        });
      }
    }

    // public void Draw(NormalizedLandmarkList targets, bool visualizeZ = true)
    // {
    //   Draw(targets.Landmark, visualizeZ);
    // }

    // public void Draw(IList<AnnotatedKeyPoint> targets, Vector2 focalLength, Vector2 principalPoint, float zScale, bool visualizeZ = true)
    // {
    //   if (ActivateFor(targets))
    //   {
    //     CallActionForAll(targets, (annotation, target) =>
    //     {
    //       if (annotation != null) { annotation.Draw(target, focalLength, principalPoint, zScale, visualizeZ); }
    //     });
    //   }
    // }

    // public void Draw(IList<mplt.RelativeKeypoint> targets, float threshold = 0.0f)
    // {
    //   if (ActivateFor(targets))
    //   {
    //     CallActionForAll(targets, (annotation, target) =>
    //     {
    //       if (annotation != null) { annotation.Draw(target, threshold); }
    //     });
    //   }
    // }

    // protected override PointAnnotation InstantiateChild(bool isActive = true)
    // {
    //   var annotation = base.InstantiateChild(isActive);
    //   annotation.SetColor(_color);
    //   annotation.SetRadius(_radius);
    //   return annotation;
    // }

    private void ShowCircle()
    {
      // Debug.Log(children[9].transform.position); // Pega a base do dedo do meio
      if (children.Count >= 20) // exibir círculo
      {
        Vector3 midPoint = children[9].transform.position;
        Vector3 newPosition = midPoint;
        newPosition.z = 0f;
        _handGear = GameObject.Find("HandGear");
        _handGear.transform.position = new Vector3(newPosition.x/10,newPosition.y/10,0);
      }
    }
    
    private void ApplyColor(Color color)
    {
      foreach (var point in children)//original
      {
        if (point != null) { point.SetColor(color); }
      }
    }

    private void ApplyRadius(float radius)
    {
      foreach (var point in children)
      {
        if (point != null) { point.SetRadius(radius); }
      }
    }
  }
}
