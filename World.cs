using Raylib_cs;

namespace kum
{
	internal class World
	{
		int width, height, resize_factor;
		Tile[,]? sandbox;

		public World(int width, int height, int resize_factor)
		{
			this.width = width / resize_factor;
			this.height = height / resize_factor;
			this.resize_factor = resize_factor;

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

		internal void Paint(int x, int y, string type, int brush_size)
		{
			try
			{
				for (int i = 0; i < brush_size; i++)
				{
					for (int j = 0; j < brush_size; j++)
					{
						sandbox[x + i, y + j] = new Tile(x + i, y + j, this, type);
					}
				}
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
						if (!(sandbox[i, j].type == "air"))
						{
							Raylib.DrawRectangle(i * resize_factor, j * resize_factor, resize_factor, resize_factor, sandbox[i, j].color);
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