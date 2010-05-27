namespace ExtMvc.Dtos
{
	public class SysdiagramDto
	{
		public string StringId { get; set; }

		public string Name { get; set; }

		public int PrincipalId { get; set; }

		public int DiagramId { get; set; }

		public int? Version { get; set; }

		// public byte[] Definition { get; set; }
	}
}