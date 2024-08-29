using System;
using SplashKitSDK;

public class Player
{
    //private const int SPEED=5;
    // Player field, X&Y, Width&Height auto properties
    private Bitmap _PlayerBitmap;//representing the player's appearance
    private Window _gameWindow;//reference to the game window

     // Add a Lives property to track the player's remaining lives
    public int Lives=5;

      // Add a Score property to track the player's score
    public int Score { get; private set; }
    // Add a Timer to track the time elapsed
     private SplashKitSDK.Timer _timer; 
    

    //properties of the player's position 
    public double X { get; set; }
    public double Y { get; set; }
    public bool Quit {get;private set;}
    public int Width
    {
        get
        {
            return _PlayerBitmap.Width;
        }
    }
    public int Height
    {
        get
        {
            return _PlayerBitmap.Height;
        }
    }

    // Constructor to initialize the Player's position
    public Player(Window gameWindow)
    {

         // Initialize the player's score
        Score = 0;

        // Create and start the timer
        _timer = new SplashKitSDK.Timer("PlayerTimer");
        _timer.Start();
        
        
        // Load the player's bitmap from "Player.png" image file
        _PlayerBitmap = new Bitmap("Player", "Player.png");
        _gameWindow=gameWindow;
        //Quit = false;

        // Position the player in the center of the screen
        X = (gameWindow.Width - Width) / 2;
        Y = (gameWindow.Height - Height) / 2;
    }

    // Method to draw the player on the screen
    public void Draw()
    {
        if (_PlayerBitmap != null)
        {
            _PlayerBitmap.Draw(X, Y);
        }
    }

 public void HandleInput()//how to use handleinput
    {
        int speed = 5;

        SplashKit.ProcessEvents();

        if(SplashKit.KeyReleased(KeyCode.EscapeKey)) Quit = true;

        if(SplashKit.KeyDown(KeyCode.LeftShiftKey) || SplashKit.KeyDown(KeyCode.RightShiftKey))//increase speed
        {
            speed = 15;
        }

        //move player based on arrow key 
        if(SplashKit.KeyDown(KeyCode.WKey) || SplashKit.KeyDown(KeyCode.UpKey))
        {
            Y -= speed;
        }

        if(SplashKit.KeyDown(KeyCode.SKey) || SplashKit.KeyDown(KeyCode.DownKey))
        {
            Y += speed;
        }

        if(SplashKit.KeyDown(KeyCode.AKey) || SplashKit.KeyDown(KeyCode.LeftKey))
        {
            X -= speed;
        }

        if(SplashKit.KeyDown(KeyCode.DKey) || SplashKit.KeyDown(KeyCode.RightKey))
        {
            X += speed;
        }

    }

    //method to make the player stay on the window
    public void StayonWindow(Window limit)
    {
        const int GAP=10;
        
        //make sure that the player do not go out of bounds 
        if(X<GAP)
        {
            X=GAP;
        }
        if(Y<GAP)
        {
            Y=GAP;
        }
        if(X>_gameWindow.Width-Width-GAP)
        {
            X=_gameWindow.Width-Width-GAP;
        }
        if(Y>_gameWindow.Height-Height-GAP)
        {
            Y=_gameWindow.Height-Height-GAP;
        }
    } 

    


    //method to check collision with the robot object
    public bool CollidedWith(Robot other)
    {
        return _PlayerBitmap.CircleCollision(X,Y, other.CollisionCircle);
    }

     // Method to update the player's score based on time elapsed
    public void UpdateScore()
    {
        // Calculate the score based on the time elapsed (1 point per second)
        Score = (int)(_timer.Ticks / 1000);
    }

}