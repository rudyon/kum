using Raylib_cs;

namespace kum
{
	internal class Tile
	{
		internal int x, y;
		internal World world;
		internal string type = "air";
		internal bool updated = false;

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
				if (CheckDown("air"))
				{
					world.Set(x, y, new Tile(x, y, world, "air"));
					world.Set(x, y + 1, this);
					y++;
				}
				else if (CheckDown("water"))
				{
					world.Set(x, y, new Tile(x, y, world, "water"));
					world.Set(x, y + 1, this);
					y++;
				}
				else if (CheckDownLeft("air"))
				{
					world.Set(x, y, new Tile(x, y, world, "air"));
					world.Set(x - 1, y + 1, this);
					x--;
					y++;
				}
				else if (CheckDownRight("air"))
				{
					world.Set(x, y, new Tile(x, y, world, "air"));
					world.Set(x + 1, y + 1, this);
					x++;
					y++;
				}
			}
			else if (type == "water")
			{
				if (CheckDown("air"))
				{
					world.Set(x, y, new Tile(x, y, world, "air"));
					world.Set(x, y + 1, this);
					y++;
				}
				else if (CheckDownLeft("air"))
				{
					world.Set(x, y, new Tile(x, y, world, "air"));
					world.Set(x - 1, y + 1, this);
					x--;
					y++;
				}
				else if (CheckDownRight("air"))
				{
					world.Set(x, y, new Tile(x, y, world, "air"));
					world.Set(x + 1, y + 1, this);
					x++;
					y++;
				}
				else if (CheckLeft("air"))
				{
					world.Set(x, y, new Tile(x, y, world, "air"));
					world.Set(x - 1, y, this);
					x--;
				}
				else if (CheckRight("air"))
				{
					world.Set(x, y, new Tile(x, y, world, "air"));
					world.Set(x + 1, y, this);
					x++;
				}
			}

			updated = true;
		}

		bool CheckDown(string type)
		{
			if (world.Get(x, y + 1).type == type)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		bool CheckRight(string type)
		{
			if (world.Get(x + 1, y).type == type)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		bool CheckLeft(string type)
		{
			if (world.Get(x - 1, y).type == type)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		bool CheckDownRight(string type)
		{
			if (world.Get(x + 1, y + 1).type == type)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		bool CheckDownLeft(string type)
		{
			if (world.Get(x - 1, y + 1).type == type)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
