using System;
using SplashKitSDK;

public class Bullet
{
    private Window _gameWindow;
    private Bitmap _bulletBitmap;
    public double X { get; set; }
    public double Y { get; set; }
    public Vector2D Velocity { get; set; }
    public bool IsOutOfScreen { get; private set; }
    public Bullet(Window gameWindow, double startX, double startY, Vector2D velocity)
    {
        _gameWindow = gameWindow;
        X = startX;
        Y = startY;
        Velocity = velocity;
        _bulletBitmap = new Bitmap("Bullet", "fire.png"); 
        IsOutOfScreen = false;
        
    }

   


    public void Update()
    {
        // Move the bullet
        X += Velocity.X;
        Y += Velocity.Y;

        // Check if the bullet is out of window
        if (X < 0 || X > _gameWindow.Width || Y < 0 || Y > _gameWindow.Height)
        {
            IsOutOfScreen = true;
        }
    }

    public void Draw()
    {
        _bulletBitmap.Draw(X, Y);
    }

     public bool CashedWith(Robot other)
    {
        return _bulletBitmap.CircleCollision(X,Y, other.CollisionCircle);
    }
  
}
