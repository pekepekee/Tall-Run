// #define ES3

using System.Collections.Generic;
using UnityEngine;

public static class SaveUtil
{
    /// <summary>
    /// 真偽値を読み込む
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>真偽値</returns>
    public static bool LoadBool(string key)
    {
#if ES3
        if (ES3.KeyExists(key)) return ES3.Load<bool>(key);
        return default;
#else
        if (PlayerPrefs.HasKey(key)) return PlayerPrefs.GetInt(key) == 1 ? true : false;
        return default;
#endif
    }
    public static bool LoadBool(SaveID id) => LoadBool(id.ToString());
    /// <summary>
    /// 真偽値を読み込む
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="defaultValue">初期値</param>
    /// <returns>真偽値</returns>
    public static bool LoadBool(string key, bool defaultValue)
    {
#if ES3
        if (!ES3.KeyExists(key))
        {
             ES3.Save(key, defaultValue);
             return defaultValue;
        }
        return ES3.Load<bool>(key);
#else
        if (!PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.SetInt(key, defaultValue ? 1 : 0);
            PlayerPrefs.Save();
            return defaultValue;
        }
        return PlayerPrefs.GetInt(key) == 1 ? true : false;
#endif
    }
    public static bool LoadBool(SaveID id, bool defaultValue) => LoadBool(id.ToString(), defaultValue);
    /// <summary>
    /// 真偽値を保存
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="value">真偽値</param>
    public static void SaveBool(string key, bool value)
    {
#if ES3
        ES3.Save(key, value);
#else
        PlayerPrefs.SetInt(key, value ? 1 : 0);
        PlayerPrefs.Save();
#endif
    }
    public static void SaveBool(SaveID id, bool value) => SaveBool(id.ToString(), value);

    /// <summary>
    /// 数値を読み込む
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>数値</returns>
    public static int LoadInt(string key)
    {
#if ES3
        if (ES3.KeyExists(key)) return ES3.Load<int>(key);
        return default;
#else
        if (PlayerPrefs.HasKey(key)) return PlayerPrefs.GetInt(key);
        return default;
#endif
    }
    public static int LoadInt(SaveID id) => LoadInt(id.ToString());
    /// <summary>
    /// 数値を読み込む
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="defaultValue">初期値</param>
    /// <returns>数値</returns>
    public static int LoadInt(string key, int defaultValue)
    {
#if ES3
        if (!ES3.KeyExists(key))
        {
             ES3.Save(key, defaultValue);
             return defaultValue;
        }
        return ES3.Load<int>(key);
#else
        if (!PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.SetInt(key, defaultValue);
            PlayerPrefs.Save();
            return defaultValue;
        }
        return PlayerPrefs.GetInt(key);
#endif
    }
    public static int LoadInt(SaveID id, int defaultValue) => LoadInt(id.ToString(), defaultValue);
    /// <summary>
    /// 数値を保存
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="value">数値</param>
    public static void SaveInt(string key, int value)
    {
#if ES3
        ES3.Save(key, value);
#else
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
#endif
    }
    public static void SaveInt(SaveID id, int value) => SaveInt(id.ToString(), value);

    /// <summary>
    /// 浮動小数点数を読み込む
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>浮動小数点数</returns>
    public static float LoadFloat(string key)
    {
#if ES3
        if (ES3.KeyExists(key)) return ES3.Load<float>(key);
        return default;
#else
        if (PlayerPrefs.HasKey(key)) return PlayerPrefs.GetFloat(key);
        return default;
#endif
    }
    public static float LoadFloat(SaveID id) => LoadFloat(id.ToString());
    /// <summary>
    /// 浮動小数点数を読み込む
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="defaultValue">初期値</param>
    /// <returns>浮動小数点数</returns>
    public static float LoadFloat(string key, float defaultValue)
    {
#if ES3
        if (!ES3.KeyExists(key))
        {
             ES3.Save(key, defaultValue);
             return defaultValue;
        }
        return ES3.Load<float>(key);
#else
        if (!PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.SetFloat(key, defaultValue);
            PlayerPrefs.Save();
            return defaultValue;
        }
        return PlayerPrefs.GetFloat(key);
#endif
    }
    public static float LoadFloat(SaveID id, float defaultValue) => LoadFloat(id.ToString(), defaultValue);
    /// <summary>
    /// 浮動小数点数を保存
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="value">浮動小数点数</param>
    public static void SaveFloat(string key, float value)
    {
#if ES3
        ES3.Save(key, value);
#else
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
#endif
    }
    public static void SaveFloat(SaveID id, float value) => SaveFloat(id.ToString(), value);

    /// <summary>
    /// 文字列を読み込む
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>文字列</returns>
    public static string LoadString(string key)
    {
#if ES3
        if (ES3.KeyExists(key)) return ES3.Load<string>(key);
        return default;
#else
        if (PlayerPrefs.HasKey(key)) return PlayerPrefs.GetString(key);
        return default;
#endif
    }
    public static string LoadString(SaveID id) => LoadString(id.ToString());
    /// <summary>
    /// 文字列を読み込む
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="defaultValue">初期値</param>
    /// <returns>文字列</returns>
    public static string LoadString(string key, string defaultValue)
    {
#if ES3
        if (!ES3.KeyExists(key))
        {
             ES3.Save(key, defaultValue);
             return defaultValue;
        }
        return ES3.Load<string>(key);
#else
        if (!PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.SetString(key, defaultValue);
            PlayerPrefs.Save();
            return defaultValue;
        }
        return PlayerPrefs.GetString(key);
#endif
    }
    public static string LoadString(SaveID id, string defaultValue) => LoadString(id.ToString(), defaultValue);
    /// <summary>
    /// 文字列を保存
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="value">文字列</param>
    public static void SaveString(string key, string value)
    {
#if ES3
        ES3.Save(key, value);
#else
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
#endif
    }
    public static void SaveString(SaveID id, string value) => SaveString(id.ToString(), value);
}

public static class SaveUtil<T>
{
    /// <summary>
    /// 読み込む
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>値</returns>
    public static T Load(string key)
    {
#if ES3
        if (ES3.KeyExists(key)) return ES3.Load<T>(key);
        return default;
#else
        if (PlayerPrefs.HasKey(key)) return PlayerPrefsUtility.Load<T>(key);
        return default;
#endif
    }
    public static T Load(SaveID id) => Load(id.ToString());
    /// <summary>
    /// 読み込む
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="defaultValue">初期値</param>
    /// <returns>値</returns>
    public static T Load(string key, T defaultValue)
    {
#if ES3
        if (!ES3.KeyExists(key))
        {
            ES3.Save(key, defaultValue);
            return defaultValue;
        }
        return ES3.Load<T>(key);
#else
        if (!PlayerPrefs.HasKey(key))
        {
            PlayerPrefsUtility.Save<T>(key, defaultValue);
            PlayerPrefs.Save();
        }
        return PlayerPrefsUtility.Load<T>(key);
#endif
    }
    public static T Load(SaveID id, T defaultList) => Load(id.ToString(), defaultList);

    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="value">値</param>
    public static void Save(string key, T value)
    {
#if ES3
        ES3.Save(key, value);
#else
        PlayerPrefsUtility.Save<T>(key, value);
        PlayerPrefs.Save();
#endif
    }
    public static void Save(SaveID id, T value) => Save(id.ToString(), value);


    /// <summary>
    /// リストを読み込む
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>リスト</returns>
    public static List<T> LoadList(string key)
    {
#if ES3
        if (ES3.KeyExists(key)) return ES3.Load<List<T>>(key);
        return default;
#else
        if (PlayerPrefs.HasKey(key)) return PlayerPrefsUtility.LoadList<T>(key);
        return default;
#endif
    }
    public static List<T> LoadList(SaveID id) => LoadList(id.ToString());
    /// <summary>
    /// リストを読み込む
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="defaultValue">初期値</param>
    /// <returns>リスト</returns>
    public static List<T> LoadList(string key, List<T> defaultValue)
    {
#if ES3
        if (!ES3.KeyExists(key))
        {
            ES3.Save(key, defaultValue);
            return defaultValue;
        }
        return ES3.Load<List<T>>(key);
#else
        if (!PlayerPrefs.HasKey(key))
        {
            PlayerPrefsUtility.SaveList(key, defaultValue);
            PlayerPrefs.Save();
        }
        return PlayerPrefsUtility.LoadList<T>(key);
#endif
    }
    public static List<T> LoadList(SaveID id, List<T> defaultList) => LoadList(id.ToString(), defaultList);
    /// <summary>
    /// リストを保存
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="defaultValue">初期値</param>
    /// <returns>リスト</returns>
    public static void SaveList(string key, List<T> value)
    {
#if ES3
        ES3.Save(key, value);
#else
        PlayerPrefsUtility.SaveList(key, value);
        PlayerPrefs.Save();
#endif
    }
    public static void SaveList(SaveID id, List<T> value) => SaveList(id.ToString(), value);
}