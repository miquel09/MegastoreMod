using MegastoreSimulator.GameLibs.Models;
using System.Collections.Generic;

namespace MegastoreSimulator.GameLibs.Managers.ComputerUiManager;

public static class ComputerUiManager
{
    private readonly static List<ButtonDefinition> _buttonDefinitions = [];

    internal static List<ButtonDefinition> ButtonDefinitions => _buttonDefinitions;

    public static void AddButton(ButtonDefinition buttonDefinition)
    {
        _buttonDefinitions.Add(buttonDefinition);
    }
}
