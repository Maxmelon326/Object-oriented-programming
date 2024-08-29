using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        const int windowWidth = 800;
        const int windowHeight = 600;
        //const int targetFramerate = 60;

        Window gameWindow = new Window("Robot Dodge Game", windowWidth, windowHeight);
        RobotDodge game = new RobotDodge(gameWindow);
                        
        do 
        {
            //SplashKit.ProcessEvents();
            game.HandleInput();
            game.Update();
            game.Draw();
            //game.Refresh();
            //player.StayonWindow();
            //SplashKit.Delay(50);
            
        } while (!gameWindow.CloseRequested);

        gameWindow.Close();
    }
}

    