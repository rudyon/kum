using Raylib_cs;


namespace kum
{
	class Program
	{
		public static void Main()
		{
			int width, height, resize_factor, mouse_x, mouse_y;
			width = 600;
			height = 600;
			resize_factor = 2;

			Raylib.InitWindow(width, height, "kum");
			Raylib.SetTargetFPS(60);

			World world = new World(width, height, resize_factor);

			while (!Raylib.WindowShouldClose())
			{
				world.Update();

				mouse_x = Raylib.GetMouseX() / resize_factor;
				mouse_y = Raylib.GetMouseY() / resize_factor;

				if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
				{
					world.Set(mouse_x, mouse_y, new Tile(mouse_x, mouse_y, world, "sand"));
				}
				else if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_RIGHT))
				{
					world.Set(mouse_x, mouse_y, new Tile(mouse_x, mouse_y, world, "water"));
				}

				Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.BLACK);

				world.Draw();

				Raylib.EndDrawing();
			}

			Raylib.CloseWindow();
		}
	}
}