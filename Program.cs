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
			string brush_type = "sand";

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
					world.Paint(mouse_x, mouse_y, brush_type, brush_size);
				}

				else if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
				{
					switch (brush_type)
					{
						case "sand":
							brush_type = "water";
							break;
						case "water":
							brush_type = "wood";
							break;
						case "wood":
							brush_type = "fire";
							break;
						case "fire":
							brush_type = "air";
							break;
						case "air":
							brush_type = "sand";
							break;
					}
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
				Raylib.DrawText(brush_type, 4, 4, 24, Color.WHITE);
				Raylib.DrawText("<space> to switch", 4, 32, 16, Color.WHITE);
				Raylib.DrawRectangleLines(mouse_x * resize_factor, mouse_y * resize_factor, brush_size * resize_factor, brush_size * resize_factor, Color.WHITE);

				Raylib.EndDrawing();
			}

			Raylib.CloseWindow();
		}
	}
}