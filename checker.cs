using System;
using System.Diagnostics;

class Checker
{
    static bool vitalsIsOk(float value, int lower, int upper)
    {
        if (value>=lower && value<=upper)
        {
            return true;
        }
        return false;
    }
    static bool vitalsIsOk(float value, int lower)
    {
        if (value>=lower)
        {
            return true;
        }
        return false;
    }
    static bool vitalsAreOk(float bpm, float spo2, float respRate)
    {
        return (vitalsIsOk(bpm,70,150) && vitalsIsOk(spo2,90) && vitalsIsOk(respRate, 30, 95));
    }
    static void ExpectTrue(bool expression)
    {
        if (!expression)
        {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    static void ExpectFalse(bool expression)
    {
        if (expression)
        {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }
    static int Main()
    {
        ExpectTrue(vitalsAreOk(100, 95, 60));
        ExpectFalse(vitalsAreOk(40, 91, 92));
        Console.WriteLine("All ok");
        return 0;
    }
}
