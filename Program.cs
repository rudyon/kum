using Raylib_cs;

namespace kum
{
	class Program
	{
		public static void Main()
		{
			Raylib.InitWindow(600, 600, "kum");

			World world = new World(600, 600);

			while (!Raylib.WindowShouldClose())
			{
				if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
				{
					world.Set(Raylib.GetMouseX(), Raylib.GetMouseY(), new Tile(Raylib.GetMouseX(), Raylib.GetMouseY(), world, "sand"));
				}

				world.Update();

				Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.BLACK);

				world.Draw();

				Raylib.EndDrawing();
			}

			Raylib.CloseWindow();
		}
	}
}