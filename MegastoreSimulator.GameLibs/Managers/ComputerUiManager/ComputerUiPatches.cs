using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using MegastoreSimulator.GameLibs.Calculators;

namespace MegastoreSimulator.GameLibs.Managers.ComputerUiManager;

[HarmonyPatch(typeof(UIWindow), nameof(UIWindow.Open))]
internal class ComputerUiPatches
{
    [HarmonyPostfix]
    public static void UIWindowOpen(UIWindow __instance)
    {
        if (__instance.gameObject.name != "ComputerUI") return;

        Transform windows = __instance.transform.Find("Windows");
        if (windows == null)
        {
            Plugin.Logger.LogWarning("ComputerUI: Could not find 'Windows' transform!");
            return;
        }

        // TODO change to management button
        Transform templateButton = windows.Find("ShoppingButton");
        if (templateButton == null)
        {
            Plugin.Logger.LogWarning("ComputerUI: Could not find 'ShoppingButton' template!");
            return;
        }

        var buttons = windows.GetComponentsInChildren<Button>()
            .Where(b => b.gameObject.activeSelf)
            .Select(b => b.gameObject)
            .ToList();

        foreach (var button in ComputerUiManager.ButtonDefinitions)
        {
            if (windows.Find(button.ButtonName) != null) continue;

            // Create a copy of the shopping button
            Transform newButton = Object.Instantiate(templateButton, windows);
            newButton.name = button.ButtonName;

            // Update the button text
            TextMeshProUGUI buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.text = button.DisplayText;
            }

            // Attach the click listener
            Button buttonComponent = newButton.GetComponent<Button>();
            if (buttonComponent != null && button.OnClicked != null)
            {
                buttonComponent.onClick.AddListener(() => button.OnClicked?.Invoke());
            }

            buttons.Add(newButton.gameObject);
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            var position = ComputerUiButtonPositionCalculator.CalculateButtonPosition(i);
            var button = buttons[i];
            button.transform.localPosition = new Vector3(position.X, position.Y, position.Z);
        }

        //for (int i = 0; i < buttons.Count; i++)
        //{
        //    var buttonDef = buttons[i];
        //    if (windows.Find(buttonDef.ButtonName) != null) continue;

        //    // Create a copy of the shopping button
        //    Transform newButton = Object.Instantiate(templateButton, windows);
        //    newButton.name = buttonDef.ButtonName;

        //    // Calculate position based on existing active button count + current index
        //    var calculatedPosition = ComputerUiButtonPositionCalculator.CalculateButtonPosition(i);
        //    newButton.localPosition = new Vector3(calculatedPosition.X, calculatedPosition.Y, calculatedPosition.Z);

        //    // Update the button text
        //    TextMeshProUGUI buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();
        //    if (buttonText != null)
        //    {
        //        buttonText.text = buttonDef.DisplayText;
        //    }

        //    // Attach the click listener
        //    Button buttonComponent = newButton.GetComponent<Button>();
        //    if (buttonComponent != null && buttonDef.OnClicked != null)
        //    {
        //        buttonComponent.onClick.AddListener(() => buttonDef.OnClicked?.Invoke());
        //    }
        //}
    }
}

// Shopping button position: 
// 125,5664 2,3622 257,7116 
// 0,0205 1,1533 -0,0806

// Management Button Position 
// 126,0165 2,4754 257,7116 
// -0,5358 0,1347 0,0001

// Price Management Button Position 
// 126,0165 2,356 257,7116 
// -0,5358 -0,0075 0,0001

// Finance Button Position 
// 126,0165 2,2352 257,7116 
// -0,5358 -0,1513 0,0001

// Shopping 2 Button
// 125,8604 2,5939 257,7115
// -0,3559 0,2758 0,0001