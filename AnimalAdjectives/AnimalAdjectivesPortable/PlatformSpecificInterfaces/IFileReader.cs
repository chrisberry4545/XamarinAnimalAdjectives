using System;
using System.Collections.Generic;

namespace AnimalAdjectivesPortable.PlatformSpecificInterfaces
{
	public interface IFileReader
	{
		List<String> ReadAllFileLines (string listFileName);
	}
}

