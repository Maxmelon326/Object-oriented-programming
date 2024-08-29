using System;
using SplashKitSDK;

public class Robot
{
    //private const int SPEED=5;
    // Player field, X&Y, Width&Height auto properties
    //private Bitmap _PlayerBitmap;
    //private Window _gameWindow;
    
    //set coordinate of the robot
    public double X { get; set; }
    public double Y { get; set; }

    public Vector2D Velocity{get;set;} //bring an arrow with both direction&magintude 
    public Color MainColor{ get; set;} //color of the robot 
    //public bool Quit{get;private set;}
    public int Width
    {
        get
        {
            return 50;////width of robot
        }
    }
    public int Height
    {
        get
        {
            return 50;//height of robot 
        }
    }

    public Circle CollisionCircle
    {
        get{ return SplashKit.CircleAt( X + 25, Y + 25, 35.36);} ///create a circle at the center of the robot 
    }

    //Constructor to initialize robot's position and color
    public Robot(Window gameWindow, Player player)//initialize Velocity in the robot constructor
    {
        //randomly pick top/bottom or left/right
        if(SplashKit.Rnd()<0.5)
        {
            X = SplashKit.Rnd( gameWindow.Width);
            if(SplashKit.Rnd()<0.5)
                Y=-Height;//top
            else Y=gameWindow.Height;//bottom
        }
        else
        {
            Y = SplashKit.Rnd( gameWindow.Height);
            if(SplashKit.Rnd()<0.5)
                Y=-Width;//left
            else X=gameWindow.Width;//right

        }
        
        MainColor = Color.RandomRGB(200);//can generate random color of robot

        const int SPEED=4;
        //Get a point from the robot
        Point2D fromPt=new Point2D()
        {
            X=X,Y=Y
        };
        //Get a point for the player
       Point2D toPt=new Point2D()
        {
            X=player.X,Y=player.Y
        };

        //calculate the direction to head. 
        Vector2D dir;
        dir=SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt,toPt));

        //set the speed and assign to the velocity
        Velocity=SplashKit.VectorMultiply(dir,SPEED); 

    }

    //fix lost robot
    public bool IsOffscreen(Window screen)
    {
        while (X<-Width||X>screen.Width||Y<-Height||Y>screen.Height)
        {
            return true;
        }
        return false;
    }

// add update() to ensure the call in RobotDodge eachrobot.Update()
     public void Update()
    {
        X += Velocity.X;
        Y += Velocity.Y;
    }

    // Method to draw the Robot on the screen
    public void Draw()
    {
        double leftX, rightX;
        double eyeY, mouthY;

        leftX = X + 12;//12
        rightX = X + 27;//27
        eyeY = Y + 10;//10
        mouthY = Y + 30;//30
        //draw different parts of robot
        SplashKit.FillRectangle( Color.Gray, X, Y, Width, Height);//body 
        SplashKit.FillRectangle( MainColor, leftX, eyeY, 10, 10);//left eye
        SplashKit.FillRectangle( MainColor, rightX, eyeY, 10, 10);//righteye
        SplashKit.FillRectangle( MainColor, leftX, mouthY, 25, 10);//mouth,25,10
        SplashKit.FillRectangle( MainColor, leftX + 2, mouthY + 2, 21, 6);//teeth
    }


    
}


