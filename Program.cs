using Raylib_cs;


namespace kum
{
	class Program
	{
		public static void Main()
		{
			Raylib.InitWindow(600, 600, "kum");

			World world = new World(300, 300);

			while (!Raylib.WindowShouldClose())
			{
				world.Update();

				Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.BLACK);

				world.Draw();

				if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
				{
					world.Set(Raylib.GetMouseX() / 2, Raylib.GetMouseY() / 2, new Tile(Raylib.GetMouseX() / 2, Raylib.GetMouseY() / 2, world, "sand"));
				}

				Raylib.EndDrawing();
			}

			Raylib.CloseWindow();
		}
	}
}