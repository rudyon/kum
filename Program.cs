using Raylib_cs;


namespace kum
{
	class Program
	{
		public static void Main()
		{
			Raylib.InitWindow(600, 600, "kum");
			Raylib.SetTargetFPS(60);

			World world = new World(150, 150);

			while (!Raylib.WindowShouldClose())
			{
				world.Update();

				Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.BLACK);

				world.Draw();

				if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
				{
					world.Set(Raylib.GetMouseX() / 4, Raylib.GetMouseY() / 4, new Tile(Raylib.GetMouseX() / 4, Raylib.GetMouseY() / 4, world, "sand"));
				}
				else if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_RIGHT))
				{
					world.Set(Raylib.GetMouseX() / 4, Raylib.GetMouseY() / 4, new Tile(Raylib.GetMouseX() / 4, Raylib.GetMouseY() / 4, world, "water"));
				}

				Raylib.EndDrawing();
			}

			Raylib.CloseWindow();
		}
	}
}