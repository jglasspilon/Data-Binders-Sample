using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    /// <summary>
    /// Takes a hexidecimal string and returns the color value
    /// </summary>
    /// <param name="str">Hex string to parse.</param>
    /// <returns>Returns the color value of a hex if string is relevant, otherwise returns white.</returns>
    public static Color ParseColor(this string str)
    {
        if (str != null)
        {
            str = str.Replace("\"", "");

            string hexString = str;
            if (!hexString.Contains("#"))
                hexString = "#" + str;

            Color newColor;

            ColorUtility.TryParseHtmlString(hexString, out newColor);
            return newColor;
        }
        else
            return Color.white;
    }

    /// <summary>
    /// Determines whether a string has value or not.
    /// </summary>
    /// <param name="str">String to test.</param>
    /// <returns>Returns true if there is value in the tested string.</returns>
    public static bool HasValue(this string str)
    {
        if (!string.IsNullOrEmpty(str) && !str.Contains("error") && str != "NaN")
            return true;
        else
            return false;
    }

    /// <summary>
    /// Determines if a string is null/empty.
    /// </summary>
    /// <param name="str">String to test.</param>
    /// <returns>Returns true if string to test is null or empty.</returns>
    public static bool IsNulOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }

    /// <summary>
    /// Determines if a string is null/empty/has an error.
    /// </summary>
    /// <param name="str">String to test.</param>
    /// <returns>Returns true if the string to test is null, empty or contains an error.</returns>
    public static bool IsNulEmptyOrError(this string str)
    {
        if (string.IsNullOrEmpty(str) || str.Contains("error") || str == "NaN")
            return true;
        else
            return false;
    }

    /// <summary>
    /// Determines if the string is a variation of true.
    /// </summary>
    /// <param name="str">String to test.</param>
    /// <returns>Returns true if the string to test is any variation of the word 'true'.</returns>
    public static bool IsTrue(this string str)
    {
        if (str.ToLower() == "true")
            return true;
        else
            return false;
    }

    /// <summary>
    /// Determines if the string is a variation of false.
    /// </summary>
    /// <param name="str">String to test.</param>
    /// <returns>Returns true of the string to test is any variation of the word 'false'.</returns>
    public static bool IsFalse(this string str)
    {
        if ((str.ToLower() == "false"))
            return true;
        else
            return false;
    }

    /// <summary>
    /// Determines if the gameobject exists and has the desired component.
    /// </summary>
    /// <typeparam name="T">Component to look for.</typeparam>
    /// <param name="obj">Object to test.</param>
    /// <returns>Returns true of the object to test has the component we are looking for.</returns>
    public static bool ExistsAndHasComponent<T> (this GameObject obj)
    {
        if (obj != null && obj.GetComponent(typeof(T)) != null)
            return true;
        else
            return false;
    }
}
