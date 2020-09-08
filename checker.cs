using System;
using System.Diagnostics;

class Checker
{
    abstract class Alert
	{
        public abstract void Alertmessage(string message);

	}
    class smsAlert:Alert
	{
        public override void Alertmessage(string message)
        {
            Console.WriteLine(message);
        }
	}
    class voiceAlert : Alert
    {
        public override void Alertmessage(string message)
        {
            Console.WriteLine(message);
        }
    }
    static bool vitalsIsOk(float value, int lower, int upper)
    {
        if (value>=lower && value<=upper)
        {
            return true;
        }
        smsAlert smsMessage=new smsAlert();
        smsMessage.Alertmessage("Vitals is not Ok");
        voiceAlert voiceMessage=new voiceAlert();
        voiceMessage.Alertmessage("Vitals is not Ok");
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
        ExpectTrue(vitalsAreOk(100, 95, 60));
        ExpectFalse(vitalsAreOk(60, 91, 92));
        ExpectTrue(vitalsAreOk(110, 105, 50));
        ExpectFalse(vitalsAreOk(120, 70, 80));
        ExpectTrue(vitalsAreOk(125, 96, 55));
        ExpectFalse(vitalsAreOk(44, 96, 98));
        ExpectTrue(vitalsAreOk(90, 122, 65));
        ExpectFalse(vitalsAreOk(30, 97, 99));
        ExpectTrue(vitalsAreOk(108, 102, 82));
        ExpectFalse(vitalsAreOk(50, 91, 92));
        Console.WriteLine("All ok");
        return 0;
    }
}
