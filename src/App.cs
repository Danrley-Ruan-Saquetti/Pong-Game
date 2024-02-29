using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pong.Entities;
using Pong.Global;

namespace Pong;

public class App : Game
{
    private GraphicsDeviceManager _graphics;
    PlayerModel[] players;
    Ball ball;

    public App()
    {
        this._graphics = new(this) { PreferredBackBufferWidth = Globals.WINDOW_WIDTH, PreferredBackBufferHeight = Globals.WINDOW_HEIGHT };
        this.Content.RootDirectory = "Content";
        this.IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        this.players = new PlayerModel[2];

        this.ball = new((Globals.WINDOW_WIDTH - Globals.BALL_SIZE) / 2, (Globals.WINDOW_HEIGHT - Globals.BALL_SIZE) / 2);
        this.players[0] = new Player(Globals.RACKET_GAP_BOARD, (Globals.WINDOW_HEIGHT - Globals.RACKET_HEIGHT) / 2) { sideCode = (int)Sides.Right };
        this.players[1] = new Adversary(Globals.WINDOW_WIDTH - Globals.RACKET_WIDTH - Globals.RACKET_GAP_BOARD, (Globals.WINDOW_HEIGHT - Globals.RACKET_HEIGHT) / 2) { sideCode = (int)Sides.Left };

        this.ResetGame();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        Globals.spriteBatch = new(GraphicsDevice);
        Globals.pixel = new(GraphicsDevice, 1, 1);
        Globals.pixel.SetData(new[] { Color.White });
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            base.Exit();
        }
        if (Keyboard.GetState().IsKeyDown(Keys.R))
        {
            this.ResetGame(true);
        }

        foreach (var player in this.players)
        {
            player.Update(gameTime);
        }
        this.ball.Update(gameTime);

        this.UpdateBallWhenCollisionBetweenBallAndPlayers();
        this.UpdateBallWhenCollisionBetweenBallAndSideWalls();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        this.GraphicsDevice.Clear(Color.Black);

        Globals.spriteBatch.Begin();

        foreach (var player in this.players)
        {
            player.Draw(gameTime);
        }
        this.ball.Draw(gameTime);

        Globals.spriteBatch.End();

        base.Draw(gameTime);
    }

    private void UpdateBallWhenCollisionBetweenBallAndSideWalls()
    {
        int sideWallCollided = this.GetSideWallCollidedBall();

        if (sideWallCollided == (int)Sides.Center)
        {
            return;
        }

        this.EndGame(sideWallCollided * -1);
    }

    private void UpdateBallWhenCollisionBetweenBallAndPlayers()
    {
        int sideCodePlayer = this.GetCodeSidePlayerCollidedBall();

        if (sideCodePlayer == (int)Sides.Center)
        {
            return;
        }

        this.ball.DefineDirectionX(sideCodePlayer * -1);
    }

    private int GetSideWallCollidedBall()
    {
        if (this.ball.rectangle.X < 0)
        {
            return this.players[0].sideCode;
        }
        if (this.ball.rectangle.X + this.ball.rectangle.Width > Globals.WINDOW_WIDTH)
        {
            return this.players[1].sideCode;
        }
        return (int)Sides.Center;
    }

    private int GetCodeSidePlayerCollidedBall()
    {
        foreach (var player in this.players)
        {
            if (player.IsCollided(this.ball))
            {
                return player.sideCode;
            }
        }

        return (int)Sides.Center;
    }

    private PlayerModel GetPlayerByCodeSide(int sideCode)
    {
        foreach (var player in this.players)
        {
            if (player.sideCode == sideCode)
            {
                return player;
            }
        }

        throw new Exception("Player not found with code \"" + sideCode + "\"");
    }

    private void EndGame(int winnerCodeSide)
    {
        var playerWinner = this.GetPlayerByCodeSide(winnerCodeSide);

        playerWinner.AddPoint();

        this.ResetGame(winnerCodeSide);
    }

    private void ResetGame()
    {
        this.ResetGame(new Random().Next(2) == 1 ? -1 : 1);
    }
    private void ResetGame(bool isEmptyPoint)
    {
        this.ResetGame(new Random().Next(2) == 1 ? -1 : 1, isEmptyPoint);
    }

    private void ResetGame(int sideStartBall)
    {
        this.ResetGame(sideStartBall, false);
    }


    private void ResetGame(int sideStartBall, bool isEmptyPoint)
    {
        this.ball = new((Globals.WINDOW_WIDTH - Globals.BALL_SIZE) / 2, (Globals.WINDOW_HEIGHT - Globals.BALL_SIZE) / 2) { directionX = sideStartBall };

        foreach (var player in this.players)
        {
            player.ResetPosition();
            player.ball = this.ball;

            if (isEmptyPoint)
            {
                player.points = 0;
            }
        }
    }
}
