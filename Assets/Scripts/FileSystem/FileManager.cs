using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;



/// <summary>
/// 
///     This interface will add these methods for calling the file manager and do other changes
/// 
/// </summary>
public interface IDataManager
{
    public void SaveData();
    public void LoadData();
}




public class FileManager<T> where T : class
{

    /// <summary>
    /// Saves the data to a file asynchronously.
    /// </summary>
    /// <param name="fileName">The name of the file to save.</param>
    /// <param name="data">The data to save.</param>
    public void OnSaveAsync(string fileName, T data)
    {
        string path = Application.persistentDataPath + "/" + fileName + GlobalConstants.SAVE_FILE_EXTENSION;


        BinaryFormatter bf = new();
        using FileStream stream = new(path, FileMode.OpenOrCreate);

        string json = JsonUtility.ToJson(data);
        bf.Serialize(stream, json);

        Debug.Log(json);


    }

    /// <summary>
    /// Loads data from a file into the specified object asynchronously.
    /// </summary>
    /// <param name="fileName">The name of the file to load.</param>
    /// <param name="target">The object to populate with loaded data.</param>
    public async Task OnLoadAsync(string fileName, T target)
    {
        string path = Application.persistentDataPath + "/" + fileName + GlobalConstants.SAVE_FILE_EXTENSION;


        await Task.Run(() =>
        {
            BinaryFormatter bf = new();
            using FileStream stream = new(path, FileMode.OpenOrCreate);
            try
            {
                string json = (string)bf.Deserialize(stream);
                JsonUtility.FromJsonOverwrite(json, target);
                Debug.Log(json);
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to load data: " + e.Message);
            }
        });
    }

}
