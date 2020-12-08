using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Transform 型の拡張メソッドを管理するクラス
/// </summary>
public static partial class TransformExtensions
{
    public static bool HasChild(this Transform transform)
    {
        return 0 < transform.childCount;
    }
}