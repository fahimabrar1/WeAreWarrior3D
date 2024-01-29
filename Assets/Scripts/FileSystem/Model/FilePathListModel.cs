using System.Collections.Generic;
using System;
using UnityEngine;
[Serializable]
public class FilePathListModel
{
    [SerializeField]
    public List<string> filePaths = new();


    /// <summary>
    /// 
    ///     Filters the name
    /// 
    /// </summary>
    /// <param name="path"></param>
    internal void AddFilePath(string path)
    {
        string p = path.Trim().ToLower().Replace(' ', '_');
        filePaths.Add(p);
    }
}
