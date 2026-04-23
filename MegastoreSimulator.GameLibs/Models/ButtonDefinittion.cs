using System;

namespace MegastoreSimulator.GameLibs.Models;

public class ButtonDefinition
{
    public string ButtonName { get; set; }
    public string DisplayText { get; set; }
    public Action OnClicked { get; set; }
}