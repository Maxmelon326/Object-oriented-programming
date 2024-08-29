using System;
using SplashKitSDK;
using System.Collections.Generic;

public class RobotDodge
{
    private Player _Player;
    private Window _GameWindow;
    
    private List<Robot> _Robots;// create a list to store robots
    
 //The heart Bitmap
    private Bitmap HeartBitmap = new Bitmap("Heart", "heart.png");

     private List<Bullet> _bullets = new List<Bullet>();

    public bool Quit
    {
        get
        {
            return _Player.Quit;
        }
    }
    public RobotDodge( Window gameWindow )
    {
        _GameWindow = gameWindow;
        _Player = new Player( gameWindow );
        _Robots = new List<Robot>();//initialize _Robots
    }

    public void HandleInput()
    {
        _Player.HandleInput();
        _Player.StayonWindow(_GameWindow);
         if (SplashKit.MouseClicked(MouseButton.LeftButton))
        {
            ShootBullet();
        }
    
    }
    
    public void Draw()
    {
        _GameWindow.Clear(Color.White);//clear the screen
        foreach(Robot eachrobot in _Robots)
        {
            eachrobot.Draw();
        }//Drow each robot from the list
        _Player.Draw();//draw the player
           // Update and display the player's score
        _Player.UpdateScore();
        DisplayScore();
          // Draw bullets
        foreach (Bullet bullet in _bullets)
        {
            bullet.Draw();
        }

        if (_Player.Lives <= 0)
        {
           
            _GameWindow.Clear(Color.Black);
            Bitmap _GameOver = new Bitmap("Game Over", "gamover.png");
            SplashKit.DrawBitmap(_GameOver, 200, 100);
        }
      
        _GameWindow.Refresh(60);
    }

    public void Update()
    {
        foreach( Robot eachrobot in _Robots )
        {
            eachrobot.Update();//Make sure each robot call Update. 
        }
        // Randomly created robots
        if (SplashKit.Rnd()<0.02)
        {
            Robot newRobot=RandomRobot();
            _Robots.Add(newRobot);
        }
        CheckCollision();
         // Update bullets
        foreach (Bullet bullet in _bullets)
        {
            bullet.Update();
        }
         // Remove out-of-bounds bullets
        _bullets.RemoveAll(bullet => bullet.IsOutOfScreen);


    }
    public Robot RandomRobot()
    {
        return new Robot(_GameWindow,_Player);// Create a new robot object with random position and color. _play is the additional argument.
    }

       private void CheckCollision()
    {
        
        //create a list to store robots that be removed.
        List<Robot> robotsToRemove=new List<Robot>();
        List<Bullet> bulletsToRemove = new List<Bullet>();
        //loop over all robots in _Robots and add the one need to remove to the new list
        foreach(Robot eachrobot in _Robots)
        {
           
            if (_Player.CollidedWith(eachrobot))
            {
                 robotsToRemove.Add(eachrobot);
            }
            if (_Player.CollidedWith(eachrobot) && _Player.Lives > 0)
            {
            
                _Player.Lives-=1;
                break;
            }    
            foreach (Bullet bullet in _bullets)
            {
                  //Check the player and robot collision
                if (bullet.CashedWith(eachrobot))
                {
                    
                    robotsToRemove.Add(eachrobot);
                    bulletsToRemove.Add(bullet);
                }
              
            }
             // Check if the player collides with a robot
            
        }
         foreach (Robot eachrobot in robotsToRemove)
        {
            _Robots.Remove(eachrobot);
        }
        foreach (Bullet bullet in bulletsToRemove)
        {
            _bullets.Remove(bullet);
        }
    }
    //drwa hearts
    public void DisplayScore()
    {DrawHearts(_Player.Lives);
    // Draw the player's score on the screen
        SplashKit.DrawText("SCORE: " + _Player.Score, Color.Black, 0, 40);}
    public void DrawHearts(int numberOfHearts)
    {
        int heartX = 0;
        for (int i = 0; i < numberOfHearts; i ++ )
        {
            if (heartX < 300)
            {
                SplashKit.DrawBitmap(HeartBitmap, heartX, 0);
                heartX = heartX + 40;
            }
        }
    }

    private const double BulletSpeed = 10.0; // Adjust the speed as needed

    private void ShootBullet()
{
    // Calculate the direction from the player to the mouse cursor
    double mouseX = SplashKit.MouseX();
    double mouseY = SplashKit.MouseY();
    double deltaX = mouseX - _Player.X;
    double deltaY = mouseY - _Player.Y;
    double length = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    
    // Normalize the direction vector
    Vector2D direction = SplashKit.VectorTo(deltaX / length, deltaY / length);
     // Multiply the direction vector by the bullet speed
    direction = SplashKit.VectorMultiply(direction, BulletSpeed);

    // Create a bullet with the calculated direction and starting position
    Bullet bullet = new Bullet(_GameWindow, _Player.X, _Player.Y, direction);

    // Add the bullet to the list
    _bullets.Add(bullet);
}
}