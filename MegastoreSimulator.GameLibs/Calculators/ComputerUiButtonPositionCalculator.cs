//using System;
//using System.Numerics;

//namespace MegastoreSimulator.GameLibs.Calculators;

//internal class ComputerUiButtonPositionCalculator
//{
//    private const float X_START_VALUE = -0.5359f;
//    private const float Y_START_VALUE = 0.2787f;
//    private const float Z_START_VALUE = 0;

//    private const float X_OFFSET = 0.18f;
//    private const float Y_OFFSET = 0.16f;

//    internal static Vector3 CalculateButtonPosition(int index)
//    {
//        var columnNumber = index % 4;
//        var rowNumber = (float)Math.Floor(index / 4f);

//        float x = X_START_VALUE + (rowNumber * X_OFFSET);
//        float y = Y_START_VALUE - (columnNumber * Y_OFFSET);

//        return new Vector3(x, y, Z_START_VALUE);
//    }
//}

///*
// * (0,0) (1,0) (2,0)
// * (0,1)
// * (0,2)
// * (0,3)
// */