//using HarmonyLib;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//namespace SalesNumbersPlugin.Patches;

//[HarmonyPatch(typeof(UIWindow), "Open")]
//public class TestPatch1
//{
//    [HarmonyPostfix]
//    public static void UIWindowPatch(UIWindow __instance)
//    {
//        if (__instance.gameObject.name != "ComputerUI") return;
//        if (__instance.transform.Find("Windows/MyModButton") != null) return;

//        //Navigate to the exact Windows container
//        Transform windows = __instance.transform.Find("Windows");
//        if (windows == null)
//        {
//            Debug.LogWarning("ComputerUI: Could not find 'Windows' transform!");
//            return;
//        }

//        // Clone ShoppingButton as our template (we know it exists)
//        Transform template = windows.Find("ShoppingButton");
//        if (template == null)
//        {
//            Debug.LogWarning("ComputerUI: Could not find 'ShoppingButton' to clone!");
//            return;
//        }

//        // Instantiate and parent inside Windows
//        GameObject newButton = GameObject.Instantiate(template.gameObject, windows);
//        newButton.name = "MyModButton";

//        // Update TMP label
//        TextMeshProUGUI label = newButton.GetComponentInChildren<TextMeshProUGUI>();
//        if (label != null)
//        {
//            label.text = "My Mod";
//        }

//        // Position it after the last known button (GamesButton is index 5)
//        // Offset based on ShoppingButton's position
//        RectTransform templateRect = template.GetComponent<RectTransform>();
//        RectTransform newRect = newButton.GetComponent<RectTransform>();

//        // -0.35
//        // Shift along X axis — adjust spacing value to match existing button gaps
//        float buttonSpacing = templateRect.rect.width + 5f;
//        newRect.anchoredPosition = templateRect.anchoredPosition + new Vector2(0.2f, 0);

//        // Wire up click
//        Button button = newButton.GetComponent<Button>();
//        button.onClick.RemoveAllListeners();
//        button.onClick.AddListener(() =>
//        {
//            Debug.Log("MyModButton clicked!");
//            // Your logic here
//        });
//    }
//}