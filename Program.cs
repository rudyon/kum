using Raylib_cs;
using System;

namespace kum
{
	class Program
	{
		public static void Main()
		{
			int width, height, resize_factor, mouse_x, mouse_y, brush_size;
			width = 600;
			height = 600;
			resize_factor = 4;
			brush_size = 4;

			Raylib.InitWindow(width, height, "kum");
			Raylib.SetTargetFPS(60);
			Raylib.HideCursor();

			World world = new World(width, height, resize_factor);

			while (!Raylib.WindowShouldClose())
			{
				world.Update();

				mouse_x = Raylib.GetMouseX() / resize_factor;
				mouse_y = Raylib.GetMouseY() / resize_factor;

				if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
				{
					world.Paint(mouse_x, mouse_y, "sand", brush_size);
				}
				else if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_RIGHT))
				{
					world.Paint(mouse_x, mouse_y, "water", brush_size);
				}
				else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
				{
					world.Paint(mouse_x, mouse_y, "wood", brush_size);
				}
				else if (Raylib.IsKeyDown(KeyboardKey.KEY_Q))
				{
					world.Paint(mouse_x, mouse_y, "air", brush_size);
				}

				if (Raylib.GetMouseWheelMove() != 0)
				{
					brush_size += (int)Raylib.GetMouseWheelMove();
				}

				if (brush_size < 1)
				{
					brush_size = 1;
				}

				Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.BLACK);

				world.Draw();
				Raylib.DrawRectangleLines(mouse_x * resize_factor, mouse_y * resize_factor, brush_size * resize_factor, brush_size * resize_factor, Color.WHITE);

				Raylib.EndDrawing();
			}

			Raylib.CloseWindow();
		}
	}
}