using Raylib_cs;

namespace kum
{
	internal class World
	{
		int width, height;
		Tile[,]? sandbox;

		public World(int width, int height)
		{
			this.width = width;
			this.height = height;

			sandbox = new Tile[width, height];

			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					sandbox[i, j] = new Tile(i, j, this, "air");
				}
			}
		}

		internal Tile Get(int x, int y)
		{
			try
			{
				return sandbox[x, y];
			}
			catch (System.NullReferenceException)
			{
				return null;
			}
			catch (IndexOutOfRangeException)
			{
				return null;
			}
		}

		internal void Set(int x, int y, Tile tile)
		{
			try
			{
				sandbox[x, y] = tile;
			}
			catch (System.NullReferenceException)
			{

			}
			catch (IndexOutOfRangeException)
			{

			}
		}

		internal void Draw()
		{
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					try
					{
						if (sandbox[i, j].type == "sand")
						{
							Raylib.DrawRectangle(i * 4, j * 4, 4, 4, Color.YELLOW);
						}
						else if (sandbox[i, j].type == "water")
						{
							Raylib.DrawRectangle(i * 4, j * 4, 4, 4, Color.BLUE);
						}
					}
					catch (System.NullReferenceException)
					{

					}

				}
			}
		}

		internal void Update()
		{
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					try
					{
						if (!(sandbox[i, j].type == "air") && !(sandbox[i, j].updated))
						{
							sandbox[i, j].Update();
						}
						else if (sandbox[i, j].updated)
						{
							sandbox[i, j].updated = false;
						}
					}
					catch (System.NullReferenceException)
					{

					}

				}
			}
		}
	}
}