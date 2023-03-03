//Created by Ben Morris.
public interface ISaveable
{
	object CaptureState(); // captures information

	void RestoreState(object state);// restores information.

	/*	 EXAMPLE

	[SerializeField] private int level = 1;
	[SerializeField] private int xp = 100;

---------------------------------------------------------------------------------------------------------

	public object CaptureState()
	{
		return new saveData
		{
			xp = xp,
			level = level
		};
	}

---------------------------------------------------------------------------------------------------------

	public void RestoreState(object state)
	{
		var savedata = (saveData)state;

		level = savedata.level;
		xp = savedata.xp;
	}

---------------------------------------------------------------------------------------------------------

	[Serializable] //Must be serializable
	private struct saveData
	{
		public int level;
		public int xp;
	}
	*/

}
