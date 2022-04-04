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
							Raylib.DrawRectangle(i * 2, j * 2, 2, 2, Color.YELLOW);
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
						if (!(sandbox[i, j].type == "air"))
						{
							sandbox[i, j].Update();
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