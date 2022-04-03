using Raylib_cs;

namespace kum
{
	internal class Tile
	{
		internal int x, y;
		internal World world;
		internal string type = "air";

		public Tile(int x, int y, World world, string type)
		{
			this.x = x;
			this.y = y;
			this.world = world;
			this.type = type;
		}

		internal void Update()
		{
			if (type == "sand")
			{
				if (world.Get(x, y + 1).type == "air")
				{
					world.Set(x, y, new Tile(x, y, world, "air"));
					world.Set(x, y + 1, this);
					y++;
				}
				else
				{
					int i = Raylib.GetRandomValue(0, 1);

					if (i == 0 && world.Get(x + 1, y).type == "air")
					{
						world.Set(x, y, new Tile(x, y, world, "air"));
						world.Set(x + 1, y, this);
						x++;
					}
					if (i == 1 && world.Get(x--, y).type == "air")
					{
						world.Set(x, y, new Tile(x, y, world, "air"));
						world.Set(x - 1, y, this);
						x--;
					}
				}
			}
		}
	}
}