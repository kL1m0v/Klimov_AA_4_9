namespace Tank1990
{
	public enum SideType: byte
	{
		Player,
		Enemy
	}
	
	public enum DirectionType: byte
	{
		Up,
		Down,
		Left,
		Right
	}

	public enum GameState: byte
	{
		NotActive,
		Pause,
		Play
	}
}
